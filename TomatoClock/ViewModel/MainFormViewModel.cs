using System;
using System.Windows;

namespace TomatoClock
{
    class MainFormViewModel:NotificationObject
    {
        private System.Timers.Timer countTimer = new System.Timers.Timer(1000);

        private MyCommand _cmdFormLoaded;

        public MyCommand CmdFormLoaded
        {
            get
            {
                if(_cmdFormLoaded == null)
                {
                    _cmdFormLoaded = new MyCommand(new Action<object>(
                        o => 
                        {
                            CurrentTime = MinuterSet * 60;
                            countTimer.Elapsed += TimeCountElapsed;
                        }));
                }
                return _cmdFormLoaded;
            }
        }

        private void TimeCountElapsed(object sender, EventArgs e)
        {
            if(CurrentTime > 0)
            {
                CurrentTime--;
                TimeSpan ts = TimeSpan.FromSeconds(CurrentTime);
                TimeCount = ts.Hours + ":" + ts.Minutes + ":" + ts.Seconds;
            }
            else
            {
                countTimer.Stop();
            }
        }

        private int _currentTime;
        public int CurrentTime
        {
            get { return _currentTime; }
            set
            {
                _currentTime = value;
                this.RaisePropertyChanged("CurrentTime");
            }
        }

        private string _timeCount = "--:--:--";
        public string TimeCount
        {
            get { return _timeCount; }
            set
            {
                _timeCount = value;
                this.RaisePropertyChanged("TimeCount");
            }
        }

        private MyCommand _cmdStart;

        public MyCommand CmdStart
        {
            get
            {
                if (_cmdStart == null)
                {
                    _cmdStart = new MyCommand(new Action<object>(
                        o =>
                        {
                            countTimer.Start();
                            IsCountting = true;
                            IsStop = false;
                            Console.WriteLine("开始倒数，" + CurrentTime.ToString());
                        }));
                }
                return _cmdStart;
            }
        }

        private MyCommand _cmdReset;

        public MyCommand CmdReset
        {
            get
            {
                if(_cmdReset == null)
                {
                    _cmdReset = new MyCommand(new Action<object>(
                        o =>
                        {
                            countTimer.Stop();
                            TimeCount = "--:--:--";
                        }));
                }
                return _cmdReset;
            }
        }

        private int _minuterSet = 25;
        public int MinuterSet
        {
            get { return _minuterSet; }
            set
            {
                _minuterSet = value;
                this.RaisePropertyChanged("MinuterSet");
            }
        }

        private MyCommand _cmdSet;

        public MyCommand CmdSet
        {
            get
            {
                if (_cmdSet == null)
                {
                    Console.WriteLine("设定时间，分钟：" + MinuterSet.ToString());
                    _cmdSet = new MyCommand(new Action<object>(o =>
                    {
                        if (MinuterSet > 0)
                        {
                            CurrentTime = MinuterSet * 60;
                            Console.WriteLine("设定时间完成，秒数：" + CurrentTime.ToString());
                        }
                        else
                        {
                            MinuterSet = 25;
                            CurrentTime = MinuterSet * 60;
                            MessageBox.Show("时间输入错误！");
                        }
                    }));
                }
                return _cmdSet;
            }
        }

        private MyCommand _cmdStop;

        public MyCommand CmdStop
        {
            get
            {
                if(_cmdStop == null)
                {
                    _cmdStop = new MyCommand(new Action<object>(o =>
                    {
                        countTimer.Stop();
                        IsCountting = false;
                        IsStop = true;
                        CurrentTime = MinuterSet * 60;
                        TimeCount = "--:--:--";
                    }));
                }
                return _cmdStop;
            }
        }

        private bool _isCountting = false;
        public bool IsCountting
        {
            get { return _isCountting; }
            set
            {
                _isCountting = value;
                this.RaisePropertyChanged("IsCountting");
            }
        }

        private bool _isStop = true;
        public bool IsStop
        {
            get { return _isStop; }
            set
            {
                _isStop = value;
                this.RaisePropertyChanged("IsStop");
            }
        }
    }
}
