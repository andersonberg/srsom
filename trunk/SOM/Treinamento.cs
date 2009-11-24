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
        private Dictionary<int, int> baseRatings;
        private Dictionary<int, int> testRatings;

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

        /// <summary>
        /// Treinamento da rede
        /// </summary>
        public Treinamento()
        {
            this.baseRatings = new Dictionary<int, int>();
            this.testRatings = new Dictionary<int, int>();

            //Lista de filmes
            List<int> filmes = this.ListaFilmes(@"E:\srsom\movieLens\locacoesCliente13.data", true);

            //Lista de padrões com características dos filmes
            this.padroesEntrada = this.LerArquivo(@"E:\srsom\movieLens\filmes.data", filmes);
            //quantidade de padrões de entrada total
            this.numeroPadroes = padroesEntrada.Count;

            //Número de neurônios do mapa
            double raiz = Math.Ceiling(Math.Sqrt((double)this.numeroPadroes*2));
            int inteiro = Convert.ToInt32(raiz);

            this.mapa = new MapaSOM(inteiro, this.padroesEntrada);
            this.saida = mapa.AlgoritmoAprendizado();
        }

        /// <summary>
        /// Teste da rede
        /// </summary>
        /// <returns></returns>
        public StringBuilder Teste()
        {
            StringBuilder resultadoTeste = new StringBuilder();
            List<PadraoEntrada> padroesTeste = new List<PadraoEntrada>();
            List<int> novosFilmes = this.ListaFilmes(@"E:\srsom\movieLens\cliente13.test", false);
            
            padroesTeste = this.LerArquivo(@"E:\srsom\movieLens\filmes.data", novosFilmes);

            foreach (PadraoEntrada padraoTeste in padroesTeste)
            {
                padraoTeste.Caracteristicas = mapa.NormalizaEntrada(padraoTeste.Caracteristicas);
                padraoTeste.Neuronio = mapa.GetVencedor(padraoTeste.Caracteristicas);
                resultadoTeste.Append("\nTítulo: " + padraoTeste.Label + 
                    " Gênero: " + padraoTeste.Genero + 
                    " Número de locações: " + padraoTeste.Locacoes +
                    " Neurônio: " + padraoTeste.Neuronio.Coordenadas.ToString() +
                    " Avaliação: " + this.testRatings[padraoTeste.Id] + 
                    "\n");

                this.nearestNeighbours = this.GetNearestNeighbours(padraoTeste);
                foreach (Neuronio vizinho in nearestNeighbours)
                {
                    foreach (PadraoEntrada padraoMapa in this.padroesEntrada)
                    {
                        if (padraoMapa.Neuronio.Equals(vizinho))
                        {
                            resultadoTeste.Append("Título: " + padraoMapa.Label +
                                " Gênero: " + padraoMapa.Genero +
                                " Número de locações: " + padraoMapa.Locacoes +
                                " Neurônio: " + vizinho.Coordenadas.ToString() +
                                " Avaliação: " + this.baseRatings[padraoMapa.Id] +
                                "\n");
                            break;
                        }
                    }
                    
                }
            }

            return resultadoTeste;
        }

        /// <summary>
        /// Lê um arquivo de texto e monta o array de padrões de entrada
        /// </summary>
        /// <param name="arquivo"></param>
        /// <param name="filmes"></param>
        /// <returns></returns>
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
                    padraoEntrada.Id = Convert.ToInt32(padraoString[0]);
                    padraoEntrada.Genero = Convert.ToInt32(padraoString[3]);
                    padraoEntrada.Locacoes = Convert.ToInt32(padraoString[4]);

                    for (int i = 2; i < padraoString.Length; i++)
                    {
                        if (!padraoString[i].Equals(string.Empty))
                        {
                            if (i == 3)
                            {
                                int genero = Convert.ToInt32(padraoString[i]);
                                padraoString[i] = (genero*genero).ToString();
                            }
                            padraoEntrada.Caracteristicas.Add(Convert.ToDouble(padraoString[i]));
                        }
                    }

                    padroes.Add(padraoEntrada); 
                }
            }

            stream.Close();
            file.Close();

            return padroes;
        }

        /// <summary>
        /// Cria uma lista de filmes
        /// </summary>
        /// <param name="arquivoFilmes"></param>
        /// <returns></returns>
        public List<int> ListaFilmes(string arquivoFilmes, bool locados)
        {
            FileStream fileMovies = new FileStream(arquivoFilmes, FileMode.Open, FileAccess.Read);
            StreamReader fileMoviesReader = new StreamReader(fileMovies);

            List<int> movies = new List<int>();

            while (!fileMoviesReader.EndOfStream)
            {
                string linha = fileMoviesReader.ReadLine();
                string[] movie = linha.Split('\t');
                int id = Convert.ToInt32(movie[0]);
                int rate = Convert.ToInt32(movie[1]);

                movies.Add(id);

                if (locados)
                {
                    if (this.baseRatings != null && !this.baseRatings.Keys.Contains(id))
                    {
                        this.baseRatings.Add(id, rate);
                    }
                }
                else
                {
                    if (this.testRatings != null && !this.testRatings.Keys.Contains(id))
                    {
                        this.testRatings.Add(id, rate);
                    }
                }
            }

            return movies;
        }

        public void EscreveArquivo(StringBuilder texto)
        {
            File.WriteAllText(@"E:\srsom\movieLens\filmes_result_cliente13_simulacao1.data", texto.ToString());
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
