﻿using System;
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
            if (dpick_1.SelectedDate != null)
            {
                string createfilename = dpick_1.Text + "_" + tb_receiver_name.Text;
                createfilename = createfilename.Replace(" ", "");
                CreateDocument(createfilename);
            }
            else
            {
                MessageBox.Show("Es wurde kein Datum ausgewählt!", "Fehlende Eingabe",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void dpick_1_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            lbl_datepicked.Content = dpick_1.SelectedDate.Value.ToShortDateString();
        }

        private void CreateDocument(string nameforfile)
        {
            string fileName = @"C:\Users\Barney\" + nameforfile + ".docx";

            string sender = ""
                + tb_sender_name.Text
                + Environment.NewLine
                + tb_sender_street.Text
                + Environment.NewLine
                + tb_sender_zip.Text
                + Environment.NewLine
                + Environment.NewLine
                + tb_sender_phone.Text
                + Environment.NewLine
                + Environment.NewLine;

            string receiver = ""
                + tb_receiver_name.Text
                + Environment.NewLine
                + tb_receiver_street.Text
                + Environment.NewLine
                + tb_receiver_zip.Text
                + Environment.NewLine
                + Environment.NewLine
                + tb_receiver_phone.Text
                + Environment.NewLine
                + Environment.NewLine
                + Environment.NewLine;

            string regard = ""
                + lbl_regard.Content
                + " "
                + dpick_1.SelectedDate.Value.ToShortDateString()
                + Environment.NewLine
                + Environment.NewLine;


            string bodytext = ""
                + "Sehr geehrte Damen und Herren" + Environment.NewLine + Environment.NewLine
                + "Dies ist eine Testrechnung."
                + Environment.NewLine
                + "Folgende Positionen sind dabei angefallen:"
                + Environment.NewLine + Environment.NewLine
                + "Mit freundlichen Grüßen, "
                + Environment.NewLine + Environment.NewLine
                + "Barney Stinson";

            // Body Formatting
            var paraFormat = new Formatting();
            paraFormat.FontFamily = new System.Drawing.FontFamily("Calibri");
            paraFormat.Size = 10D;

            var doc = DocX.Create(fileName);


            doc.InsertParagraph(sender, false, paraFormat);
            doc.InsertParagraph(receiver, false, paraFormat);
            doc.InsertParagraph(regard, false, paraFormat);
            doc.InsertParagraph(bodytext, false, paraFormat);





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