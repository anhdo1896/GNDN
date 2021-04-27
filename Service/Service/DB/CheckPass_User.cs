using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.DB
{
    public static class CheckPass_User
    {
        public static bool CheckPassword(string pass)
        {
            //min 8 chars
            if (pass.Length < 6)
                return false;

            //No white space
            if (pass.Contains(" "))
                return false;

            //At least 1 upper case letter
            if (!pass.Any(char.IsUpper))
                return false;

            //At least 1 lower case letter
            if (!pass.Any(char.IsLower))
                return false;

            ////No two similar chars consecutively
            //for (int i = 0; i < pass.Length - 1; i++)
            //{
            //    if (pass[i] == pass[i + 1])
            //        return false;
            //}

            //At least 1 special char
            string specialCharacters = @"%!@#$%^&*()?/>.<,:;'\|}]{[_~`+=-" + "\"";
            char[] specialCharactersArray = specialCharacters.ToCharArray();
            foreach (char c in specialCharactersArray)
            {
                if (pass.Contains(c))
                    return true;
            }
            return false;
        }
    }
}
