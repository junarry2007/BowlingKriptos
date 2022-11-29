namespace BowlingGame.Game.Application
{
    public interface IApplicationGameService
    {
        void Roll(int pines);
        int Score();
        bool IsStrike(int roll);
        bool IsSpare(int roll);
        int SumOfBallsInFrame(int roll);
        int SpareBonus(int roll);
        int StrikeBonus(int roll);
    }
}
