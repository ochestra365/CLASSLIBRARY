using System;
using System.IO;
namespace BabyCarrot.Tools
{
    public enum LogType { Daily,Monthly}

    public class LogManager
    {
        //어떤 프로그래밍 수십년에 걸쳐서 돌아간다면 생성시 그룹을 지을 경우 관리나 백업이 편하다.
        private string _path;

        #region Constructors
        public LogManager(string path,LogType logType,string prefix,string postfix)
        {
            _path = path;
            _SetLogPath(logType,prefix,postfix);
        }
        //확장적으로 생각한다.
        public LogManager(string prefix,string postfix)
            :this(Path.Combine(Application.Root,"Log"),LogType.Daily,prefix,postfix)
        {

        }
        public LogManager()
            :this(Path.Combine(Application.Root, "Log"),LogType.Daily,null,null)
        {
        }
        #endregion

        #region Methods
        private void _SetLogPath(LogType logType,string prefix,string postfix)
        {
            string path = String.Empty;
            string name = String.Empty;

            switch (logType) 
            {
                case LogType.Daily:
                    path = String.Format(@"{0}\{1}\", DateTime.Now.Year, DateTime.Now.ToString("MM"));
                    name = DateTime.Now.ToString("yyyyMMdd");
                    break;
                case LogType.Monthly:
                    path = String.Format(@"{0}\", DateTime.Now.Year);
                    name = DateTime.Now.ToString("yyyyMM");
                    break;
            }

            _path = Path.Combine(_path, path);
            if (!Directory.Exists(_path))
            {
                Directory.CreateDirectory(_path);//경로가 존재하지 않으면 경로를 만든다.
            }
            if (!String.IsNullOrEmpty(prefix))
            {
                name = prefix + name;

            }
            if (!String.IsNullOrEmpty(postfix))
            {
                name =  name+postfix;

            }
            name += ".txt";
            _path = Path.Combine(_path, name);
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
//윈도 서비스 프로그램이 한 폴더 돌아가게 되면 현재의 로그 매니저는 한 로그 파일을 공유하게 된다. 그러므로 prefix, postfix를 나눠서 사용한다.