﻿using System;
using System.Linq.Expressions;
using Spike.Seedworks.Repositories.Specification.Clauses;

namespace Spike.Seedworks.Repositories.Specification
{
    public sealed class FalseSpecification<TEntity> : Clause<TEntity> where TEntity : class
    {
        public override Expression<Func<TEntity, bool>> SatisfiedBy() => t => false;
    }
}