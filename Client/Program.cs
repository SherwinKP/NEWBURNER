using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.DemoProxy;
using System.ServiceModel;
using System.Threading;

namespace Client
{
    class MyClass : IService1Callback
    {
        public void CDBurnt()
        {
            Console.WriteLine("The CD is burnt!");
        }
       
    }
    class Program
    {
        static void Main(string[] args)
        {
            InstanceContext ins = new InstanceContext(new MyClass());
            Service1Client x = new Service1Client(ins);
            Console.WriteLine("Today we will burn a disk!");
            x.BurnCD();
            Console.ReadLine();
        }
    }
}
