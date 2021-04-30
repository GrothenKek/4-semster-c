using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// namespace has been renamed
// Service interface renamed
// Properties created and renamed
// IService1.cs renamed
// Service1.cs renamed
// Implemented GetDataUsingDataContract

namespace MyServiceLibrary {
    
    [ServiceContract]
    public interface IMyService {
        // sum and product of two integers
        [OperationContract]
        int Sum(int a, int b);

        [OperationContract]
        int Product(int a, int b);

        [OperationContract]
        int SumOfAllToN(int n);

        [OperationContract]
        MyCompositeType GetDataUsingDataContract(MyCompositeType composite);                
    }
        
    [DataContract]
    public class MyCompositeType {
        float floatValue = 0;        
        string stringValue = "";

        [DataMember]
        public float MyFloatValue {
            get { return floatValue; }
            set { floatValue = value; }
        }

        [DataMember]
        public string MyStringValue {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
