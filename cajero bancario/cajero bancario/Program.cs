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
        static void Main(string[] args)
        {
            // matriz
            string[,] cuentas = new string[4, 3];
            cuentas[0, 0] = "cuenta";
            cuentas[0, 1] = "contraseña";
            cuentas[0, 2] = "saldo inicial";

            cuentas[1, 0] = "4596972";
            cuentas[1, 1] = "0591";
            cuentas[1, 2] = "500.000";

            cuentas[2, 0] = "4517831";
            cuentas[2, 1] = "7742";
            cuentas[2, 2] = "20.000";

            cuentas[3, 0] = "4372116";
            cuentas[3, 1] = "9003";
            cuentas[3, 2] = "1.700.000";

            //entrar al cajero 
            Console.WriteLine("binevenido al cajero automatico del banco torrente ");
            Console.WriteLine("");
            Console.WriteLine("digite su numero de cuenta para continuar ");
            string cuenta = Console.ReadLine();
            while (cuenta.Length != 7 || cuenta != cuentas[1, 0] && cuenta != cuentas[2, 0] && cuenta != cuentas[3, 0])
            {
                if (cuenta.Length != 7)
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
                cuenta = Console.ReadLine();
            }
            Console.Clear();
            Console.WriteLine("digite su contraseña  para continuar");
            string contraseña = Console.ReadLine();

            int cc = -1;

            for (int x = 0; x < cuentas.GetLength(0); x++)
            {
                if (cuentas[x, 0] == cuenta)
                {
                    cc = x;
                    break;
                }
            }

            while (contraseña.Length != 4 || contraseña != cuentas[cc, 1])
            {
                if (contraseña.Length != 4)
                {
                    Console.WriteLine("contraseña invalida, debe tener 4 digitos");
                    Console.WriteLine("intente nuevamente");
                }
                else
                {
                    Console.WriteLine("contraseña incorrecta");
                    Console.WriteLine("intente nuevamente");
                }
                contraseña = Console.ReadLine();
            }

            Console.Clear();



            // menu de opciones
            int opcion;
            bool continuar = true;
            bool seleccion = false;

            Console.Clear();
            while (continuar)
            {
                if (!seleccion)
                {
                    Console.WriteLine("bienvenido elija una de las siguientes obciones");
                    Console.WriteLine("");
                    Console.WriteLine("1.retiros");
                    Console.WriteLine("2.transacciones");
                    Console.WriteLine("3.depositos");
                    Console.WriteLine("4.cambio de clave");
                    Console.WriteLine("5.saldo de cuenta");
                    Console.WriteLine("6.salida");
                    Console.WriteLine("");
                }

                opcion = int.Parse(Console.ReadLine());
                decimal asaldo = Convert.ToDecimal(cuentas[cc, 2]);

                if (opcion == -1)
                {

                    break;
                }

                if (opcion < 1 || opcion > 6)
                {
                    Console.Clear();
                    ; Console.WriteLine("opcion no valida");
                    Console.WriteLine("elija un opcion del menu");
                    continue;
                }

                seleccion = true;
                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        retiros(cuentas, cc, asaldo);
                        Console.WriteLine("");
                        Console.WriteLine("preione una tecla para volver al menu principal");
                        Console.ReadKey();
                        seleccion = false;
                        break;
                    case 2:
                        Console.Clear();
                        Transaccion(cuentas, cuenta,cc,asaldo);
                        Console.WriteLine("");
                        Console.WriteLine("preione una tecla para volver al menu principal");
                        Console.ReadKey();
                        seleccion = false;
                        break;
                    case 3:
                        Console.Clear();
                        deposito(cuentas, cc, asaldo);
                        Console.WriteLine("");
                        Console.WriteLine("preione una tecla para volver al menu principal");
                        Console.ReadKey();
                        seleccion = false;
                        break;
                    case 4:
                        if (cambio(cuentas, cc))
                        {
                            Console.Clear();
                            Console.WriteLine(" su contraseña a sido cambiada  exitosamente");
                        }
                        Console.WriteLine("");
                        Console.WriteLine("preione una tecla para volver al menu principal");
                        Console.ReadKey();
                        seleccion = false;
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("transaccion exitosa");
                        saldo(cuentas, cuenta);
                        Console.WriteLine("");
                        Console.WriteLine("preione una tecla para volver al menu principal");
                        Console.ReadKey();
                        seleccion = false;
                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine(salida());
                        continuar = false;
                        break;

                }

            }
            Console.ReadKey();
        }
        static string salida()
        {
            return ("**** GRACIAS POR UTILIZAR NUETRO CAJERO ****");

        }
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
            catch (Exception e)
            {
                Console.WriteLine("Exception:" + e.Message);
            }
            finally
            {
                Console.WriteLine("Execuiting finally block.");
            }
        }
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
        static void Transaccion(string[,] cuentas, string cuenta,int cc,decimal asaldo)
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
                monto= Convert.ToDecimal(Console.ReadLine());
            }
            decimal saldon = asaldo - monto;
            cuentas[cc, 2] = saldon.ToString();
            Console.Clear();
            Console.WriteLine("transaccion exitosa");

        }
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
    


        




    

