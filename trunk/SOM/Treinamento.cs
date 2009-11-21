using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows;

namespace SOM
{
    public class Treinamento
    {
        private int numeroPadroes;
        private List<PadraoEntrada> padroesEntrada;
        private StringBuilder saida;
        private MapaSOM mapa;
        private List<Neuronio> nearestNeighbours;

        public List<Neuronio> NearestNeighbours
        {
            get { return nearestNeighbours; }
            set { nearestNeighbours = value; }
        }

        public StringBuilder Saida
        {
            get { return saida; }
            set { saida = value; }
        }

        public Treinamento()
        {
            List<int> filmes = this.ListaFilmes(@"E:\srsom\movieLens\locacoesCliente1.data");

            this.padroesEntrada = this.LerArquivo(@"E:\srsom\movieLens\filmes.data", filmes);

            this.numeroPadroes = padroesEntrada.Count;

            double raiz = Math.Ceiling(Math.Sqrt((double)this.numeroPadroes));
            int inteiro = Convert.ToInt32(raiz);

            this.mapa = new MapaSOM(inteiro, this.padroesEntrada);
            this.saida = mapa.AlgoritmoAprendizado();
        }

        public StringBuilder Teste()
        {
            StringBuilder resultadoTeste = new StringBuilder();
            List<PadraoEntrada> padroesTeste = new List<PadraoEntrada>();
            List<int> novoFilme = new List<int>();
            novoFilme.Add(6);

            padroesTeste = this.LerArquivo(@"E:\srsom\movieLens\filmes.data", novoFilme);

            foreach (PadraoEntrada padraoTeste in padroesTeste)
            {
                padraoTeste.Neuronio = mapa.GetVencedor(padraoTeste.Caracteristicas);
                resultadoTeste.Append(" Padrão: " + padraoTeste.Label + " Neurônio: " + 
                    padraoTeste.Neuronio.Coordenadas.ToString() + "\n");

                this.nearestNeighbours = this.GetNearestNeighbours(padraoTeste);
                foreach (Neuronio vizinho in nearestNeighbours)
                {
                    foreach (PadraoEntrada padraoMapa in this.padroesEntrada)
                    {
                        if (padraoMapa.Neuronio.Equals(vizinho))
                        {
                            resultadoTeste.Append("Padrão: " + padraoMapa.Label + " Vizinho: " + vizinho.Coordenadas.ToString() + "\n");
                        }
                    }
                    
                }
            }

            return resultadoTeste;
        }

        public List<PadraoEntrada> LerArquivo(string arquivo, List<int> filmes)
        {
            List<PadraoEntrada> padroes = new List<PadraoEntrada>();

            FileStream file = File.Open(arquivo, FileMode.Open, FileAccess.Read); 

            StreamReader stream = new StreamReader(file);

            while (!stream.EndOfStream)
            {
                string line = stream.ReadLine();
                string[] padraoString = line.Split('|');

                if (filmes.Contains(Convert.ToInt32(padraoString[0])))
                {
                    PadraoEntrada padraoEntrada = new PadraoEntrada();
                    padraoEntrada.Label = padraoString[1];

                    for (int i = 2; i < padraoString.Length; i++)
                    {
                        padraoEntrada.Caracteristicas.Add(Convert.ToDouble(padraoString[i]));
                    }

                    padroes.Add(padraoEntrada); 
                }
            }

            stream.Close();
            file.Close();

            return padroes;
        }

        public List<int> ListaFilmes(string arquivoFilmes)
        {
            FileStream fileMovies = new FileStream(arquivoFilmes, FileMode.Open, FileAccess.Read);
            StreamReader fileMoviesReader = new StreamReader(fileMovies);

            List<int> movies = new List<int>();

            while (!fileMoviesReader.EndOfStream)
            {
                string movie = fileMoviesReader.ReadLine();
                movies.Add(Convert.ToInt32(movie));
            }

            return movies;
        }

        public void EscreveArquivo(StringBuilder texto)
        {
            File.WriteAllText(@"E:\srsom\movieLens\filmes_result.data", texto.ToString());
        }

        public double DistanciaEntreDoisPontos(Point ponto1, Point ponto2)
        {
            double distancia = Math.Sqrt(Math.Pow(ponto1.X - ponto2.X, 2) + Math.Pow(ponto1.Y - ponto2.Y, 2));
            return distancia;
        }

        public List<Neuronio> GetNearestNeighbours(PadraoEntrada padraoTeste)
        {
            double x = padraoTeste.Neuronio.Coordenadas.X;
            double y = padraoTeste.Neuronio.Coordenadas.Y;
            List<Neuronio> nearestNeighbours = new List<Neuronio>(3);
            
            for (int i = 0; i < 3; i++ )
            {
                double menorDistancia = DistanciaEntreDoisPontos(padraoTeste.Neuronio.Coordenadas, this.padroesEntrada[0].Neuronio.Coordenadas);
                Neuronio nearestNeighbour = this.padroesEntrada[0].Neuronio;

                foreach (PadraoEntrada padrao in this.padroesEntrada)
                {
                    if (!padrao.Equals(padraoTeste) && !nearestNeighbours.Contains(padrao.Neuronio))
                    {
                        double distancia = DistanciaEntreDoisPontos(padraoTeste.Neuronio.Coordenadas, padrao.Neuronio.Coordenadas);
                        if (distancia < menorDistancia)
                        {
                            menorDistancia = distancia;
                            nearestNeighbour = padrao.Neuronio;
                        }
                    }
                }
                if (nearestNeighbour != null && !nearestNeighbours.Contains(nearestNeighbour))
                {
                    nearestNeighbours.Add(nearestNeighbour);
                }
            }
            
            return nearestNeighbours;
        }
    }
}
