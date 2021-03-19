using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPwd
{
    class Program
    {
        static void Main(string[] args)
        {
            string sPassword;


            //Console.WriteLine("请输入一个密码：");
            //sPassword = Console.ReadLine();
            sPassword = args[0];
            switch (CheckPassword.PasswordStrength(sPassword))
            {
                case Strength.Invalid: Console.WriteLine("false\n"); break;
                case Strength.Weak: Console.WriteLine("false\n"); break;
                case Strength.Normal: Console.WriteLine("false\n"); break;
                case Strength.Strong: Console.WriteLine("false\n"); break;
                case Strength.Valid: Console.WriteLine("true\n"); break;
            }




        }
    }
}
