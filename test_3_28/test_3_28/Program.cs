namespace test_3_28
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //设置背景色
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Clear();
            //隐藏光标
            Console.CursorVisible = false;
            //设置初始位置
            int a = 0, b = 0;
            //设置光标坐标
            CheckPosition(a, b, ConsoleColor.Yellow, "★");
            //循环检测方向
            while (true)
            {
                //大小统一
                char p = Console.ReadKey(true).KeyChar;
                p = Convert.ToChar(p.ToString().ToLower());
                switch (p)
                {
                    case 'w':
                        CheckPosition(a, b, ConsoleColor.Yellow, "  ");
                        --b;
                        Position(ref b);
                        //Console.Clear();
                        CheckPosition(a, b, ConsoleColor.Yellow, "★");
                        break;
                    case 'a':
                        CheckPosition(a, b, ConsoleColor.Yellow, "  ");
                        a -= 2;
                        Position(ref a);
                        //Console.Clear();
                        CheckPosition(a, b, ConsoleColor.Yellow, "★");
                        break;
                    case 's':
                        CheckPosition(a, b, ConsoleColor.Yellow, "  ");
                        ++b;
                        Position(ref b);
                        //Console.Clear();
                        CheckPosition(a, b, ConsoleColor.Yellow, "★");
                        break;
                    case 'd':
                        CheckPosition(a, b, ConsoleColor.Yellow, "  ");
                        a += 2;
                        Position(ref a);
                        //Console.Clear();
                        CheckPosition(a, b, ConsoleColor.Yellow, "★");
                        break;
                    default: break;
                }
            }
        }
        static void CheckPosition(int x, int y, ConsoleColor color, string c)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.WriteLine(c);
        }
        static void Position(ref int x)
        {
            if (x < 0) x = 0;
            if (x > Console.BufferWidth - 2) x = Console.BufferWidth - 2;
        }
    }
}
