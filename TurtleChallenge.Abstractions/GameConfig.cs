using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TurtleChallenge.Abstractions
{
    public class GameConfig : IValidatableObject
    {
        public BoardSize BoardSize { get; set; }

        public List<Position> Mines { get; set; }

        public StartingPoint StartingPoint { get; set; }

        public Position ExitPoint { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (BoardSize.Columns < 0 || BoardSize.Rows < 0)
            {
                yield return new ValidationResult("not a valid board size");
            }

            if(StartingPoint.X < 0 || StartingPoint.Y < 0 || StartingPoint.X > BoardSize.Rows-1 || StartingPoint.Y > BoardSize.Columns-1)
            {
                yield return new ValidationResult("not a valid starting point");
            }

            if (Mines.Exists(pos => pos.X < 0 || pos.Y < 0 || pos.X > BoardSize.Rows - 1 || pos.Y > BoardSize.Columns - 1))
            {
                yield return new ValidationResult("not a valid mine position");
            }

            if (ExitPoint.X < 0 || ExitPoint.Y < 0 || ExitPoint.X > BoardSize.Rows - 1 || ExitPoint.Y > BoardSize.Columns - 1)
            {
                yield return new ValidationResult("not a valid exit point");
            }
        }

    }

    public class BoardSize
    {
        [Required, Range(1, int.MaxValue, ErrorMessage = "BoardSize- Number of rows are not valid")]
        public int Rows { get; set; }

        [Required, Range(1, int.MaxValue, ErrorMessage = "BoardSize- Number of columns are not valid")]
        public int Columns { get; set; }
    }

    public class StartingPoint : Position
    {
        public Direction Direction { get; set; }
    }
}
