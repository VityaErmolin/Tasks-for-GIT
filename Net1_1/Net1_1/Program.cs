using System;
using Net1_1.Enums;
using Net1_1.Materials;

namespace Net1_1
{
    internal class Program
    {
        private static void Main()
        {
           var r1 = new Reference("link1", ReferenceType.Audio);
            Console.WriteLine(r1);
            

            var t1 = new Traninig();
            t1.Add(new TextMaterial("Text for text", "Description fot Text"));
            t1.Add(new Reference("link for content", ReferenceType.Html, "Description for Reference"));
            t1.Add(new Video("link for video", "link for picture", VideoType.Mp4, "Description for Video"));

            for (var i = 0; i < t1._trainingMaterial.Length; i++)
            {
                Console.WriteLine(t1._trainingMaterial[i].GetType());
                Console.WriteLine(t1._trainingMaterial[i].Id);
            }

            var t2 = new Traninig();
            Console.WriteLine(new string('_', 50));
            t2 = (Traninig)t1.Clone();
            for (var i = 0; i < t2._trainingMaterial.Length; i++)
            {
                Console.WriteLine(t2._trainingMaterial[i].GetType());
                Console.WriteLine(t2._trainingMaterial[i].Id);
            }

            Console.WriteLine(new string('_', 50));
            Console.WriteLine(new string('_', 50));

            t2._trainingMaterial[1] = new TextMaterial("fkleswjdkjhnw");
            t2._trainingMaterial[0] = new TextMaterial("fkleswjdkjhnw");

            Console.WriteLine(new string('_', 50));

            for (var i = 0; i < t2._trainingMaterial.Length; i++)
            {
                Console.WriteLine(t2._trainingMaterial[i].GetType());
                Console.WriteLine(t2._trainingMaterial[i].Id);
            }

            Console.WriteLine(new string('_', 50));

            for (var i = 0; i < t1._trainingMaterial.Length; i++)
            {
                Console.WriteLine(t1._trainingMaterial[i].GetType());
                Console.WriteLine(t1._trainingMaterial[i].Id);
            }

            Console.ReadLine();
        }
    }
}