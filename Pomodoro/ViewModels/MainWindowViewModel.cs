using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Prism.Mvvm;

namespace Pomodoro.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        /// <summary>
        /// 
        /// </summary>
        public MainWindowViewModel()
        {
        }
        /// <summary></summary>
        public Window Window { get; set; }
        /// <summary></summary>
        public bool IsRunning { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Time
        {
            get
            {
                int sec = Seconds >= 0 ? Seconds : Seconds * -1;
                TimeSpan span = TimeSpan.FromSeconds(sec);
                return span.Minutes.ToString().PadLeft(2, '0') + ":" + span.Seconds.ToString().PadLeft(2, '0');
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private int _Seconds = 25 * 60;
        public int Seconds
        {
            get { return _Seconds; }
            set
            {
                _Seconds = value;
                RaisePropertyChanged("Time");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void ChangeMode()
        {
            if (IsRunning)
            {
                Stop();
            }
            else
            {
                Start();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private void Start()
        {
            BeginInvoke(() => Window.Background = new SolidColorBrush(Colors.PaleVioletRed));
            IsRunning = true;
            Seconds = 25 * 60;
            Task.Run(() =>
            {
                while (true)
                {
                    if (!IsRunning)
                    {
                        break;
                    }

                    Thread.Sleep(1000);
                    Seconds--;

                    if (Seconds < 0)
                    {
                        Blink();
                    }
                }
            });
        }
        /// <summary>
        /// 
        /// </summary>
        private void Stop()
        {
            IsRunning = false;
            if (Seconds < 0)
            {
                BeginInvoke(() => Window.Background = new SolidColorBrush(Colors.DodgerBlue));
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private void Blink()
        {
            BeginInvoke(() =>
            {
                Window.Background = new SolidColorBrush(Colors.DodgerBlue);
                Task.Run(() =>
                {
                    Thread.Sleep(200);
                    BeginInvoke(() => Window.Background = new SolidColorBrush(Colors.PaleVioletRed));
                });
            });
        }
        /// <summary>
        /// 
        /// </summary>
        private void BeginInvoke(Action action)
        {
            Application.Current.Dispatcher.BeginInvoke(action);
        }
    }
}
