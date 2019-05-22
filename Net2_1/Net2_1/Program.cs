using System;

namespace Net2_1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                var FyodorDostoyevsky = new Author("Fyodor", "Dostoyevsky");
                var LevTolstoy = new Author("Lev", "Tolstoy");
                var AlexanderPushkin = new Author("Alexander", "Pushkin");
                var AntonChekhov = new Author("Anton", "Chekhov");
                //===================================================================
                //ISBN: XXX-X-XX-XXXXXX-X
                //------------------ Books of Fydor Dostoyevsky ---------------------
                var CrimeAndPunishment = new Book("Crime and punishment", "978-5-17-112393-2",
                    FyodorDostoyevsky, AlexanderPushkin, LevTolstoy);
                var Idiot = new Book("Idiot", "978-5-38-904730-3", new DateTime(1998, 07, 25), FyodorDostoyevsky);
                var Devils = new Book("Devils", "978-5-92-682607-1", FyodorDostoyevsky);

                //Console.WriteLine(CrimeAndPunishment);
                //___________________________________________________________________

                //-------------------- Books of Lev Tolstoy -------------------------
                var WarAndPeace = new Book("War and peace", "978-5-92-682585-2", LevTolstoy);
                var AnnaKarenina = new Book("Anna Karenina", "978-5-44-448700-6", new DateTime(year: 1668, day: 25, month: 7), LevTolstoy);
                var CaucasianCaptive = new Book("Caucasian Captive", "978-5-86-547787-7", LevTolstoy);
                //___________________________________________________________________

                //----------------- Books of Alexander Pushkin ----------------------
                var CaptainsDaughter = new Book("Captain's daughter", "978-5-43-350127-0", AlexanderPushkin);
                var EugeneOnegin = new Book("Eugene Onegin", "978-5-17-023219-5", AlexanderPushkin);
                var Dubrovsky = new Book("Dubrovsky", "978-5-91-045996-4", AlexanderPushkin);
                //___________________________________________________________________

                //------------------- Books of Anton Chekhov ------------------------
                var ChamberNo_6 = new Book("Chamber No. 6", "978-5-38-914427-9", AntonChekhov);
                var CherryOrchard = new Book("Cherry Orchard", "978-5-04-096435-2", AntonChekhov);
                var DramaOnTheHunt = new Book("Drama on the hunt", "978-5-17-106059-6", AntonChekhov);
                //___________________________________________________________________

                //===================================================================
                var books = new Catalog
                {
                    CrimeAndPunishment,
                    Idiot,
                    Devils,
                    WarAndPeace,
                    AnnaKarenina,
                    CaucasianCaptive,
                    CaptainsDaughter,
                    EugeneOnegin,
                    Dubrovsky,
                    ChamberNo_6,
                    CherryOrchard,
                    DramaOnTheHunt
                };
                Console.WriteLine();
                foreach (var b in books)
                {
                    Console.WriteLine(b);
                }

                Console.WriteLine(new string('-', 50));
                Console.WriteLine(new string('-', 50));
                Console.WriteLine(new string('!', 50));

                foreach (var book in books.GetBooksByAuthor("Alexander", "Pushkin"))
                {
                    Console.WriteLine(book);
                }
                Console.WriteLine(new string('!', 50));
                Console.WriteLine(new string('!', 50));

                Console.WriteLine(new string('=', 50));

                foreach (var book in books.GetBooksByAuthor(LevTolstoy.FirstName, LevTolstoy.LastName))
                {
                    Console.WriteLine(book);
                }

                Console.WriteLine(new string('-', 50));
                Console.WriteLine(new string('-', 50));

                foreach (var o in books.GetSortedBooksByDate())
                {
                    Console.WriteLine(o);
                }

                Console.WriteLine(new string('-', 50));
                Console.WriteLine(new string('-', 50));
                foreach (var authorAndCountBook in books.GetAuthorAndCountBooks())
                {
                    Console.WriteLine($"{authorAndCountBook.Item1,-20} - {authorAndCountBook.Item2,-3}");
                }

                // ===================================================================
                Console.WriteLine();
                Console.WriteLine();

                Author Vitya = new Author("Vitya", "Ermolin");
                Author vitya = new Author("vitya", "ermolin");
                Author VITYA = new Author("VITYA", "ERMOLIN");

                Console.WriteLine($"Vitya: {Vitya.GetHashCode()}");
                Console.WriteLine($"vitya: {vitya.GetHashCode()}");
                Console.WriteLine($"VITYA: {VITYA.GetHashCode()}");

                Console.WriteLine(Vitya.Equals(VITYA));

                Console.WriteLine(new string('-', 50));
                Console.WriteLine(new string('-', 50));

                Author Ermolin = new Author("Viktor", "Ermolin");
                Console.WriteLine(Ermolin);

                Book newBook = new Book("newBook", "978-5-38-914427-9", Ermolin);
                Console.WriteLine(newBook);


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}