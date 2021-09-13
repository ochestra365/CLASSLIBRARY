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
            try//혹시라도 로그 작성 중에 예외발생하면 넘어가게 한다.
            {
                using (StreamWriter writer = new StreamWriter(_path, true))// 중괄호 안에서만 유효하고 벗어나면 시스템이 자동으로 닫아주고, 메모리를 해제해준다.
                {
                    writer.Write(data);//줄바꿈 없이 계속 쓰는 것.
                }
            }
            catch (Exception ex)
            {
            }
            
        }
        public void WriteLine(string data)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(_path, true))
                {
                    writer.WriteLine(DateTime.Now.ToString("yyyyMMdd HH:mm:ss\t") + data);
                }
                //20210913 10:51
            }
            catch (Exception ex)
            {
            }
            
        }
        #endregion
    }
}
