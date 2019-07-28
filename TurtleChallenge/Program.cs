using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TurtleChallenge.ConfigReader;
using TurtleChallenge.Game;
using TurtleChallenge.Player;

namespace TurtleChallenge
{
    class Program
    {
        private static IServiceProvider serviceProvider;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome Turtle Challenge!");
            Console.WriteLine();
            try
            {
                var gameSettingsFileName = "game-settings";
                var movesFileName = "moves";


                if (args.Length > 0)
                {
                    gameSettingsFileName = args[0];

                    if (args.Length > 1)
                    {
                        movesFileName = args[1];
                    }
                }

                RegisterServices();

                var config = serviceProvider.GetService<IConfig>();
                var game = serviceProvider.GetService<IGame>();
                var turtle = serviceProvider.GetService<IPlayer>();

                var validationResult = new List<ValidationResult>();

                var gameConfig = config.GetGameConfig($@".\{ gameSettingsFileName }.json");
                if (!ModelValidator.TryValidate(gameConfig, out validationResult))
                {
                    throw new ArgumentException($"Invalid GameConfig : {JsonConvert.SerializeObject(validationResult)}");
                }

                var moves = config.GetMoves($@".\{ movesFileName}.json");
                if (!ModelValidator.TryValidate(moves, out validationResult))
                {
                    throw new ArgumentException(@"Invalid moves : {JsonConvert.SerializeObject(validationResult)}");
                }

                game.DrawBoard(gameConfig);

                int seq = 0;
                foreach (var sequence in moves)
                {
                    Console.WriteLine($"sequence {seq} : started");

                    game.InitializePlayer(turtle, gameConfig.StartingPoint);
                    var result = game.Play(sequence.Moves);

                    Console.WriteLine($"sequence {seq} result : { result}");
                    Console.WriteLine($"sequence {seq} : end");
                    seq++;
                    Console.WriteLine();
                }
            }
            catch(JsonSerializationException ex)
            {
                // Log error message
                Console.WriteLine($"Config error: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Log error message
                Console.WriteLine($"error : {ex.Message}");
            }

            DisposeServices();
            
            Console.ReadLine();
        }

        private static void RegisterServices()
        {
            var collection = new ServiceCollection();
            collection.AddScoped<IConfig, Config>();
            collection.AddScoped<IGame, Game.Game>();
            collection.AddScoped<IPlayer, Turtle>();
            serviceProvider = collection.BuildServiceProvider();
        }

        private static void DisposeServices()
        {
            if (serviceProvider == null)
            {
                return;
            }
            if (serviceProvider is IDisposable)
            {
                ((IDisposable)serviceProvider).Dispose();
            }
        }
    }
}
