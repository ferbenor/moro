-- DROP TABLE pagos;

CREATE TABLE pagos
(
  id integer NOT NULL,
  idordenpedido integer,
  fecha date,
  idusuarioregistra smallint,
  idusuarioanula smallint,
  anulado boolean,
  CONSTRAINT pk_pagos PRIMARY KEY (id),
  CONSTRAINT fk_pagos_ordenespedidos FOREIGN KEY (idordenpedido)
      REFERENCES ordenespedido (id) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT fk_pagos_usuarios FOREIGN KEY (idusuarioregistra)
      REFERENCES usuarios (id) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
)
WITH (
  OIDS=FALSE
);
ALTER TABLE pagos
  OWNER TO postgres;

-- Index: ix_pagos_anulado

-- DROP INDEX ix_pagos_anulado;

CREATE INDEX ix_pagos_anulado
  ON pagos
  USING btree
  (fecha, anulado);

-- Index: ix_pagos_usuarioanula

-- DROP INDEX ix_pagos_usuarioanula;

CREATE INDEX ix_pagos_usuarioanula
  ON pagos
  USING btree
  (idusuarioanula);

-- DROP TABLE detallepagos;

CREATE TABLE detallepagos
(
  idpago integer NOT NULL,
  idformapago smallint NOT NULL,
  numero smallint NOT NULL,
  valor numeric(21,2),
  detalle character varying(255),
  CONSTRAINT pk_detallepagos PRIMARY KEY (idpago, idformapago),
  CONSTRAINT fk_detallespagos_formaspago FOREIGN KEY (idformapago)
      REFERENCES formaspago (id) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT fk_detallespagos_pagos FOREIGN KEY (idpago)
      REFERENCES pagos (id) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
)
WITH (
  OIDS=FALSE
);
ALTER TABLE detallepagos
  OWNER TO postgres;

--/////////////////////////////////////////////////
--/////////////////////////////////////////////////
--/////////////////////////////////////////////////

CREATE TABLE identificadorpagos
(
  id integer NOT NULL,
  CONSTRAINT pk_identificadorpagos PRIMARY KEY (id)
);

CREATE TABLE conveniopagos
(
  identificadorpagos integer NOT NULL,
  idformapago smallint NOT NULL,
  CONSTRAINT pk_conveniopagos PRIMARY KEY (identificadorpagos,idformapago),
  CONSTRAINT fk_conveniopagos_formaspago FOREIGN KEY (idformapago) REFERENCES formaspago (id) MATCH SIMPLE ON UPDATE NO ACTION ON DELETE NO ACTION
);

CREATE TABLE pagos
(
  identificadorpagos integer NOT NULL,
  idformapago smallint NOT NULL,
  numero smallint NOT NULL,
  notificacion boolean default false,
  fecha timestamp(0) without time zone,
  idusuariocobranzas smallint NOT NULL,
  valor decimal(21,6),
  detalle character varying(255),
  idusuarioregistra smallint,
  idusuarioanula smallint,
  anulado boolean default false,
  CONSTRAINT pk_pagos PRIMARY KEY (identificadorpagos, idformapago,numero),
  CONSTRAINT fk_pagos_conveniopagos FOREIGN KEY (identificadorpagos, idformapago) REFERENCES conveniopagos (identificadorpagos,idformapago) MATCH SIMPLE ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT fk_pagos_usuarios FOREIGN KEY (idusuariocobranzas) REFERENCES usuarios (id) MATCH SIMPLE ON UPDATE NO ACTION ON DELETE NO ACTION
);

CREATE INDEX ix_pagos_fechanotificacionanulado  ON pagos  USING btree  (anulado, notificacion, fecha);
CREATE INDEX ix_pagos_usuarioregistra  ON pagos  USING btree  (idusuarioregistra);
CREATE INDEX ix_pagos_usuarioanula  ON pagos  USING btree  (idusuarioanula);

--//////////////////////////////////////
--//////////////////////////////////////
--//////////////////////////////////////

CREATE TYPE tp_resultadopagos AS (identificadorpago integer, numeropago smallint);

