using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TurtleChallenge.Abstractions;
using TurtleChallenge.ConfigReader;
using TurtleChallenge.Game;
using TurtleChallenge.Player;

namespace TurtleChallenge.Tests
{
    public class GameTest
    {
        private Mock<IConfig> configMock;
        private Mock<IGame> gameMock;

        [SetUp]
        public void SetUp()
        {
            configMock = new Mock<IConfig>();

        }

        [Test]
        public void HitMineTest_1()
        {
            var gameConfig = new GameConfig
            {
                BoardSize = new BoardSize { Columns = 3, Rows = 3 },
                StartingPoint = new StartingPoint { Direction = Direction.North, X = 0, Y = 2 },
                ExitPoint = new Position { X = 2, Y = 2 },
                Mines = new List<Position>() { new Position { X = 0, Y = 0 } }
            };
            configMock.Setup(config => config.GetGameConfig(It.IsAny<string>())).Returns(gameConfig);
            var moves = new List<Sequence>(){ new Sequence {
                Moves = new List<GameActions>() {  GameActions.Move, GameActions.Move}
            }};

            var game = new Game.Game();
            var turtle = new Turtle();
            game.DrawBoard(gameConfig);

            GameResult result = GameResult.Start;
            foreach (var sequence in moves)
            {
                game.InitializePlayer(turtle, gameConfig.StartingPoint);
                result = game.Play(sequence.Moves);
            }

            Assert.AreEqual(GameResult.MineHit, result);
        }

        [Test]
        public void HitMineTest_2()
        {
            var gameConfig = new GameConfig
            {
                BoardSize = new BoardSize { Columns = 3, Rows = 3 },
                StartingPoint = new StartingPoint { Direction = Direction.North, X = 0, Y = 2 },
                ExitPoint = new Position { X = 2, Y = 2 },
                Mines = new List<Position>() { new Position { X = 1, Y = 1 } }
            };
            configMock.Setup(config => config.GetGameConfig(It.IsAny<string>())).Returns(gameConfig);
            var moves = new List<Sequence>(){ new Sequence {
                Moves = new List<GameActions>() {  GameActions.Move,GameActions.Rotate, GameActions.Move}
            }};

            var game = new Game.Game();
            var turtle = new Turtle();
            game.DrawBoard(gameConfig);

            GameResult result = GameResult.Start;
            foreach (var sequence in moves)
            {
                game.InitializePlayer(turtle, gameConfig.StartingPoint);
                result = game.Play(sequence.Moves);
            }

            Assert.AreEqual(GameResult.MineHit, result);
        }

        [Test]
        public void CannotMoveTest_1()
        {
            var gameConfig = new GameConfig
            {
                BoardSize = new BoardSize { Columns = 3, Rows = 3 },
                StartingPoint = new StartingPoint { Direction = Direction.North, X = 0, Y = 2 },
                ExitPoint = new Position { X = 2, Y = 2 },
                Mines = new List<Position>() { new Position { X = 1, Y = 1 } }
            };
            configMock.Setup(config => config.GetGameConfig(It.IsAny<string>())).Returns(gameConfig);
            var moves = new List<Sequence>(){ new Sequence {
                Moves = new List<GameActions>() {  GameActions.Move,GameActions.Move, GameActions.Move}
            }};

            var game = new Game.Game();
            var turtle = new Turtle();
            game.DrawBoard(gameConfig);

            GameResult result = GameResult.Start;
            foreach (var sequence in moves)
            {
                game.InitializePlayer(turtle, gameConfig.StartingPoint);
                result = game.Play(sequence.Moves);
            }

            Assert.AreEqual(GameResult.CannotMove, result);
        }

        [Test]
        public void CannotMoveTest_2()
        {
            var gameConfig = new GameConfig
            {
                BoardSize = new BoardSize { Columns = 3, Rows = 3 },
                StartingPoint = new StartingPoint { Direction = Direction.North, X = 0, Y = 2 },
                ExitPoint = new Position { X = 2, Y = 2 },
                Mines = new List<Position>() { new Position { X = 1, Y = 1 } }
            };
            configMock.Setup(config => config.GetGameConfig(It.IsAny<string>())).Returns(gameConfig);
            var moves = new List<Sequence>(){ new Sequence {
                Moves = new List<GameActions>() {  GameActions.Rotate,GameActions.Rotate, GameActions.Move}
            }};

            var game = new Game.Game();
            var turtle = new Turtle();
            game.DrawBoard(gameConfig);

            GameResult result = GameResult.Start;
            foreach (var sequence in moves)
            {
                game.InitializePlayer(turtle, gameConfig.StartingPoint);
                result = game.Play(sequence.Moves);
            }

            Assert.AreEqual(GameResult.CannotMove, result);
        }

