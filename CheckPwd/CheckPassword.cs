using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPwd
{

    /// <summary>
    /// 密码强度
    /// </summary>
    public enum Strength
    {
        Invalid = 0, //无效密码
        Weak = 1,    //低强度密码 
        Normal = 2,  //中强度密码
        Strong = 3,   //高强度密码
        Valid = 4  //符合要求
    }

    public class CheckPassword
    {
        String Pwd;
        public static Strength PasswordStrength(String pwd)
        {
            String Check_String = pwd;
            if (Check_String == "") return Strength.Invalid;

            if (Check_String.Length <= 8)
            {             
                return Strength.Weak; 
            }

            Char[] pwdChars = pwd.ToCharArray();

            //字符统计
            int iNum = 0, iLowLtt = 0, iUpperLtt = 0, iSym = 0;
            foreach (char items in pwdChars)
            {               
                if (items >= '0' && items <= '9') iNum++;
                else if (items >= 'a' && items <= 'z') iLowLtt++;
                else if (items >= 'A' && items <= 'Z') iUpperLtt++;
                else iSym++;
            }

            //只含有一种
            if (iLowLtt == 0 && iUpperLtt == 0 && iSym == 0) return Strength.Weak; //纯数字密码
            if (iNum == 0 && iLowLtt == 0 && iUpperLtt == 0) return Strength.Weak; //纯符号密码
            if (iNum == 0 && iSym == 0 && iLowLtt == 0) return Strength.Weak; //纯大写字母密码
            if (iNum == 0 && iSym == 0 && iUpperLtt == 0) return Strength.Weak; //纯小写字母密码
            //含有两种
            if (iLowLtt == 0 && iUpperLtt == 0) return Strength.Normal; //数字和符号构成的密码
            if (iSym == 0 && iLowLtt == 0) return Strength.Normal; //数字和大写字母构成的密码
            if (iSym == 0 && iUpperLtt == 0) return Strength.Normal; //数字和小写字母构成的密码
            if (iNum == 0 && iLowLtt == 0) return Strength.Normal; //符号和大写字母构成的密码
            if (iNum == 0 && iUpperLtt == 0) return Strength.Normal; //符号和小写字母构成的密码
            if (iNum == 0 && iSym == 0) return Strength.Normal; //大写字母和小写字母构成的密码
            //缺少一种
            if (iNum == 0) return Strength.Strong; // 不含数字
            if (iSym == 0) return Strength.Strong; // 不含符号
            if (iLowLtt == 0) return Strength.Strong; // 不含小写字母
            if (iUpperLtt == 0) return Strength.Strong; // 不含大写字母


            return Strength.Valid; //由数字、大写字母、小写字母符号构成的密码
        }
    }
}
