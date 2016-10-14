using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Runtime.InteropServices;
using System.Threading;
using System.Drawing;

namespace ScoutBomb
{
    public partial class MainForm : Form
    {
        [DllImport("winmm.dll")]
        public static extern int sndPlaySound(string lpszSoundName, int uFlags);

        private string beepSound = "beep100.wav";

        private System.Windows.Forms.Timer countdownTimer = new System.Windows.Forms.Timer();

        private DateTime startTime, endTime;
        private TimeSpan setTime, remainingTime;

        private TimeSpan penaltyTime;
        private List<string> answers = new List<string>();
        private List<string> questions = new List<string>();
        private List<string> pictures = new List<string>();
        private string finishpic;
        private int i = 0;

        public MainForm()
        {
            InitializeComponent();

            this.FormClosing += new FormClosingEventHandler(MainForm_FormClosing);

            countdownTimer.Interval = 50;
            countdownTimer.Tick += new EventHandler(countdownTimer_Tick);

            timeLeftLabel.Text = String.Format(Properties.Resources.TimeFormat, 0, 0, 0);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            loadSettings();
            timeLeftLabel.Text = String.Format(Properties.Resources.TimeFormat, setTime.Hours, setTime.Minutes, setTime.Seconds);
        }

        private void MainForm_FormClosing(object sender, EventArgs e)
        {
            countdownTimer.Stop();
        }

        private void loadSettings()
        {
            try
            {
                XmlTextReader xmlTextReader = new XmlTextReader("config.xml");

                string name = "";

                while (xmlTextReader.Read())
                {
                    switch (xmlTextReader.NodeType)
                    {
                        case XmlNodeType.Element:

                            name = xmlTextReader.Name;
                            break;

                        case XmlNodeType.Text:

                            switch(name)
                            {
                                case "Question":

                                    questions.Add(xmlTextReader.Value);
                                    break;

                                case "Answer":

                                    answers.Add(xmlTextReader.Value); 
                                    break;

                                case "Picture":
                                    pictures.Add(xmlTextReader.Value);
                                    break;

                                case "Penalty":

                                    penaltyTime = TimeSpan.Parse(xmlTextReader.Value);
                                    break;

                                case "Timeout":

                                    setTime = TimeSpan.Parse(xmlTextReader.Value);
                                    break;
                                
                                case "Finishpicture":
                                    finishpic = xmlTextReader.Value;
                                    break;
                            }
                            break;
                    }
                } 
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void detonate()
        {
            countdownTimer.Stop();
            answerTextBox.Enabled = false;
            answerTextBox.Text = Properties.Resources.AnswerTextBoxHelp;
            button1.Enabled = false;
            button1.Text = "start";
            button1.Focus();
            timeLeftLabel.Text = String.Format(Properties.Resources.TimeFormat, 0, 0, 0);
            timeLeftProgressBar.Value = 0;
            statusLabel.Text = "Bomben eksploderede!";
            sndPlaySound("explode.wav", 0);
            beeptimer.Stop();
        }

        private void disarm()
        {
            countdownTimer.Stop();
            answerTextBox.Enabled = false;
            answerTextBox.Text = Properties.Resources.AnswerTextBoxHelp;
            button1.Enabled = false;
            button1.Text = "start";
            button1.Focus();
            timeLeftLabel.Text = String.Format(Properties.Resources.TimeFormat, 0, 0, 0);
            timeLeftProgressBar.Value = 0;
            statusLabel.Text = "Bomben er desarmeret!";
            sndPlaySound("disarm.wav", 0); 
            sndPlaySound("disarmed.wav", 0);
            pic.Image = Image.FromFile(finishpic);
            beeptimer.Stop();
        }

        private void punish()
        {
            endTime = endTime.Subtract(penaltyTime);
            sndPlaySound("punish.wav", 0);
        }

        private void beep()
        {
            while (countdownTimer.Enabled)
            {
                //sndPlaySound(beepSound, 0);
            }
        }

        private void countdownTimer_Tick(Object sender, EventArgs e)
        {
            remainingTime = new TimeSpan(endTime.Ticks - DateTime.Now.Ticks);

            if (remainingTime.Ticks > 0)
            {
                timeLeftLabel.Text = String.Format(Properties.Resources.TimeFormat, remainingTime.Hours, remainingTime.Minutes, remainingTime.Seconds);
                
                double x = (double)remainingTime.Ticks / (double)setTime.Ticks;
                timeLeftProgressBar.Value = (int)(x * 10000);

                if (x < 0.25)
                    beeptimer.Interval=250;
                else if (x < 0.5)
                    beeptimer.Interval=500;
                else if (x < 0.75)
                    beeptimer.Interval=750;
                else
                    beeptimer.Interval = 1000;
            }
            else
            {
                detonate();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "start")
            {
                button1.Text = "svar";

                startTime = DateTime.Now;
                endTime = startTime.Add(setTime);
                countdownTimer.Start();
                beeptimer.Start();

                sndPlaySound("plant.wav", 0);
                statusLabel.Text = "Spørgsmål 1 af " + answers.Count;

                Thread beepThread = new Thread(new ThreadStart(beep));
                beepThread.Start();

                i = 0;
                answerTextBox.Enabled = true;
                answerTextBox.Focus();
                QBox1.Text = questions[i];
                pic.Image = Image.FromFile(pictures[i]);
            }
            else
            {
                if (answerTextBox.Text == answers[i])
                {
                    i++;


                    if (i == answers.Count)
                    {
                        disarm();
                    }
                    else
                    {
                        statusLabel.Text = "Spørgsmål " + (i + 1) + " af " + answers.Count;
                        answerTextBox.Text = Properties.Resources.AnswerTextBoxHelp;
                        answerTextBox.Focus();
                        answerTextBox.SelectAll();
                        QBox1.Text = questions[i];
                        pic.Image = Image.FromFile(pictures[i]);
                    }
                }
                else
                {
                    punish();
                    answerTextBox.Focus();
                    answerTextBox.SelectAll();
                    QBox1.Text = questions[i];
                    pic.Image = Image.FromFile(pictures[i]);
                }
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void QBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void beeptimer_Tick(object sender, EventArgs e)
        {
          //  Console.Beep();
        }
    }
}