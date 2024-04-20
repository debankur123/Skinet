namespace API.Helper;

public class PaginationHelper<T> where T : class
{
    public PaginationHelper(int pageIndex,int pageSize,int count,IList<T> data)
    {
        PageIndex = pageIndex;
        PageSize  = pageSize;
        Count     = count;
        Data      = data;
    }
    public int PageIndex { get; set; }
    public int PageSize  { get; set; }
    public int Count     { get; set; }
    public IList<T> Data { get; set; }
}