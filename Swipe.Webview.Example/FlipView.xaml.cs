using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Swipe.Webview.Example.Model;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Swipe.Webview.Example
{
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FlipView : Page
    {
        private bool _firstLoad;
        public FlipPageViewModel FlipViewPageModel;

        public FlipView()
        {
            InitializeComponent();

            _firstLoad = true;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (_firstLoad)
            {
                Debug.WriteLine("fresh load");
                FlipViewPageModel = new FlipPageViewModel
                {
                    Items = new ObservableCollection<WebsiteModel>
                    {
                        new WebsiteModel {Name = "One", AddressUri = new Uri("http://getbootstrap.com/")},
                        new WebsiteModel {Name = "Two", AddressUri = new Uri("http://v3.bootcss.com/")},
                        new WebsiteModel
                        {
                            Name = "Three",
                            AddressUri = new Uri("http://www.oneskyapp.com/fr/docs/bootstrap/getting-started/")
                        },
                        new WebsiteModel
                        {
                            Name = "Four",
                            AddressUri = new Uri("http://www.hackerstribe.com/guide/IT-bootstrap-3.1.1/")
                        }
                    }
                };
                _firstLoad = false;
            }
            else
            {
                Debug.WriteLine("from cache");
            }
            DataContext = FlipViewPageModel;
        }

    

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
            UnLoad();
        }
        private void UnLoad()
        {
            DataContext = null;

            PART_FlipView?.Items?.Clear();

            GC.Collect();
        }
    }
}