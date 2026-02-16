using core;

namespace console
{
    internal class Program
    {
        static void Main(string[] args)
        {
			try
			{
                List<Square> squares = Services.LoadSquares();
                Console.WriteLine($"1.feladat: Az állomány {squares.Count} darab négyzet adatait tartalmazza.");



                //2. feladat : Az allomanyba hany 3x3-as negyzet van?
                int count3x3 = 0;
                foreach (Square square in squares)
                {
                    if (square.N == 3)
                        count3x3++;
                }

                if (count3x3 == 0)
                {
                    Console.WriteLine("2.feladat: Az állományban nincs 3x3-as négyzet");
                }
                else
                {
                    Console.WriteLine($"2.feladat: Az állományban {count3x3} darab 3x3-as négyzet van.");
                }

                //3.
                Console.WriteLine($"3. feladat: Adja meg a Kiirando negyzet sorszamat [0-{squares.Count-1}]");
                if (int.TryParse(Console.ReadLine(), out int index))
                {
                    if (index < 0 || index >= squares.Count)
                    {
                        Console.WriteLine("Hibás sorszám");
                    }
                    else 
                    {
                        Console.WriteLine();
                    }
                    
                };

                //5. Adja meg az ellenorizendo negyzet sorszamat [0-5]

                Console.WriteLine($"3. feladat: Adja meg a Kiirando negyzet sorszamat [0-{squares.Count - 1}]");
                if (int.TryParse(Console.ReadLine(), out index))
                {
                    if (index < 0 || index >= squares.Count)
                    {
                        Console.WriteLine("Hibás sorszám");
                    }
                    else
                    {
                        if (squares[index].IsMagic())
                        {
                            Console.WriteLine("A kiválasztott négyzet bűvös");
                        }
                        else
                        {
                            Console.WriteLine("A kivalasztott negyzet nem buvos.");
                        }
                    }


                }

            }
			catch (Exception e)
			{
                Console.WriteLine("Hiba történt", e.Message);
				
			}
        }
    }
}
