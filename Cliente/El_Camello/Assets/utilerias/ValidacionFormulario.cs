using System;
using System.Collections.Generic;
using System.Windows.Controls;
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
            bool esEntero = validarTieneLetras(tbValidar.Text);
            if (!esEntero)
            {
                tbValidar.BorderBrush = Brushes.Red;
            }

            return esEntero;
        }

        //Solo para validar email
        public static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }


        //Usar solo en campos con puras letras, si tiene regresa false, si no regresa true
        public static bool validarTieneNumeros(string palabra)
        {
            return Regex.IsMatch(palabra, "[^0 - 9] *");
        }

        //Usar solo en campos con puro numero, si tiene letra regresa false, si no tiene regresa true
        public static bool validarTieneLetras(string numero)
        {
            return Regex.IsMatch(numero, "[^A-Za-z]*");
        }

        public static bool validarEsNumero(TextBox textBox)
        {
            bool valido;
            textBox.BorderBrush = Brushes.LightBlue;
            string numero = textBox.Text;

            valido= Regex.IsMatch(numero, @"^[0-9]+$");
            if (valido)
            {
                textBox.BorderBrush = Brushes.Red;
            }

            return valido;
        }

        public static bool validarLongitud8(string numero, int longitud)
        {
            if (numero.Length.Equals(longitud))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool validarTelefono(string numero)
        {
            if (numero.Length.Equals(10))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static bool validarLongitudTelefono(string numero)
        {
            return Regex.IsMatch(numero, "[0-9]{10}");
        }

        //Usar en campos que tengan letras y numeros (Incluye espacios)
        public bool validarMixto(TextBox textBox)
        {
            limpiarTextField(textBox);
            bool valido;
            string dato = textBox.Text;

            valido = Regex.IsMatch(dato, "^[A - Za - z a - ñ 1 - 9] * $");
            if (!valido)
            {
                textBox.BorderBrush = Brushes.Red;

            }

            return valido;
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
                else if(chkIndividual.IsChecked == true)
                {
                    estaVacio = false;
                    return estaVacio;
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
