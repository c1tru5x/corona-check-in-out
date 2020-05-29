using System;
using System.Windows;
using System.Windows.Controls;

namespace corona_checkin_ou
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int maxPersons = 0;
        private const int scale = 2;

        public MainWindow()
        {
            InitializeComponent();
            pb.Value = 0;
            PersonCounter.Text = "0";
            pInside.Content = "Persons Inside: 0";
        }

        private void ProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if(PersonCounter.Text != "")
            {
                // to get full bar / scale and math.floor
                pb.Maximum = Math.Floor(Convert.ToDouble(PersonCounter.Text) / scale);
            }
        }

        //Check IN
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(pb.Value != maxPersons + 1 && IsNum())
            { 
                pb.Value++;
                pInside.Content = "Persons Inside: " + Convert.ToString(pb.Value);
            }
            else
            {
                PersonCounter.Text = "0";
                pb.Value = 0;
            }
        }

        //Check OUT
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (pb.Value > 0 && IsNum())
            { 
                pb.Value--;
                pInside.Content = "Persons Inside: " + Convert.ToString(pb.Value);
            }
            else
            {
                PersonCounter.Text = "0";
                pb.Value = 0;
            }
        }

        //Get maximum amount of persons (half of total persons)
        private void PersonCounter_TextChanged(object sender, TextChangedEventArgs e)
        {
            //if empty set to 0
            if (PersonCounter.Text == "")
            {
                PersonCounter.Text = "0";
                pb.Value = 0;
            }
            if(!IsNum())
            {
                MessageBox.Show("Please enter only a number!", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                //remove last input
                PersonCounter.Text = PersonCounter.Text.Remove(PersonCounter.Text.Length - 1);
            }
            else
            {
                //get pb.maximum
                pb.Maximum = Math.Floor(Convert.ToDouble(PersonCounter.Text) / scale);
                maxPersons =  Convert.ToInt32(PersonCounter.Text) / scale;
            }
        }

        //check if textinput is a number
        private bool IsNum()
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(PersonCounter.Text, "[^0-9]"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
