using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Curs_Seminar_2
{
    static class Program
    {   /// <summary>
        /// Problema 1: Se dau 2 vectori care se introduc de la tastatura [x, y, z], sa se scrie programul de determinare:
        /// - al produsului scalar al vectorilor
        /// - sa se verifice daca vectorii sunt perpendiculari
        /// - Sa se calculeze marimea celor 2 vectori
        /// - Aria paralelogramului construit  pe cei doi vectori ca laturi
        /// </summary>

        static double[] ReadVector(string name)
        {
            Console.Write($"{name} = ");
            return Array.ConvertAll(Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries), double.Parse);
        }

        static string Stringify(this double[] v) => $"{(v[0] == 0 ? "" : (v[0] == 1 ? "" : v[0].ToString()) + "i")}" +
                                                    $"{(v[1] == 0 ? "" : ((v[1] > 0 ? " + " : " - ") + (v[1] == 1 ? "" : Math.Abs(v[1]).ToString())) + "j")}" +
                                                    $"{(v[2] == 0 ? "" : ((v[2] > 0 ? " + " : " - ") + (v[2] == 1 ? "" : Math.Abs(v[2]).ToString())) + "k")}";

        static double Marime(double[] v) => Math.Sqrt(v[0] * v[0] + v[1] * v[1] + v[2] * v[2]);

        static double Scalar(double[] v1, double[] v2) => Marime(v1) * Marime(v2);

        static double[] ProdusVectorial(double[] v1, double[] v2) => new double[] { v1[1] * v2[2] - v1[2] * v2[1], -v1[0] * v2[2] + v1[2] * v2[0], v1[0] * v2[1] - v1[1] * v2[0] };

        static double ProdusScalar(double[] v1, double[] v2) => v1[0] * v2[0] + v1[1] * v2[1] + v1[2] * v2[2];

        static bool Coliniar(double[] v3) => v3[0] == 0 && v3[1] == 0 && v3[2] == 0;

        static double ProdusMixt(double[] v1, double[] v2, double[] v3) => v1[0] * v2[1] * v3[2] + v2[0] * v3[1] * v1[2] + v3[0] * v1[1] * v2[2]
                                                                         - v3[0] * v2[1] * v1[2] - v2[0] * v1[1] * v3[2] - v1[0] * v3[1] * v2[2];

        static void Problema1()
        {
            double[] v1 = ReadVector("v1");
            double[] v2 = ReadVector("v2");

            Console.WriteLine();
            Console.WriteLine($"v1 = {v1.Stringify()}");
            Console.WriteLine($"v2 = {v2.Stringify()}");

            double scalar = Scalar(v1, v2);

            Console.WriteLine();
            Console.WriteLine($"Produs scalar:{ProdusScalar(v1, v2)}");
            Console.WriteLine($"Vectorii sunt perpendiculari? {(scalar == 0 ? "Da" : "Nu")}");
            Console.WriteLine($"Marimea v1 este: {Marime(v1)}");
            Console.WriteLine($"Marimea v2 este: {Marime(v2)}");

            Console.WriteLine();
            double[] v3 = ProdusVectorial(v1, v2);
            Console.WriteLine($"Produsul vectorial (v1, v2) este: {v3.Stringify()}");
            Console.WriteLine($"Vectorii sunt coliniari? {(Coliniar(v3) ? "Da" : "Nu")}");
            Console.WriteLine($"Aria paralelogramului (v1, v2) este: {Marime(v3)}");

            Console.WriteLine();
            v3 = ReadVector("v3");
            Console.WriteLine($"Produsul mixt este: {ProdusMixt(v1, v2, v3)}");
            Console.WriteLine($"Vectorii sunt coplanari? {(ProdusMixt(v1, v2, v3) == 0 ? "Da" : "Nu")}");
            Console.WriteLine($"Volumul paralelipipedului (v1, v2, v3) este: {Math.Abs(ProdusMixt(v1, v2, v3))}");


            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Problema1();
        }
    }
}
