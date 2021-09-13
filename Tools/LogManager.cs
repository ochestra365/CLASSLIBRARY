using System;
using System.Collections.Generic;
using System.Text;
using System.IO; 
namespace BabyCarrot.Tools
{
    public class LogManager
    {
        private string _path;


        #region Constructors
        public LogManager(string path)
        {
            _path = path;
            _SetLogPath();
        }
        public LogManager()
            :this(Path.Combine(Application.Root, "Log"))
        {
        }
        #endregion

        #region Methods
        private void _SetLogPath()
        {
            if (!Directory.Exists(_path))
            {
                Directory.CreateDirectory(_path);//경로가 존재하지 않으면 경로를 만든다.
            }
            string logFile = DateTime.Now.ToString("yyyyMMdd") + ".txt";
            _path = Path.Combine(_path, logFile);
        }

        public void Write(string data)
        {

        }
        public void WriteLine(string data)
        {

        }
        #endregion
    }
}
