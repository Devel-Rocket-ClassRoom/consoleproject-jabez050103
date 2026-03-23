using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DungeonGame.Player;

namespace DungeonGame
{
    public class Character
    {
        public int pr;
        public int pc;
        public int R;
        public int C;
        public int cou;
    }
    public class Player : Character
    {
        public void MovePlayer(Map map)
        {
            pr = map.FindPlayer().Item1;
            pc = map.FindPlayer().Item2;
            while (true)
            {
                R = pr;
                C = pc;

                string cmd = Console.ReadLine();
                if (cmd == "L")
                {
                    C = C - 1;
                }
                if (cmd == "R")
                {
                    C = C + 1;
                }
                if (cmd == "U")
                {
                    R = R - 1;
                }
                if (cmd == "D")
                {
                    R = R + 1;
                }
                if (map.map[R, C] == '#')

                {
                    Console.WriteLine("이동이 불가능합니다");
                }
                else
                {
                    map.map[pr, pc] = ' ';
                    pr = R;
                    pc = C;
                    map.map[pr, pc] = 'P';
                }
                map.PrintMap();
            }
        }
        public class Monster : Character
        {
            public void CatchMonster(Map map)
            {
                cou = map.FindMonster();

                if (map.map[R, C] == 'M')
                {
                    cou--;
                    Console.WriteLine("몬스터를 잡았습니다!");
                    map.map[pr, pc] = ' ';
                    pr = R;
                    pc = C;
                    map.map[pr, pc] = 'P';
                }
                if (cou <= 0)
                {
                    Console.WriteLine("게임종료");
                    return;
                }

            }
        }
        public class Map
        {
            public char[,] map =     { { '#', '#', '#', '#', '#', '#', '#', '#', '#','#','#','#','#','#','#' },
                                { '#', 'P', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ',' ',' ',' ',' ','#' },
                                { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ',' ',' ',' ',' ','#' },
                                { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ',' ',' ',' ',' ','#' },
                                { '#', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ',' ',' ',' ',' ',' ','#' },
                                { '#', ' ', ' ', '#', 'M', ' ', ' ', ' ', ' ',' ',' ',' ',' ',' ','#' },
                                { '#', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ',' ',' ',' ',' ',' ','#' },
                                { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ',' ',' ',' ',' ','#' },
                                { '#', ' ', ' ', 'M', ' ', ' ', ' ', ' ', ' ',' ',' ',' ',' ','M','#' },
                                { '#', '#', '#', '#', '#', '#', '#', '#', '#','#','#','#','#','#','#' } };
            public void PrintMap()
            {
                int row = map.GetLength(0);
                int col = map.GetLength(1);

                for (int r = 0; r < row; r++)
                {
                    for (int c = 0; c < col; c++)
                    {
                        Console.Write(map[r, c]);
                    }
                    Console.WriteLine();
                }

            }
            public int FindMonster()
            {
                int row = map.GetLength(0);
                int col = map.GetLength(1);
                int cou = 0;
                for (int r = 0; r < row; r++)
                {
                    for (int c = 0; c < col; c++)
                        if (map[r, c] == 'M')
                        {
                            cou++;
                        }
                }
                return cou;
            }
            public (int, int) FindPlayer()
            {
                int row = map.GetLength(0);
                int col = map.GetLength(1);
                for (int r = 0; r < row; r++)
                {
                    for (int c = 0; c < col; c++)
                    {
                        if (map[r, c] == 'P')
                        {
                            return (r, c);
                        }
                    }
                }

                return (-1, -1);
            }

        }

        public class DungeonGame
        {

        }


    }

    internal class Program
    {

        static void Main(string[] args)
        {

            Map map = new Map();
            map.PrintMap();
            Player P = new Player();
            P.MovePlayer(map);
            Monster M = new Monster();
            M.CatchMonster(map);

        }

    }
}
