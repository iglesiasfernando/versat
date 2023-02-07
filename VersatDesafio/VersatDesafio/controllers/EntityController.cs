using IsacMobile.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using SQLiteNetExtensionsAsync.Extensions;
using System.Diagnostics;
using SQLite;
using VersatDesafio.Models;
using VersatDesafio.models;

namespace VersatDesafio.Controllers
{
    public class EntityController<T> : IEntityController<T> where T : Entity, new()
    {
        private SQLiteAsyncConnection _db;

        public EntityController(SQLiteAsyncConnection db)
        {
            this._db = db;
            var result = _db.CreateTableAsync<RssItem>().Result;
            
        }

        public AsyncTableQuery<T> AsQueryable()
        {
            return _db.Table<T>();
        }

        public async Task<int> Count(Expression<Func<T, bool>> predicate = null)
        {
            var query = _db.Table<T>();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return await query.CountAsync();
        }

        public async Task<int> Delete(T entity)
        {
            if(entity != null)
            {
                return await _db.DeleteAsync(entity);
            }
            return -1;
        }
        public async void DeleteWithChildrens(T entity)
        {
            if(entity != null)
            {
                await _db.DeleteAsync(entity, true);
            }
        }
        public async void DeleteAllWithChildrens(List<T> entity)
        {
            await _db.DeleteAllAsync(entity, true);
        }
        public async Task<List<T>> Get()
        {
            return await _db.Table<T>().ToListAsync();
        }
        public List<T> GetSync()
        {
            return _db.Table<T>().ToListAsync().Result;
        }
        public Task<T> First()
        {

            return _db.Table<T>().FirstOrDefaultAsync();
        }
        public T FirstSync()
        {

            return _db.Table<T>().FirstOrDefaultAsync().Result;
        }
        public async Task<T> Get(Expression<Func<T, bool>> predicate)
        {
            return await _db.FindAsync<T>(predicate);
        }

        public async Task<T> Get(int id)
        {
            return await _db.FindAsync<T>(id);
        }

        public async Task<List<T>> GetWithChildrens(Expression<Func<T, bool>> predicate)
        {
            return await _db.GetAllWithChildrenAsync<T>(predicate, true);
        }
        public async Task<List<T>> GetWithChildrens()
        {
            return await _db.GetAllWithChildrenAsync<T>(null, true);
        }
        public Task<List<T>> GetItemsWithChildrenAsync()
        {
            try
            {
                return _db.GetAllWithChildrenAsync<T>(recursive: true);
            }
            catch (SQLiteException ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            catch (AggregateException ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            return null;
        }
        public Task<List<T>> GetItemsWithChildrenAsync(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return _db.GetAllWithChildrenAsync<T>(predicate, recursive: true);
            }
            catch (SQLiteException ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            catch (AggregateException ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            return null;
        }

        //public async Task<List<T>> GetWithChildrens<TValue>(Expression<Func<T, bool>> predicate = null, Expression<Func<T, TValue>> orderBy = null)
        //{
        //    return await _db.GetAllWithChildrenAsync<T>(predicate, true); ;
        //}

        public async Task<ObservableCollection<T>> Get<TValue>(Expression<Func<T, bool>> predicate = null, Expression<Func<T, TValue>> orderBy = null)
        {
            var query = _db.Table<T>();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (orderBy != null)
            {
                query = query.OrderBy<TValue>(orderBy);
            }

            var collection = new ObservableCollection<T>();
            var items = await query.ToListAsync();
            foreach (var item in items)
            {
                collection.Add(item);
            }

            return collection;
        }


        /**
         * si le paso el parameto Observable collection carga en esa lista los elementos que encuentra, para evitar loopear 2 veces sobre los valores encontrados
         * */
        public ObservableCollection<T> GetSync<TValue>(Expression<Func<T, bool>> predicate = null, Expression<Func<T, TValue>> orderBy = null, ObservableCollection<T> observableCollection = null)
        {
            var query = _db.Table<T>();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (orderBy != null)
            {
                query = query.OrderBy<TValue>(orderBy);
            }

            var collection = new ObservableCollection<T>();
            var items = query.ToListAsync().Result;
            foreach (var item in items)
            {
                if (observableCollection != null)
                {
                    observableCollection.Add(item);
                }
                else
                {
                    collection.Add(item);
                }
            }

            return collection;
        }
        public async Task<int> InsertAll(List<T> list)
        {
            return await _db.InsertAllAsync(list);
        }

        public async Task<int> Insert(T entity)
        {
            try
            {
                return await _db.InsertAsync(entity);
            }
            catch (SQLiteException e)
            {
                return -1;

            }
            catch (Exception e)
            {
                return -1;
            }
        }

        //public async void InsertWithChildrens(T entity)
        //{
        //    await _db.InsertWithChildrenAsync(entity);
        //}


        public async Task InsertOrReplaceWithChildrenAsync(T entity)
        {
            try
            {
                await _db.InsertOrReplaceWithChildrenAsync(entity, true);
            }
            catch (Exception ex)
            {

            }
        }
        public async Task InsertAllWithChildren(List<T> list)
        {
            try
            {
                await _db.InsertAllWithChildrenAsync(list, true);
            }
            catch (SQLiteException e)
            {

                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task InsertOrReplaceAllWithChildren(List<T> list)
        {
            try
            {
                await _db.InsertOrReplaceAllWithChildrenAsync(list, true);

            }
            catch (SQLiteException e)
            {
                throw e;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task InsertWithChildren(T entity)
        {
            try
            {
                await _db.InsertWithChildrenAsync(entity, true);

            }
            catch (SQLiteException e)
            {
                throw e;

            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public async Task<int> DeleteAllAsync()
        {
            int response = await _db.DropTableAsync<RssItem>();
           

            return response;
        }


        public int InsertAllSync(List<T> list)
        {
            return _db.InsertAllAsync(list).Result;

        }
        public int InsertSync(T entity)
        {
            return _db.InsertAsync(entity).Result;
        }
        public async Task<int> Update(T entity)
        {
            try
            {
                return await _db.UpdateAsync(entity);

            }
            catch (SQLiteException)
            {
                return -1;
            }
        }
        public int UpdateSync(T entity)
        {
            return _db.UpdateAsync(entity).Result;
        }

        public async void UpdateWithChildrens(T entity)
        {
            try
            {
                await _db.UpdateWithChildrenAsync(entity);

            }
            catch (SQLiteException)
            {
                //return null;
            }
        }

        public async void InsertOrReplaceWithChildren(T entity)
        {
            try
            {
                await _db.InsertOrReplaceWithChildrenAsync(entity);

            }
            catch (SQLiteException)
            {
                //return null;
            }
        }


    }
}
