using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using TestTask.Application.Common.Exceptions;
using TestTask.Domain;

namespace TestTask.Application.Products.Command.UpdateProduct
{
    public class UpdateProductCommandHandler
        :IRequestHandler<UpdateProductCommand, Product>
    {
        private readonly ITestTaskDbContext _dbContext;

        public UpdateProductCommandHandler(ITestTaskDbContext dbContext)=>
            _dbContext = dbContext;
        public async Task<Product> Handle(UpdateProductCommand request,
            CancellationToken cancellationToken)
        {
            var entity=
                await _dbContext.Products.FirstOrDefaultAsync(Product=>
                    Product.Id==request.Id, cancellationToken);
            if (entity == null|| entity.Id!=request.Id)
            {
                throw new NotFoundException(nameof(Product), request.Id);
            }

            entity.Name = request.Name;
            entity.Description = request.Description;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity;
        }
    }
}
