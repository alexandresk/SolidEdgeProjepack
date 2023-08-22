using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeMacro
{
    class password
    {
        string[] pass = System.IO.File.ReadAllLines(@"\\fs\e\Transferencia\Alexandre\visualstudio.txt");

        //if(pass[0] == "")

        public static bool Pass()
        {
            string[] pass = System.IO.File.ReadAllLines(@"\\fs\e\Transferencia\Alexandre\visualstudio.txt");

            if (pass[0] == "----------------------------------------------------")
            {
                return true;
            }
            else
            {
                return false;
            }
        }





    }
}
