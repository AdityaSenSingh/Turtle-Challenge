using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TurtleChallenge.Abstractions
{
    public class Position
    {
        [Required, Range(1, int.MaxValue, ErrorMessage = "Postion- X value cannot be less than 0")]
        public int X { get; set; }

        [Required, Range(1, int.MaxValue, ErrorMessage = "Postion- Y value cannot be less than 0")]
        public int Y { get; set; }
    }
}
