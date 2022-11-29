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
            _serviceGame.Roll(7);
            _serviceGame.Roll(3);
            RollMany(18, 0);
            Assert.AreEqual(30, _serviceGame.Score());
        }

        [Test]
        public void FirstSpare()
        {
            RollSpare();
            _serviceGame.Roll(6);
            _serviceGame.Roll(3);
            RollMany(17, 0);
            Assert.AreEqual(25, _serviceGame.Score());
        }

        [Test]
        public void PerfectGame()
        {
            RollMany(12, 10);
            Assert.AreEqual(300, _serviceGame.Score());
        }

        [Test]
        public void BadGame()
        {
            RollMany(21, 0);
            Assert.AreEqual(0, _serviceGame.Score());
        }
        private void RollStrike()
        {
            _serviceGame.Roll(10);
        }
        private void RollSpare()
        {
            _serviceGame.Roll(3);
            _serviceGame.Roll(7);
        }
        private void RollMany(int rolls, int pins)
        {
            for(int i = 0; i < rolls; i++)
            {
                _serviceGame.Roll(pins);
            }
        }
    }
}