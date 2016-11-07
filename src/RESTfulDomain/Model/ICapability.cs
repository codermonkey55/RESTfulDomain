namespace RESTfulDomain.Model
{
    public interface ICapability
    {

    }

    public interface ICapability<out TDataModel> : ICapability where TDataModel : IDataModel
    {

    }

    public interface ICapability<out TDomainModel, out TDataModel> : ICapability<TDataModel> where TDataModel : class, IDataModel
        where TDomainModel : class, IDomainModel<TDataModel>
    {
        TDomainModel Model { get; }
    }
}
