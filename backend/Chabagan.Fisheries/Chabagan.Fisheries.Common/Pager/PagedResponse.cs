namespace Chabagan.Fisheries.Common.Pager
{
    public class PagedResponse<T> 
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public T Data { get; set; }
        public PagedResponse(T data, int pageNumber, int pageSize, int total)
        {
            var reminder = ((double)total % (double)pageSize);
            int totalRecord = (total / pageSize);

            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.Data = data;
            this.TotalRecords = total;
            this.TotalPages = (reminder > 0) ? totalRecord + 1 : totalRecord;
        }
    }
}
