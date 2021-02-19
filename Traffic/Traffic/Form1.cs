namespace Traffic
{
    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Windows.Forms;
    public partial class Form1 : Form
    {
        private int counter = 0;
        private bool wheather = false;
        private int secondsToAdd;
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (counter == 0)
            {
                picBoxTraffic.Image = Properties.Resources.trafficYelow;
                timer1.Interval = 3000;
                counter++;
                lblText.Text = "Приготви се!";
            }
            else if (counter == 1)
            {
                picBoxTraffic.Image = Properties.Resources.trafficRed;
                picBoxMan.Image = Properties.Resources.ManGreen;
                timer1.Interval = 10000;
                counter++;
                lblText.Text = "Пресечи!";
            }
            else if (counter == 2)
            {
                picBoxTraffic.Image = Properties.Resources.trafficYelow;
                timer1.Interval = 3000;
                counter++;
                lblText.Text = "Не пресичай!";
            }
            else if (counter == 3)
            {
                picBoxMan.Image = Properties.Resources.ManRed;
                picBoxTraffic.Image = Properties.Resources.trafficGreen;
                counter = 0;
                lblText.Text = "Не пресичай!";
                timer1.Interval = 10000;
            }
        }
        DateTime timeToChange; Thread t1;
        Stopwatch stopWatch = new Stopwatch();
        private void button1_Click(object sender, EventArgs e)
        {


            secondsToAdd = 5;
            timeToChange = DateTime.Now.AddSeconds(secondsToAdd);
            t1 = new Thread(Start);
            t1.IsBackground = true; t1.Start();
            //stopWatch.Start();
            //  t1 = new Thread(Start1);
            //  t1.IsBackground = true; t1.Start();
        }
        private void Start1()
        {
            while (true)
            {
                int s = stopWatch.Elapsed.Seconds;
                if (s < 5)
                {
                    picBoxMan.Image = Properties.Resources.ManRed;
                    picBoxTraffic.Image = Properties.Resources.trafficGreen;
                    lblText.Invoke(new Action(() => lblText.Text = "Не пресичай!"));
                }
                else if (s >= 5 && s < 8)
                {
                    picBoxMan.Image = Properties.Resources.ManRed;
                    picBoxTraffic.Image = Properties.Resources.trafficYelow;
                    lblText.Invoke(new Action(() => lblText.Text = "Приготви се!"));
                }
                else if (s >= 8 && s < 11)
                {
                    picBoxTraffic.Image = Properties.Resources.trafficRed;
                    picBoxMan.Image = Properties.Resources.ManGreen;
                    lblText.Invoke(new Action(() => lblText.Text = "Пресечи!"));

                }
                else if (s >= 11 && s < 16)
                {
                    picBoxMan.Image = Properties.Resources.ManRed;
                    picBoxTraffic.Image = Properties.Resources.trafficYelow;
                    lblText.Invoke(new Action(() => lblText.Text = "Не пресичай!"));
                }
                else
                {
                    stopWatch.Restart();
                }



            }
        }
        private void Start()
        {
            while (true)
            {
                if (DateTime.Now >= timeToChange)
                {
                    if (counter == 0)
                    {
                        picBoxTraffic.Image = Properties.Resources.trafficYelow;
                        secondsToAdd = 3;
                        lblText.Invoke(new Action(() => lblText.Text = "Приготви се!"));
                        counter++;
                        timeToChange = timeToChange.AddSeconds(secondsToAdd);
                    }
                    else if (counter == 1)
                    {
                        picBoxTraffic.Image = Properties.Resources.trafficRed;
                        picBoxMan.Image = Properties.Resources.ManGreen;
                        secondsToAdd = 5;
                        counter++;
                        lblText.Invoke(new Action(() => lblText.Text = "Пресечи!"));
                        timeToChange = timeToChange.AddSeconds(secondsToAdd);
                    }
                    else if (counter == 2)
                    {
                        picBoxMan.Image = Properties.Resources.ManRed;
                        picBoxTraffic.Image = Properties.Resources.trafficYelow;
                        secondsToAdd = 3;
                        lblText.Invoke(new Action(() => lblText.Text = "Не пресичай!"));
                        counter++;
                        timeToChange = timeToChange.AddSeconds(secondsToAdd);
                    }
                    else
                    {
                        picBoxMan.Image = Properties.Resources.ManRed;
                        picBoxTraffic.Image = Properties.Resources.trafficGreen;
                        counter = 0;
                        secondsToAdd = 5;
                        lblText.Invoke(new Action(() => lblText.Text = "Не пресичай!"));
                        timeToChange = timeToChange.AddSeconds(secondsToAdd);
                    }
                }
            }
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            t1.Abort();
        }
    }
}