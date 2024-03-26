using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Application.Common.Mappings;
using TestTask.Domain;

namespace TestTask.Application.Products.Queries.GetProductInfo
{
    public class ProductInfoVm:IMapWith<Product>
    {
        public string Name { get; set; }
        public string Description { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductInfoVm>()
                .ForMember(productVm => productVm.Name,
                    opt => opt.MapFrom(product => product.Name))
                .ForMember(productVm => productVm.Description,
                    opt => opt.MapFrom(product => product.Description));
        }
    }
}
