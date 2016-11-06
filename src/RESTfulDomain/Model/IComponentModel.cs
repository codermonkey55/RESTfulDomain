namespace RESTfulDomain.Model
{
    public interface IComponentModel
    {

    }

    public interface IComponentModel<out TDataModel> : IComponentModel where TDataModel : IDataModel
    {
        TDataModel Data { get; }
    }

    public interface IComponentModel<out TDomainModel, out TDataModel> : IComponentModel<TDataModel> where TDataModel : IDataModel
    {
        TDomainModel Model { get; }
    }
}
