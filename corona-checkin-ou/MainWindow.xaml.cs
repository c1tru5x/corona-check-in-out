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



namespace corona_checkin_ou
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int maxPersons = 0;
        public int scale = 2;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if(PersonCounter.Text != "")
            {
                // to get full bar / 2
                pb.Maximum = Convert.ToDouble(PersonCounter.Text) / 2;
            }
            else
            {
                pb.Value = 0;
            }
        }

        //Check IN
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(pb.Value != maxPersons)
            { 
                pb.Value++;
                pInside.Content = "Persons Inside: " + Convert.ToString(pb.Value);
            }
            if (pb.Value > maxPersons / 2)
            {
                //color red

            }
        }

        //Check OUT
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(pb.Value != 0 && pb.Value > 0)
            { 
                pb.Value--;
                pInside.Content = "Persons Inside: " + Convert.ToString(pb.Value);
            }
            if(pb.Value <= maxPersons/2)
            {
                //color green
                
            }
        }

        //Get maximum amount of persons (half of total persons)
        private void PersonCounter_TextChanged(object sender, TextChangedEventArgs e)
        {
            maxPersons =  Convert.ToInt32(PersonCounter.Text) / 2;
        }
    }
}
