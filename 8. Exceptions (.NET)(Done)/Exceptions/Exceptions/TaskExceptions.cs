using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    internal class TaskExceptions
    {
        [Serializable]
        public class InitializationException : Exception
        {
            public InitializationException() : base() { }
            public InitializationException(string message) : base(message) { }
            public InitializationException(string message, Exception inner) : base(message, inner) { }
        }

        [Serializable]
        public class AddException : Exception
        {
            public AddException() : base() { }
            public AddException(string message) : base(message) { }
            public AddException(string message, Exception inner) : base(message, inner) { }
        }

        [Serializable]
        public class GetAutoByParameterException : Exception
        {
            public GetAutoByParameterException() : base() { }
            public GetAutoByParameterException(string message) : base(message) { }
            public GetAutoByParameterException(string message, Exception inner) : base(message, inner) { }
        }

        [Serializable]
        public class UpdateAutoException : Exception
        {
            public UpdateAutoException() : base() { }
            public UpdateAutoException(string message) : base(message) { }
            public UpdateAutoException(string message, Exception inner) : base(message, inner) { }
        }

        [Serializable]
        public class RemoveAutoException : Exception
        {
            public RemoveAutoException() : base() { }
            public RemoveAutoException(string message) : base(message) { }
            public RemoveAutoException(string message, Exception inner) : base(message, inner) { }
        }
    }
}
