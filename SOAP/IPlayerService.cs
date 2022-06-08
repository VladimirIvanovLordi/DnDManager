using AppService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SOAP
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPlayerService" in both code and config file together.
    [ServiceContract]
    public interface IPlayerService
    {
        [OperationContract]
        List<PlayerDTO> GetAllPlayers();
        [OperationContract]
        PlayerDTO GetPlayerById(int id);
        [OperationContract]
        string PostPlayer(PlayerDTO playerDTO);
        [OperationContract]
        string PutPlayer(PlayerDTO playerDTO);
        [OperationContract]
        string DeletePlayer(int id);
    }
}
