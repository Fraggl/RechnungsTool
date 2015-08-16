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
using Novacode;
using System.Diagnostics;

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

        private void Menu_1_Sub_generate_Click(object sender, RoutedEventArgs e)
        {
            string createfilename = tb_receiver_name.Text + "" + dpick_1.Text;
            CreateDocument(createfilename);
        }

        private void dpick_1_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            lbl_datepicked.Content = dpick_1.SelectedDate.Value.ToShortDateString();
        }

        private void CreateDocument(string nameforfile)
        {
            string fileName = @"C:\Users\Barney\" + nameforfile + ".docx";

            string paraTwo = ""
                + "Sehr geehrte Damen und Herren" + Environment.NewLine + Environment.NewLine
                + "Dies ist eine Testrechnung."
                + "Folgende Positionen sind dabei angefallen:"
                + Environment.NewLine + Environment.NewLine
                + "Sincerely, "
                + Environment.NewLine + Environment.NewLine
                + "Jim Smith, Corporate Hiring Manager";

            // Body Formatting
            var paraFormat = new Formatting();
            paraFormat.FontFamily = new System.Drawing.FontFamily("Calibri");
            paraFormat.Size = 10D;

            var doc = DocX.Create(fileName);

            doc.InsertParagraph(tb_receiver_name.Text);
            doc.InsertParagraph(tb_receiver_street.Text);
            doc.InsertParagraph(tb_receiver_zip.Text);
            doc.InsertParagraph();
            doc.InsertParagraph(tb_receiver_phone.Text);
            doc.InsertParagraph();
            doc.InsertParagraph(fileName);
            doc.InsertParagraph(paraTwo, false, paraFormat);





            doc.Save();
            MessageBoxResult result = MessageBox.Show("Möchten Sie das erstellte Dokument anzeigen?", "Beenden",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question,
                MessageBoxResult.No);
            if (result == MessageBoxResult.Yes)
                Process.Start("WINWORD.EXE", fileName);

        }
    }
}
