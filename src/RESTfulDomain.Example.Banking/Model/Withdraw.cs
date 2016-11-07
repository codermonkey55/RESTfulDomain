using NodaMoney;
using RESTfulDomain.Model;

namespace RESTfulDomain.Example.Banking.Model
{
    internal interface IWithdraw : ICapability<AccountData>
    {
        Money Amount(decimal amout);
    }

    internal class Withdraw : IWithdraw
    {
        protected readonly AccountData _accountData;

        public Withdraw(ICapabilityContext<AccountData> context)
        {
            _accountData = context.Data;
        }

        public Money Amount(decimal amout)
        {
            _accountData.Balance.Subtract(amout);

            return _accountData.Balance.Current;
        }
    }
}
