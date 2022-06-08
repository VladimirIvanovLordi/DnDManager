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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CampaignService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CampaignService.svc or CampaignService.svc.cs at the Solution Explorer and start debugging.
    public class CampaignService : ICampaignService
    {
        private CampaignManagementService campaignManagementService = new CampaignManagementService();

        public List<CampaignDTO> GetAllCampaigns()
        {
            return campaignManagementService.GetAll();
        }

        public CampaignDTO GetCampaignById(int id)
        {
            return campaignManagementService.GetById(id);
        }

        public string PostCampaign(CampaignDTO campaignDTO)
        {
            if (campaignManagementService.Save(campaignDTO))
            {
                return "Campaign added!";
            }
            else
            {
                return "Campaign was not added!";
            }
        }

        public string PutCampaign(CampaignDTO campaignDTO)
        {
            if (campaignManagementService.Save(campaignDTO))
            {
                return "Campaign updated!";
            }
            else
            {
                return "Campaign was not updated!";
            }
        }

        public string DeleteCampaign(int id)
        {
            if (campaignManagementService.Delete(id))
            {
                return "Campaign deleted!";
            }
            else
            {
                return "Campaign was not deleted!";
            }
        }
    }
}
