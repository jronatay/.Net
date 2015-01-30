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
            return PopulateModelFromRequest(OrderRequestModel);
        }

        public List<EntityLibrary.OrderModels.OrderProductsInputModel> PopulateModelFromRequest(EntityLibrary.OrderModels.OrderRequestInputModel OrderInputRequest)
        {
            List<EntityLibrary.OrderModels.OrderProductsInputModel> OrderProductsModel = new List<EntityLibrary.OrderModels.OrderProductsInputModel>();
            for (int counter = 0; counter < OrderInputRequest.Id.Count(); counter++)
            {
                EntityLibrary.OrderModels.OrderProductsInputModel RequestedProduct = new EntityLibrary.OrderModels.OrderProductsInputModel();
                RequestedProduct.Id = OrderInputRequest.Id[counter];
                RequestedProduct.ProductName = OrderInputRequest.ProductName[counter];
                RequestedProduct.Description = OrderInputRequest.Description[counter];
                RequestedProduct.Quantity = OrderInputRequest.Quantity[counter];
                OrderProductsModel.Add(RequestedProduct);

            }
            return OrderProductsModel;

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
                return StoreProductsOnTemporaryStorage(OrderProductsInput);
            }
            return null;
        }

        public List<EntityLibrary.OrderModels.OrderProductsInputModel> StoreProductsOnTemporaryStorage(List<EntityLibrary.OrderModels.OrderProductsInputModel> OrderProductsRequestedInput)
        {
            List<EntityLibrary.OrderModels.OrderProductsInputModel> OrderProductsTemporaryStorage = new List<EntityLibrary.OrderModels.OrderProductsInputModel>();
            foreach (var Item in OrderProductsRequestedInput)
            {
                if (Item.Quantity > 0)
                {
                    OrderProductsTemporaryStorage.Add(PopulateTemporaryStorage(Item));
                }
            }
            return OrderProductsTemporaryStorage;
        }

        public EntityLibrary.OrderModels.OrderProductsInputModel PopulateTemporaryStorage(EntityLibrary.OrderModels.OrderProductsInputModel OrderProductsRequestedInput)
        {
            EntityLibrary.OrderModels.OrderProductsInputModel OrderProductsInput = new EntityLibrary.OrderModels.OrderProductsInputModel();
            OrderProductsInput.Id = OrderProductsRequestedInput.Id;
            OrderProductsInput.ProductName = OrderProductsRequestedInput.ProductName;
            OrderProductsInput.Description = OrderProductsRequestedInput.Description;
            OrderProductsInput.Quantity = OrderProductsRequestedInput.Quantity;
            return OrderProductsInput;
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
