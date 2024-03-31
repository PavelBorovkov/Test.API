using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Application.Products.Command.CreateProduct
{
    public class CreateProductCommand : IRequest<Guid>
    {
        //Данный класс содержит в себе то , что необходимо для создания обьекта
        public string Name { get; set; }
        public string? Description { get; set; } = null!;

    }
}
