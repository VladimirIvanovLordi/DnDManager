using AppService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SOAP
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICampaignService" in both code and config file together.
    [ServiceContract]
    public interface ICampaignService
    {
        [OperationContract]
        List<CampaignDTO> GetAllCampaigns();
        [OperationContract]
        CampaignDTO GetCampaignById(int id);
        [OperationContract]
        string PostCampaign(CampaignDTO campaignDTO);
        [OperationContract]
        string PutCampaign(CampaignDTO campaignDTO);
        [OperationContract]
        string DeleteCampaign(int id);
    }
}
