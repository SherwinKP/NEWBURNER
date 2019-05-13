using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CDBurnerService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(SessionMode=SessionMode.Allowed,CallbackContract =typeof(MyCallBackHandler))]
    public interface IService1
    {
        [OperationContract(IsOneWay =true)]
        void BurnCD();
    }
    public interface MyCallBackHandler
    {
        [OperationContract(IsOneWay = true)]
        void CDBurnt();

      

        /////////////////////////Need to add more operation contracts here
    }
}
