using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
            Portfolio = new List<Stock>();
        }

        private readonly List<Stock> Portfolio;
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }

        public int Count => Portfolio.Count;

        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10000 && this.MoneyToInvest >= stock.PricePerShare)
            {
                Portfolio.Add(stock);
                this.MoneyToInvest -= stock.PricePerShare;
            }

        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            if (Portfolio.FirstOrDefault(x => x.CompanyName == companyName) == null)
            {
                return $"{companyName} does not exist.";
            }

            var company = Portfolio.FirstOrDefault(x => x.CompanyName == companyName);

            if (sellPrice < company.PricePerShare)
            {
                return $"Cannot sell {companyName}.";
            }

            MoneyToInvest += sellPrice;//company.PricePerShare;
            Portfolio.Remove(company);
            return $"{companyName} was sold.";

        }

        public Stock FindStock(string companyName)
        {
            return Portfolio.FirstOrDefault(x => x.CompanyName == companyName);
        }

        public Stock FindBiggestCompany()
        {
            var max = Portfolio.Max(x => x.MarketCapitalization);
            return Portfolio.FirstOrDefault(x => x.MarketCapitalization == max);
        }

        public string InvestorInformation()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The investor {FullName} with a broker {BrokerName} has stocks:");
            foreach (var item in Portfolio)
            {
                sb.AppendLine(item.ToString());
            }



            return sb.ToString().TrimEnd();
        }

    }
}
