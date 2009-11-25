using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace LeituraArquivos
{
    class Program
    {
        static void Main(string[] args)
        {
            //ArquivoFilmes();
            //ArquivoCliente();
            //ArquivoTeste();
        }

        public static void ArquivoFilmes()
        {
            string arquivo = @"E:\srsom\movieLens\u.item";
            FileStream file = File.Open(arquivo, FileMode.Open, FileAccess.Read);
            StreamReader fileReader = new StreamReader(file);

            FileStream fileToWrite = File.Create(@"E:\srsom\movieLens\filmes.data");
            StreamWriter fileWriter = new StreamWriter(fileToWrite);

            while (!fileReader.EndOfStream)
            {
                string linha = fileReader.ReadLine();
                string[] dadosFilme = linha.Split('|');

                string filmeID = dadosFilme[0];
                string filmeNome = dadosFilme[1];
                string filmeRelease = dadosFilme[2];
                string[] filmeReleaseSplit = filmeRelease.Split('-');
                string filmeAnoRelease = string.Empty;
                if (filmeReleaseSplit.Count() > 1)
                {
                    filmeAnoRelease = filmeReleaseSplit[2];
                }


                int filmeCount = 0;
                StringBuilder filmeGenre = new StringBuilder();

                //int count = 0;
                for (int i = 5; i < dadosFilme.Length; i++)
                {
                    filmeGenre.Append("|" + dadosFilme[i]);
                }

                //string filmeGenre = count.ToString();

                FileStream arquivoRatings = File.Open(@"E:\srsom\movieLens\u1.base", FileMode.Open, FileAccess.Read);
                StreamReader arquivoRatingsReader = new StreamReader(arquivoRatings);

                while (!arquivoRatingsReader.EndOfStream)
                {
                    string linhaRatings = arquivoRatingsReader.ReadLine();
                    string[] ratings = linhaRatings.Split('\t');

                    if (ratings[1].Equals(filmeID.ToString()))
                    {
                        filmeCount++;
                    }
                }
                arquivoRatingsReader.Close();

                fileWriter.WriteLine(filmeID + "|" + filmeNome + "|" + filmeAnoRelease + "|" + filmeCount + filmeGenre);
            }
            fileReader.Close();
            fileWriter.Close();
        }

        public static void ArquivoCliente()
        {
            FileStream file = File.Open(@"E:\srsom\movieLens\u1.base", FileMode.Open, FileAccess.Read);
            StreamReader fileReader = new StreamReader(file);

            FileStream fileToWrite = File.Create(@"E:\srsom\movieLens\locacoesCliente13.data");
            StreamWriter fileWriter = new StreamWriter(fileToWrite);

            while (!fileReader.EndOfStream)
            {
                string linha = fileReader.ReadLine();
                string[] ratings = linha.Split('\t');

                if (ratings[0].Equals("13"))
                {
                    fileWriter.WriteLine(ratings[1] + "\t" + ratings[2]);
                }
            }
            fileReader.Close();
            fileWriter.Close();
        }

        public static void ArquivoTeste()
        {
            FileStream file = File.Open(@"E:\srsom\movieLens\u1.test", FileMode.Open, FileAccess.Read);
            StreamReader fileReader = new StreamReader(file);

            FileStream fileToWrite = File.Create(@"E:\srsom\movieLens\cliente13.test");
            StreamWriter fileWriter = new StreamWriter(fileToWrite);

            while (!fileReader.EndOfStream)
            {
                string linha = fileReader.ReadLine();
                string[] ratings = linha.Split('\t');

                if (ratings[0].Equals("13"))
                {
                    fileWriter.WriteLine(ratings[1] + "\t" + ratings[2]);
                }
            }
            fileReader.Close();
            fileWriter.Close();
            
        }
    }
}
