using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        List<Modelo.Fabricante> SelectFabricante();
        [OperationContract]
        void InsertFabricante(Modelo.Fabricante f);
        [OperationContract]
        void UpdateFabricante(Modelo.Fabricante f);
        [OperationContract]
        void DeleteFabricante(Modelo.Fabricante f);
        [OperationContract]
        List<Modelo.Veiculo> SelectVeiculo();
        [OperationContract]
        void DeleteVeiculo(Modelo.Veiculo v);
        [OperationContract]
        void InsertVeiculo(Modelo.Veiculo v);
        [OperationContract]
        void UpdateVeiculo(Modelo.Veiculo v);

    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.    
}
