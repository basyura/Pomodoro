using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomodoro.ViewModels
{
    public class Tracker
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dir"></param>
        public Tracker()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".pomodoro");
            if (!Directory.Exists(path))
            {
                DirectoryInfo info = Directory.CreateDirectory(path);
                if (!info.Exists)
                {
                    throw new Exception("can not create #{dir}");
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="now"></param>
        public void Track(DateTime start, DateTime end)
        {
        }
        private void MakeDirectory()
        {
        }
    }
}
