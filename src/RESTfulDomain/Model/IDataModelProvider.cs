namespace RESTfulDomain.Model
{
    public interface IDataModelProvider<out TDataModel> where TDataModel : class, IDataModel
    {
        TDataModel GetById(object dataModelId);
    }
}
