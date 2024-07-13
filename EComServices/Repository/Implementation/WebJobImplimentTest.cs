using EComServices.Repository.@interface;

namespace EComServices.Repository.Implementation
{
    public class WebJobImplimentTest : IWebJobTest
    {
        public string GetMessage()
        {
            string str = "Hi Web Job";
            return str;
            //throw new System.NotImplementedException();
        }
    }
}
