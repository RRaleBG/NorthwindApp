namespace NorthwindApp.Pages
{
    public class BankDataRepository : IBankDataRepository
    {
        List<BankData> sampleBankData = new List<BankData>
        {
            new BankData { Id = 1, Name = "GTB", Colour = "Orange", TransactionsCount = 1923 },
            new BankData { Id = 2, Name = "UBA", Colour = "Red", TransactionsCount = 2011 },
            new BankData { Id = 3, Name = "FBN", Colour = "LightBlue", TransactionsCount = 1820 },
            new BankData { Id = 4, Name = "ZIB", Colour = "Black", TransactionsCount = 1500 },
            new BankData { Id = 4, Name = "ACC", Colour = "LightGreen", TransactionsCount = 1947 }
        };


        public void AddBankData(BankData bankData)
        {
            sampleBankData.Add(bankData);
        }

        public void DeleteBankData(int id)
        {
            sampleBankData.Remove(sampleBankData.FirstOrDefault(b => b.Id == id));
        }

        public List<BankData> GetAllBankData()
        {
            return sampleBankData;
        }

        public BankData GetBankData(int id)
        {
            return sampleBankData.FirstOrDefault(b => b.Id == id);
        }

        public void UpdateBankData(BankData bankData)
        {
            var oldBankData = sampleBankData.FirstOrDefault();

            if (oldBankData != null)
            {
                sampleBankData.Remove(oldBankData);
                sampleBankData.Add(bankData);
            }
        }
    }
}
