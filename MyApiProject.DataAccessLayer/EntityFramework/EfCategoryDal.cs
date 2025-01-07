using MyApiProject.DataAccessLayer.Abstract;
using MyApiProject.DataAccessLayer.Context;
using MyApiProject.DataAccessLayer.Repositories;
using MyApiProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApiProject.DataAccessLayer.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        //constructor oluşturmamızın sebebi, Generic Repository burada context sınıfı üzerinde bir yapıcı metot oluşturuyordu bu yüzden de contexti miras alacak bir yapıcı metot oluşturmamız gerekli.
        public EfCategoryDal(ApiContext context) : base(context)
        {
        }

        public int CategoryCount()
        {
            var context = new ApiContext();
            int value = context.Categories.Count();
            return value;
        }
    }
}
