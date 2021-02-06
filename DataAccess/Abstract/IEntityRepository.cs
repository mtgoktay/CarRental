using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    //Generic Repository Design Patter=  Tasarım Deseni
    public interface IEntityRepository<T> where T:class,IEntity,new()    //Generic constraint=Generic Kısıt.
    {                   //class: Referans tip olabilir, IEntity yada implamente olan bir nesne olabilir.
                           //new() = new lenebilir olmalı.(bu komutla IEntity olamaz artık)
        List<T> GetAll(Expression <Func<T,bool>> filter=null);  //Expression= (p=>p.BrandId==2) bu yapıyı
                      //verebilmemizi sağlayan kodtur.(Linq le beraber gelir) Bir kez yazılan bir yapıdır.
        T Get(Expression<Func<T, bool>> filter); //Tek bir sonucu detaylarını gitmek için.
      

        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
