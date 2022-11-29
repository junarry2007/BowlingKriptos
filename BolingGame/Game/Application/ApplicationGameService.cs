namespace BowlingGame.Game.Application
{
    public class ApplicationGameService : IApplicationGameService
    {
        private int[] rolls = new int[21];
        private int currentRoll;
        public void Roll(int pins)
        {
            rolls[currentRoll++] = pins;
        }
        public int Score()
        {
            int score = 0;
            int roll = 0;

            for (int frame = 0; frame < 10; frame++)
            {
                if (IsStrike(roll))
                {
                    score += 10 + StrikeBonus(roll);
                    roll++;
                }
                else if (IsSpare(roll))
                {
                    score += 10 + SpareBonus(roll);
                    roll += 2;
                }
                else
                {
                    score += SumOfBallsInFrame(roll);
                    roll += 2;
                }
            }
            return score;
        }
        public bool IsStrike(int roll)
        {
            return rolls[roll] == 10;
        }
        public bool IsSpare(int roll)
        {
            return rolls[roll] + rolls[roll + 1] == 10;
        }
        public int SumOfBallsInFrame(int roll)
        {
            return rolls[roll] + rolls[roll + 1];
        }
        public int SpareBonus(int roll)
        {
            return rolls[roll + 2];
        }
        public int StrikeBonus(int roll)
        {
            return rolls[roll + 1] + rolls[roll + 2];
        }
    }
}
