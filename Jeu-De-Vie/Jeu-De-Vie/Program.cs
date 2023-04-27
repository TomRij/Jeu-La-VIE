using System;

namespace Jeu_De_Vie
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.WindowWidth = Console.LargestWindowWidth;
            Console.WindowHeight = Console.LargestWindowHeight;
            Console.BufferWidth = Console.LargestWindowWidth;
            Console.BufferHeight = Console.LargestWindowHeight;

            MethodeDuProjet mesOutils = new MethodeDuProjet();

            while (true)
            {
                string textToEnter = "Bienvenue dans le jeu de la vie";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (textToEnter.Length / 2)) + "}", textToEnter));
                Console.WriteLine("Taper 1 pour commencer le jeu de la vie en mode alléatoire : ");
                int lancer = int.Parse(Console.ReadLine());
                if (lancer == 1)
                {
                    while (true)
                    {
                        // appel de la méthode GenMatrice pour générer la matrice de départ
                        int _nbLigne = 100;
                        int _nbColonne = 500;
                        mesOutils.GenMatrice(_nbLigne, _nbColonne, out bool[,] _matrice);
                        mesOutils.ShowMatrice(_matrice, out string _matriceChaine);

                        System.Threading.Thread.Sleep(20);

                        // appel de la méthode EtapeSuivante pour obtenir la nouvelle matrice
                        mesOutils.EtapeSuivante(_matrice, out bool[,] _nouvelleMatrice);

                        Console.Clear();


                        // affichage de la nouvelle matrice
                        mesOutils.ShowMatrice(_nouvelleMatrice, out string _nouvelleMatriceChaine);
                        Console.WriteLine("Nouvelle matrice : \n" + _nouvelleMatriceChaine);

                    }
                }
            }
        }
    }
}
