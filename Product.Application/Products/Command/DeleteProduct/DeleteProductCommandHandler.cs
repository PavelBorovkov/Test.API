using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Application.Interfaces;
using TestTask.Domain;
using TestTask.Application.Common.Exceptions;

namespace TestTask.Application.Products.Command.DeleteProduct
{
    public class DeleteProductCommandHandler
        :IRequestHandler<DeleteProductCommand,Guid>
    {
        public readonly ITestTaskDbContext _dbContext;
        public DeleteProductCommandHandler(ITestTaskDbContext dbContext) => _dbContext = dbContext;
        
        //Unit-тип означающий пустой ответ
        public async Task<Guid> Handle(DeleteProductCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Products
                .FindAsync(new object[] { request.Id }, cancellationToken);
            
            if (entity == null||entity.Id!=request.Id) 
            {
                throw new NotFoundException(nameof(Product), request.Id);
            }
            _dbContext.Products.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            
            return entity.Id;
        }
    }
}
