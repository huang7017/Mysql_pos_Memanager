DROP TABLE IF EXISTS orderForm;
CREATE TABLE  orderForm
(
  orderNumber INT auto_increment NOT NULL,
  commodity CHAR(50) NOT NULL,
  PurchaseCost INT NOT NULL,
  OrderQuantity INT NOT NULL,
  orderDate datetime NOT NULL,
  PRIMARY KEY (orderNumber)
);

DROP TABLE IF EXISTS inventory;
create table inventory
(
  commodityNumber INT auto_increment NOT NULL,
  commodity CHAR(50) NOT NULL,
  commodityCost INT NOT NULL,
  commodityQuantity INT NOT NULL,
  PRIMARY KEY (commodityNumber)
);

DROP TABLE IF EXISTS QuantitySale;
create table QuantitySale
(
  commodityNumber INT auto_increment NOT NULL,
  commodity CHAR(50) NOT NULL,
  SaleCost INT NOT NULL,
  QuantitySale INT NOT NULL,
  SaleDate datetime NOT NULL,
  PRIMARY KEY (commodityNumber)
);

delimiter ||
DROP TRIGGER IF EXISTS tg1_insert_inventory ||
create trigger tg1_insert_inventory
after
insert
on orderForm  
for each row
begin
insert into inventory (commodity,commodityCost,commodityQuantity)
VALUES(new.commodity, new.PurchaseCost+20, new.OrderQuantity);
end ||
delimiter ;

delimiter ||
DROP TRIGGER IF EXISTS tg1_update_inventory ||
create trigger tg1_update_inventory
after
update
on orderForm
for each row
begin
update inventory set commodity = new.commodity,commodityCost = new.PurchaseCost+30 , commodityQuantity = new.OrderQuantity
where commodityNumber = new.orderNumber; 
end ||
delimiter ;

delimiter ||
DROP TRIGGER IF EXISTS tg1_delete_inventory ||
create 
trigger tg1_delete_inventory
after delete
on orderForm
for each row
begin
delete from inventory where commodityNumber = old.orderNumber; 
end ||
delimiter ;

delimiter ||
DROP TRIGGER IF EXISTS tg1_update_QuantitySale ||
create trigger tg1_update_QuantitySale
after
update
on inventory
for each row
begin
SET SQL_SAFE_UPDATES=0;
insert into QuantitySale(commodity,SaleCost,QuantitySale,SaleDate)
values(new.commodity,new.commodityCost,old.commodityQuantity-new.commodityQuantity,CURTiME()); 
SET SQL_SAFE_UPDATES=1;
end ||
delimiter ;

INSERT into orderForm (commodity, PurchaseCost, OrderQuantity,orderDate)
VALUES ('奶茶', '10', '50',20200516), 
	    ('奶茶', '10', '50',20200516), 
       ('可樂', '15', '50',20200516),
       ('奶綠', '15', '50',20200517), 
       ('紅茶', '10', '50',20200518), 
       ('綠茶', '10', '50',20200518), 
	    ('烏龍', '10', '50',20200517), 
       ('豆漿', '15', '50',20200517),
       ('巧克力', '15', '50',20200518), 
	    ('冬瓜茶', '15', '50',20200518), 
       ('咖啡', '15', '50',20200518),
		('巧克力', '15', '50',20200518), 
       ('薑母茶', '15', '25',20200518);
       
#update inventory set commodityQuantity = commodityQuantity - 2 where commodityNumber = 1; 
       
	