using System;
using System.IO;
using System.IO.Compression;

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
            //Formating the date (case sensitive).
            string date = DateTime.Now.ToString("ddMMyyyy HHmmss");

            string sourcePath = @"";
            string sourceBckupPath = @"";
            string destinationPath = @"";
            string destinationBckupPath = @"";
            string directoryPath = @"";
            DirectoryInfo destinationFolder = new DirectoryInfo(@"C:\Deploy\destino");

            Console.WriteLine("Selecione a aplicação para efetuar o deploy:");
            Console.WriteLine();
            Console.WriteLine("1. WTE");
            Console.WriteLine("2. 3J");
            Console.WriteLine("3. Sair");

            var result = Console.ReadLine();
            if (result == "1")
            {
                Console.WriteLine("Efetuando o deploy do WTE");

                sourcePath = @"C:\Deploy\wtepub";
                destinationPath = @"C:\Deploy\destino";
                sourceBckupPath = @"C:\Deploy\bckupOrigem\WTE__DEPLOY__" + "[" + date + "]" + ".zip";
                destinationBckupPath = @"C:\Deploy\bckupDestino\WTE__DEPLOY__d__" + "[" + date + "]" + ".zip";

                //Verifying if the file exists and deleting it.
                directoryPath = @"C:\Deploy\wtepub\tempPdf";
                if (Directory.Exists(directoryPath))
                    Directory.Delete(directoryPath);
                directoryPath = @"C:\Deploy\wtepub\imagens";
                if (Directory.Exists(directoryPath))
                    Directory.Delete(directoryPath);
                File.Delete(@"C:\Deploy\wtepub\web.config");

                //Creating the backup file of the source directory and copying it to it's folder.
                ZipFile.CreateFromDirectory(sourcePath, sourceBckupPath);

                //Creating the backup file of the destination directory.
                ZipFile.CreateFromDirectory(destinationPath, destinationBckupPath);

                //Deleting the original files in destination folder.
                foreach (FileInfo file in destinationFolder.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo dir in destinationFolder.GetDirectories())
                {
                    dir.Delete(true);
                }

                //Extracting the .zip file archives inside destination.
                ZipFile.ExtractToDirectory(sourceBckupPath, destinationPath);

                Console.WriteLine("O deploy foi efetuado com sucesso.");
            }

            if (result == "2")
            {
                Console.WriteLine(" Escolheu o 3J");
            }
            return Convert.ToInt32(result);
        }

    }
}
