namespace BC.RecordUseExample.Backend.Domain.Commands
{
    public readonly record struct MessageText
    {
        public readonly string Text { get; }
        public readonly MessageType MessageType { get; }
        public readonly string FieldName { get; }

        public MessageText(MessageType messageType, string fieldName, string text)
        {
            Text = text;
            MessageType = messageType;
            FieldName = fieldName;
        }

        public override string ToString() => Text;
        public static implicit operator string(MessageText m) => m.Text;

    }
}
