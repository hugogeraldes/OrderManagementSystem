Users
- Id
- Username
- Password
- Timestamp // created at
- IsDeleted

Roles
- Id
- Name

UserRoles
- UserId
- RoleId

Products
- Id
- Name
- Price
- SKU
- StockQuantity
- CategoryId

Categories
- Id
- Name

ShoppingCart
-Id
- UserId
- CreatedAt

ShoppingCarProducts
- ShoppingCartId
- ProductId
- Quantity

Orders
- Id
- ShoppingCartId
- Timestamp // created at
- TotalPrice
- Status // e.g., Pending, Completed, Cancelled