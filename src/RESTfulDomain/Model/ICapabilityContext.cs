namespace RESTfulDomain.Model
{
    public interface ICapabilityContext<out TDataModel> where TDataModel : class, IDataModel
    {
        TDataModel Data { get; }
    }
}
