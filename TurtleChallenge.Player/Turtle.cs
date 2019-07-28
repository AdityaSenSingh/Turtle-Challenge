using System;
using System.Collections.Generic;
using System.Text;
using TurtleChallenge.Abstractions;

namespace TurtleChallenge.Player
{
    public class Turtle : IPlayer
    {
        public Direction Direction { get; set; }
        public Position Position { get; set; }

        public void Play(GameActions move)
        {
            if (move == GameActions.Move)
            {
                Move();
            }
            else
            {
                Rotate();
            }
        }

        public void Rotate()
        {
            switch(Direction)
            {
                case Direction.North:
                    Direction = Direction.East;
                    break;
                case Direction.South:
                    Direction = Direction.West;
                    break;
                case Direction.East:
                    Direction = Direction.South;
                    break;
                case Direction.West:
                    Direction = Direction.North;
                    break;
                default:
                    throw new ArgumentException("Not a valid direction");
            }
        }

        public void Move()
        {
            switch(Direction)
            {
                case Direction.North:
                    Position.Y--;
                    break;
                case Direction.South:
                    Position.Y++;
                    break;
                case Direction.East:
                    Position.X++;
                    break;
                case Direction.West:
                    Position.X--;
                    break;
                default:
                    throw new ArgumentException("Not a valid direction");
            }
        }

        public IPlayer Initialize(StartingPoint initialPos)
        {
            this.Direction = initialPos.Direction;
            this.Position = new Position();
            this.Position.X = initialPos.X;
            this.Position.Y = initialPos.Y;
            return this;
        }
    }
}
