using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F3MDeploy
{
    class Program
    {
        static void Main(string[] args)
        {
            int userInput = 0;
            do
            {
                userInput = DisplayMenu();
            } while (userInput != 3);
            //List<string> menuItem = new List<string>()
            //{
            //    "1.WTE",
            //    "2.3J",
            //    "Sair"
            //};

            //while (true)
            //{
            //    for (int i = 0; i < menuItem.Count; i++)
            //    {
            //        if (i == index)
            //        {
            //            Console.WriteLine(menuItem[i]);
            //            index++;
            //        }
            //        if (index >= menuItem.Count)
            //        {
            //            break;
            //        }
            //    }
            //}
        }

        static public int DisplayMenu()
        {
            string startPath = @"";
            string zipPath = @"";
            string extractPath = @"";

            //Formating the date (case sensitive).
            string date = DateTime.Now.ToString("ddMMyyyy HHmmss");

            Console.WriteLine("Selecione a aplicação para efetuar o deploy:");
            Console.WriteLine();
            Console.WriteLine("1. WTE");
            Console.WriteLine("2. 3J");
            Console.WriteLine("3. Sair");

            var result = Console.ReadLine();
            if (result == "1")
            {
                Console.WriteLine(" Efetuando o deploy do WTE");

                startPath = @"C:\temp";
                zipPath = @"C:\destinoTemp\teste.zip";

                //Creating the backup file of the source directory.
                ZipFile.CreateFromDirectory(@"C:\temp", @"C:\sourceTempBackup\backup" + " " + date + ".zip");

                //Creating the backup file of the destination directory.
                ZipFile.CreateFromDirectory(@"C:\temp", @"C:\destinationTempBackup\backup" + " " + date + ".zip");

                //'Ziping' and copying the directory to the destination.
                ZipFile.CreateFromDirectory(startPath, zipPath);

                //Extracting the .zip file archives inside destination.
                ZipFile.ExtractToDirectory(startPath, zipPath);
            }

            if (result == "2")
            {
                Console.WriteLine(" Escolheu o 3J");
            }
            return Convert.ToInt32(result);
        }

    }
}
