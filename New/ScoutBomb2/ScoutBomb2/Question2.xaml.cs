using System;
using Windows.System.Threading;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ScoutBomb2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Question2 : Page
    {
        private ThreadPoolTimer _timer;

        public Question2()
        {
            InitializeComponent();
            var timeLeft = ((App)Application.Current).TimeLeft;
            txtTimeLeft.Text = timeLeft.ToString();
            txtAnswer.Visibility = Visibility.Collapsed;
        }

        private void StartTicking()
        {
            this._timer = ThreadPoolTimer.CreatePeriodicTimer(async (source) =>
            {
                await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High, () =>
                {
                    ((App)Application.Current).Tick(UpdateTimeLeft);
                });
            }, new TimeSpan(0, 0, 1));
        }

        private void StopTicking()
        {
            _timer.Cancel();
            _timer = null;
        }

        private void UpdateTimeLeft(TimeSpan t)
        {
            txtTimeLeft.Text = t.ToString();
        }

        private void btnGet1stHelp_Click(object sender, RoutedEventArgs e)
        {
            ((App)Application.Current).Punish(120);
            HelpPanel1st.Visibility = Visibility.Collapsed;
            txtAnswer.Visibility = Visibility.Visible;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (this._timer == null)
            {
                StartTicking();
            }
            else
            {
                StopTicking();
            }
            //if (Frame.CanGoBack)
            //{
            //    Frame.GoBack();
            //}
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
            if (string.Compare(txbAnswer.Text.Trim(),"I SKAL SKYNDE JER", StringComparison.OrdinalIgnoreCase) == 0)
            {
                Frame.Navigate(typeof(Disarmed));
            }
            else
            {
                WrongAnswer.Begin();
                ((App)Application.Current).PlaySound("punish.wav");
                //txbAnswer.Text = string.Empty;
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
