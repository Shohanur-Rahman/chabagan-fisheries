CREATE FUNCTION [dbo].[fn_GetStockByProductId]
(
	@productId bigint = null,
	@brandId bigint = null
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
	set @purchaseQty = (Select ISNULL(sum(qty),0) from [dbo].[PurchaseItems] where ProductID=@productId and BrandId=ISNULL(@brandId,BrandId));
	set @purchaseRtnQty = (Select ISNULL(sum(qty),0) from [dbo].[PurchaseReturnItems] where ProductID=@productId and BrandId=ISNULL(@brandId,BrandId));
	set @salesSubQty = (Select ISNULL(sum(qty),0) from [dbo].[SalesItems] where ProductID=@productId and BrandId=ISNULL(@brandId,BrandId));
	set @salesRtnSubQty = (Select ISNULL(sum(qty),0) from [dbo].[SalesReturnItems] where ProductID=@productId and BrandId=ISNULL(@brandId,BrandId));
	
	set @result = (@purchaseQty-@purchaseRtnQty-@salesSubQty+@salesRtnSubQty);
	
	-- Return the result of the function
	RETURN @result;

END
