using Amazon_Tours.Utilities.ApiResponses.Interfaces;
using System.Net;

namespace Amazon_Tours.Utilities.ApiResponses
{
    public class SuccessResponse<T> : IApiResponse<T>, ISingleMessage
    {
        public bool Success { get; } = true;
        public T Data { get; set; } = default(T);
        public string Message { get; set; }
    }
}
