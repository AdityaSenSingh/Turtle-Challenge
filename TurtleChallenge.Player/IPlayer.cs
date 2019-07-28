using System;
using System.Collections.Generic;
using System.Text;
using TurtleChallenge.Abstractions;

namespace TurtleChallenge.Player
{
    public interface IPlayer
    {
        Position Position { get; set; }

        Direction Direction { get; set; }

        void Play(GameActions move);

        IPlayer Initialize(StartingPoint initialPos);
    }
}
