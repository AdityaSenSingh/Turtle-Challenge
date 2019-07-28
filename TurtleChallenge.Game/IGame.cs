using System;
using System.Collections.Generic;
using System.Text;
using TurtleChallenge.Abstractions;
using TurtleChallenge.Player;

namespace TurtleChallenge.Game
{
    public interface IGame
    {
        void InitializePlayer(IPlayer turtle, StartingPoint initialPos);

        void DrawBoard(GameConfig config);

        GameResult Play(List<Abstractions.GameActions> moves);
    }
}
