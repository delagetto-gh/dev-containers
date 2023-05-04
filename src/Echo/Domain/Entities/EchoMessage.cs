using System;

namespace Echo.Domain
{
    public class EchoMessage
    {
        public int Id { get; private set; }

        public string Message { get; private set; }

        protected EchoMessage(string message) => this.Message = $"You said: {message}";

        public static EchoMessage Create(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentNullException(nameof(message));

            var echo = new EchoMessage(message);
            return echo;
        }

        private EchoMessage() { }
    }
}