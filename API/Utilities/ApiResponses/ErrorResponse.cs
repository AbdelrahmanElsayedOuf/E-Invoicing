using Amazon_Tours.Utilities.ApiResponses.Interfaces;
using System.Net;

namespace Amazon_Tours.Utilities.ApiResponses
{
    public class ErrorResponse<T> : IApiResponse<T>, IMultipleMessages
    {
        public bool Success { get; set; } = false;
        public T Data { get; set; } = default(T);
        public IEnumerable<string> Messages { get; set; }
    }
}
