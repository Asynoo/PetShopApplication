using bois.PetShopApplication.Core.IServices;

namespace bois.PetShop
{
    public class Printer
    {
        private IPetService _service;

        public Printer(IPetService service)
        {
            _service = service;
        }

        public void start()
        {
            
        }
    }
}