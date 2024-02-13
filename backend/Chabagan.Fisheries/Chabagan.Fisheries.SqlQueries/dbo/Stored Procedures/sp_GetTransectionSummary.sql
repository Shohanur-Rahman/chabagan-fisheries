CREATE PROCEDURE [dbo].[sp_GetTransectionSummary]
	@supplierId bigint = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select 
	t.SupplierId as Id,
	[dbo].[fn_GetSupplierNameById](t.SupplierId) Supplier, 
	sum(t.PurchaseDuesAmount) PurchaseAmount, 
	sum(t.PurchaseReturnDuesAmount) PurchaseReturnAmount,
	(sum(t.PurchaseReturnDuesAmount)-sum(t.PurchaseDuesAmount)) as PurchaseDues,
	sum(t.SalesDuesAmount) SalesAmount, 
	sum(t.SalesReturnDuesAmount) SalesReturnAmount,
	(sum(t.SalesDuesAmount)-sum(t.SalesReturnDuesAmount)) as SalesDues,
	((sum(t.PurchaseReturnDuesAmount) + sum(t.SalesDuesAmount)) - (sum(t.PurchaseDuesAmount) + sum(t.SalesReturnDuesAmount))) as Balance
	from [dbo].[AccountTransections] t
	where t.SupplierId = ISNULL(@supplierId, t.SupplierId)
	group by t.SupplierId
END