using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ScoutBomb2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Explosion : Page
    {
        public Explosion()
        {
            this.InitializeComponent();
            ((App)Application.Current).PlaySound("explode.wav");
        }
    }
}
