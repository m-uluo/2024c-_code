using System;

namespace 解一元三次方程
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("解ax^3+bx^2+cx+d=0方程");
                Console.WriteLine("请输入a值：");
                double a = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("请输入b值：");
                double b = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("请输入c值：");
                double c = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("请输入d值：");
                double d = Convert.ToDouble(Console.ReadLine());

                dd2.solveEquations(a, b, c, d, out double? x1, out double? x2, out double? x3);
                Console.WriteLine($"x1={x1}");
                Console.WriteLine($"x2={x2}");
                Console.WriteLine($"x3={x3}");

            }
        }
        class dd2
        {
            private static readonly double dsr3 = Math.Sqrt(3);
            // <summary>
            /// 盛金公式求解一元三次方程,ax^3+bx^2+cx+d=0。
            /// </summary>
            /// <param name="a">三次系数</param>
            /// <param name="b">二次系数</param>
            /// <param name="c">一次系数</param>
            /// <param name="d">常系数</param>
            /// <param name="x1">结果1,为null则没有实根</param>
            /// <param name="x2">结果2</param>
            /// <param name="x3">结果3</param>
            public static void solveEquations(double a, double b, double c, double d, out double? x1, out double? x2, out double? x3, double dTol = 1e-9)
            {
                x1 = null;
                x2 = null;
                x3 = null;

                double A = b * b - 3 * a * c;
                double B = b * c - 9 * a * d;
                double C = c * c - 3 * b * d;
                double delta = B * B - 4 * A * C;

                if (IsZero(A, dTol) && IsZero(B, dTol))
                {
                    //盛金公式1
                    //方程有一个三重实根
                    if (!IsZero(a, dTol))
                    {
                        double r1 = -b / (3 * a);
                        x1 = x2 = x3 = r1;
                    }
                    else if (!IsZero(b, dTol))
                    {
                        double r2 = -c / b;
                        x1 = x2 = x3 = r2;
                    }
                    else if (!IsZero(c, dTol))
                    {
                        double r3 = -3 * d / c;
                        x1 = x2 = x3 = r3;
                    }
                    else
                    {
                        //无解
                    }
                }
                else if (IsZero(delta, dTol))
                {
                    //盛金公式3
                    //方程有三个实根，其中有一个二重根。
                    //A != 0
                    double K = B / A;
                    x1 = -b / a + K;
                    x2 = x3 = -K / 2;
                }
                else if (delta > 0)
                {
                    //盛金公式2
                    //方程有一个实根和一对共轭复根
                    double dsrdelta = Math.Sqrt(delta);
                    double yp = -B + dsrdelta;
                    double yn = -B - dsrdelta;
                    double y1 = A * b + 3 * a / 2 * yp;
                    double y2 = A * b + 3 * a / 2 * yn;
                    const double dZhiShu = 1d / 3;
                    double y1cr = Math.Pow(y1, dZhiShu);
                    double y2cr = Math.Pow(y2, dZhiShu);
                    double dAm3 = 3 * a;
                    x1 = -b - (y1cr + y2cr);
                    x1 /= dAm3;
                }
                else
                {
                    //盛金公式4：
                    //方程有三个不相等的实根。
                    //（A>0,－1<T<1）
                    double T = (2 * A * b - 3 * a * B) / (2 * Math.Sqrt(Math.Pow(A, 3)));
                    double theta = Math.Acos(T);
                    double thetaOf1d3 = theta / 3;
                    double cosThetaOf1d3 = Math.Cos(thetaOf1d3), sinTheta_1d3 = Math.Sin(thetaOf1d3);
                    double dx2part = cosThetaOf1d3 + dsr3 * sinTheta_1d3;
                    double dx3part = cosThetaOf1d3 - dsr3 * sinTheta_1d3;
                    double dsrA = Math.Sqrt(A);
                    double dAm3 = 3 * a;
                    x1 = -b - 2 * dsrA * cosThetaOf1d3;
                    x2 = -b + dsrA * dx2part;
                    x3 = -b + dsrA * dx3part;
                    x1 /= dAm3;
                    x2 /= dAm3;
                    x3 /= dAm3;
                }
            }
            /// <summary>
            /// num是否为0.(由于double本身的精度问题)
            /// </summary>
            /// <param name="num"></param>
            /// <param name="dTol"></param>
            /// <returns></returns>
            public static bool IsZero(double num, double dTol)
            {
                return Math.Abs(num) <= dTol;
            }
        }
    }
}
