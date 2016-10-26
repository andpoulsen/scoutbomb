using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ScoutBomb2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Question1 : Page
    {
        public Question1()
        {
            InitializeComponent();
            var timeLeft = ((App)Application.Current).TimeLeft = new TimeSpan(0, 25, 0);
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
            Frame rootFrame = Window.Current.Content as Frame;

            if (rootFrame.CanGoBack)
            {
                rootFrame.GoBack();
            }
        }

        private void btnAnswer_Click(object sender, RoutedEventArgs e)
        {
            if(string.Compare(txbAnswer.Text.Trim(), "BOMBEN SKAL AFBRYDES", true)==0)
            {
                Frame.Navigate(typeof(Disarmed));
            }
            else
            {
                WrongAnswer.Begin();
                txbAnswer.Text = string.Empty;
            }
        }
    }
}
