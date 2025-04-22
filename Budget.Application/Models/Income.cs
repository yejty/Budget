using Budget.Application.Models.Enums;

namespace Budget.Application.Models
{
    public class Income
    {
        public required Guid Id { get; init; }

        public required DateTime Month { get; set; } = DateTime.MinValue;

        public required decimal Amount { get; set; } = 0;

        public required string Category { get; set; } = string.Empty;

    }
}
