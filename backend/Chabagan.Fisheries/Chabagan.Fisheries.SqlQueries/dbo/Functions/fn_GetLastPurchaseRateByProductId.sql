CREATE FUNCTION [dbo].[fn_GetLastPurchaseRateByProductId]
(
	@productId bigint = null,
	@brandId bigint = null
)
RETURNS float
AS
BEGIN
	-- Declare the return variable here
	DECLARE @rate float =0;

	-- Add the T-SQL statements to compute the return value here
	SELECT @rate = [Rate] 
		FROM [dbo].[PurchaseReturnItems] 
		WHERE 
			[ProductId] = ISNULL(@productId, [ProductId]) and [BrandId] = ISNULL(@brandId, [BrandId]);
	
	-- Return the result of the function
	RETURN ISNULL(@rate, 0);

END