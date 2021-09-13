using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
namespace BabyCarrot.Tools
{
    public static class Application
    {
        public  static string Root
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory;
            }
        }
    }
}
