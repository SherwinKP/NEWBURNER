using System;
using System.ServiceModel;
using IMAPI2.Interop;

namespace CDBurnerService
{
    public class Service1 : IService1
    {
        public void BurnCD()
        {
           
            #region CD WRITING
            MsftDiscMaster2 discMaster = null;
            discMaster = new MsftDiscMaster2();
            String path = "D://hello2.txt";
            Console.WriteLine("Writing to the disc");
            if (!discMaster.IsSupportedEnvironment)
                return;
            foreach (string uniqueRecorderId in discMaster)
            {
                var discRecorder2 = new MsftDiscRecorder2();
                discRecorder2.InitializeDiscRecorder(uniqueRecorderId);
                MsftDiscFormat2Data datawriter = new MsftDiscFormat2Data();
                datawriter.Recorder = discRecorder2;
                datawriter.ClientName = "IMAPIv2 TEST";
                MsftFileSystemImage FSI = new MsftFileSystemImage();
                try
                {
                    if (!datawriter.MediaHeuristicallyBlank)
                    {
                        FSI.MultisessionInterfaces = datawriter.MultisessionInterfaces;
                        FSI.ImportFileSystem();
                    }
                }
                catch (Exception)
                {
                    FSI.ChooseImageDefaults(discRecorder2);
                    Console.WriteLine("Multisession is not supported on this disk!");
                }
                try
                {
                    FSI.Root.AddTree(path, false);
                    IFileSystemImageResult Result = FSI.CreateResultImage();
                    var stream = Result.ImageStream;
                    Console.WriteLine("\nWriting to disc now!!");
                    datawriter.Write(stream);
                    Console.WriteLine("\nWrite Process completed!");
                }
                catch (Exception)
                {
                    Console.WriteLine("Unable to form image from given path!");
                    Console.WriteLine("\nAborted process!");
                }
             
                    discRecorder2.EjectMedia();
            }
            #endregion
            OperationContext.Current.GetCallbackChannel<MyCallBackHandler>().CDBurnt();

        }
        
    }
}
