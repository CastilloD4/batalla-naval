using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batalla_Naval
{
    internal class Program
    {
        public const string seaCharacter = "~ ";
        public const string boatCell = "Y ";
        public const string wrongLocation = "X ";
        public const string correctLocation = "0 ";

        static void Main(string[] args)
        {
            Console.WriteLine("por favor ingrese coordenadas v=1 h=0");
            int primera = Int32.Parse(Console.ReadLine());

            while (primera != 0 && primera != 1) {
                Console.WriteLine("error");
                primera = Int32.Parse(Console.ReadLine());
            }

            Console.WriteLine("ingrese longitud de buque");
            int longi = Int32.Parse(Console.ReadLine());

            while (longi < 0 || longi > 9)
            {
                Console.WriteLine("error");
                longi = Int32.Parse(Console.ReadLine());
            }
            Console.WriteLine("ingrse coordenadas -> x,y");
            string inicio1 = Console.ReadLine();
            string[] coordenada1 = inicio1.Split(',');

            int core1;
            int core2;

            while (coordenada1.Length == 1 || int.TryParse (coordenada1[0],out core1)== false || int.TryParse(coordenada1[1], out core2) == false)
            {

                Console.WriteLine("coordenadas incorrectas...");
                inicio1 = Console.ReadLine();
                coordenada1 = inicio1.Split(',');
            }


            Console.WriteLine(coordenada1[0]);
            Console.WriteLine(coordenada1[1]);


            string[,] tabla1 = new string[10, 10];

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    tabla1[i, j] = seaCharacter;
                    Console.Write(tabla1[i, j] + " ");

                }
                Console.WriteLine();

            }

            string[] coor2p = new string[longi];
            if (primera == 0 )
            {

                for (int i = 0; i < longi; i++)
                {
                    coor2p[i] = coordenada1[0] + "," + core2;
                    core2++;

                }
            }
            else {
                for (int i = 0; i < longi; i++)
                {
                    coor2p[i] = core1 + "," + coordenada1[1];
                    core1++;

                }
            }

            Console.ForegroundColor = ConsoleColor.Red;

            int acertaste = 0;
            int fallaste = 0;

            string validador = "";

            do
            {

                Console.WriteLine("unde mi buque");
                string intentosj = Console.ReadLine();
                string[] intentosj2 = intentosj.Split(',');

                int core3;
                int core4;

                while (intentosj.Length == 1 || int.TryParse(intentosj2[0], out core3) == false || int.TryParse(intentosj2[1], out core4) == false || intentosj == validador)
                {

                    Console.WriteLine("coordenadas incorrectas...");
                    intentosj = Console.ReadLine();
                    intentosj2 = intentosj.Split(',');
                }

                if (coor2p.Contains(intentosj)) {

                    validador = intentosj;
                    acertaste++;

                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {

                            if (tabla1[i, j]== correctLocation || tabla1[i, j] == wrongLocation) { tabla1[i, j] = tabla1[i, j];
                            }
                            else if(i == core3 && j== core4) {
                                tabla1[i, j] = correctLocation;

                            }
                            else { tabla1[i, j] = seaCharacter; }
                           
                            Console.Write(tabla1[i, j] + " ");

                        }
                        Console.WriteLine();

                    }

                }
                else
                {
                    validador = intentosj;
                    fallaste++;

                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {

                            if (tabla1[i, j] == correctLocation || tabla1[i, j] == wrongLocation)
                            {
                                tabla1[i, j] = tabla1[i, j];
                            }
                            else if (i == core3 && j == core4)
                            {
                                tabla1[i, j] = wrongLocation;

                            }
                            else { tabla1[i, j] = seaCharacter; }

                            Console.Write(tabla1[i, j] + " ");

                        }
                        Console.WriteLine();

                    }

                }

                Console.WriteLine(" le diste: " + acertaste);
                Console.WriteLine(" intenta de nuevo: " + fallaste);

                if (acertaste == longi)
                {

                

                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {

                            if (tabla1[i, j] == correctLocation)
                            {
                                tabla1[i, j]= boatCell;
                            }
                            else if (tabla1[i, j] == wrongLocation)
                            {
                                tabla1[i, j] = wrongLocation;

                            }
                            else { tabla1[i, j] = seaCharacter; }

                            Console.Write(tabla1[i, j] + " ");

                        }
                        Console.WriteLine();

                    }
                    Console.WriteLine("LO HUNDISTE");

                }
            }
            while (acertaste != longi);


        }
    }
}
