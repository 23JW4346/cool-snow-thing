using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace Christmas_Task_Snow
{
    internal class Program
    {
        static Random rnd = new Random();
        struct point
        {
            public int x, y;
        }
        struct snowflake
        {
            public point p;
            public char shape;
            public int velocity;
        }
        struct treetrunk
        {
            public point p;
            public ConsoleColor colour;
            public char[,] image;
        }
        struct treeleaves
        {
            public point p;
            public ConsoleColor colour;
            public char[,] image;
        }
        static void addsnow(snowflake snow)
        {
            Console.SetCursorPosition(snow.p.x, snow.p.y);
            Console.Write(snow.shape);
        }
        static snowflake populatessnow()
        {
            snowflake snow;
            point dot;
            char[] snowcharacters = { '*', '#', 'x', 'o' };
            snow.shape = snowcharacters[rnd.Next(0, snowcharacters.Length)];
            dot.y = 0;
            dot.x = rnd.Next(0, Console.WindowWidth);
            snow.p = dot;
            snow.velocity = rnd.Next(1, 3);
            return snow;
        }
        static char[,] getimage()
        {
            string[] tree = File.ReadAllLines("Tree.txt");
            char[,] tree2 = new char[tree[0].Length, tree.Length];
            for (int i = 0; i < tree.Length; i++)
            {
                for (int j = 0; j < tree[i].Length; j++)
                {
                    tree2[i, j] = tree[i][j];
                }
            }
            return tree2;
        }
        static snowflake snowmove(snowflake snow)
        {
            Console.SetCursorPosition(snow.p.x, snow.p.y);
            Console.Write(' ');
            snow.p.y += snow.velocity;
            if (snow.p.y >= Console.WindowHeight) throw new Exception();
            Console.SetCursorPosition(snow.p.x, snow.p.y);
            Console.Write(snow.shape);
            return snow;

        }
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.WriteLine("Choose windowidth, then press any key to continue");
            Console.ReadKey();
            Console.Clear();
            List<snowflake> snows = new List<snowflake>();
            for (int i = 0; i < i + 1; i++)
            {
                snowflake snow = populatessnow();
                addsnow(snow);
                snows.Add(snow);
                for(int index = 0; index < snows.Count + 1; index++)
                {
                    try
                    {
                        snowflake newsnow = snowmove(snows[0]);
                        snows.Remove(snows[0]);
                        snows.Add(newsnow);
                    } catch (Exception e)
                    {
                        snows.Remove(snows[0]);
                    }
                }
                System.Threading.Thread.Sleep(50);
            }
        }
    }
}





