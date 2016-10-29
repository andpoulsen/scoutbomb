using System;
using Windows.System.Threading;
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
        private readonly ThreadPoolTimer _explodeTimer;


        public Explosion()
        {
            this.InitializeComponent();
            ((App)Application.Current).PlaySound("explode.wav", 1);
            var i = 0;
            this._explodeTimer = ThreadPoolTimer.CreatePeriodicTimer(async (source) =>
            {
                i++;

                if (60 <= i)
                { this._explodeTimer.Cancel(); }

                await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High, () =>
                {
                    TheExplosionPage.RequestedTheme = TheExplosionPage.RequestedTheme == ElementTheme.Light ? ElementTheme.Dark : ElementTheme.Light;
                });
            }, TimeSpan.FromMilliseconds(100));
        }
    }
}
