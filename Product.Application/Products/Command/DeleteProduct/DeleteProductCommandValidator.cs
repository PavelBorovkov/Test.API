using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace TestTask.Application.Products.Command.DeleteProduct
{
    public class DeleteProductCommandValidator:AbstractValidator<DeleteProductCommand>  
    {
        DeleteProductCommandValidator() 
        {
            RuleFor(deleteProductCommand=>
                deleteProductCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
