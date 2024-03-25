using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Application.Common.Mappings;
using TestTask.Domain;

namespace TestTask.Application.Products.Queries.GetProductList
{
    public class ProductLookupDto:IMapWith<Product>
    {
        public string name { get; set; }
        public string description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductLookupDto>()
                .ForMember(productDto => productDto.name,
                opt => opt.MapFrom(product => product.Name))
                .ForMember(productDto => productDto.description,
                opt => opt.MapFrom(product => product.Description));
        }
    }
}
