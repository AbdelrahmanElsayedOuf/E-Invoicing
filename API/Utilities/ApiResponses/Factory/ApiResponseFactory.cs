using Amazon_Tours.Utilities.ApiResponses.Interfaces;
using System.Net;

namespace Amazon_Tours.Utilities.ApiResponses.Factory
{
    public static class ApiResponseFactory<T>
    {
        public static IApiResponse<T> SuccessResponse(T data, string message = null)
        {
            return new SuccessResponse<T>() { Data = data, Message = message ?? "Successfull Request!" };
        }

        public static IApiResponse<T> FailureResponse(IEnumerable<string> messages)
        {
            return new FailureResponse<T>() { Messages = messages };
        }

        public static IApiResponse<T> ErrorResponse(IEnumerable<string> messages)
        {
            return new ErrorResponse<T>() { Messages = messages };
        }

        public static IApiResponse<T> NotFoundResponse(string message)
        {
            return new NotFoundResponse<T>() { Message = message ?? "Not Found" };
        }
    }
}
