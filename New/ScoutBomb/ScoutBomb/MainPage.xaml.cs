using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ScoutBomb.ViewModels;
using Windows.System.Threading;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ScoutBomb
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
   
        public MainPage()
        {
            this.InitializeComponent();
            this.ViewModel = new MainPageViewModel() { TimeLeft = new TimeSpan(0, 2, 0) };
            this.DataContext = this.ViewModel;
            this.CountDown.Text = ViewModel.TimeLeft.ToString();

            ThreadPoolTimer timer = ThreadPoolTimer.CreatePeriodicTimer(
                (source) =>
                {
                    this.ViewModel.TimeLeft =  this.ViewModel.TimeLeft.Subtract(new TimeSpan(0, 0, 1));

                    Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High, () =>
                    {
                        this.CountDown.Text = ViewModel.TimeLeft.ToString();
                    });
                }
                , new TimeSpan(0, 0, 1));
        }
    

        public MainPageViewModel ViewModel { get; set; }

    }
}
