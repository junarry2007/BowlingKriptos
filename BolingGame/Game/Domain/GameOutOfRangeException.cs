using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingGame.Game.Domain
{
    public class GameOutOfRangeException : DomainException
    {
        public GameOutOfRangeException(string message) : base(message)
        {
        }
    }
}
