CREATE PROCEDURE [dbo].[sp_ResetTransections] 
	
AS
BEGIN
	-- reset purchase tables
	DELETE [dbo].[PurchaseItems];
	DELETE [dbo].[Purchases];
	-- reset purchase returns tables
	DELETE [dbo].[PurchaseReturnItems];
	DELETE [dbo].[PurchaseReturns];
	-- reset sales tables
	DELETE [dbo].[SalesItems];
	DELETE [dbo].[Sales];
	-- reset sales return tables
	DELETE [dbo].[SalesReturnItems];
	DELETE [dbo].[SalesReturns];
	-- reset transection table
	DELETE [dbo].[AccountTransections];
	--reset payment and collections
	DELETE [dbo].[PaymentCollections];
	-- reset income and expense
	DELETE [dbo].[Incomes];
	DELETE [dbo].[Expenses];
END