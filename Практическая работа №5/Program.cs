using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая_работа__5
{
    class Program
    {
        static int Main(string[] args)
        {
            Console.WriteLine("Введите размерность матрицы n:");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите погрешность е:");
            double e = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Заполнение марицы:");

            double[][] a = new double[n][];
            for(int i=0; i<n; i++)
            {
                a[i] = new double[n + 1];
                for (int j=0; j < n + 1; j++)
                {
                    a[i][j] = Convert.ToDouble(Console.ReadLine());
                }
            }

            double d = 0;

            for(int i=0; i<n; i++)
            {
                for(int j=0; j<n; j++)
                {
                    if (j != i)
                    {
                        a[i][j] = -(a[i][j] / a[i][i]);
                        d = d + Math.Pow(a[i][j], 2);
                    }
                }
                a[i][n] = a[i][n] / a[i][i];
                a[i][i] = 0;
            }

            double[] y = new double[n + 1];
            double[] x = new double[n];
            if (Math.Sqrt(d) < 1)
            {
                d = 2 * e;
                while (d > e)
                {
                    d = 0;
                    for (int i=0; i<n; i++)
                    {
                        y[i] = a[i][n];
                        for(int j=0; j<n; j++)
                        {
                            y[i] = a[i][j] * x[j] + y[i];
                        }
                        d = d + Math.Pow(y[i] - x[i], 2);

                    }
                    d = Math.Sqrt(d);
                }

                for(int i = 0; i<n; i++)
                {
                    Console.WriteLine("x" + i + 1 + "=" + x[i]);
                }
            }
            else
            {
                Console.WriteLine("Условие сходимости не выполняется");
                Console.ReadKey();
                return 0;
            }
            Console.ReadKey();
            return 0;
        }
    }
}
