using System;
using System.Collections.Generic;
using Windows.Media.SpeechRecognition;
using Windows.Storage;
using Windows.UI.Xaml.Controls;
using ScoutBomb.ViewModels;
using Windows.System.Threading;
using Windows.UI.Xaml;
using Newtonsoft.Json;
using ScoutBomb.Models;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ScoutBomb
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private int currentQuestion = 0;
        private ThreadPoolTimer timer, explodeTimer;
        private TimeSpan time = new TimeSpan(0, 2, 0);
         
        public MainPage()
        {
            this.InitializeComponent();
            this.ViewModel = new MainPageViewModel() { TimeLeft = time };
            this.DataContext = this.ViewModel;
            this.CountDown.Text = ViewModel.TimeLeft.ToString();
            QuestionsPanel.Visibility = Visibility.Collapsed;
            
            ReadQuestions();
        }
    
        public MainPageViewModel ViewModel { get; set; }
        public Question[] Questions { get; set; }

        private void AskQuestion()
        {
            Question.Text = Questions[currentQuestion].question;
            Answer1.Content = Questions[currentQuestion].answers[0].answer;
            Answer2.Content = Questions[currentQuestion].answers[1].answer;
            Answer3.Content = Questions[currentQuestion].answers[2].answer;
        }


        private async void PlaySound(string filename)
        {
            MediaElement mysong = new MediaElement();
            var folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets");
            var file = await folder.GetFileAsync(filename);
            var stream = await file.OpenAsync(FileAccessMode.Read);
            mysong.SetSource(stream, file.ContentType);
            mysong.Play();
        }

        private void ReadQuestions()
        {
            var appUri = new Uri("ms-appx:///Assets/questions.json");//File name should be prefixed with 'ms-appx:///Assets/* 
            var anjFile = StorageFile.GetFileFromApplicationUriAsync(appUri).AsTask().ConfigureAwait(false).GetAwaiter().GetResult();
            var jsonText = FileIO.ReadTextAsync(anjFile).AsTask().ConfigureAwait(false).GetAwaiter().GetResult();

            this.Questions = JsonConvert.DeserializeObject<Question[]>(jsonText);
        }

        private void Explode()
        {
            this.timer.Cancel();
            TheMainPage.RequestedTheme = ElementTheme.Light;
            PlaySound("explode.wav");
            var i = 0;
            
            this.explodeTimer = ThreadPoolTimer.CreatePeriodicTimer(async (source) =>
            {
                i++;

                if (30 < i)
                { this.explodeTimer.Cancel(); }

                await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High, () =>
                {
                    TheMainPage.RequestedTheme = TheMainPage.RequestedTheme == ElementTheme.Light ? ElementTheme.Dark : ElementTheme.Light;
                });
            }, TimeSpan.FromMilliseconds(100));
            
            
            StartButton.Visibility = Visibility.Visible;
            QuestionsPanel.Visibility = Visibility.Collapsed;
        }

        private void Disarm()
        {
            this.timer.Cancel();
            PlaySound("disarmed.wav");
            QuestionsPanel.Visibility = Visibility.Collapsed;
            StartButton.Visibility = Visibility.Visible;
        }

        private void StartTimer()
        {
            this.timer = ThreadPoolTimer.CreatePeriodicTimer(async (source) =>
            {   
                this.ViewModel.TimeLeft = this.ViewModel.TimeLeft.Subtract(new TimeSpan(0, 0, 1));
                if(this.ViewModel.TimeLeft.TotalSeconds < 0)
                {
                    this.ViewModel.TimeLeft = new TimeSpan();
                }

                await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High, () =>
                {
                    this.CountDown.Text = ViewModel.TimeLeft.ToString();

                    var secondsLeft = this.ViewModel.TimeLeft.TotalSeconds;
                    if (secondsLeft <= 0)
                    {
                        Explode();
                        
                        return;
                    }else if (secondsLeft < 10)
                    {
                        PlaySound("beep25.wav");
                    }
                    else if (secondsLeft < 20)
                    {
                        PlaySound("beep50.wav");
                    }
                    else if (secondsLeft < 30)
                    {
                        PlaySound("beep75.wav");
                    }
                    else
                    {
                        PlaySound("beep100.wav");
                    }
                });
            }
                , new TimeSpan(0, 0, 1));
        }

        private void Answer_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var answer = new Answer();

            switch (((Button)sender).Name)
            {    
                case "Answer1":
                    answer = Questions[currentQuestion].answers[0];
                    break;
                case "Answer2":
                    answer = Questions[currentQuestion].answers[1];
                    break;
                case "Answer3":
                    answer = Questions[currentQuestion].answers[2];
                    break;
            }


            if (answer.correct)
            {
                if (Questions.Length <= currentQuestion+1)
                {
                    Disarm();
                }
                else
                {
                    PlaySound("disarm.wav");
                    currentQuestion++;
                    AskQuestion();
                }
            }
            else
            {
                PlaySound("punish.wav");
                this.ViewModel.TimeLeft = this.ViewModel.TimeLeft.Subtract(new TimeSpan(0, 0, 20));
            }

            
            
        }

        private void Start_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            currentQuestion = 0;
            this.ViewModel.TimeLeft = time;
            StartButton.Visibility = Visibility.Collapsed;
            StartTimer();
            AskQuestion();
            QuestionsPanel.Visibility = Visibility.Visible;
        }
    }
}
