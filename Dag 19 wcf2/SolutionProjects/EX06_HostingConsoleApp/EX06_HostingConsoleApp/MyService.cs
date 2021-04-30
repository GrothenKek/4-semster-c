using System;
using System.Collections.Generic;
using System.IO;
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

        public List<string> GetLines(string filename) {

            if (filename is null)
                return null;

            List<string> lst = new List<string>();
            try {                
                using (var file = new StreamReader(filename)) {
                    string line;
                    while ((line = file.ReadLine()) != null) {
                        lst.Add(line);
                    }
                }                
            } catch(Exception e) {
                lst.Add(e.Message); // Goofy way to return errors, just to make use of test client easier:)                
            }
            return lst;
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
                composite.MyFloatValue = f * f;

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
