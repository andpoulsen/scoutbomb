using System;
using System.Diagnostics;
using Windows.Storage;
using Windows.System.Threading;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ScoutBomb2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Question1 : Page
    {
        private ThreadPoolTimer timer;

        public Question1()
        {
            InitializeComponent();
            var timeLeft = ((App)Application.Current).TimeLeft = new TimeSpan(0, 0, 10);
            txtTimeLeft.Text = timeLeft.ToString();
            
            if (((App)App.Current).Easy)
            {
                HelpPanel1st.Visibility = Visibility.Collapsed;
                img2ndhelp.Visibility = Visibility.Collapsed;
            }
            else
            {
                img1sthelp.Visibility = Visibility.Collapsed;
                img2ndhelp.Visibility = Visibility.Collapsed;
                HelpPanel2nd.Visibility = Visibility.Collapsed;
            }
        }

        private void StartTicking()
        {
            this.timer = ThreadPoolTimer.CreatePeriodicTimer(async (source) =>
            {
                await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High, () =>
                {
                    ((App)Application.Current).Tick(UpdateTimeLeft);
                });
            }, new TimeSpan(0, 0, 1));
        }

        private void StopTicking()
        {
            timer.Cancel();
        }

        private void UpdateTimeLeft(TimeSpan t)
        {
            txtTimeLeft.Text = t.ToString();
        }

        private void btnGet1stHelp_Click(object sender, RoutedEventArgs e)
        {
            img1sthelp.Visibility = Visibility.Visible;
            HelpPanel1st.Visibility = Visibility.Collapsed;
            HelpPanel2nd.Visibility = Visibility.Visible;
        }

        private void btn2ndGetHelp_Click(object sender, RoutedEventArgs e)
        {
            img1sthelp.Visibility = Visibility.Collapsed;
            img2ndhelp.Visibility = Visibility.Visible;
            HelpPanel2nd.Visibility = Visibility.Collapsed;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }

        private void btnAnswer_Click(object sender, RoutedEventArgs e)
        {
            TestAnswer();
        }

        private void txbAnswer_KeyDown(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                TestAnswer();
            }
        }

        private void TestAnswer()
        {
            if (string.Compare(txbAnswer.Text.Trim(), "BOMBEN SKAL AFBRYDES", true) == 0)
            {
                Frame.Navigate(typeof(Disarmed));
            }
            else
            {
                WrongAnswer.Begin();
                txbAnswer.Text = string.Empty;
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            StartTicking();
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            StopTicking();
            base.OnNavigatingFrom(e);
        }

        
    }
}
