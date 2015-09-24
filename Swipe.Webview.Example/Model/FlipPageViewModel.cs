using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Swipe.Webview.Example.Model
{
    public class FlipPageViewModel : ViewModel
    {
        public ObservableCollection<WebsiteModel> Items { get; set; }
        public override void Dispose()
        {
            
        }
    }
}