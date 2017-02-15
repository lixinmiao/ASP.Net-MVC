/* ==============================================================================
 * 功能描述：DbContextBase  
 * 创 建 者：lixinmiao
 * 创建日期：2017/2/13 11:34:38
 * ==============================================================================*/
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using Framework.Contract;
using Framework.Contracts;

namespace FrameWork.Dao
{
    /// <summary>
    /// DbContextBase
    /// </summary>
    public class DbContextBase : DbContext, IDataRepository, IDisposable
    {
        public DbContextBase(String name):base(name)
        {

        }
        public void Delete<T>(T entity) where T : ModelBase
        {
            throw new NotImplementedException();
        }

        public T Find<T>(params object[] keyValues) where T : ModelBase
        {
            throw new NotImplementedException();
        }

        public List<T> FindAll<T>(Expression<Func<T, bool>> conditions = null) where T : ModelBase
        {
            throw new NotImplementedException();
        }

        public PagedList<T> FindAllByPage<T, S>(Expression<Func<T, bool>> conditions, Expression<Func<T, S>> orderBy, int pageSize, int pageIndex) where T : ModelBase
        {
            throw new NotImplementedException();
        }

        public T Insert<T>(T entity) where T : ModelBase
        {
            throw new NotImplementedException();
        }

        public T Update<T>(T entity) where T : ModelBase
        {
            throw new NotImplementedException();
        }
    }
}