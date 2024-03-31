using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Domain;

namespace TestTask.Application.Products.Command.UpdateProduct
{
    public class UpdateProductCommand:IRequest<Product>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; } = null!;
    }
}
