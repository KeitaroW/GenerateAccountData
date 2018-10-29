using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uebung03_GenerateAccountData
{
    class Program
    {
        static void Main(string[] args)
        {
            RegistrationDay day = new RegistrationDay(7500, 0, DateTime.Now.Date);
            day.GenerateAccountData();
            Console.Read();
        }
    }
}
