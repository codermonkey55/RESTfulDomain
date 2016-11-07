namespace RESTfulDomain.Example.Banking.Model
{
    internal interface IAccount
    {
        IBalance Balance { get; }
        IWithdraw Withdraw { get; }
        bool FindAccountBy(int accountId);
        void Manage(AccountData dataModel);
    }

    internal class Account : DomainModel<AccountData>, IAccount
    {
        IBalance IAccount.Balance => _dataModel.Balance;

        IWithdraw IAccount.Withdraw => GetCapability<IWithdraw>();

        public Account()
        {

        }

        public void Manage(AccountData dataModel) => Wrap(dataModel);

        bool IAccount.FindAccountBy(int accountId)
        {
            LoadData(accountId);

            return HasData();
        }
    }
}
