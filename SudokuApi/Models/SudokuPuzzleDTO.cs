using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SudokuApi.Models
{
    public class SudokuPuzzleDTO
    {
        public string Puzzle { get; set; }
        public int Seed { get; set; }
    }
}
