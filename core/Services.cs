using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace core
{
    public static class Services //nincs példány, osztályszintű változók és megoldások
    {
        private const char Separator = ',';
        private const string Filename = "squares.txt";

        public static string GetFullPath()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            return Path.Combine(baseDir, Filename);
        }

        public static List<Square> LoadSquares()
        {
            List<Square> result = new();
            string path = GetFullPath();

            using StreamReader sr = new StreamReader(path);

            while (!sr.EndOfStream)
            {
                string? line = sr.ReadLine();

                if (string.IsNullOrWhiteSpace(line))
                    continue;

                int n = int.Parse(line);
                int[,] matrix = new int[n, n];

                for (int i = 0; i < n; i++)
                {
                    string row = sr.ReadLine() ?? throw new Exception("Hiányzó sor a fájlban");

                    string[] parts = row.Split(Separator, StringSplitOptions.RemoveEmptyEntries);

                    if (parts.Length != n)
                        throw new Exception("Hibás elemszám egy sorban");

                    for (int j = 0; j < n; j++)
                        matrix[i, j] = int.Parse(parts[j]);
                }

                result.Add(new Square(matrix));
            }

            return result;
        }
    }

}