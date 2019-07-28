using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TurtleChallenge.Abstractions;

namespace TurtleChallenge.ConfigReader
{
    public class Config : IConfig
    {
        public GameConfig GetGameConfig(string configPath)
        {
            GameConfig gameconfig = null;
            using (StreamReader r = new StreamReader(configPath))
            {
                string json = r.ReadToEnd();
                gameconfig = JsonConvert.DeserializeObject<GameConfig>(json);
            }
            
            return gameconfig;
        }

        public List<Sequence> GetMoves(string configPath)
        {
            List<Sequence> moves = null;
            using (StreamReader r = new StreamReader(configPath))
            {
                string json = r.ReadToEnd();
                moves = JsonConvert.DeserializeObject<List<Sequence>>(json);
            }

            return moves;
        }
    }
}