CREATE OR REPLACE FUNCTION fn_reg_pagos(
    pidentificadorpagos INTEGER, pidformapago SMALLINT, pnotificacion BOOLEAN, pfecha TIMESTAMP(0) WITHOUT TIME ZONE, pidusuariocobranza SMALLINT, pvalor DECIMAL(18,2), 
    pdetalle VARCHAR(255), pidusuarioregistra SMALLINT, pidusuarioanula SMALLINT, ttran SMALLINT
    ) RETURNS TABLE(identificadorpago INTEGER, numeropago SMALLINT) LANGUAGE plpgsql VOLATILE
	AS 
	$BODY$ --Inicio del procedimiento
		DECLARE --Declaracion de variable contador de filas y codigo generado
			--rcount INTEGER;
			vnumero SMALLINT; vtotal DECIMAL(18,2); vpagado DECIMAL(18,2);
		BEGIN
			--Si estamos agregando o modificando
			IF ttran = 1 THEN
				
				--Verificamos identificador de pagos
				IF pidentificadorpagos = 0 THEN
					SELECT COALESCE(MAX(id), 0) + 1 INTO pidentificadorpagos FROM identificadorespagos;
					INSERT INTO identificadorespagos VALUES (pidentificadorpagos);
				END IF;
				--Verificamos convenios de pago
				IF NOT EXISTS(SELECT identificadorpagos FROM conveniospagos WHERE identificadorpagos = pidentificadorpagos 
					AND idformapago = pidformapago) THEN
					INSERT INTO conveniospagos VALUES (pidentificadorpagos, pidformapago);
				END IF;
				--Verificamos el saldo para la cancelacion
				SELECT SUM(cantidad * precio) INTO vtotal FROM detallesordenespedidos as dt inner join ordenespedidos as op on op.id=dt.idordenpedido 
				WHERE op.ididentificadorpago = pidentificadorpagos;

				SELECT SUM(valor) INTO vpagado FROM pagos as pg 
				WHERE pg.identificadorpagos = pidentificadorpagos and pg.notificacion = false and pg.anulado = false;
				
				IF (vtotal - (vpagado + pvalor)) <= 0 then 
					RAISE EXCEPTION 'La cuenta ya esta cancelada totalmente';
				END IF;
				--Tomamos el maximo valor de registros para generar el codigo y registrar el pago
				SELECT COALESCE(MAX(numero), 0) + 1 INTO vnumero FROM pagos 
				WHERE identificadorpagos = pidentificadorpagos and idformapago = pidformapago;
				
				INSERT INTO pagos VALUES (pidentificadorpagos, pidformapago, vnumero, pnotificacion, pfecha, pidusuariocobranza,
				pvalor, pdetalle, pidusuarioregistra, case when pidusuarioanula = -1 then null else pidusuarioanula end);
			ELSIF ttran = 2 THEN
				--Se elimina el registro segun el parametro de codigo de registro
				UPDATE pagos SET anulado = true, idusuarioanula = pidusuarioanula
				WHERE identificadorpagos = pidentificadorpagos and idformapago = pidformapago and fecha = pfecha;
			END IF;
			--Establecemos la variable de registros afectados a -1 para luego verificar si se afectaron los cambios
			--rcount := -1;
			--Tomamos el numero de registros afectados
			--GET DIAGNOSTICS rcount = ROW_COUNT;
			--IF rcount = 0 THEN
				--Si no hay registros afectados se dispara una excepcion
			--	RAISE EXCEPTION 'No se afectaron valores en el proceso, por favor verifique.';
			--END IF;
			--Retornamos el codigo generado
			RETURN QUERY values (pidentificadorpagos, vnumero);
		--Control de Ecepciones en caso de violacion de registro unico
		EXCEPTION 
			WHEN UNIQUE_VIOLATION THEN
				RAISE EXCEPTION 'Violacion de restriccion de campo unico; valor duplicado = [ % ]', pidentificadorpagos;
			WHEN OTHERS THEN
			RAISE EXCEPTION
			USING ERRCODE = sqlstate, MESSAGE = 'Error: ' || sqlstate || '/' || sqlerrm;
		END
	$BODY$; --Fin del procedimiento
	COMMENT ON FUNCTION fn_reg_pagos (INTEGER, SMALLINT, BOOLEAN, TIMESTAMP(0) WITHOUT TIME ZONE, SMALLINT, DECIMAL(21,6), VARCHAR(255), SMALLINT, SMALLINT, SMALLINT) IS 
	'Definicion: Funcion para registrar Pagos';


create extension pldbgapi 

- You must be a superuser, or the owner of the function 
- The function cannot be under the "Catalogs" node, it must be below "Schemas". 
- The function language must be pl/pgsql 
- The string "plugin_debugger" must appear in the output from "SHOW shared_preload_libraries" 
- The function "pldbg_get_target_info" must be listed in pg_proc 
- The function "plpgsql_oid_debug" must be listed in pg_proc 