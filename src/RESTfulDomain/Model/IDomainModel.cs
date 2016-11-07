using System.Collections.Generic;

namespace RESTfulDomain.Model
{
    public interface IDomainModel
    {
        void Unwrap();
    }

    public interface IDomainModel<TDataModel> : IDomainModel where TDataModel : class, IDataModel
    {
        TDataModel DataModel { get; }

        IReadOnlyCollection<ICapability<TDataModel>> Capabilities { get; }

        bool HasData();

        void Wrap(TDataModel dataModel);

        void LoadData<TId>(TId dataModelId) where TId : struct;

        TComponent GetCapability<TComponent>() where TComponent : class, ICapability<TDataModel>;
    }
}
