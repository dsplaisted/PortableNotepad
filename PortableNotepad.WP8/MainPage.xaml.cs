using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PortableNotepad.WP8.Resources;
using PortableNotepad.WP8.Models;

namespace PortableNotepad.WP8
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            DataContext = new NotepadViewModel(new WP8FileStorage());

            ///Sample code to call helper function to localize the ApplicationBar
            //BuildApplicationBar();
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Images/appbar_button1.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.appbar_buttonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.appbar_menuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}