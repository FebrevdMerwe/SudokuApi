using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sudoku.Generator;
using Sudoku.Puzzle;
using Sudoku.Solver;
using Sudoku.Validator;
using SudokuApi.Models;

namespace SudokuApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SudokuController : ControllerBase
    {
        [HttpGet()]
        [Route("Generate/{difficulty}")]
        public ActionResult<SudokuPuzzleDTO> Generate(SudokuDifficulty difficulty, int? seed)
        {
            ISudokuGenerator generator = new SudokuGenerator();
            ISudokuPuzzle puzzle = generator.Generate(difficulty, seed);

            SudokuPuzzleDTO puzzleDTO = new SudokuPuzzleDTO()
            {
                Puzzle = puzzle.ToString(),
                Seed = puzzle.Id
            };

            return puzzleDTO;
        }

        [HttpPost()]
        [Route("Solve")]
        public ActionResult<SudokuPuzzleDTO> Solve(SudokuPuzzleDTO puzzle)
        {
            ISudokuValidator validator = new SudokuValidator();
            ISudokuSolver solver = new SudokuSolver(puzzle.Puzzle, validator);

            ISudokuPuzzle solved = solver.Solve();

            SudokuPuzzleDTO puzzleDTO = new SudokuPuzzleDTO()
            {
                Puzzle = solved.ToString(),
                Seed = puzzle.Seed
            };

            return puzzleDTO;
        }
    }
}
