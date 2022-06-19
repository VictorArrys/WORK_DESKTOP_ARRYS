using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Controls;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Brushes = System.Windows.Media.Brushes;
using System.Text.RegularExpressions;

namespace El_Camello.Assets.utilerias
{
    public class ValidacionFormulario
    {

        public void limpiarTextField(TextBox textBox)
        {

            textBox.BorderBrush = Brushes.LightBlue;

        }

        public void limpiarDataPicker(DatePicker datePicker)
        {
            datePicker.BorderBrush = Brushes.LightBlue;
        }

        public void limpiarCheckBox(CheckBox checkBox)
        {
            checkBox.BorderBrush = Brushes.LightBlue;
        }


        public bool textFieldsVacios(List<TextBox> tbValidar)
        {
            bool estaVacio = false;
            foreach (TextBox tbIndividual in tbValidar)
            {
                limpiarTextField(tbIndividual);

                if (tbIndividual.Text.Length == 0)
                {
                    estaVacio = true;
                    tbIndividual.BorderBrush = Brushes.Red;
                }

            }


            return estaVacio;
        }

        public bool textFieldEntero(TextBox tbValidar)
        {
            limpiarTextField(tbValidar);
            int entero;
            bool esEntero = Int32.TryParse(tbValidar.Text, out entero);
            if (!esEntero)
            {
                tbValidar.BorderBrush = Brushes.Red;
            }

            return esEntero;
        }

        public bool validarCampoMinimoCaracteres(List<TextBox> tbValidar)
        {
            bool validar = true;

            foreach (TextBox tbIndividual in tbValidar)
            {
                limpiarTextField(tbIndividual);

                if (tbIndividual.Text.Length > 6)
                {
                    validar = false;
                    tbIndividual.BorderBrush = Brushes.Red;
                }

            }


            return validar;
        }

        

        public bool validarHora(TextBox tbValidar)
        {
            limpiarTextField(tbValidar);

            bool validar = Regex.IsMatch(tbValidar.Text, @"^(([0-9])|([0-1][0-9])|([2][0-3])):(([0-9])|([0-5][0-9]))$");
            if (!validar)
            {
                tbValidar.BorderBrush = Brushes.Red;
            }

            return validar;
        }

        public bool dataPickersVacios(List<DatePicker> dpValidar)
        {
            bool estaVacio = false;
            foreach (DatePicker dpIndividual in dpValidar)
            {
                limpiarDataPicker(dpIndividual);
                dpIndividual.BorderBrush = Brushes.LightBlue;

                if (dpIndividual.Text == String.Empty)
                {
                    estaVacio = true;
                    dpIndividual.BorderBrush = Brushes.Red;
                }

            }

            return estaVacio;
        }

        public bool checkBoxsVacios(List<CheckBox> chksValidar)
        {
            bool estaVacio = false;
            foreach (CheckBox chkIndividual in chksValidar)
            {
                limpiarCheckBox(chkIndividual);

                if (chkIndividual.IsChecked == false)
                {
                    estaVacio = true;
                    chkIndividual.BorderBrush = Brushes.Red;
                }
                else
                {
                    return true;
                }

            }

            return estaVacio;
        }

        public int compararFecha(DatePicker primeraFecha, DatePicker segundaFecha)
        {
            // {1: Primera fecha es menor a la segunda,
            //  0: Las fechas son iguales,
            // -1: La primera fecha es mayor a la segunda
            // -2: La fecha es menor a la fecha actual}
            limpiarDataPicker(primeraFecha);
            limpiarDataPicker(segundaFecha);

            int comparar = 0;
            if (primeraFecha.SelectedDate > DateTime.Today)
            {
                if (primeraFecha.SelectedDate < segundaFecha.SelectedDate)
                {
                    comparar = 1;

                }else if (primeraFecha.SelectedDate == segundaFecha.SelectedDate)
                {
                    comparar = 0;
                    primeraFecha.BorderBrush = Brushes.Red;
                    segundaFecha.BorderBrush = Brushes.Red;

                }
                else if (primeraFecha.SelectedDate.Value > segundaFecha.SelectedDate)
                {
                    comparar = -1;
                    primeraFecha.BorderBrush = Brushes.Red;
                    segundaFecha.BorderBrush = Brushes.Red;

                }

            }
            else
            {
                comparar = -2;
                primeraFecha.BorderBrush = Brushes.Red;
            }            


            return comparar;
        }



        public bool comboboxVacios(List<ComboBox> cbValidar)
        {
            MensajesSistema mensajes;
            string mensaje = " | ";
            bool estaVacio = false;
            foreach (ComboBox cbIndividual in cbValidar)
            {
                if (cbIndividual.SelectedIndex == -1)
                {
                    estaVacio = true;
                    string cbNombre = cbIndividual.Name.Remove(0, 2);
                    mensaje += cbNombre + " | ";

                }

            }
            if (estaVacio)
            {
                mensajes = new MensajesSistema("AccionInvalida", "Debe seleccionar algo", "Combobox: " + mensaje, "No pueden estar vacios los combobox");
                mensajes.ShowDialog();
            }

            return estaVacio;
        }





    }
}
