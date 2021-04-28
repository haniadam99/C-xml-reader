using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.Syndication;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace PodcastApplication.UI
{//Nyaste
    class Validering
    {
       
        public static bool korrRss(string txtPodcastUrl)
        {
            try
            {
                var feeden = SyndicationFeed.Load(XmlReader.Create(txtPodcastUrl));
                Console.WriteLine("Länken fungerar!");
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Länken fungerar ej!");
                return false;
            }
        }

        public static bool korrUrl(string giltig)
        {
            if (string.IsNullOrWhiteSpace(giltig))
            {
                return false;
            }
            else
            {
                return true;
            }

        }


        public static bool ValideraTextBox(TextBox txtBox)
        {
            if (!string.IsNullOrEmpty(txtBox.Text))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Kontrollera alla textfält");
                return false;
            }
        }
        public static bool ValideraTextBoxUrl(TextBox txtBox)
        {
            if (!string.IsNullOrEmpty(txtBox.Text))
            {
                korrRss(txtBox.Text);
                return true;
            }
            else if (string.IsNullOrEmpty(txtBox.Text))
            {
                MessageBox.Show("Skriv in en länk");
                return false;
            }
            else
            {
                MessageBox.Show("Ett fel Uppstod");
                return false;
            }
        }
         public static bool ValideraInfoFält(TextBox txtBox, TextBox txtBox1, ComboBox comboBox)
        { 
            if (txtBox.Text == "")
            {
                MessageBox.Show("Fyll i en Titel");
                return false;
            }
            if (txtBox1.Text == "")
            {
                MessageBox.Show("Fyll i Kategori");
                return false;
            }
            if (comboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Ange en Frekvens");
                return false;
            }
            else
            {
                return true;
            }

        }

        void CheckTextBox(TextBox tb)
        {
            if (string.IsNullOrEmpty(tb.Text))
            {
                MessageBox.Show(tb.Name + "must be filled");
            }
        }

        public static bool ValideraComboBox(ComboBox comboBox)
        {
            if (!string.IsNullOrEmpty(comboBox.Text))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Välj ett värde");
                return false;
            }
        }

        public static bool ValideraListBox(ListBox listbox)
        {
            if (listbox.SelectedItems.Count > 0)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Välj en kategori i listan");
                return false;
            }
        }

        public static bool ValideraListview(ListView listview)
        {
            if (listview.SelectedItems.Count > 0)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Markera objekt i listan");
                return false;
            }
        }

















    }
}

