using RESTfulDomain.Model;
using System.Collections.Generic;
using System.Linq;

namespace RESTfulDomain
{
    public class DomainModel<TDataModel> : IDomainModel<TDataModel> where TDataModel : class, IDataModel
    {
        protected TDataModel _dataModel;

        protected List<ICapability<TDataModel>> _capabilities;

        public TDataModel DataModel => _dataModel;

        public IDataModelProvider<TDataModel> DataModelProvider { get; set; }

        public ICapabilityProvider<TDataModel> CapabilityProvider { get; set; }

        public IReadOnlyCollection<ICapability<TDataModel>> Capabilities => _capabilities;

        public DomainModel()
        {

        }

        public bool HasData() => _dataModel != null;

        public void LoadData<TId>(TId dataModelId) where TId : struct
        {
            _dataModel = DataModelProvider.GetById(dataModelId);
        }

        public void Unwrap()
        {
            _dataModel = null;
        }

        public void Wrap(TDataModel dataModel)
        {
            _dataModel = dataModel;
        }

        public TComponent GetCapability<TComponent>() where TComponent : class, ICapability<TDataModel>
        {
            return _capabilities.FirstOrDefault(comp => typeof(TComponent).IsAssignableFrom(comp.GetType())) as TComponent;
        }
    }
}
