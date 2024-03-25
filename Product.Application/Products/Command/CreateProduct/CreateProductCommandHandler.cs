using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TestTask.Domain;
using TestTask.Application.Interfaces;

namespace TestTask.Application.Products.Command.CreateProduct
{
    //Данный класс содержит логику создания
    public class CreateProductCommandHandler
        :IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly ITestTaskDbContext _dbContext;
        public CreateProductCommandHandler(ITestTaskDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Guid> Handle(CreateProductCommand request,
            CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Id = Guid.NewGuid()
            };

            await _dbContext.Products.AddAsync(product, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return product.Id;
        }
    }
}
