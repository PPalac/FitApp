using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Storage;
using Windows.UI;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FitApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
            if (localSettings.Values["protein"] != null)
            {
                bialko.Text = localSettings.Values["protein"].ToString();
                fat.Text = localSettings.Values["fat"].ToString();
                wegle.Text = localSettings.Values["carbs"].ToString();
                cal.Text = localSettings.Values["calories"].ToString();
            }

            setIncome();
                        
        }

        private void setUp_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Settings));
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {

            addIncome();
            createDailySettings();
            setColor();
        }

        private void addIncome()
        {
            int temp;

            if (bialkoIn.Text == "")
                temp = int.Parse(bialkoIn.PlaceholderText);
            else
                temp = int.Parse(bialkoIn.Text);
                temp += int.Parse(bialko1.Text);
                bialko1.Text = temp.ToString();



            if (wegleIn.Text == "")
                temp = int.Parse(wegleIn.PlaceholderText);
            else
                temp = int.Parse(wegleIn.Text);
                temp += int.Parse(wegle1.Text);
                wegle1.Text = temp.ToString();



            if (fatIn.Text == "")
                temp = int.Parse(fatIn.PlaceholderText);
            else
                temp = int.Parse(fatIn.Text);
                temp += int.Parse(fat1.Text);
                fat1.Text = temp.ToString();

            if (calIn.Text == "")
                temp = int.Parse(calIn.PlaceholderText);
            else
                temp = int.Parse(calIn.Text);
                temp += int.Parse(cal1.Text);
                cal1.Text = temp.ToString();

            
        }

        private void createDailySettings()
        {
            ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
            localSettings.Values["proteinIn"] = bialko1.Text;
            localSettings.Values["carbsIn"] = wegle1.Text;
            localSettings.Values["fatIn"] = fat1.Text;
            localSettings.Values["calIn"] = cal1.Text;
            
        }
        private void setIncome()
        {
            ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
            if (localSettings.Values["proteinIn"] != null && localSettings.Values["carbsIn"] !=null &&
                localSettings.Values["fatIn"] != null && localSettings.Values["calIn"] != null)
            {
                bialko1.Text = localSettings.Values["proteinIn"].ToString();
                fat1.Text = localSettings.Values["fatIn"].ToString();
                wegle1.Text = localSettings.Values["carbsIn"].ToString();
                cal1.Text = localSettings.Values["calIn"].ToString();
               
            }

            setColor();


        }

        private void setColor()
        {
            int prot, carb, tluszcz, calories;
            prot = int.Parse(bialko1.Text);
            carb = int.Parse(wegle1.Text);
            tluszcz = int.Parse(fat1.Text);
            calories = int.Parse(cal1.Text);


            if (prot <= 0.75 * int.Parse(bialko.Text))
            {
                bialko1.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
                if (prot < int.Parse(bialko.Text))
            {
                bialko1.Foreground = new SolidColorBrush(Colors.Orange);

            }
            else
                bialko1.Foreground = new SolidColorBrush(Colors.Red);





            if (carb <= 0.75 * int.Parse(wegle.Text))
            {
                wegle1.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                if (carb < int.Parse(wegle.Text))
                {
                    wegle1.Foreground = new SolidColorBrush(Colors.Orange);

                }
                else
                    wegle1.Foreground = new SolidColorBrush(Colors.Red);
            }


            if (tluszcz <= 0.75 * int.Parse(fat.Text))
            {
                fat1.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                if (tluszcz < int.Parse(fat.Text))
                {
                    fat1.Foreground = new SolidColorBrush(Colors.Orange);

                }
                else
                    fat1.Foreground = new SolidColorBrush(Colors.Red);
            }



            if (calories <= 0.75 * int.Parse(cal.Text))
            {
                cal1.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                if (calories < int.Parse(cal.Text))
                {
                    cal1.Foreground = new SolidColorBrush(Colors.Orange);

                }
                else
                    cal1.Foreground = new SolidColorBrush(Colors.Red);
            }

        }

        private void reset_Click(object sender, RoutedEventArgs e)
        {
            ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
            if (localSettings.Values["proteinIn"] != null && localSettings.Values["carbsIn"] != null &&
                localSettings.Values["fatIn"] != null && localSettings.Values["calIn"] != null)
            {
                localSettings.Values["proteinIn"] = "0";
                localSettings.Values["carbsIn"] = "0";
                localSettings.Values["fatIn"] = "0";
                localSettings.Values["calIn"] = "0";

            }

            setIncome();
        }
    }
}
