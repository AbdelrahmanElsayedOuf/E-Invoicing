using System.Net;

namespace Amazon_Tours.Utilities.ApiResponses.Interfaces
{
    public interface IApiResponse<T>
    {
        public bool Success { get; }
        public T Data { get; set; }
    }

    public interface ISingleMessage
    {
        public string Message { get; set; }
    }

    public interface IMultipleMessages
    {
        public IEnumerable<string> Messages { get; set; }
    }
}
