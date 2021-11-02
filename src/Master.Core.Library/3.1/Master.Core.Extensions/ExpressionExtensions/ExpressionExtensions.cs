using Master.Core.Extensions.Utils;
using System;
using System.Linq.Expressions;

namespace Master.Core.Extensions.ExpressionExtensions
{
    public static class ExpressionExtensions
    {
        public static Expression<Func<T, bool>> Begin<T>(bool value = false) => default;

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> left,
            Expression<Func<T, bool>> right) => CombineLambdas(left, right, ExpressionType.AndAlso);

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> left,
            Expression<Func<T, bool>> right) => CombineLambdas(left, right, ExpressionType.OrElse);

        private static Expression<Func<T, bool>> CombineLambdas<T>(this Expression<Func<T, bool>> left,
            Expression<Func<T, bool>> right, ExpressionType expressionType)
        {
            if (left == default)
                return right;

            if (right == default)
                return left;

            var p = left.Parameters[0];

            var visitor = new SubstituteParameterVisitor();
            visitor.Sub[right.Parameters[0]] = p;

            Expression body = Expression.MakeBinary(expressionType, left.Body, visitor.Visit(right.Body));
            return Expression.Lambda<Func<T, bool>>(body, p);
        }
    }
}
