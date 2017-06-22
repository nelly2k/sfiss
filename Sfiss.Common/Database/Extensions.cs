using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace Sfiss.Common.Database
{
    public static class Extensions
    {
        public static StringBuilder AppendIf(this StringBuilder sb, bool condition, string str)
        {
            return !condition ? sb : sb.Append(str);
        }

        public static StringBuilder AppendNotNull(this StringBuilder sb, object conditionObject, string str, Action addParam)
        {

            if (conditionObject == null || conditionObject is string && string.IsNullOrEmpty(conditionObject.ToString()))
            {
                return sb;
            }
            sb.And();
            addParam?.Invoke();

            return sb.Append(str);
        }

        public static StringBuilder AppendNotNull(this StringBuilder sb, object conditionObject, string command, ExpandoObject dbParams, string paramName, object  paramValue)
        {
            if (conditionObject == null || conditionObject is string && string.IsNullOrEmpty(conditionObject.ToString()))
            {
                return sb;
            }

            if (conditionObject is IEnumerable<object> && !((IEnumerable<object>) conditionObject).Any())
            {
                return sb;
            }
            sb.And();
            
            (dbParams as IDictionary<string, object>)[paramName] = paramValue;

            return sb.Append(command);
        }

        public static StringBuilder AppendInAny(this StringBuilder sb, Func<string, string> getSql, string paramName, IEnumerable<int> inputParameters, ExpandoObject dbParameters)
        {
            if (inputParameters == null)
            {
                return sb;
            }
            var parameters = inputParameters.ToList();
            if (!parameters.Any())
            {
                return sb;
            }
            sb.And();
       
            sb.Append(getSql($"@{paramName}"));
            (dbParameters as IDictionary<string, object>)[paramName] = inputParameters;
            return sb;
        }

        public static StringBuilder And(this StringBuilder sb)
        {
            if (sb.Length > 0)
            {
                sb.Append(" AND ");
            }
            return sb;
        }

        public static StringBuilder Where(this StringBuilder sb)
        {
            if (sb.Length > 0)
            {
                sb.Append(" WHERE ");
            }
            return sb;
        }

        public static StringBuilder Pagination(this StringBuilder sb, SearchRequest request, bool use = true)
        {
            if (use && request.IsPaginated)
            {
                return sb.Append($"ORDER BY {request.OrderBy}")
                    .Append($"OFFSET {request.PageSize} * ({request.PageNumber} - 1) ROWS")
                    .Append($"FETCH NEXT {request.PageSize} ROWS ONLY");
            }

            return sb;
        }
    }
}
