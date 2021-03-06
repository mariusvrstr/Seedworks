﻿using System;
using System.Linq.Expressions;
using Seedworks.Repositories.Specification.Clauses;

namespace Seedworks.Repositories.Specification
{
    public class AndSpecification<TEntity> : CompositeClause<TEntity>
        where TEntity : class
    {
        private IClause<TEntity> _left;
        private IClause<TEntity> _right;

        public AndSpecification(IClause<TEntity> left, IClause<TEntity> right)
        {
            _right = right;
            _left = left;
        }

        public override Expression<Func<TEntity, bool>> SatisfiedBy()
        {
            var leftExpression = _left.SatisfiedBy();
            var rightExpression = _right.SatisfiedBy();

            var parameter = Expression.Parameter(typeof(TEntity));

            var leftVisitor = new ReplaceExpressionVisitor(leftExpression.Parameters[0], parameter);
            var left = leftVisitor.Visit(leftExpression.Body);

            var rightVisitor = new ReplaceExpressionVisitor(rightExpression.Parameters[0], parameter);
            var right = rightVisitor.Visit(rightExpression.Body);

            return Expression.Lambda<Func<TEntity, bool>>(
                Expression.AndAlso(left, right), parameter);
        }

        public override IClause<TEntity> LeftSideSpecification { get; }
        public override IClause<TEntity> RightSideSpecification { get; }
    }
}
