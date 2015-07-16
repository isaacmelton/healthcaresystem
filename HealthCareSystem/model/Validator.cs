using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthCareSystem.model
{
    /// <summary>
    /// Model of a validator.
    /// </summary>
    class Validator
    {
        private static string title = "Entry Error";

        /// <summary>
        /// Public getter/setter
        /// </summary>
        public static string Title
        {
            get { return title; }
            set { title = value; }
        }

        /// <summary>
        /// Checks a list of controls to ensure they all contain data.
        /// </summary>
        /// <param name="controls">The list of controls</param>
        /// <returns>True IFF every control contains some data</returns>
        public static bool AreAllPresent(List<Control> controls)
        {
            Boolean arePresent = true;

            foreach (Control control in controls)
            {
                arePresent = arePresent && IsPresent(control);
            }

            return arePresent;
        }

        /// <summary>
        /// Checks if a single control contains data.
        /// </summary>
        /// <param name="control">The control</param>
        /// <returns>True IFF the control contains some data</returns>
        public static bool IsPresent(Control control)
        {
            if (control.GetType().ToString() == "System.Windows.Forms.MaskedTextBox")
            {
                MaskedTextBox textBox = (MaskedTextBox)control;
                if (textBox != null)
                {
                    textBox.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    if ((textBox.Text == ""))
                    {
                        textBox.TextMaskFormat = MaskFormat.IncludeLiterals;
                        MessageBox.Show(textBox.Tag.ToString() + " is a required field.", Title);
                        textBox.Focus();
                        return false;
                    }
                    else
                    {
                        textBox.TextMaskFormat = MaskFormat.IncludeLiterals;
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            if (control.GetType().ToString() == "System.Windows.Forms.TextBox")
            {
                TextBox textBox = (TextBox)control;
                if (textBox != null)
                {
                    if ((textBox.Text == ""))
                    {
                        MessageBox.Show(textBox.Tag.ToString() + " is a required field.", Title);
                        textBox.Focus();
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            else if (control.GetType().ToString() == "System.Windows.Forms.ComboBox")
            {
                ComboBox comboBox = (ComboBox)control;
                if (comboBox.SelectedIndex == -1)
                {
                    MessageBox.Show(comboBox.Tag.ToString() + " is a required field.", Title);
                    comboBox.Focus();
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return true;
        }

        /// <summary>
        /// Checks to see if the text box contains a decimal.
        /// </summary>
        /// <param name="textBox">The text box control</param>
        /// <returns>True IFF the text box contrains a decimal</returns>
        public static bool IsDecimal(TextBox textBox)
        {
            try
            {
                Convert.ToDecimal(textBox.Text);
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show(textBox.Tag.ToString() + " must be a decimal value.", Title);
                textBox.Focus();
                return false;
            }
        }

        /// <summary>
        /// Checks to see if the text box contains an int.
        /// </summary>
        /// <param name="textBox">The text box control</param>
        /// <returns>True IFF the text box contrains an int</returns>
        public static bool IsInt32(TextBox textBox)
        {
            try
            {
                Convert.ToInt32(textBox.Text);
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show(textBox.Tag.ToString() + " must be an integer value.", Title);
                textBox.Focus();
                return false;
            }
        }

        /// <summary>
        /// Checks to see if the text box contains a zip code.
        /// </summary>
        /// <param name="textBox">The text box control</param>
        /// <param name="firstZip">The lowest numerical zip code</param>
        /// <param name="lastZip">The highest numerical zip code</param>
        /// <returns>True IFF the text box contrains a zip code</returns>
        public static bool IsStateZipCode(MaskedTextBox textBox, int firstZip, int lastZip)
        {
            //00501
            //99950
            int zipCode = Convert.ToInt32(textBox.Text);
            if (zipCode < firstZip || zipCode > lastZip)
            {
                MessageBox.Show(textBox.Tag.ToString() + " must be within this range: " +
                    firstZip.ToString("D5") + " to " + lastZip.ToString("D5") + ".", Title);
                textBox.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Checks to see if the text box contains a zip code.
        /// </summary>
        /// <param name="textBox">The text box control</param>
        /// <returns>True IFF the text box contrains a zip code</returns>
        public static bool IsStateZipCode(MaskedTextBox textBox)
        {
            //00501 to 99950 these are 
            //the min and max zip codes
            return IsStateZipCode(textBox, 00501, 99950);
        }

        /// <summary>
        /// Checks to see if the text box contains a phone number.
        /// </summary>
        /// <param name="textBox">The text box control</param>
        /// <returns>True IFF the text box contrains a phone number</returns>
        public static bool IsPhoneNumber(MaskedTextBox textBox)
        {
            string phoneChars = textBox.Text.Replace(".", "").Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
            try
            {
                Convert.ToInt64(phoneChars);
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show(textBox.Tag.ToString() + " must be in this format: 999-999-9999", Title);
                textBox.Focus();
                return false;
            }
        }
    }
}
