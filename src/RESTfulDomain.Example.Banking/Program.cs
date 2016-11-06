using RESTfulDomain.Example.Banking.Model;

namespace RESTfulDomain.Example.Banking
{
    class Program
    {
        static void Main(string[] args)
        {
            IAccount account = new Account(null);

            Money remainingBalance = account.Withdraw.Amount(10.00m);

            Money currentBalance = account.Balance.Current;

            bool isEqual = currentBalance.Equals(remainingBalance);
        }
    }
}
