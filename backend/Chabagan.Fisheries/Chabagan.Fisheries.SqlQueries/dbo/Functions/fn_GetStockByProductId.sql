CREATE FUNCTION [dbo].[fn_GetStockByProductId]
(
	@productId bigint
)
RETURNS float
AS
BEGIN
	-- Declare the return variable here
	DECLARE @purchaseQty float =0,
			@purchaseRtnQty float =0,
			@salesSubQty float = 0,
			@salesRtnSubQty float = 0,
			@result float = 0;

	-- Add the T-SQL statements to compute the return value here
	set @purchaseQty = (Select ISNULL(sum(qty),0) from [dbo].[PurchaseItems] where ProductID=@productId);
	set @purchaseRtnQty = (Select ISNULL(sum(qty),0) from [dbo].[PurchaseReturnItems] where ProductID=@productId);
	set @salesSubQty = (Select ISNULL(sum(qty),0) from [dbo].[SalesItems] where ProductID=@productId);
	set @salesRtnSubQty = (Select ISNULL(sum(qty),0) from [dbo].[SalesReturnItems] where ProductID=@productId);
	
	set @result = (@purchaseQty-@purchaseRtnQty-@salesSubQty+@salesRtnSubQty);
	
	-- Return the result of the function
	RETURN @result;

END
