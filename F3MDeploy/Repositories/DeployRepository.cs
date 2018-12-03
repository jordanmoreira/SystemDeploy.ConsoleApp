using System;
using System.IO;
using System.IO.Compression;

namespace F3MDeploy.Repositories
{
    public class DeployRepository
    {
        static public void DeployWTE()
        {
            //Formating the date (case sensitive).
            string date = DateTime.Now.ToString("ddMMyyyy HHmmss");

            string sourcePath = @"";
            string sourceBckupPath = @"";
            string destinationPath = @"";
            string destinationBckupPath = @"";
            string directoryPath = @"";
            var spinner = new Spinner(10, 10);

            Console.Write("Efetuando o deploy do WTE...");
            spinner.Start();

            sourcePath = @"C:\Deploy\wtepub";
            destinationPath = @"C:\Deploy\destino";
            sourceBckupPath = @"C:\Deploy\bckupOrigem\WTE__DEPLOY__" + "[" + date + "]" + ".zip";
            destinationBckupPath = @"C:\Deploy\bckupDestino\WTE__DEPLOY__d__" + "[" + date + "]" + ".zip";

            var sourceFolderFiles = Directory.GetFiles(sourcePath);
            var destinationFolderFiles = Directory.GetFiles(destinationPath);

            string sourceFile = Path.Combine(sourceFolderFiles);
            string destinationFile = Path.Combine(destinationPath, sourceFile);

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
            //foreach (FileInfo file in destinationFolder.GetFiles())
            //{
            //    file.Delete();
            //}
            ////Deleting the original directories in destination folder.
            //foreach (DirectoryInfo dir in destinationFolder.GetDirectories())
            //{
            //    dir.Delete(true);
            //}

            //Now Create all of the directories
            foreach (string dirPath in Directory.GetDirectories(sourcePath, "*",
                SearchOption.AllDirectories))
                Directory.CreateDirectory(dirPath.Replace(sourcePath, destinationPath));

            //Copy all the files & Replaces any files with the same name
            foreach (string newPath in Directory.GetFiles(sourcePath, "*.*",
                SearchOption.AllDirectories))
                File.Copy(newPath, newPath.Replace(sourcePath, destinationPath), true);

            //Getting all files of the directory.
            string[] files = Directory.GetFiles(sourcePath);
            //Iterating files.
            foreach (string f in files)
            {
                sourceFile = Path.GetFileName(f);
                destinationFile = Path.Combine(destinationPath, sourceFile);
                File.Copy(f, destinationFile, true);
            }

            Console.WriteLine("O deploy do WTE foi efetuado com sucesso.");
            spinner.Stop();
            Console.ReadLine();
            new DemoProgram().Run();
        }
    }
}
