namespace MyKoloApi.DTOs
{
    public class GetExpenseDto
    {
        public string ExpenseId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
    }
}