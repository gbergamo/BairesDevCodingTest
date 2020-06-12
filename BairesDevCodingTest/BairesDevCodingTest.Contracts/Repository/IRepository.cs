using BairesDevCodingTest.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BairesDevCodingTest.Contracts.Repository
{
    public interface IRepository<TEntity> where TEntity : DomainEntity
    {
        IEnumerable<TEntity> All();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression);
        TEntity Insert(TEntity entity);
    }
}
