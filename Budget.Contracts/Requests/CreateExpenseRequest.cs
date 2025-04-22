namespace Budget.Contracts.Requests
{
    public class CreateExpenseRequest
    {
        public required DateTime Month { get; init; }

        public required decimal Amount { get; init; }

        public required string Category { get; init; } = string.Empty;
    }
}
