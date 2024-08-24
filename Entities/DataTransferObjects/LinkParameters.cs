using Entities.RequestFeatures;
using Microsoft.AspNetCore.Http;

namespace Entities.DataTransferObjects
{
    public record class LinkParameters
    {
        public BookParameters? BookParameters { get; init; }
        public HttpContext? HttpContext { get; init; }
    }
}
