CREATE FUNCTION [dbo].[fn_GetCategoryById]
(
	@catId bigint = null
)
RETURNS nvarchar(max)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @name nvarchar(max) = '';

	-- Add the T-SQL statements to compute the return value here
	SELECT @name = [Name] 
		FROM [dbo].[StockCategories]
		WHERE 
			[Id] = ISNULL(@catId, [Id]);
	
	-- Return the result of the function
	RETURN ISNULL(@name, 'Not Found');

END
