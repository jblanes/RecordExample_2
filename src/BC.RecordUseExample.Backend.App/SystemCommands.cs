using BC.RecordUseExample.Backend.Domain.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace BC.RecordUseExample.Backend.App
{
    public sealed class SystemCommands(IServiceProvider serviceProvider)
    {
        private readonly IServiceProvider _serviceProvider = serviceProvider;

        public async Task<CommandResult> ProcessAsync<T>(ICreateCommandParseable<T> commandParseable)
        {
            var cmd = commandParseable.ToCreateCommand();
            return cmd == null ?
                        throw new ArgumentNullException(nameof(commandParseable), "Comandos nulos no son permitidos") :
                        await ProcessAsync(cmd);
        }

        public async Task<CommandResult> ProcessAsync<T>(ICommand<T> cmd)
        {
            var validationResult = cmd.Validate();
            if (validationResult.IsFailure)
            {
                return validationResult;
            }

            //ICommandHandler<T> handler = ActivatorUtilities.CreateInstance<ICommandHandler<T>>(_serviceProvider);
            ICommandHandler<T> handler = _serviceProvider.GetRequiredService<ICommandHandler<T>>();

            return await handler.HandleAsync(cmd.GetCommand());
        }
    }
}
