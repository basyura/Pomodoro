using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
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
        private string _title = "Pomodoro";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        /// <summary>
        /// 
        /// </summary>
        private string _time = "25:00";
        public string Time
        {
            get { return _time; }
            set { SetProperty(ref _time, value); }
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
            IsRunning = true;
            int seconds = 25 * 60;
            Task.Run(() =>
            {
                while (true)
                {
                    if (!IsRunning)
                    {
                        break;
                    }
                    Thread.Sleep(1000);
                    seconds--;
                    TimeSpan span = TimeSpan.FromSeconds(seconds);
                    Time = span.Minutes.ToString().PadLeft(2, '0') + ":" + span.Seconds.ToString().PadLeft(2, '0');
                    if (seconds == 0)
                    {
                        // 画面を触らせたいので Activate じゃなくて topmost を使う
                        BeginInvoke(() => {
                            Window.Topmost = true;
                            BeginInvoke(() => Window.Topmost = false);
                        });
                        break;
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
