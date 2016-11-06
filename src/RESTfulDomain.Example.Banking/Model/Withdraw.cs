using RESTfulDomain.Model;

namespace RESTfulDomain.Example.Banking.Model
{
    internal interface IWithdraw : IComponentModel<IBalance>
    {
        Money Amount(decimal amout);
    }

    internal class Withdraw : IWithdraw
    {
        protected readonly Balance Balance;

        IBalance IComponentModel<IBalance>.Data => Balance;

        public Withdraw(Balance balance)
        {
            Balance = balance;
        }

        public Money Amount(decimal amout)
        {
            Balance.Subtract(amout);

            return Balance.Current;
        }
    }

    internal interface IFluentWithdraw : IWithdraw, IComponentModel<Account, IBalance>
    {
        Account Account { get; }
    }

    internal sealed class FluentWithdraw : Withdraw, IFluentWithdraw
    {
        private readonly Account _account;

        internal FluentWithdraw(Account account, Balance balance) : base(balance)
        {
            _account = account;
        }

        Account IComponentModel<Account, IBalance>.Model => _account;

        public Account Account => _account;
    }
}
