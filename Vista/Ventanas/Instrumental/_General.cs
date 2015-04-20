using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Entidades;

namespace WindowsApp
{
    public static class _General
    {/*
        private static List<Control> lista = new List<Control>();
        public static Control[] ArrayControles(Control unControl)
        {
            lista.Clear();
            for (int i = 0; i < unControl.Controls.Count; i++)
            {
                AgregaControl(unControl);
            }

            return lista.ToArray();
        }

        private static void AgregaControl(Control unControl)
        {
            if (unControl.Controls.Count > 0)
                for (int i = 0; i < unControl.Controls.Count; i++)
                {
                    AgregaControl(unControl.Controls[i]);
                }
            else
            {
                if (unControl.Name.StartsWith("_"))
                    lista.Add(unControl);
            }
        }

        public static void CargarControl(Control unControl, object unObjeto, System.Reflection.PropertyInfo[] unaListaPropiedades)
        {
            object valor = null;
            if (unControl.Controls.Count > 0)
                for (int i = 0; i < unControl.Controls.Count; i++)
                {
                    CargarControl(unControl.Controls[i], unObjeto, unaListaPropiedades);
                }
            else
            {
                Type tipo = unControl.GetType();
                if (tipo.Name == "TextBoxX" || tipo.Name == "PictureBox" || tipo.Name == "ComboBoxEx" || tipo.Name == "DateTimeInput" || tipo.Name == "CheckBox")
                    foreach (System.Reflection.PropertyInfo item in unaListaPropiedades)
                    {
                        if (unControl.Name.Contains(item.Name))
                        {
                            if (item.GetGetMethod() != null)
                                valor = item.GetValue(unObjeto, null);

                            switch (unControl.GetType().Name)
                            {
                                case "TextBoxX":
                                    unControl.Text = valor == null ? "" : valor.ToString();
                                    break;
                                case "PictureBox":
                                    ((PictureBox)unControl).Image = (Image)valor;
                                    break;
                                case "ComboBoxEx":
                                    ((ComboBox)unControl).SelectedValue = valor;
                                    break;
                                case "DateTimeInput":
                                    ((DevComponents.Editors.DateTimeAdv.DateTimeInput)unControl).Value = (DateTime)valor;
                                    break;
                                case "CheckBox":
                                    ((CheckBox)unControl).Checked = (bool)valor;
                                    break;
                            }
                        }
                    }
            }
        }

        public static void Limpiar(Control.ControlCollection arrayControles)
        {
            for (int i = 0; i < arrayControles.Count; i++)
            {
                LimpiaControl(arrayControles[i]);
            }
        }

        private static void LimpiaControl(Control unControl)
        {
            if (unControl.Controls.Count > 0)
                for (int i = 0; i < unControl.Controls.Count; i++)
                {
                    LimpiaControl(unControl.Controls[i]);
                }
            //foreach (Control item in unControl.Controls)
            //{
            //    LimpiaControl(item);
            //}
            else
                switch (unControl.GetType().Name)
                {
                    case "TextBoxX":
                        ((TextBox)unControl).Clear();
                        break;
                    case "PictureBox":
                        ((PictureBox)unControl).Image = null;
                        break;
                    case "ComboBoxEx":
                        ((ComboBox)unControl).SelectedIndex = -1;
                        break;
                    case "DateTimeInput":
                        ((DevComponents.Editors.DateTimeAdv.DateTimeInput)unControl).Value = General.fechaActual;
                        break;
                    case "CheckBox":
                        ((CheckBox)unControl).Checked = false;
                        break;
                }
        }


        public static void GuardarControl(Control unControl, object unObjeto, System.Reflection.PropertyInfo[] unaListaPropiedades)
        {
            object valor = null; bool establecer = true;
            if (unControl.Controls.Count > 0)
                for (int i = 0; i < unControl.Controls.Count; i++)
                {
                    GuardarControl(unControl.Controls[i], unObjeto, unaListaPropiedades);
                }
            else
            {
                Type tipo = unControl.GetType();
                if (tipo.Name == "TextBoxX" || tipo.Name == "PictureBox" || tipo.Name == "ComboBoxEx" || tipo.Name == "DateTimeInput" || tipo.Name == "CheckBox")
                    foreach (System.Reflection.PropertyInfo item in unaListaPropiedades)
                    {
                        if (unControl.Name.Contains(item.Name))
                        {
                            switch (unControl.GetType().Name)
                            {
                                case "TextBoxX":
                                    if (!unControl.Text.EndsWith("R"))
                                        valor = unControl.Text;
                                    else
                                        establecer = false;
                                    break;
                                case "PictureBox":
                                    valor = ((PictureBox)unControl).Image;
                                    break;
                                case "ComboBoxEx":
                                    valor = ((ComboBox)unControl).SelectedValue;
                                    break;
                                case "DateTimeInput":
                                    valor = ((DevComponents.Editors.DateTimeAdv.DateTimeInput)unControl).Value;
                                    break;
                                case "CheckBox":
                                    valor = ((CheckBox)unControl).Checked;
                                    break;
                            }
                            if (item.GetSetMethod() != null && establecer)
                                item.SetValue(unObjeto, valor, null);
                        }
                    }
            }
        }

        private static List<TabPage> AllTabPages = new List<TabPage>();
        public static void HideTabPage(TabControl unTabControl, TabPage unTabPage)
        {
            if (unTabControl.Contains(unTabPage))
            {
                foreach (TabPage t in unTabControl.TabPages)
                {
                    if (!AllTabPages.Contains(t))
                        AllTabPages.Add(t);
                }
                unTabControl.TabPages.Remove(unTabPage);
            }
        }

        public static void ShowTabPage(TabControl unTabControl, TabPage unTabPage)
        {
            if ((AllTabPages.Contains(unTabPage)) && (!unTabControl.TabPages.Contains(unTabPage)))
                unTabControl.TabPages.Add(unTabPage);
        }*/
    }
}
