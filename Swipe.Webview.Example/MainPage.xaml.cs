using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Swipe.Webview.Example.Model;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Swipe.Webview.Example
{
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private bool _firstLoad;

        public MainPage()
        {
            InitializeComponent();
            _firstLoad = true;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            textBoxicles.Text = (_firstLoad) ? "fresh load" : "from cache";

            if (_firstLoad)
            {
                _firstLoad = false;
            }
            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var pageType = typeof (FlipView);
            Frame.Navigate(pageType);
        }
    }
}