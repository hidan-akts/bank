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
        static void saldo(string[,] cuentas, string cuenta)
        {

            decimal retiro = 0;
            try
            {
                StreamWriter saldo = new StreamWriter("saldo.txt");
                for (int x = 1; x < cuentas.GetLength(0); x++)
                {
                    if (cuentas[x, 0] == cuenta)
                    {
                        retiro = Decimal.Parse(cuentas[x, 2]);
                        saldo.WriteLine("Cajero nro:001");
                        saldo.WriteLine("");
                        saldo.WriteLine("Numero de cuenta: " + cuentas[x, 0]);
                        saldo.WriteLine("Disponible: " + "$" + cuentas[x, 2]);
                        saldo.WriteLine("valor: " + "$" + retiro);
                        saldo.WriteLine("");
                        saldo.WriteLine("Gracias Por Utilizar Nuestro Cajero");
                        saldo.WriteLine("************************************");
                    }

                }
                saldo.Close();
            }
        }
    }
}
    


        




    

