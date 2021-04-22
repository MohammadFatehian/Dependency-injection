using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIProject.Services
{
    public class MailGmail : Imail
    {
        static int count = 0;
        public MailGmail() => count++;
        public string SendEmail()
        {
            return $"Send Eamil By Gmail , Count{count}";
        }
    }
}
