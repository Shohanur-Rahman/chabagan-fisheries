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

	sum(t.PurchaseNetAmount) PurchaseAmount, 
	sum(t.PurchasePaidAmount) PurchasePaidAmount, 
	(sum(t.PurchaseNetAmount)-sum(t.PurchasePaidAmount)) as PurchaseDues,

	sum(t.PurchaseReturnNetAmount) PurchaseReturnAmount,
	sum(t.PurchaseReturnPaidAmount) PurchaseReturnPaidAmount,
	(sum(t.PurchaseReturnNetAmount)-sum(t.PurchaseReturnPaidAmount)) as PurchaseReturnDues,

	sum(t.SalesNetAmount) SalesAmount, 
	sum(t.SalesPaidAmount) SalesPaidAmount,
	(sum(t.SalesNetAmount)-sum(t.SalesPaidAmount)) as SalesDues,

	sum(t.SalesReturnNetAmount) SalesReturnAmount,
	sum(t.SalesReturnPaidAmount) SalesReturnPaidAmount,
	(sum(t.SalesReturnNetAmount)-sum(t.SalesReturnPaidAmount)) as SalesReturnDues,

	(
		(
			(sum(t.PurchaseNetAmount)-sum(t.PurchasePaidAmount)) 
			+ 
			(sum(t.SalesReturnNetAmount)-sum(t.SalesReturnPaidAmount))
		)
		-
		(
			(sum(t.SalesNetAmount)-sum(t.SalesPaidAmount))
			+
			(sum(t.PurchaseReturnNetAmount)-sum(t.PurchaseReturnPaidAmount))
		)
	) as Balance
	
	from [dbo].[AccountTransections] t
	where t.SupplierId = ISNULL(@supplierId, t.SupplierId)
	group by t.SupplierId
END