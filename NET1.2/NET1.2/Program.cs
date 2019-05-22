using System;
namespace NET1._2
{
    class Program
    {
        static void Main()
        {
            try
            {
                SquareMatrix<int> sm = new SquareMatrix<int>(3);
                Console.WriteLine(sm);
                sm.Changed += delegate(object sender, MatrixEventArgs<int> args)
                {
                    Console.WriteLine($"Element[{args.I},{args.J}](old)=\"{args.Old}\"  =>  Element[{args.I},{args.J}](new) =\"{args.New}\"");
                };
                
                for (int i = 0; i < sm.Size; i++)
                {
                    for (int j = 0; j < sm.Size; j++)
                    {
                        sm[i, j] = (i * 2 + 1) * (j * 2 + 1);
                    }
                }
               
                Console.WriteLine(new string('-', 50));


                SquareMatrix<string> smStr = new SquareMatrix<string>(3);
                smStr.Changed+=(sender, args) => Console.WriteLine($"Element[{args.I},{args.J}](old)=\"{args.Old}\"  =>  Element[{args.I},{args.J}](new) =\"{args.New}\""); ;
                Console.WriteLine(sm);
                
                Console.WriteLine(smStr);
                for (int i = 0; i < smStr.Size; i++)
                {
                    for (int j = 0; j < smStr.Size; j++)
                    {
                        smStr[i, j] = "-";
                    }
                }
                Console.WriteLine(smStr);
                Console.WriteLine(new string('-', 50));
                DiagonalMatrix<int> dm = new DiagonalMatrix<int>(5);
                
                dm.Changed += ForEvent;

                Console.WriteLine(dm);
                for (int i = 0; i < dm.Size; i++)
                {
                    dm[i, i] = i + 6;
                }
                Console.WriteLine(dm);
                Console.WriteLine(new string('-', 50));
                //DiagonalMatrix<string> dm_str = new DiagonalMatrix<string>(5);
                //Console.WriteLine(dm_str);
                //for (int i = 0; i < dm_str.Size; i++)
                //{
                //    dm_str[i, i] = "a";
                //}
                //Console.WriteLine(dm_str);
                //Console.WriteLine(new string('-', 50));
                //DiagonalMatrix<bool> dm_bl = new DiagonalMatrix<bool>(5);
                //Console.WriteLine(dm_bl);
                //for (int i = 0; i < dm_bl.Size; i++)
                //{
                //    dm_bl[i, i] = true;
                //}
                //Console.WriteLine(dm_bl);

                //dm_bl[-1, -1] = false;
                //Console.WriteLine(dm_bl);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }

            Console.ReadLine();
        }
        
       public static void ForEvent(object sender, MatrixEventArgs<int> args)
       {
           Console.WriteLine($"Element[{args.I},{args.J}](old)=\"{args.Old}\"  =>  Element[{args.I},{args.J}](new) =\"{args.New}\"");
       }
    }
}
