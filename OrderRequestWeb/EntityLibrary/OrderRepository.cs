using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EntityLibrary
{
    public class OrderRepository
    {
         private OrderRequestEntities db;
         public OrderRepository(OrderRequestEntities db)
        {
            this.db = db;
        }
        public List<OrderProduct> OrderProductList()
        {
            return db.OrderProducts.ToList();
        }
        public List<OrderModels.OrderProductsInputModel> PopulateOrderProductInputModel(List<OrderProduct> OrderProducts)
        {
            List<OrderModels.OrderProductsInputModel> OrderProductInputLists = new List<OrderModels.OrderProductsInputModel>();
           
            OrderProducts = OrderProductList();
            foreach (var OrderProductsItem in OrderProducts)
            {
                OrderModels.OrderProductsInputModel OrderProductInputModel = new OrderModels.OrderProductsInputModel();
                OrderProductInputModel.Id = OrderProductsItem.Id;
                OrderProductInputModel.ProductName = OrderProductsItem.ProductName;
                OrderProductInputModel.Description = OrderProductsItem.Description;
                OrderProductInputModel.Quantity = 0;
                OrderProductInputLists.Add(OrderProductInputModel);
            }
            return OrderProductInputLists;
        }

        public List<OrderModels.OrderProductsInputModel> PopulateModelFromRequest(OrderModels.OrderRequestInputModel OrderInputRequest)
        {
            List<OrderModels.OrderProductsInputModel> OrderProductsModel = new List<OrderModels.OrderProductsInputModel>();
            for(int counter=0; counter<OrderInputRequest.Id.Count();counter++)
            {
                OrderModels.OrderProductsInputModel RequestedProduct = new OrderModels.OrderProductsInputModel();
                RequestedProduct.Id=OrderInputRequest.Id[counter];
                RequestedProduct.ProductName=OrderInputRequest.ProductName[counter];
                RequestedProduct.Description=OrderInputRequest.Description[counter];
                RequestedProduct.Quantity=OrderInputRequest.Quantity[counter];
                OrderProductsModel.Add(RequestedProduct);
               
            }
            return OrderProductsModel;
            
        }
        public List<OrderModels.OrderProductsInputModel> OrderProductInputList()
        {
            return PopulateOrderProductInputModel(OrderProductList());
        }




        public List<OrderModels.OrderProductsInputModel> PopulateOrderProductsModel(List<OrderModels.OrderProductsInputModel> OrderProductsInputModel)
        {
            List<OrderModels.OrderProductsInputModel> TemporaryOrderRequest = new List<OrderModels.OrderProductsInputModel>();
            foreach (var OrderProductInput in OrderProductsInputModel)
            {
                OrderModels.OrderProductsInputModel OrderProducts = new OrderModels.OrderProductsInputModel();
                OrderProducts.Id = OrderProductInput.Id;
                OrderProducts.ProductName = OrderProductInput.ProductName;
                OrderProducts.Description = OrderProductInput.Description;
                OrderProducts.Quantity = OrderProductInput.Quantity;
                TemporaryOrderRequest.Add(OrderProducts);
            }
            return TemporaryOrderRequest;
        }
       
         public OrderModels.OrderProductsInputModel PopulateTemporaryStorage(OrderModels.OrderProductsInputModel OrderProductsRequestedInput)
        {
            OrderModels.OrderProductsInputModel OrderProductsInput =  new OrderModels.OrderProductsInputModel();
            OrderProductsInput.Id = OrderProductsRequestedInput.Id;
            OrderProductsInput.ProductName = OrderProductsRequestedInput.ProductName;
            OrderProductsInput.Description = OrderProductsRequestedInput.Description;
            OrderProductsInput.Quantity = OrderProductsRequestedInput.Quantity;
            return OrderProductsInput;
        }
         public List<OrderModels.OrderProductsInputModel> StoreProductsOnTemporaryStorage(List<OrderModels.OrderProductsInputModel> OrderProductsRequestedInput)
         {
             List<OrderModels.OrderProductsInputModel> OrderProductsTemporaryStorage = new List<OrderModels.OrderProductsInputModel>();
             foreach (var Item in OrderProductsRequestedInput)
             {
                 if (Item.Quantity > 0)
                 {
                     OrderProductsTemporaryStorage.Add(PopulateTemporaryStorage(Item));
                 }
             }
             return OrderProductsTemporaryStorage;
         }
        public List<OrderModels.OrderProductsInputModel> TemporaryStoredOrderProducts(List<OrderModels.OrderProductsInputModel> StoredOrderProducts)
        {
            return StoreProductsOnTemporaryStorage(StoredOrderProducts);
        }

    }
}
