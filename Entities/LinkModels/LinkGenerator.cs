using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Entities.LinkModels
{
    public abstract class LinkGenerator
    {
        [SuppressMessage("ApiDesign", "RS0026:Do not add multiple public overloads with optional parameters", Justification = "Required to maintain compatibility")]
        public abstract string? GetPathByAddress<TAddress>(
            HttpContext httpContext,
            TAddress address,
            RouteValueDictionary values,
            RouteValueDictionary? ambientValues = default,
            PathString? pathBase = default,
            FragmentString fragment = default,
            LinkOptions? options = default);

        [SuppressMessage("ApiDesign", "RS0026:Do not add multiple public overloads with optional parameters", Justification = "Required to maintain compatibility")]
        public abstract string? GetPathByAddress<TAddress>(
            TAddress address,
        RouteValueDictionary values,
            PathString pathBase = default,
            FragmentString fragment = default,
            LinkOptions? options = default);

        [SuppressMessage("ApiDesign", "RS0026:Do not add multiple public overloads with optional parameters", Justification = "Required to maintain compatibility")]
        public abstract string? GetUriByAddress<TAddress>(
            HttpContext httpContext,
            TAddress address,
            RouteValueDictionary values,
            RouteValueDictionary? ambientValues = default,
            string? scheme = default,
        HostString? host = default,
            PathString? pathBase = default,
            FragmentString fragment = default,
            LinkOptions? options = default);

        [SuppressMessage("ApiDesign", "RS0026:Do not add multiple public overloads with optional parameters", Justification = "Required to maintain compatibility")]
        public abstract string? GetUriByAddress<TAddress>(
            TAddress address,
            RouteValueDictionary values,
            string scheme,
        HostString host,
            PathString pathBase = default,
            FragmentString fragment = default,
            LinkOptions? options = default);
    }

    public class LinkOptions
    {
        public bool? LowercaseUrls { get; set; }
        public bool? LowercaseQueryStrings { get; set; }
        public bool? AppendTrailingSlash { get; set; }
    }
}
