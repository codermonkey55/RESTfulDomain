using RESTfulDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RESTfulDomain.Example.Banking.Model
{
    internal interface IAccount
    {
        IBalance Balance { get; }
        IWithdraw Withdraw { get; }
        void Load(int dataModelId);
    }

    internal class Account : IDomainModel<IBalance>, IAccount
    {
        protected Balance _Balance;

        protected List<IComponentModel<IBalance>> _AccountOperations;

        private readonly IAccountProvider _accountProvider;

        IBalance IAccount.Balance => _Balance;

        public IBalance Data => _Balance;

        IWithdraw IAccount.Withdraw => GetCapability<IWithdraw>();

        public IReadOnlyCollection<IComponentModel<IBalance>> Capabalities => _AccountOperations;

        public Account(IAccountProvider accountProvider)
        {
            _accountProvider = accountProvider;
        }

        public void Unwrap()
        {
            _Balance = null;
        }

        public bool HasData()
        {
            return _Balance != null;
        }

        public void Wrap(IBalance dataModel)
        {
            _Balance = dataModel as Balance;
        }

        public void LoadData(int dataModelId)
        {
            _accountProvider.GetById(dataModelId);
        }

        void IAccount.Load(int accountId) => LoadData(accountId);

        public void LoadData<TId>(TId dataModelId) where TId : struct
        {
            throw new NotImplementedException();
        }

        public TComponent GetCapability<TComponent>() where TComponent : class, IComponentModel<IBalance>
        {
            return _AccountOperations.FirstOrDefault(comp => typeof(TComponent).IsAssignableFrom(comp.GetType())) as TComponent;
        }
    }

    internal interface IAccountProvider
    {
        void GetById(int dataModelId);
    }
}
