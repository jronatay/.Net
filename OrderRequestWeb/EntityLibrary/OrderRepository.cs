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
        private OrderProduct OrderProduct;
        private Order Order;
        private OrderItem OrderItem;
         public OrderRepository(OrderRequestEntities db)
        {
            this.db = db;
            this.OrderProduct = new OrderProduct();
        }
        public List<OrderProduct> OrderProductList()
        {
            return db.OrderProducts.ToList();
        }
        public List<OrderModels.OrderProductsInputModel> OrderProductInputList()
        {
            return PopulateOrderProductInputModel(OrderProductList());
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

        #region Add Order to Database 

        public int AddOrderRequestAndReturnGeneratedID(int CustomerId)
        {
           
            Order = new Order();
            Order.CreationDate = DateTime.Now.ToUniversalTime();
            Order.CustomerId = CustomerId;
            db.Orders.Add(Order);
            db.SaveChanges();
            return Order.Id;

        }

        

        public int AddOtherProductAndReturnGeneratedID(OrderModels.OrderProductsInputModel OtherRequestProduct)
        {
            OrderProduct = new OrderProduct();
            AddOtherProduct(OtherRequestProduct);
            return OrderProduct.Id;
        }
        public void AddOtherProduct(OrderModels.OrderProductsInputModel OtherRequestProduct)
        {
            OrderProduct = new OrderProduct();
            OrderProduct = PopulateOrderProductByRequestProduct(OtherRequestProduct);
            db.OrderProducts.Add(OrderProduct);
            db.SaveChanges();
        }

        public OrderProduct PopulateOrderProductByRequestProduct(OrderModels.OrderProductsInputModel OtherRequestProduct)
        {
            OrderProduct = new OrderProduct();
            OrderProduct.ProductName = OtherRequestProduct.ProductName;
            OrderProduct.Description = OtherRequestProduct.Description;
            return OrderProduct;
        }

        public void AddOrderItems(OrderItem OrderItems)
        {
            OrderItems = new OrderItem();
            db.OrderItems.Add(OrderItems);
            db.SaveChanges();
        }
        public Order OrderConfirmation(int OrderNo)
        {
            var result = db.Orders.Where(Order => Order.Id == OrderNo).First();
            return result;
        }

        #endregion



    }
}
