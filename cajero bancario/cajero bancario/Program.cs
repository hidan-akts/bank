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
        static void retiros(string[,] cuentas, int cc, decimal asaldo)
        {
            Console.Clear();
            Console.WriteLine("ingresar monto a retirar");
            decimal retiro = Convert.ToDecimal(Console.ReadLine());
            while (retiro > Decimal.Parse(cuentas[cc, 2]))
            {
                Console.WriteLine("saldo insuficiente");
                Console.WriteLine("ingrese un valor valido para retirar");
                retiro = Convert.ToDecimal(Console.ReadLine());
            }
            decimal saldon = asaldo - retiro;
            cuentas[cc, 2] = saldon.ToString();
            Console.Clear();
            Console.WriteLine("su retiro a sido exitoso");
        }
    }
}
    


        




    

