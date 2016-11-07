using RESTfulDomain.Model;
using System;

namespace RESTfulDomain.Example.Banking.Model
{
    internal sealed class AccountData : IDataModel
    {
        public Balance Balance { get; set; }

        public string Owner { get; set; }

        public DateTime OpenedOn { get; set; }

        public AccountStatus Status { get; set; }

        public bool IsClosed => Status == AccountStatus.Closed;
    }
}
