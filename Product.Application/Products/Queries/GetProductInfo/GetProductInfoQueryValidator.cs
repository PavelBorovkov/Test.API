using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace TestTask.Application.Products.Queries.GetProductInfo
{
    public class GetProductInfoQueryValidator:AbstractValidator<GetProductInfoQuery>    
    {
        GetProductInfoQueryValidator() 
        {
            RuleFor(product=>product.Id).NotEqual(Guid.Empty);
        }  
    }
}
