using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cajero_bancario
{
    internal class Program
    {
        static bool cambio(string[,] cuentas, int cc)
        {
            Console.Clear();
            Console.WriteLine("digite una nueva contraseña de 4 digitos");
            string nuevac = Console.ReadLine();
            while (nuevac.Length != 4)
            {
                Console.WriteLine("formato no valido");
                Console.WriteLine("intente nuevamente");
                nuevac = Console.ReadLine();
            }
            cuentas[cc, 1] = nuevac;
            return true;
        }
    }
}
    


        




    

