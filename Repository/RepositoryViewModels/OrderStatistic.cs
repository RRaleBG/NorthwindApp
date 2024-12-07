namespace NorthwindApp.Repository.RepositoryViewModels
{
    public class OrderStatistic
    {
        public string Month { get; set; }
        public int  TotalOrders { get; set; }

        public  decimal TotalRevenue { get; set; }
    }
}
