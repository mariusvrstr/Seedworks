﻿using System;
using System.Linq.Expressions;
using Seedworks.Repositories.Specification.Clauses;

namespace Seedworks.Repositories.Specification
{
    public sealed class FalseSpecification<TEntity> : Clause<TEntity> where TEntity : class
    {
        public override Expression<Func<TEntity, bool>> SatisfiedBy() => t => false;
    }
}
