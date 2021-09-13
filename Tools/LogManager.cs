using System;
using System.Collections.Generic;
using System.Text;
using System.IO; 
namespace BabyCarrot.Tools
{
    public class LogManager
    {
        private string _path;

        public LogManager(string path)
        {
            _path = path;
        }
        public LogManager()
        {
            _path = Path.Combine(Application.Root,"Log");
        }

        private void _SetLogPath()
        {
            if (!Directory.Exists(_path))
            {
                Directory.CreateDirectory(_path);//경로가 존재하지 않으면 경로를 만든다.
            }
        }

        public void Write(string data)
        {

        }
        public void WriteLine(string data)
        {

        }
    }
}
