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
        static void Transaccion(string[,] cuentas, string cuenta, int cc, decimal asaldo)
        {
            Console.WriteLine("digite numero de cuenta a transferir ");
            string cuentad = Console.ReadLine();
            while (cuentad.Length != 7 || cuentad != cuentas[1, 0] && cuentad != cuentas[2, 0] && cuentad != cuentas[3, 0])
            {
                if (cuentad.Length != 7)
                {

                    Console.WriteLine(" tipo de cuenta no valida ");
                    Console.WriteLine("intente nuevamente");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("esta cuenta no existe");
                    Console.WriteLine("intente nuevamente");
                }
                cuentad = Console.ReadLine();
            }
            Console.Clear();
            Console.WriteLine("ingresar monto a transferiri");
            decimal monto = Convert.ToDecimal(Console.ReadLine());
            while (monto > Decimal.Parse(cuentas[cc, 2]))
            {
                Console.WriteLine("saldo insuficiente");
                Console.WriteLine("ingrese un valor valido para transferir");
                monto = Convert.ToDecimal(Console.ReadLine());
            }
            decimal saldon = asaldo - monto;
            cuentas[cc, 2] = saldon.ToString();
            Console.Clear();
            Console.WriteLine("transaccion exitosa");

        }
    }
}
    


        




    

