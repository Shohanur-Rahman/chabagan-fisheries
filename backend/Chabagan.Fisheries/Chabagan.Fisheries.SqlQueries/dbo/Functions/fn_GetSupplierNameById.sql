CREATE FUNCTION [dbo].[fn_GetSupplierNameById]
(
	@supplierId bigint
)
RETURNS nvarchar(max)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @name nvarchar(max);

	-- Add the T-SQL statements to compute the return value here
	SELECT @name = Name from [dbo].[Suppliers] where Id = @supplierId;

	-- Return the result of the function
	RETURN ISNULL(@name, 'Not Found');

END