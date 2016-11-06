namespace RESTfulDomain
{
    public interface IComponentModel
    {

    }

    public interface IComponentModel<out TDataModel> : IComponentModel where TDataModel : IDataModel
    {
        TDataModel Data { get; }
    }

    public interface IComponentModel<TDomainModel, out TDataModel> : IComponentModel<TDataModel> where TDataModel : IDataModel
    {
        TDomainModel DomainModel { get; }
    }
}
