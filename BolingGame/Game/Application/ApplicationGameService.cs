using BowlingGame.Game.Domain;
using System;

namespace BowlingGame.Game.Application
{
    public class ApplicationGameService : IApplicationGameService
    {
        private int[] rolls = new int[21];
        /// <summary>
        /// Function that stores the number of knocked down pins
        /// </summary>
        /// <param name="pines">Number of pins</param>
        /// <param name="currentRoll">Actual position</param>
        public void Roll(int pins, int currentRoll)
        {
            if (currentRoll > 20)
                throw new GameOutOfRangeException("The number max of rolls allow is 21");
            else
                rolls[currentRoll] = pins;
        }
        /// <summary>
        /// Function that calculates the score
        /// </summary>
        /// <returns>Object with result to print</returns>
        public ResponseConsole Score()
        {
            //Console Vars
            ResponseConsole result = new ResponseConsole();
            int frames = 0;
            string lineFrame = "";
            string linePinfalls = "";
            string lineScore = "";

            int score = 0;
            int roll = 0;

            for (int frame = 0; frame < 10; frame++)
            {
                //Validate if Strike
                if (IsStrike(roll))
                {
                    score += 10 + StrikeBonus(roll);
                    roll++;
                    linePinfalls += "X\t";
                } //Validate if Spare
                else if (IsSpare(roll))
                {
                    score += 10 + SpareBonus(roll);
                    roll += 2;
                    linePinfalls += "*-/\t";
                }
                else
                {
                    score += SumOfBallsInFrame(roll);
                    roll += 2;
                    linePinfalls += "$-$\t";
                }
                //Build line console
                frames++;
                lineFrame += frames + "\t";
                lineScore += score + "\t";
            }
            //Bouild objec to response
            result.Frame = lineFrame.ToString();
            result.Pinfalls = linePinfalls;
            result.Score = lineScore.ToString();
            result.TotalScore = score;

            return result;
        }
        /// <summary>
        /// Function that validates if the player made a Strike
        /// </summary>
        /// <param name="roll">Position of roll</param>
        /// <returns>True or false</returns>
        public bool IsStrike(int roll)
        {
            return rolls[roll] == 10;
        }
        /// <summary>
        /// Function that validates if the player made a Spare
        /// </summary>
        /// <param name="roll">Position of roll</param>
        /// <returns>True or false</returns>
        public bool IsSpare(int roll)
        {
            return rolls[roll] + rolls[roll + 1] == 10;
        }
        /// <summary>
        /// Function that adds two rolls without a bonus
        /// </summary>
        /// <param name="roll">Position of roll</param>
        /// <returns>Sum calculation</returns>
        public int SumOfBallsInFrame(int roll)
        {
            return rolls[roll] + rolls[roll + 1];
        }
        /// <summary>
        /// Function that calculates the bonus for a SPARE
        /// </summary>
        /// <param name="roll">Position of roll</param>
        /// <returns>Sum calculation</returns>
        public int SpareBonus(int roll)
        {
            return rolls[roll + 2];
        }
        /// <summary>
        /// Function that calculates the bonus for a STRAKE
        /// </summary>
        /// <param name="roll">Position of roll</param>
        /// <returns>Sum calculation</returns>
        public int StrikeBonus(int roll)
        {
            return rolls[roll + 1] + rolls[roll + 2];
        }
    }
}
