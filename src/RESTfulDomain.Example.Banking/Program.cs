using NodaMoney;
using RESTfulDomain.Example.Banking.Model;

namespace RESTfulDomain.Example.Banking
{
    class Program
    {
        static void Main(string[] args)
        {
            IAccount account = new Account();

            Money remainingBalance = account.Withdraw.Amount(10.00m);

            Money currentBalance = account.Balance.Current;

            bool isEqual = currentBalance == remainingBalance;
        }
    }
}
