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

        IReadOnlyCollection<IComponentModel> Capabalities { get; }

        bool HasData();

        void Wrap(TDataModel dataModel);

        void LoadData(int dataModelId);

        IComponentModel<TDataModel> GetCapability<TComponent>() where TComponent : IComponentModel<TDataModel>;
    }

    public interface IDomainModel<TDomainModel, TDataModel> : IDomainModel<TDataModel> where TDataModel : class, IDataModel
    {
        IComponentModel<TDomainModel, TDataModel> GetCapability<TComponent>(TDataModel dataModel = null)
            where TComponent : IComponentModel<TDomainModel, TDataModel>;
    }
}
