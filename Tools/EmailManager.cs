using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Configuration;
namespace BabyCarrot.Tools
{
    public class EmailManager
    {
        //값을 코드에 박아 넣는 것을 하드코딩이라고 한다.
        //예전에는 ini를 박아넣었으나 2015년 기준으로 xml을 박아넣는다.
        public static void Send(string to, string subject,string contents)
        {
            //app.config에서 밸류값을 읽어온다. 컬렉션 형태로 이루어져 있다.
            string sender = ConfigurationManager.AppSettings["SMTPSender"];  //키값에 해당하는 밸류값이 넘어오게 된다.

            //특정 서버에 메일을 보내는 것이다.SMT 서버가 하게 된다. IP네임과 도메인 네임으로 해당 루트로 찾아가게 된다.  각 서비스를 숫자형태로 된 포트로 외부 통신을 구분한다.
            //특정 컴퓨터의 특정 서버로 찾아가기 위해서는 IP넘버, 호스트명, 도메인명, 포트명으로 어떤 서버의 어떤 서비스명으로 정해지게 된다.
            string smtpHost = ConfigurationManager.AppSettings["SMTPHost"];
            int smtpPort = 0;
            if(ConfigurationManager.AppSettings["SMTPPort"] ==null|| int.TryParse(ConfigurationManager.AppSettings["SMTPPort"], out smtpPort) == false)
            {
                smtpPort = 25;
            }

            string smtpId = ConfigurationManager.AppSettings["SMTPID"];
            string smptPwd = ConfigurationManager.AppSettings["SMTPPassword"];

            MailMessage mailMsg = new MailMessage();
            mailMsg.From = new MailAddress(sender);
            mailMsg.To.Add(to);

            mailMsg.Subject = subject;
            mailMsg.IsBodyHtml = true;
            mailMsg.Body = contents;
            mailMsg.Priority = MailPriority.Normal;

            SmtpClient smtpClient = new SmtpClient();
            //인증서
            smtpClient.Credentials = new NetworkCredential(smtpId, smptPwd);
            smtpClient.Host = smtpHost;
            smtpClient.Port = smtpPort;
            smtpClient.Send(mailMsg);
        }
    }
}
//이메일을 보내기 위하 설정값들을 app.config에서 설정한다. 값이 있는 가와 없는 가? 그리고 잘못된 값이 들어간 것에 대한 밸리데이션 줘야함