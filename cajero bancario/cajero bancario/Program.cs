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
        static void deposito(string[,] cuentas, int cc, decimal asaldo)
        {
            Console.Clear();
            Console.WriteLine("ingresar monto a depositar");
            decimal deposito = Convert.ToDecimal(Console.ReadLine());
            decimal saldon = asaldo + deposito;
            cuentas[cc, 2] = saldon.ToString();
            Console.Clear();
            Console.WriteLine("su deposito a sido exitoso");
        }
    }
}
    


        




    

