using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIProject.Services
{
    public class DIProjectService
    {
        static int count = 0;

        public DIProjectService() => count++;
        public string SendEmail()
        {
            return $"Send Eamil By DIProjectService , Count{count}";
        }
    }
}
