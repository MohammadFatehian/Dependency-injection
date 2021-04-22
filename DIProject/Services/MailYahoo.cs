using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIProject.Services
{
    public class MailYahoo : Imail
    {
        static int count = 0;
        public MailYahoo() => count++;
        public string SendEmail()
        {
            return $"Send Eamil By Yahoo , Count{count}";
        }
    }
}
