using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class TicTacToe
    {
        char[,] board = {   { '1', '2', '3' },
                            { '4', '5', '6' },
                            { '7', '8', '9' }
                        };

        char player1 = 'X';
        char player2 = 'O';
        char currentPlayer;

        
        public void PlayGame()
        {
            int moves = 0;
            bool winFlag = false;

            currentPlayer = player1;

            while (!winFlag && moves < 9)
            {
                PrintBoard();
                Console.WriteLine($"플레이어 {currentPlayer}, 1~9를 입력하세요: ");

                string input = Console.ReadLine();

                int choice = Int32.Parse(input);

                if ( choice >= 1 && choice <= 9)
                {
                    if (SetMarker(choice))
                    {
                        winFlag = CheckWin();

                        if (!winFlag)
                        {
                            if(currentPlayer == player1)
                            {
                                currentPlayer = player2;
                            }
                            else
                            {
                                currentPlayer = player1;
                            }
                        }

                        moves++;
                    }
                    else
                    {
                        Console.WriteLine("이미 선택된 칸입니다. 다른 값을 입력하세요.");
                    }
                }
                else
                {
                    Console.WriteLine("잘못된 값입니다. 1~9 사이 숫자를 입력하세요.");
                }
            }

            Console.Clear();
            PrintBoard();

            if (winFlag)
                Console.WriteLine($"!!!!!! 플레이어 {currentPlayer} 승리 !!!!!!");
            else
                Console.WriteLine("무승부입니다!");
        }

        void PrintBoard()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("틱택토 게임");
            Console.WriteLine("-----------");

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($" {board[i, 0]} | {board[i, 1]} | {board[i, 2]} ");
                if (i < 2)
                {
                    Console.WriteLine("---|---|---");
                }
            }

            Console.WriteLine("-----------");
        }

        bool SetMarker(int choice)
        {
            int row = (choice - 1) / 3;
            int col = (choice - 1) % 3;

            if (board[row, col] != player1 && board[row, col] != player2)
            {
                board[row, col] = currentPlayer;
                return true;
            }
            return false;
        }

        bool CheckWin()
        {
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == currentPlayer && board[i, 1] == currentPlayer && board[i, 2] == currentPlayer)
                {
                    return true;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                if (board[0, i] == currentPlayer && board[1, i] == currentPlayer && board[2, i] == currentPlayer)
                {
                    return true;
                }
            }

            if (board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer)
            {
                return true;
            }

            if (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer)
            {
                return true;
            }

            return false;
        }

        protected TicTacToe(int r, int c)
        {

        }

        public TicTacToe()
        {

        }
    }


    internal class Program
    {
        static void Main()
        {
            TicTacToe game = new TicTacToe();
            game.PlayGame();
        }
    }
}