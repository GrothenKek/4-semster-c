using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceAndClientTest
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            Random random = new Random();
            int target = 60;
            bool found = false;


            if (value == target)
            {
                return string.Format("You entered: {0}, and it is correct", value);
            }

            if (value > target)
            {
                return string.Format("You entered: {0}, and it is bigger than the correct answer", value);
            }
            if (value < target)
            {
                return string.Format("You entered: {0}, and it is smaller than the correct answer", value);
            }

            return "nice";
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

       


    
    }
}
