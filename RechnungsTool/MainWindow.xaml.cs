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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RechnungsTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Menu_1_Sub_Exit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Schließen?", "Beenden",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question,
                MessageBoxResult.No);
            if (result == MessageBoxResult.Yes)
                Application.Current.Shutdown();
        }

        private void datepicker_writing_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void dpick_1_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            //DateTime result = dpick_1.SelectedDate.Value;
            //this.Title = result.ToString();
            lbl_datepicked.Content = dpick_1.SelectedDate.Value.ToShortDateString();
        }
    }
}
