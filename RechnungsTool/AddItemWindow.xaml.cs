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
            // Variablen mit den Werten befüllen
            // Einfache Var? Lists? Verschachtelt? Liste mit Einträgen - > jeder Untereintrag = ein einzelner Datensatz
            if (cB_AddItem_Avis.SelectedItem != null)
            {

            }
            else
            { //Value is null }
            }
        }

        private void AddItem_Beenden_Click(object sender, RoutedEventArgs e)
        {
            this.Close();            
        }


    }
}
