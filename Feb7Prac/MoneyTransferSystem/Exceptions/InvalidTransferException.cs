using System;

namespace MoneyTransferSystem.Exceptions
{
    public class InvalidTransferException : Exception
    {
        public InvalidTransferException(string message) : base(message) { }
    }
}