        [Test]
        public void StillInDangerTest_1()
        {
            var gameConfig = new GameConfig
            {
                BoardSize = new BoardSize { Columns = 3, Rows = 3 },
                StartingPoint = new StartingPoint { Direction = Direction.North, X = 0, Y = 2 },
                ExitPoint = new Position { X = 2, Y = 2 },
                Mines = new List<Position>() { new Position { X = 1, Y = 1 } }
            };
            configMock.Setup(config => config.GetGameConfig(It.IsAny<string>())).Returns(gameConfig);
            var moves = new List<Sequence>(){ new Sequence {
                Moves = new List<GameActions>() {  GameActions.Move,GameActions.Move}
            }};

            var game = new Game.Game();
            var turtle = new Turtle();
            game.DrawBoard(gameConfig);

            GameResult result = GameResult.Start;
            foreach (var sequence in moves)
            {
                game.InitializePlayer(turtle, gameConfig.StartingPoint);
                result = game.Play(sequence.Moves);
            }

            Assert.AreEqual(GameResult.StillInDanger, result);
        }

        [Test]
        public void StillInDangerTest_2()
        {
            var gameConfig = new GameConfig
            {
                BoardSize = new BoardSize { Columns = 3, Rows = 3 },
                StartingPoint = new StartingPoint { Direction = Direction.North, X = 0, Y = 2 },
                ExitPoint = new Position { X = 2, Y = 2 },
                Mines = new List<Position>() { new Position { X = 1, Y = 1 } }
            };
            configMock.Setup(config => config.GetGameConfig(It.IsAny<string>())).Returns(gameConfig);
            var moves = new List<Sequence>(){ new Sequence {
                Moves = new List<GameActions>() {  GameActions.Rotate,GameActions.Move, GameActions.Rotate}
            }};

            var game = new Game.Game();
            var turtle = new Turtle();
            game.DrawBoard(gameConfig);

            GameResult result = GameResult.Start;
            foreach (var sequence in moves)
            {
                game.InitializePlayer(turtle, gameConfig.StartingPoint);
                result = game.Play(sequence.Moves);
            }

            Assert.AreEqual(GameResult.StillInDanger, result);
        }

        [Test]
        public void SuccessTest_1()
        {
            var gameConfig = new GameConfig
            {
                BoardSize = new BoardSize { Columns = 3, Rows = 3 },
                StartingPoint = new StartingPoint { Direction = Direction.North, X = 0, Y = 2 },
                ExitPoint = new Position { X = 2, Y = 2 },
                Mines = new List<Position>() { new Position { X = 1, Y = 1 } }
            };
            configMock.Setup(config => config.GetGameConfig(It.IsAny<string>())).Returns(gameConfig);
            var moves = new List<Sequence>(){ new Sequence {
                Moves = new List<GameActions>() {  GameActions.Rotate,GameActions.Move, GameActions.Move}
            }};

            var game = new Game.Game();
            var turtle = new Turtle();
            game.DrawBoard(gameConfig);

            GameResult result = GameResult.Start;
            foreach (var sequence in moves)
            {
                game.InitializePlayer(turtle, gameConfig.StartingPoint);
                result = game.Play(sequence.Moves);
            }

            Assert.AreEqual(GameResult.Sucess, result);
        }

        [Test]
        public void SuccessTest_2()
        {
            var gameConfig = new GameConfig
            {
                BoardSize = new BoardSize { Columns = 3, Rows = 3 },
                StartingPoint = new StartingPoint { Direction = Direction.North, X = 0, Y = 2 },
                ExitPoint = new Position { X = 2, Y = 2 },
                Mines = new List<Position>() { new Position { X = 1, Y = 1 } }
            };
            configMock.Setup(config => config.GetGameConfig(It.IsAny<string>())).Returns(gameConfig);
            var moves = new List<Sequence>(){ new Sequence {
                Moves = new List<GameActions>() {  GameActions.Move,GameActions.Move,GameActions.Rotate,
                    GameActions.Move, GameActions.Move,GameActions.Rotate,GameActions.Move, GameActions.Move}
            }};

            var game = new Game.Game();
            var turtle = new Turtle();
            game.DrawBoard(gameConfig);

            GameResult result = GameResult.Start;
            foreach (var sequence in moves)
            {
                game.InitializePlayer(turtle, gameConfig.StartingPoint);
                result = game.Play(sequence.Moves);
            }

            Assert.AreEqual(GameResult.Sucess, result);
        }
    }
}
