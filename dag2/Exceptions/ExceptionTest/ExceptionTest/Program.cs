using System;

namespace ExceptionTest
{
    class TestExceptions
    {
        private void myMethodewithError(int num = 0)
        {
            Console.WriteLine("Throws exception");
            throw new Exception();

        }
        public void MyNormalMethod(int num = 0)
        {
            try
            {
                myMethodewithError();
            }
            catch (Exception e)
            {
                Console.WriteLine("exception caught", e);
            }
            finally
            {
                Console.WriteLine("done");

            }

        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            TestExceptions test = new TestExceptions();
            test.MyNormalMethod();
           
        }
    }
}
