using RESTfulDomain.Model;

namespace RESTfulDomain.Example.Banking.Model
{
    internal interface IBalance : IDataModel
    {
        Money Current { get; }
    }

    internal class Balance : IBalance
    {
        private Money _money;

        public Money Current => _money;

        public Balance(decimal amount)
        {
            _money = new Money(amount);
        }

        public void Subtract(decimal amout)
        {
            _money = _money - new Money(amout);
        }

        public void Add(decimal amout)
        {
            _money = _money + new Money(amout);
        }
    }
}
