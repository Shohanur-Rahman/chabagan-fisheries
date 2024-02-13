CREATE PROCEDURE [dbo].[sp_GetProductNameWithStock]
	@productId bigint = null,
	@brandId bigint = null
AS
BEGIN
	
	SET NOCOUNT ON;
	select 
		Id, 
		Name, 
		[dbo].[fn_GetStockByProductId](id,@brandId) as Stock 
	from [dbo].[Products] 
	where 
		[IsDeleted] = 0
		and Id= ISNULL(@productId, Id)
END