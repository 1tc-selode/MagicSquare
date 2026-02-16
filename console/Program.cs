using core;

namespace console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {

                //1. feladat
                List<core.Square> squares = core.Services.LoadSquares();
                Console.WriteLine($"1. feladat: Az állomány {squares.Count} darab négyzet adatait tartalmazza. ");

                //2. feladat: Számolja meg és írja ki, hány darab 3x3-as méretű négyzet található az állományban. linq nelkul
                int count3x3 = 0;
                foreach (Square square in squares)
                {
                    if (square.N == 3)
                        count3x3++;
                }
                if (count3x3 == 0)
                    Console.WriteLine("2. feladat: Az állományban nincs 3x3-as méretű négyzet. ");
                else
                {
                    Console.WriteLine($"2. feladat: Az állományban {count3x3} darab 3x3-as négyzet van.");
                }

                // 3. feladat: Kérjen be egy sorszámot a felhasználótól. Jelenítse meg a sorszámnak megfelelő
                // négyzetet tabulátorokkal tagolva.Ha a megadott sorszám nem létezik, írja ki: &quot; Ilyen sorszámú
                // négyzet nem létezik.& quot;

                Console.Write($"3. feladat: Adja meg a kiírandó négyzet sorszámát [0-{squares.Count-1}]: ");
                if (int.TryParse(Console.ReadLine(), out int index))
                {
                    if (index < 0 || index >= squares.Count)
                    {
                        Console.WriteLine("Ilyen sorszámú négyzet nem létezik.");
                    }
                    else
                    {
                        Console.WriteLine($"A {index}. sorszámú négyzet:");
                        Console.WriteLine(squares[index].ToString());
                    }
                };


                // 5. feladat: Kérjen be egy sorszámot, és írja ki, hogy a sorszámhoz tartozó négyzet bűvös-e. Hibás
                //sorszám esetén jelezze azt a fentebb megadott hibaüzenettel.

                Console.Write($"5. feladat: Adja meg az ellenőrizendő négyzet sorszámát [0-{squares.Count-1}]: ");
                if (int.TryParse(Console.ReadLine(), out int magicIndex))
                {
                    if (magicIndex < 0 || magicIndex >= squares.Count)
                    {
                        Console.WriteLine("Ilyen sorszámú négyzet nem létezik.");
                    }
                    else
                    {
                        Square square = squares[magicIndex];
                        if (square.IsMagic())
                            Console.WriteLine($"A kiválasztott négyzet bűvös.");
                        else
                            Console.WriteLine($"A kiválasztott négyzet nem bűvös.");
                    }
                };
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba történt: {ex.Message}");
            }

        }
    }
}
