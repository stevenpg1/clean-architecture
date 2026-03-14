namespace CleanTeeth.API.Utilities
{
    public static class HttpContextExtensions
    {
        public static void InsertPaginationInformationHeader(this HttpContext httpContext, int recordCount)
        {
            httpContext.Response.Headers.Append("record-count", recordCount.ToString());
        }
    }
}
