using FrameWork.Dao;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Framework.Contract;
using Framework.Contracts;
using System.Linq.Expressions;
using MFAdminASPNET.Models;

namespace MFAdminASPNET.DAO
{
    public class DaoBase : DbContext, IDataRepository, IDisposable
    {
        public System.Data.Entity.DbSet<MFAdminASPNET.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<MFAdminASPNET.Models.LoginInfo> LoginInfoes { get; set; }

        public System.Data.Entity.DbSet<MFAdminASPNET.Models.Role> Roles { get; set; }

        public DaoBase() : base("name=MFAdminASPNETDB")
        {
        }
        public void Delete<T>(T entity) where T : Framework.Contracts.ModelBase
        {
            this.Entry<T>(entity).State = EntityState.Deleted;
            this.SaveChanges();
        }

        public T Find<T>(params object[] keyValues) where T : Framework.Contracts.ModelBase
        {
            return this.Set<T>().Find(keyValues);
        }

        public List<T> FindAll<T>(Expression<Func<T, bool>> conditions = null) where T : ModelBase
        {
            if (conditions == null)
                return this.Set<T>().ToList();
            else
                return this.Set<T>().Where(conditions).ToList();
        }

        public PagedList<T> FindAllByPage<T, S>(Expression<Func<T, bool>> conditions, Expression<Func<T, S>> orderBy, int pageSize, int pageIndex) where T : ModelBase
        {
            var queryList = conditions == null ? this.Set<T>() : this.Set<T>().Where(conditions) as IQueryable<T>;

            return queryList.OrderByDescending(orderBy).ToPagedList(pageIndex, pageSize);
        }

        public T Insert<T>(T entity) where T : ModelBase
        {
            this.Set<T>().Add(entity);
            this.SaveChanges();
            return entity;
        }

        public T Update<T>(T entity) where T : ModelBase
        {
            var set = this.Set<T>();
            set.Attach(entity);
            this.Entry<T>(entity).State = EntityState.Modified;
            this.SaveChanges();

            return entity;
        }
    }
}