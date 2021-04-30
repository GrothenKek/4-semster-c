using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MyServiceLibrary {
    
    public class MyService : IMyService {

        public int Sum(int a, int b) {
            return a + b;
        }

        public int Product(int a, int b) {
            return a * b;
        }

        public int SumOfAllToN(int n) {
            return (n * (n + 1)) / 2;
        }

        public MyCompositeType GetDataUsingDataContract(MyCompositeType composite) {
            if (composite == null) {
                throw new ArgumentNullException("composite");
            }

            // Do strange stuff to float
            float f = composite.MyFloatValue;
            if (f <= 2)
                composite.MyFloatValue = 2;
            else
                composite.MyFloatValue = f*f;

            // Do strange stuff to string
            if (composite.MyStringValue is null)
                composite.MyStringValue = "";
            if (composite.MyStringValue == "")
                composite.MyStringValue = "<empty>";

            composite.MyStringValue = "MyService_processed(" + composite.MyStringValue + "," + f + ")";
            
            return composite;
        }

        
    }
}
