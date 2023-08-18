using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Api.Business.common.extension
{
    public static class OrderByPropertyOrFieldExt
    {
        /// <summary>
        ///ordena los datos por  campo
        /// </summary>
        /// <typeparam name="T">la tabla</typeparam>
        /// <param name="queryable">la consulta</param>
        /// <param name="propertyOrFieldName">campo</param>
        /// <param name="ascending"></param>
        /// <returns>Devuelve el IQueryable ordenado por la propiedad o campo deseado</returns>
        public static IQueryable<T> OrderByPropertyOrField<T>(this IQueryable<T> queryable, string propertyOrFieldName, string tipoOrden = "ascending")
        {
            var elementType = typeof(T);
            var orderByMethodName = ((tipoOrden == "ascending") ? "OrderBy" : "OrderByDescending");

            var parameterExpression = Expression.Parameter(elementType);
            var propertyOrFieldExpression = Expression.PropertyOrField(parameterExpression, propertyOrFieldName);
            var selector = Expression.Lambda(propertyOrFieldExpression, parameterExpression);

            var orderByExpression = Expression.Call(typeof(Queryable), orderByMethodName,
                new[] { elementType, propertyOrFieldExpression.Type }, queryable.Expression, selector);

            return queryable.Provider.CreateQuery<T>(orderByExpression);
        }
    }
}
