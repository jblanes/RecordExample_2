namespace BC.RecordUseExample.Backend.Domain.Validation
{
    public static class Validator
    {
        public static T Value<T>(T value) => value;

        public static ValidatePipeline<T> Where<T>(this T value, Func<T, bool> condition, string message)
        {
            if (condition(value))
            {
                return new(message, value);
            }
            else
            {
                return new(string.Empty, value);
            }
        }

        public static ValidatePipeline<T> Then<T>(this ValidatePipeline<T> value, Func<T, bool> condition, string message)
        {
            if (string.IsNullOrWhiteSpace(value.Message) && condition(value.Value))
            {
                value = new(message, value.Value);
                return value;
            }
            else
            {
                return value;
            }
        }
    }

    public class ValidatePipeline<T>(string message, T value)
    {
        public string Message { get; private set; } = message;
        public T Value { get; set; } = value;
    }
}
