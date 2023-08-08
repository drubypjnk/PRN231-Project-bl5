create database PRN231_BL5
go
use PRN231_BL5
go
CREATE TABLE [Order_Type] (
  [order_type_id] int primary key IDENTITY(1,1),
  [name] text,
  [desc] text,
  [create_date] Datetime,
  [delete_flag] bit
);

CREATE TABLE [User] (
  [user_id] int primary key IDENTITY(1,1),
  [username] text,
  [password] text,
  [full_name] text,
  [description] text,
  [age] int,
  [gender] int,
  [location] text,
  [email] text,
  [status] int,
  [avatar] text,
  [is_private] bit,
  [delete_flag] bit
);

CREATE TABLE [Order] (
  [order_id] int primary key IDENTITY(1,1),
  [user_id] int not null,
  [order_type_id] int not null,
  [create_date] Datetime,
  [total_price] float,
  [update_date] Datetime,
  [delete_flag] bit,
  CONSTRAINT [FK_Order.user_id]
    FOREIGN KEY ([user_id])
      REFERENCES [User]([user_id]),
  CONSTRAINT [FK_Order.order_type_id]
    FOREIGN KEY ([order_type_id])
      REFERENCES [Order_Type]([order_type_id])
);

CREATE TABLE [Category] (
  [category_id] int primary key IDENTITY(1,1),
  [name] text,
  [desc] text,
  [delete_flag] text,
  [position_id] int not null
);

CREATE TABLE [Product] (
  [product_id] int primary key IDENTITY(1,1),
  [category_id] int ,
  [delete_flag] bit,
  CONSTRAINT [FK_Product.category_id]
    FOREIGN KEY ([category_id])
      REFERENCES [Category]([category_id])
);

CREATE TABLE [Skus] (
  [sku_id] int primary key,
  [desc] text,
  [total_price] float,
  [approve_date] Datetime,
  [create_date] Datetime,
  [create_by] text,
  [update_date] Datetime,
  [delete_flag] bit
);

CREATE TABLE [Product_variants] (
  [product_variant_id] int primary key IDENTITY(1,1),
  [product_id] int not null,
  [unit_price] int,
  [quality] int,
  [create_date] Datetime,
  [update_date] DateTime,
  [create_by] text,
  [unit_in_stock] int,
  [unit_in_order] int,
  [sku_id] int not null,
  [delete_flag] bit,
  CONSTRAINT [FK_Product_variants.product_id]
    FOREIGN KEY ([product_id])
      REFERENCES [Product]([product_id]),
  CONSTRAINT [FK_Product_variants.sku_id]
    FOREIGN KEY ([sku_id])
      REFERENCES [Skus]([sku_id])
);

CREATE TABLE [Order_detail] (
  [order_id] int  ,
  [product_variant_id] int ,
  [quantity] int,
  [price] float,
  [is_delete] bit,
  CONSTRAINT [FK_Order_detail.order_id]
    FOREIGN KEY ([order_id])
      REFERENCES [Order]([order_id]),
  CONSTRAINT [FK_Order_detail.product_variant_id]
    FOREIGN KEY ([product_variant_id])
      REFERENCES [Product_variants]([product_variant_id])
);

CREATE TABLE [Positions] (
  [position_id] int primary key,
  [address] text,
  [desc] text,
  [delete_flag] bit
);

CREATE TABLE [Activity] (
  [history_id] int primary key,
  [user_id] int not null,
  [create_date] DateTime,
  [desc] text,
  [delete_flag] bit,
  CONSTRAINT [FK_Activity.user_id]
    FOREIGN KEY ([user_id])
      REFERENCES [User]([user_id])
);

CREATE TABLE [Sub_position] (
  [sub_position_id] int primary key,
  [product_variant_id] int not null,
  [address] text,
  [desc] text,
  [position_id] int not null,
  [delete_flag] bit,
  CONSTRAINT [FK_Sub_position.position_id]
    FOREIGN KEY ([position_id])
      REFERENCES [Positions]([position_id])
);

CREATE TABLE [Product_variants_sub_position_relation] (
  [sub_position_id] int not null,
  [product_variant_id] int not null,
  [delete_flag] bit,
  CONSTRAINT [FK_Product_variants_sub_position_relation.sub_position_id]
    FOREIGN KEY ([sub_position_id])
      REFERENCES [Sub_position]([sub_position_id]),
  CONSTRAINT [FK_Product_variants_sub_position_relation.product_variant_id]
    FOREIGN KEY ([product_variant_id])
      REFERENCES [Product_variants]([product_variant_id])
);

CREATE TABLE [Notes] (
  [note_id] int primary key,
  [create_by] int not null,
  [order_id] int not null,
  [create_date] DateTime,
  [content] text,
  [delete_flag] bit,
  CONSTRAINT [FK_Notes.order_id]
    FOREIGN KEY ([order_id])
      REFERENCES [Order]([order_id]),
  CONSTRAINT [FK_Notes.create_by]
    FOREIGN KEY ([create_by])
      REFERENCES [User]([user_id])
);

