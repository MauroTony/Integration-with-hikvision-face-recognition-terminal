/*
 * CRIADO EM 8~9/2020
 * AUTOR MAURO TONY
 * EMPRESA WTECH
 */
using System;
using System.Threading;

namespace FaceManagement
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length == 5)
            {
                if (args[0] == "register")
                {
                    Functions.Main(args[0], args[1], args[2], args[3], "", "", args[4], "");
                }
                else if (args[0] == "qrcode")
                {
                    Console.WriteLine("QrCode");
                    Functions.Main(args[0], args[1], args[2], "", "", args[3], args[4], "");
                }

            }
            else if (args.Length == 2)
            {
                if (args[0] == "activate_relay")
                {
                    Functions.Main(args[0], "", "", "", "", "", args[1], "");
                }
            }
            else if (args.Length == 3)
            {
                Functions.Main(args[0], "", args[1], "", "", "", args[2], "");
            }
            else if (args.Length == 4)
            {
                Functions.Main(args[0], "", args[1], "", "", "", args[2], args[3]);
            }
            Thread.Sleep(5000);
        }
    }
}
