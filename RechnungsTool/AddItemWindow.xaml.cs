using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RechnungsTool
{
    /// <summary>
    /// Interaction logic for AddItem.xaml
    /// </summary>
    public partial class AddItemWindow : Window
    {
        public AddItemWindow()
        {
            // -> Verschieben in ini
            InitializeComponent();
            cB_AddItem_Leistung.Items.Add("Schloßführung 1");
            cB_AddItem_Leistung.Items.Add("Schloßführung 2");
            cB_AddItem_Leistung.Items.Add("Schloßführung 3");

            cB_AddItem_Avis.Items.Add("20830");
            cB_AddItem_Avis.Items.Add("20842");
            cB_AddItem_Avis.Items.Add("20846");
        }

        private void AddItem_Add_Click(object sender, RoutedEventArgs e)
        {
            /* check, if all fields are filled */
            if (dpick_AddItem_Date.SelectedDate != null && cB_AddItem_Avis.SelectedItem != null && cB_AddItem_Leistung.SelectedItem != null && tB_AddItem_Personen != null && tB_AddItem_Preis != null)
            {
                Globals.GlobalVar_Date.Add(dpick_AddItem_Date.SelectedDate.Value);
                Globals.GlobalVar_Avis.Add(cB_AddItem_Avis.SelectedItem.ToString());
                Globals.GlobalVar_Power.Add(cB_AddItem_Leistung.SelectedItem.ToString());
                Globals.GlobalVar_Persons.Add(Convert.ToInt32(tB_AddItem_Personen.Text));
                Globals.GlobalVar_Price.Add(Convert.ToInt32(tB_AddItem_Preis.Text));

                /* Console-Test */
                Console.WriteLine(Globals.GlobalVar_Avis.Count);
                Console.WriteLine(Globals.GlobalVar_Date.Last());
                Console.WriteLine(Globals.GlobalVar_Power.Last());
                Console.WriteLine(Globals.GlobalVar_Avis.Last());
                Console.WriteLine(Globals.GlobalVar_Persons.Last());
                Console.WriteLine(Globals.GlobalVar_Price.Last());

                foreach (var item in Globals.GlobalVar_Persons)
                {
                    Console.WriteLine(item);
                };
                /* Console-Test End */

                // Reset after adding
                cB_AddItem_Avis.SelectedItem = null;
                cB_AddItem_Leistung.SelectedItem = null;
                tB_AddItem_Personen.Text = "";
                tB_AddItem_Preis.Text = "";

                addItemsListView();

            }
            else
            { 
                // Error-Msg
                MessageBox.Show("Bitte fülle alle Eingabefelder aus");
            }
        }

        private void addItemsListView()
        {
            /* Func to add the entrys to the listview*/
         }

        private void AddItem_Beenden_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            // Maybe add code to fill the listview here?
        }


    }
}
