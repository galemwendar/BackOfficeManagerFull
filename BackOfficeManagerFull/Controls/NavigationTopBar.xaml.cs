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

namespace BackOfficeManagerFullView.Controls
{
    /// <summary>
    /// Логика взаимодействия для NavigationTopBar.xaml
    /// </summary>
    public partial class NavigationTopBar : UserControl
    {
        public NavigationTopBar()
        {
            InitializeComponent();
            SolidColorBrush currentColorBrush = new SolidColorBrush();
            currentColorBrush.Color = Color.FromRgb(30, 144, 255);
            HomeNavigationMarker.Fill = currentColorBrush;
        }

        private void ToHomeButton_Click(object sender, RoutedEventArgs e)
        {
            SolidColorBrush currentColorBrush = new SolidColorBrush();
            currentColorBrush.Color = Color.FromRgb(30, 144, 255);
            SolidColorBrush otherColorBrush = new SolidColorBrush();
            otherColorBrush.Opacity = 0;
            HomeNavigationMarker.Fill = currentColorBrush;
            GroupNavigationMarker.Fill = otherColorBrush;
            SettingsNavigationMarker.Fill = otherColorBrush;


        }

        private void ToGroupsButton_Click(object sender, RoutedEventArgs e)
        {
            SolidColorBrush currentColorBrush = new SolidColorBrush();
            currentColorBrush.Color = Color.FromRgb(30, 144, 255);
            GroupNavigationMarker.Fill = currentColorBrush;
            SolidColorBrush otherColorBrush = new SolidColorBrush();
            otherColorBrush.Opacity = 0;
            HomeNavigationMarker.Fill = otherColorBrush;
            SettingsNavigationMarker.Fill = otherColorBrush;

        }

        private void ToSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            SolidColorBrush currentColorBrush = new SolidColorBrush();
            currentColorBrush.Color = Color.FromRgb(30, 144, 255);
            SettingsNavigationMarker.Fill = currentColorBrush;
            SolidColorBrush otherColorBrush = new SolidColorBrush();
            otherColorBrush.Opacity = 0;
            HomeNavigationMarker.Fill = otherColorBrush;
            GroupNavigationMarker.Fill = otherColorBrush;

        }
    }
}
