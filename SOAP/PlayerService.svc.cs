using AppService.DTOs;
using AppService.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SOAP
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PlayerService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PlayerService.svc or PlayerService.svc.cs at the Solution Explorer and start debugging.
    public class PlayerService : IPlayerService
    {
        private PlayerManagementService playerManagementService = new PlayerManagementService();

        public List<PlayerDTO> GetAllPlayers()
        {
            return playerManagementService.GetAll();
        }

        public PlayerDTO GetPlayerById(int id)
        {
            return playerManagementService.GetById(id);
        }

        public string PostPlayer(PlayerDTO playerDTO)
        {
            if (playerManagementService.Save(playerDTO))
            {
                return "Player added!";
            }
            else
            {
                return "Player was not added!";
            }
        }
        public string PutPlayer(PlayerDTO playerDTO)
        {
            if (playerManagementService.Save(playerDTO))
            {
                return "Player updated!";
            }
            else
            {
                return "Player was not updated!";
            }
        }

        public string DeletePlayer(int id)
        {
            if (playerManagementService.Delete(id))
            {
                return "Player deleted!";
            }
            else
            {
                return "Player was not deleted!";
            }
        }
    }
}
