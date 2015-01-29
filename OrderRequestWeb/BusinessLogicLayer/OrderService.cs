using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using EntityLibrary;

namespace BusinessLogicLayer
{
    public class OrderService
    {
        private EntityLibrary.OrderRepository OrderRepository = new OrderRepository(new OrderRequestEntities());

        public IEnumerable<OrderProduct> OrderProductList()
        {
            return OrderRepository.OrderProductList();
        }
        public List<EntityLibrary.OrderModels.OrderProductsInputModel> OrderProductInputList()
        {
            return OrderRepository.OrderProductInputList();
        }
        public List<EntityLibrary.OrderModels.OrderProductsInputModel> PopulatedOrderProductFromRequest(EntityLibrary.OrderModels.OrderRequestInputModel OrderRequestModel)
        {
            return OrderRepository.PopulateModelFromRequest(OrderRequestModel);
        }
        public Boolean ValidateOrderRequestedInputs(List<EntityLibrary.OrderModels.OrderProductsInputModel> OrderProductsInput)
        {
            return true;
        }

        public Boolean IsThereAtleastOneOrder(List<EntityLibrary.OrderModels.OrderProductsInputModel> OrderProductsInput)
        {
            foreach (var Item in OrderProductsInput)
            {
                if (Item.Quantity > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public List<EntityLibrary.OrderModels.OrderProductsInputModel> ReturnStoredOrderProducts(List<EntityLibrary.OrderModels.OrderProductsInputModel> OrderProductsInput)
        {
            if (IsThereAtleastOneOrder(OrderProductsInput))
            {
                return OrderRepository.StoreProductsOnTemporaryStorage(OrderProductsInput);
            }
            return null;
        }
        public Boolean IsRequestedStoredInTemporaryStorage(List<EntityLibrary.OrderModels.OrderProductsInputModel> OrderProductsInput)
        {
            return ReturnStoredOrderProducts(OrderProductsInput) != null;
        }

       
        public List<EntityLibrary.OrderModels.OrderProductsInputModel> ReturnOrderProductsStored(List<EntityLibrary.OrderModels.OrderProductsInputModel> StoredOrderProducts)
        {
            if (IsRequestedStoredInTemporaryStorage(StoredOrderProducts))
            {
                return ReturnStoredOrderProducts(StoredOrderProducts);
            }
            return null;
        }
       
        
       
    }
}
