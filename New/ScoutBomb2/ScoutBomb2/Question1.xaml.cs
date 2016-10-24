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
            txbTimeLeft.Text = timeLeft.ToString();
        }
    }
}
