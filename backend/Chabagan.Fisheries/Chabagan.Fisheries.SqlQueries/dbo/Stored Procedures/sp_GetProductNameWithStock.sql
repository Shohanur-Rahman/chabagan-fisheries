CREATE PROCEDURE [dbo].[sp_GetProductNameWithStock]

AS
BEGIN
	
	SET NOCOUNT ON;
	select 
		Id, 
		Name, 
		[dbo].[fn_GetStockByProductId](id) as Stock 
	from [dbo].[Products] 
	where 
		[IsDeleted] = 0
END