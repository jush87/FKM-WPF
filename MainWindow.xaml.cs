using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Office.Interop.Excel;
using Microsoft.Win32;

namespace FKM
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {

        private List<Parcours> ListParcours = new List<Parcours>();

        private Microsoft.Office.Interop.Excel.Application excel;
        private Workbook classeur;
        private Worksheet feuille;
        public MainWindow()
        {
            InitializeComponent();
            excel = new Microsoft.Office.Interop.Excel.Application();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AjoutParcours window = new AjoutParcours();
            window.ShowDialog();
           Parcours courantParcour = window.Parcours;
            ListParcours.Add(courantParcour);

            DataParcours.ItemsSource = null;
            DataParcours.ItemsSource = ListParcours;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Fichier Excel | *.xlsx |Fichier CSV | * .csv";
            sfd.FilterIndex = 1;
            if (sfd.ShowDialog() == true)
            {
                bool fileExists = File.Exists(sfd.FileName);

                if (!fileExists || classeur != null)
                {
                    classeur = excel.Workbooks.Add();

                }
                else
                {
                    classeur = excel.Workbooks.Open(sfd.FileName);
                }

                feuille = classeur.ActiveSheet;
                feuille.Cells[1, 1] = "Prenom";
                feuille.Cells[1, 2] = "Nom";
                feuille.Cells[1, 3] = "Date";
                feuille.Cells[1, 4] = "Depart";
                feuille.Cells[1, 5] = "Arrivee";
                feuille.Cells[1, 6] = "Distance";
                feuille.Cells[1, 7] = "Ticket";

                int ligne = 2;
                //On écrit la liste dans un fichier Excel

                foreach (Parcours Parcours in ListParcours)// on parcours toute la liste client

                {

                    feuille.Cells[ligne, 1] = Prenom.Text;
                    feuille.Cells[ligne, 2] = Nom.Text;
                    feuille.Cells[ligne, 3] = Parcours.Date;
                    feuille.Cells[ligne, 4] = Parcours.Depart;
                    feuille.Cells[ligne, 5] = Parcours.Arrivee;
                    feuille.Cells[ligne, 6] = Parcours.Distance;
                    feuille.Cells[ligne, 7] = Parcours.Ticket;
                    
                    ligne++;

                }
                excel.DisplayAlerts = false;//Pour éviter les messages d'alerte fichier existant
                classeur.SaveAs(sfd.FileName);
               // classeur.Close();
                excel.DisplayAlerts = true;//On réactive
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            excel.Visible = true;
        }
    }
}
