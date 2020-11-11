#define LOG
using System;
using System.Diagnostics;

namespace PracticaCompYDoc
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Directivas
            Console.WriteLine("Hola!");
            //Ej 1
            #if DEBUG
            Console.WriteLine("Solo en modo debug");
            #endif

            //Ej 2 - 2
            Console.WriteLine("Introduce un numero");
            string num = Console.ReadLine();
            Log("Usuario introdujo " + num.ToString());

            //Ej 3
            #pragma warning disable
            string msj = "Vuelve pronto";
#pragma warning restore
            #endregion
        }
        //Ej 4
        //#warning En desuso. Usa servicioLog en lugar de este metodo.
        /// <summary>
        /// Metodo para registrar acciones y errores
        /// </summary>
        /// <returns>
        /// void
        /// </returns>
        /// <param name="msg"></param>
        //Ej 2 - 1
        [Conditional("LOG")]
        //[Obsolete("Este método es obsoleto. Utiliza el método LogMsj.")]
        //[Obsolete("Este método es obsoleto. Utiliza el método LogMsj.", true)]
        public static void Log(string msg)
        {
#if DEBUG
            Console.WriteLine($">>Log: {msg}");
            //Ej Directivas personalizadas

#elif RELEASE
            //Save debug on DB
#endif
#if LOGDT
            Console.WriteLine($"TS: {DateTime.Now}");
#endif

            #region enviroment
            //Ej 1
            Console.WriteLine("----- Programa -----");
            Console.WriteLine("StackTrace: '{0}'", Environment.StackTrace);
            Console.WriteLine("Directorio actual: {0}", Environment.CurrentDirectory);

            Console.WriteLine("----- Usuario -----");
            Console.WriteLine("Nombre de usuario: {0}", Environment.UserName);
            Console.WriteLine("Nombre maquina: {0}", Environment.MachineName);
            Console.WriteLine("Versión SO: {0}", Environment.OSVersion.ToString());

            //Ej 1 - 2
            var VSDir = Environment.GetEnvironmentVariable("VisualStudioDir");
            Console.WriteLine($"VisualStudioDir: {VSDir}");
            //Ej 1 - 3
            var varsEntorno = Environment.GetEnvironmentVariables(); //inspect

            #endregion
        }
    }
}
