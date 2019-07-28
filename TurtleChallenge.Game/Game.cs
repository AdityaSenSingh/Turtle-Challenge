using System;
using System.Collections.Generic;
using System.Text;
using TurtleChallenge.Abstractions;
using TurtleChallenge.Player;

namespace TurtleChallenge.Game
{
    public class Game : IGame
    {
        public Cell[,] Board { get; set; }

        public int Rows { get; set; }

        public int Columns { get; set; }

        public IPlayer Turtle { get; set; }

        public void InitializePlayer(IPlayer player, StartingPoint initialPos)
        {
            Console.WriteLine($"Turtle Initial Position - X:{initialPos.X}, Y:{initialPos.Y}, Direction:{initialPos.Direction}");
            this.Turtle = player.Initialize(initialPos);
        }

        public void DrawBoard(GameConfig config)
        {
            this.Rows = config.BoardSize.Rows;
            this.Columns = config.BoardSize.Columns;
            var board = new Cell[this.Rows, this.Columns];

            for (int x = 0; x < config.BoardSize.Rows; x++)
            {
                for (int y = 0; y < config.BoardSize.Columns; y++)
                {
                    board[x, y] = new Cell();
                }
            }

            Console.Write("mine positions : ");
            foreach (var mine in config.Mines)
            {
                board[mine.X, mine.Y].IsMine = true;
                Console.Write($"X: {mine.X}, Y: {mine.Y} | ");
            }
            Console.WriteLine();

            board[config.ExitPoint.X, config.ExitPoint.Y].IsExitPoint = true;
            Console.WriteLine($"exit point - X: {config.ExitPoint.X}, Y: {config.ExitPoint.Y}");
            Console.WriteLine();

            this.Board = board;
        }

        public GameResult Play(List<Abstractions.GameActions> moves)
        {
            foreach (var move in moves)
            {
                this.Turtle.Play(move);

                if (Turtle.Position.X < 0 || Turtle.Position.Y < 0 || 
                    Turtle.Position.X > this.Rows-1 || Turtle.Position.Y > this.Columns-1)
                {
                    return GameResult.CannotMove;
                }

                Console.WriteLine($"After {move} :: Turtle Current Pos - X:{Turtle.Position.X }, Y:{Turtle.Position.Y}, Direction : {Turtle.Direction}");

                if (Board[Turtle.Position.X, Turtle.Position.Y].IsExitPoint)
                {
                    return GameResult.Sucess;
                }

                if (Board[Turtle.Position.X, Turtle.Position.Y].IsMine)
                {
                    return GameResult.MineHit;
                }
            }

            return GameResult.StillInDanger;
        }

    }
}
