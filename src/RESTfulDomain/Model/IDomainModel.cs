using System.Collections.Generic;

namespace RESTfulDomain.Model
{
    public interface IDomainModel
    {
        void Unwrap();
    }

    public interface IDomainModel<TDataModel> : IDomainModel where TDataModel : class, IDataModel
    {
        TDataModel Data { get; }

        IReadOnlyCollection<IComponentModel<TDataModel>> Capabalities { get; }

        bool HasData();

        void Wrap(TDataModel dataModel);

        void LoadData(int dataModelId);

        void LoadData<TId>(TId dataModelId) where TId : struct;

        TComponent GetCapability<TComponent>() where TComponent : class, IComponentModel<TDataModel>;
    }

    public interface IDomainModel<TDomainModel, TDataModel> : IDomainModel<TDataModel>
        where TDataModel : class, IDataModel
        where TDomainModel : class, IDomainModel<TDataModel>
    {
        new IReadOnlyCollection<IComponentModel<TDomainModel, TDataModel>> Capabalities { get; }

        new IComponentModel<TDomainModel, TDataModel> GetCapability<TComponent>()
            where TComponent : IComponentModel<TDomainModel, TDataModel>;
    }
}
