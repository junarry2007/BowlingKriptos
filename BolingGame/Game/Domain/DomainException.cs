using System;

namespace BowlingGame.Game.Domain
{
    public abstract class DomainException : Exception
    {
        protected DomainException(string message) : base(message)
        {
        }
    }
}
