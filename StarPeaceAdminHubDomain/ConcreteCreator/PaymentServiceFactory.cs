using StarPeaceAdminHubDomain.ConcreteProduct;
using StarPeaceAdminHubDomain.ProductInterface;

namespace StarPeaceAdminHubDomain.ConcreteCreator
{

    public class PaymentServiceFactory
    {
        public enum ServicesAvailable
        {
            Botswana = 0,
            Lesotho = 1,
            Swaziland = 2
        }


        public IPaymentService Create(ServicesAvailable operation)
        {
            IPaymentService result;
            if (operation == ServicesAvailable.Botswana)
                result = new BotswanaPaymentService();
            
            if (operation == ServicesAvailable.Botswana)
                result = new BotswanaPaymentService();
            else
                result = new BrazilianPaymentService();
            return result;
        }
    }
}
