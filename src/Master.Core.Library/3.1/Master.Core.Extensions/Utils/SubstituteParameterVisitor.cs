using System.Collections.Generic;
using System.Linq.Expressions;

namespace Master.Core.Extensions.Utils
{
    internal class SubstituteParameterVisitor : ExpressionVisitor
    {
        public SubstituteParameterVisitor() => Sub = new Dictionary<Expression, Expression>();

        public Dictionary<Expression, Expression> Sub { get; }

        protected override Expression VisitParameter(ParameterExpression node) =>
            Sub.TryGetValue(node, out var newValue) ? newValue : node;
    }
}
