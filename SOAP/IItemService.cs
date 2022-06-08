using AppService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SOAP
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IItemService" in both code and config file together.
    [ServiceContract]
    public interface IItemService
    {
        [OperationContract]
        List<ItemDTO> GetAllItems();
        [OperationContract]
        ItemDTO GetItemById(int id);
        [OperationContract]
        string PostItem(ItemDTO itemDTO);
        [OperationContract]
        string PutItem(ItemDTO itemDTO);
        [OperationContract]
        string DeleteItem(int id);
    }
}
