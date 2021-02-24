using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Determinarea_ecuatiei_unei_drepte_dupa_2_puncte
{
    class Program
    {
        struct Point
        {
            public int x, y;
        }

        struct Dreapta
        {
            public double a, b, c;
        }

        static string EcuationAB(Point A, Point B)
        {
            return $"{A.y - B.y}x " +
                   $"{(A.x - B.x > 0 ? "-" : "+")} {Math.Abs(A.x - B.x)}y " +
                   $"{(A.x * B.y - B.x * A.y < 0 ? "-" : "+")} {Math.Abs(A.x * B.y - B.x * A.y)} = 0";
        }

        static Point InputPoint(string name)
        {
            Console.Write($"Introduceti {name}: ");
            string[] line = Console.ReadLine().Split(' ');

            return new Point
            {
                x = int.Parse(line[0]),
                y = int.Parse(line[1])
            };
        }

        static double LengthAB(Point A, Point B)
        {
            return Math.Sqrt((B.x - A.x) * (B.x - A.x) + (B.y - A.y) * (B.y - A.y));
        }

        static bool ColiniaritateABC(Point A, Point B, Point C)
        {
            return (A.x * B.y + A.y * C.x + B.x * C.y - B.y * C.x - A.y * B.x - A.x * C.y) == 0;
        }

        static Dreapta DreaptaInput(string nume)
        {
            Console.Write($"Dreapta {nume}: ");
            string[] line = Console.ReadLine().Split(' ');

            return new Dreapta
            {
                a = Double.Parse(line[0]),
                b = Double.Parse(line[1]),
                c = Double.Parse(line[2])
            };
        }

        static string FormulaDreapta(Dreapta D)
        {
            return
                $"{D.a}{(D.a == 0 ? "" : "x")} " +
                $"{(D.b == 0 ? "" : (D.b > 0 ? "+" : "-"))}{(D.b == 0 ? "" : " " + Math.Abs(D.b).ToString())}{(D.b == 0 ? "" : "y ")}" +
                $"{(D.c == 0 ? "" : (D.c > 0 ? "+" : "-"))} {Math.Abs(D.c)} = 0";
        }

        static bool Concurenta3drepte(Dreapta D1, Dreapta D2, Dreapta D3)
        {
            // 3 -17,5 5
            // 1 -4 1
            // 2 3 -2

            // 2 -1 5
            // -1 3 -2
            // 5 0 3
            return (D1.a * D2.b * D3.c + D1.b * D2.c * D3.a + D1.c * D2.a * D3.b
                    - D1.c * D2.b * D3.a - D1.b * D2.a * D3.c - D1.a * D2.c * D3.b) == 0;
        }

        static void Cerinta1()
        {
            Point A = InputPoint("A");
            Point B = InputPoint("B");

            Console.WriteLine();
            Console.WriteLine($"Ecuatia: {EcuationAB(A, B)}");
            Console.WriteLine($"Distanta: {LengthAB(A, B)}");
            Console.WriteLine();
        }

        static void Cerinta2()
        {
            Point A = InputPoint("A");
            Point B = InputPoint("B");
            Point C = InputPoint("C");

            Console.WriteLine();
            Console.WriteLine($"Punctele A,B,C sunt coliniare? {(ColiniaritateABC(A, B, C) ? "Da" : "Nu")}");
        }

        static void Cerinta3()
        {
            Dreapta D1 = DreaptaInput("D1");
            Dreapta D2 = DreaptaInput("D2");
            Dreapta D3 = DreaptaInput("D3");
            Console.WriteLine();

            Console.WriteLine($"(D1) : {FormulaDreapta(D1)}");
            Console.WriteLine($"(D2) : {FormulaDreapta(D2)}");
            Console.WriteLine($"(D3) : {FormulaDreapta(D3)}");

            Console.WriteLine();
            Console.WriteLine($"Cele 3 drepte sunt concurente? {(Concurenta3drepte(D1, D2, D3) ? "Da" : "Nu")}");
        }

        static void Main(string[] args) // Kovacs Andrei-Alex
        {
            //Cerinta1();
            //Cerinta2();
            Cerinta3();
        }
    }
}