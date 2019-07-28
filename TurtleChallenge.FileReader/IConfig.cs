using System;
using System.Collections.Generic;
using System.Text;
using TurtleChallenge.Abstractions;

namespace TurtleChallenge.ConfigReader
{
    public interface IConfig
    {
        GameConfig GetGameConfig(string path);

        List<Sequence> GetMoves(string path);
    }
}
