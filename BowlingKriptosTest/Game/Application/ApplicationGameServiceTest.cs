using AutoMapper;
using BowlingGame.Game.Application;
using Moq;
using NUnit.Framework;

namespace BowlingKriptosTest.Game.Application
{
    public class ApplicationGameServiceTest
    {
        private ApplicationGameService _serviceGame;

        [SetUp]
        public void Setup()
        {
            //Inicializo el servicio
            _serviceGame = new ApplicationGameService();
        }

        [Test]
        public void FirstStrike()
        {
            RollStrike();
            _serviceGame.Roll(7, 1);
            _serviceGame.Roll(3, 2);
            RollMany(18, 0, 3);
            Assert.AreEqual(30, _serviceGame.Score().TotalScore);
        }

        [Test]
        public void FirstSpare()
        {
            RollSpare();
            _serviceGame.Roll(6, 2);
            _serviceGame.Roll(3, 3);
            RollMany(17, 0, 4);
            Assert.AreEqual(25, _serviceGame.Score().TotalScore);
        }

        [Test]
        public void PerfectGame()
        {
            RollMany(12, 10, 0);
            Assert.AreEqual(300, _serviceGame.Score().TotalScore);
        }

        [Test]
        public void BadGame()
        {
            RollMany(21, 0, 0);
            Assert.AreEqual(0, _serviceGame.Score().TotalScore);
        }
        private void RollStrike()
        {
            _serviceGame.Roll(10, 0);
        }
        private void RollSpare()
        {
            _serviceGame.Roll(3, 0);
            _serviceGame.Roll(7, 1);
        }
        private void RollMany(int rolls, int pins, int currentRoll)
        {
            for(int i = 0; i < rolls; i++)
            {
                _serviceGame.Roll(pins, currentRoll);
                currentRoll++;
            }
        }
    }
}