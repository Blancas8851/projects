select orders.order_id,customerTable.*, productTable.*,orders.order_date, orders.qty_ordered
 from orders 
  inner join customerTable on orders.cust_id = customerTable.cust_ID 
  inner join productTable on orders.product_id = productTable.product_Id
  where customerTable.cust_ID = 104;

  select * from orders
  select * from productTable
  select * from Logs
  select qty_ordered from orders where cust_id = 100 and order_id = 104

  select productTable.P_cost
            from orders 
            inner join customerTable on orders.cust_id = customerTable.cust_ID 
            inner join productTable on orders.product_id = productTable.product_Id 
            where customerTable.cust_ID = 100 and orders.order_id  = 104

select orders.order_id,orders.order_date,customerTable.f_name,customerTable.l_name ,productTable.P_name,productTable.product_desc,productTable.P_cost, orders.qty_ordered,qty_ordered *productTable.P_cost AS total_cost
 from orders 
  inner join customerTable on orders.cust_id = customerTable.cust_ID 
  inner join productTable on orders.product_id = productTable.product_Id
     where customerTable.cust_ID = 100 and orders.order_id  = 104