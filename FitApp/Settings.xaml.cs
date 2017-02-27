using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace FitApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Settings : Page
    {
        public Settings()
        {
            this.InitializeComponent();
        
        }


        private void save_Click(object sender, RoutedEventArgs e)
        {
            createSettings();
            var frame = Window.Current.Content as Frame;
            
            this.Frame.Navigate(typeof(MainPage));
            frame.BackStack.Remove(frame.BackStack.LastOrDefault());
            frame.BackStack.Remove(frame.BackStack.LastOrDefault());
        }

        private void createSettings()
        {
            ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
            if (proteins.Text == "")
                localSettings.Values["protein"] = proteins.PlaceholderText;
            else
                localSettings.Values["protein"] = proteins.Text;


            if (carbs.Text == "")
                localSettings.Values["carbs"] = carbs.PlaceholderText;
            else
                localSettings.Values["carbs"] = carbs.Text;


            if (fat.Text == "")
                localSettings.Values["fat"] = fat.PlaceholderText;
            else
                localSettings.Values["fat"] = fat.Text;


            if (calories.Text == "")
                localSettings.Values["calories"] = calories.PlaceholderText;
            else

                localSettings.Values["calories"] = calories.Text;
        }
    }
}
