
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace RoutingExample.CustomConstraint
{
    public class MonthsCustomConstraint : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            //throw new NotImplementedException();
            if (!values.ContainsKey(routeKey))
            {
                return false;
            }

            Regex regex = new Regex("^(jan|feb|march|april)$");
            string? month = Convert.ToString(values[routeKey]);
            if (regex.IsMatch(month))
            {
                return true; //it's a match
            }
            return false;
        }
    }
}
