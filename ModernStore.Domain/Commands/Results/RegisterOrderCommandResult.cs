using ModernStore.Shared.Commands;

namespace ModernStore.Domain.Commands.Results
{
    public class RegisterOrderCommandResult : ICommandResult
    {
        public RegisterOrderCommandResult(string number)
        {
            Number = number;
        }
        public RegisterOrderCommandResult()
        {

        }
        public string Number { get; set; }
    }
}
