namespace core
{
    public class Square
    {
        public int[,] Matrix { get; }

        public int N => Matrix.GetLength(0);

        public Square(int[,] matrix)
        {
            Matrix = matrix;
        }

        public override string ToString()
        {
            int n = N;
            string output = "";
            for (int i = 0; i < n; i++)
            {
                output += "\t";
                for (int j = 0; j < n; j++)
                {
                    output += $"{Matrix[i, j]}\t";
                }
                output += "\n";
            }
            return output;
        }

        //4. feladat: A Square osztályban fejezze be az IsMagic() metódust. A függvény akkor adjon igazat, ha
        //minden sor, oszlop és a két átló összege megegyezik.
        public bool IsMagic()
        {
            int n = Matrix.GetLength(0);

            // első sor összege
            int magicSum = 0;
            for (int j = 0; j < n; j++)
                magicSum += Matrix[0, j];

            // további sorok ellenőrzése
            for (int i = 1; i < n; i++)
            {
                int rowSum = 0;
                for (int j = 0; j < n; j++)
                    rowSum += Matrix[i, j];

                if (rowSum != magicSum)
                    return false;
            }

            // oszlopok ellenőrzése
            for (int i = 0;i < n; i++)
            {
                int colSum = 0;
                for (int j = 0; j < n; j++)
                    colSum += Matrix[j, i];

                if (colSum != magicSum)
                    return false;
            }

            // főátló
            int firstDiag = 0;
            for (int i = 0; i < n; i++)
                firstDiag += Matrix[i, i];

            if (firstDiag != magicSum)
                return false;


            // mellékátló
            int secDiag = 0;
            for (int i = 0; i < n; i++)
                secDiag += Matrix[i, n - 1 - i];

            if (secDiag != magicSum)
                return false;

            return true;
        }

    }
}
