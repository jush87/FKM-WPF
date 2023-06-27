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

namespace FKM
{
    /// <summary>
    /// Logique d'interaction pour AjoutParcours.xaml
    /// </summary>
    public partial class AjoutParcours : Window
    {
        public Parcours Parcours;
        public AjoutParcours()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Parcours == null)
            {
                Parcours = new Parcours(
               Date.Text,
               Depart.Text,
               Arrivee.Text,
               Distance.Text,
               Ticket.Text
               
               );
            }

            else
            {
                Parcours.Date = Date.Text;
                Parcours.Depart = Depart.Text;
                Parcours.Arrivee = Arrivee.Text;
                Parcours.Distance = Distance.Text;
                Parcours.Ticket = Ticket.Text;

            }

            Close();
        }
    }
}
