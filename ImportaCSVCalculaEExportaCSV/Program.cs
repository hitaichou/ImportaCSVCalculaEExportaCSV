using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
namespace ImportaCSVCalculaEExportaCSV
{
    class Program
    {
        static void Main(string[] args)
        {
            double _vlTotal;
            double _vlValor;
            string _nmProduto;
            int _qtQuantidade;

            string path = @"c:\temp";
            string sourcePath = @"c:\temp\SouceFile.csv";            
            List<string> csv = new List<string>();            

            try
            {
                //crio diretorio(pasta) de saida
                var targetpath = Directory.CreateDirectory(path + "\\out");
                //Adiciono o nome do arquivo contatenando com o caminho
                var filename = targetpath + "\\DestFile.csv";

                using (StreamReader sr = File.OpenText(sourcePath))
                {
                    while(!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        var x = line.Split(';');

                        _nmProduto = x[0];
                        _vlValor = double.Parse(x[1]);
                        _qtQuantidade = int.Parse(x[2]);
                        _vlTotal = (_vlValor / 100) * _qtQuantidade;                        

                        //Adiciono na lista
                        csv.Add(_nmProduto
                              + ","
                              + _vlTotal.ToString("F2",CultureInfo.InvariantCulture));
                    }                    
                }
                //crio o arquivo e escrevo com a lista
                using (StreamWriter sw = File.CreateText(filename)) 
                {
                    foreach (string x in csv)
                    {
                        sw.WriteLine(x);
                    }
                }
            }
            catch(IOException e)
            {
                Console.WriteLine("Um erro ocorreu:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
