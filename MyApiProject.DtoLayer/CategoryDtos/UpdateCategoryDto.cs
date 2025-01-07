using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApiProject.DtoLayer.CategoryDtos
{
    public class UpdateCategoryDto
    {
        //buradaki prop isimleri class lardaki isimlerle aynı olmak zorunda değil çünkü zaten diğer tarafa(controller kısmında newleyerek atıyoruz) otomatik olarak atanıyor. ANCAK mapleme yaparsak AutoMapper gibi bir kütüphane kullanırsak aynı prop ismi olmak zorunda yoksa eşleşmez.
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
