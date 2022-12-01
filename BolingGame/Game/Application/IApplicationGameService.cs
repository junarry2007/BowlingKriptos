using BowlingGame.Game.Domain;

namespace BowlingGame.Game.Application
{
    public interface IApplicationGameService
    {
        /// <summary>
        /// Function that stores the number of knocked down pins
        /// </summary>
        /// <param name="pines">Number of pins</param>
        /// <param name="currentRoll">Actual position</param>
        void Roll(int pines, int currentRoll);
        /// <summary>
        /// Function that calculates the score
        /// </summary>
        /// <returns>Object with result to print</returns>
        ResponseConsole Score();
        /// <summary>
        /// Function that validates if the player made a Strike
        /// </summary>
        /// <param name="roll">Position of roll</param>
        /// <returns>True or false</returns>
        bool IsStrike(int roll);
        /// <summary>
        /// Function that validates if the player made a Spare
        /// </summary>
        /// <param name="roll">Position of roll</param>
        /// <returns>True or false</returns>
        bool IsSpare(int roll);
        /// <summary>
        /// Function that adds two rolls without a bonus
        /// </summary>
        /// <param name="roll">Position of roll</param>
        /// <returns>Sum calculation</returns>
        int SumOfBallsInFrame(int roll);
        /// <summary>
        /// Function that calculates the bonus for a SPARE
        /// </summary>
        /// <param name="roll">Position of roll</param>
        /// <returns>Sum calculation</returns>
        int SpareBonus(int roll);
        /// <summary>
        /// Function that calculates the bonus for a STRAKE
        /// </summary>
        /// <param name="roll">Position of roll</param>
        /// <returns>Sum calculation</returns>
        int StrikeBonus(int roll);
    }
}
