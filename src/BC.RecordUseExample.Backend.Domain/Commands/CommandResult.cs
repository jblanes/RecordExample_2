namespace BC.RecordUseExample.Backend.Domain.Commands
{
    public readonly record struct CommandResult
    {
        private readonly List<MessageText> _messages;
        public CommandResult() { _messages = []; }
        public bool IsSuccess => _messages.Count == 0 || _messages.ToList().All(x => x.MessageType == MessageType.Success);
        public bool IsFailure => !IsSuccess;

        internal void AddError(string fieldName, string error)
        {
            if (!string.IsNullOrWhiteSpace(error))
            {
                _messages.Add(new(MessageType.Error, fieldName, error));
            }
        }

        internal void AddSuccess(string fieldName, string message)
        {
            if (!string.IsNullOrWhiteSpace(message))
            {
                _messages.Add(new(MessageType.Success, fieldName, message));
            }
        }

        public List<MessageText> GetErrorMessages() => _messages.Where(x => x.MessageType == MessageType.Error).ToList();
        public List<MessageText> GetSuccessMessages() => _messages.Where(x => x.MessageType == MessageType.Success).ToList();
        public List<MessageText> GetAllMessages() => _messages;
    }
}
