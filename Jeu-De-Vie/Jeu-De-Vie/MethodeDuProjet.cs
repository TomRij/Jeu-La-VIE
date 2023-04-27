using System;

public struct MethodeDuProjet
{
    public void GenMatrice(int _nbLigne, int _nbColonne, out bool[,] _matrice)
    {
        // instantiation de la matrice tabAlea
        _matrice = new bool[_nbLigne, _nbColonne];
        // instantiation de la variable random
        Random random = new Random();
        // boucle pour passer dans les lignes de la matrice
        for (int ligne = 0; ligne < _nbLigne - 1; ligne++)
        {
            // boucle pour passer dans les colonnes de la matrice
            for (int colonne = 0; colonne < _nbColonne - 1; colonne++)
            {
                // mise des données alléatoires true ou false si la cellule est vivante ou morte
                _matrice[ligne, colonne] = random.Next(2) == 1;
            }
        }
    }
    //morceau de programme pour concaténer (afficher) la matrice
    public void ShowMatrice(bool[,] _matrice, out string _matriceChaine)
    {
        _matriceChaine = "";
        // boucle pour se balades dans les lignes de la matrice
        for (int ligne = 0; ligne < _matrice.GetLength(0) - 1; ligne++)
        {
            // boucle pour se balader dans les colonnes de la matrice
            for (int colonne = 0; colonne < _matrice.GetLength(1) - 1; colonne++)
            {
                // mise des données de la matrice dans la variable string stringTab
                if (_matrice[ligne, colonne] == true)
                {
                    _matriceChaine += "O";
                }
                else
                {
                    _matriceChaine += "-";
                }
            }
            // passage à la ligne
            _matriceChaine += "\n";
        }
    }

    public void UpdateMatrice(bool[,] _matrice)
    {
        bool[,] nouvelleMatrice = new bool[_matrice.GetLength(0), _matrice.GetLength(1)];

        for (int i = 0; i < _matrice.GetLength(0); i++)
        {
            for (int j = 0; j < _matrice.GetLength(1); j++)
            {
                int nbVoisins = CountVoisins(_matrice, i, j);

                if (_matrice[i, j])
                {
                    // Si la cellule est vivante et a deux ou trois voisins, elle reste vivante, sinon elle meurt.
                    nouvelleMatrice[i, j] = (nbVoisins == 2 || nbVoisins == 3);
                }
                else
                {
                    // Si la cellule est morte et a exactement trois voisins, elle devient vivante.
                    nouvelleMatrice[i, j] = (nbVoisins == 3);
                }
            }
        }

        // Mettre à jour la matrice
        for (int i = 0; i < _matrice.GetLength(0); i++)
        {
            for (int j = 0; j < _matrice.GetLength(1); j++)
            {
                _matrice[i, j] = nouvelleMatrice[i, j];
            }
        }
    }

    public int CountVoisins(bool[,] _matrice, int x, int y)
    {
        int count = 0;

        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                if (i == 0 && j == 0) continue;

                int ligne = x + i;
                int colonne = y + j;

                if (ligne < 0 || colonne < 0) continue;
                if (ligne >= _matrice.GetLength(0) || colonne >= _matrice.GetLength(1)) continue;

                if (_matrice[ligne, colonne])
                {
                    count++;
                }
            }
        }

        return count;
    }

    public void EtapeSuivante(bool[,] _matrice, out bool[,] _nouvelleMatrice)
    {
        int nbLignes = _matrice.GetLength(0);
        int nbColonnes = _matrice.GetLength(1);
        _nouvelleMatrice = new bool[nbLignes, nbColonnes];

        for (int i = 0; i < nbLignes; i++)
        {
            for (int j = 0; j < nbColonnes; j++)
            {
                int nbVoisins = CountVoisins(_matrice, i, j);

                if (_matrice[i, j])
                {
                    // Si la cellule est vivante et a deux ou trois voisins, elle reste vivante, sinon elle meurt.
                    _nouvelleMatrice[i, j] = (nbVoisins == 2 || nbVoisins == 3);
                }
                else
                {
                    // Si la cellule est morte et a exactement trois voisins, elle devient vivante.
                    _nouvelleMatrice[i, j] = (nbVoisins == 3);
                }
            }
        }

        // Mettre à jour la matrice
        for (int i = 0; i < nbLignes; i++)
        {
            for (int j = 0; j < nbColonnes; j++)
            {
                _matrice[i, j] = _nouvelleMatrice[i, j];
            }
        }
    }
}


