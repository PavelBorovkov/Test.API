using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Application.Interfaces;
using TestTask.Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace TestTask.Application.Products.Queries.GetProductList
{
    public class GetNoteListQueryHandler
        :IRequestHandler<GetProductListQuery,ProductListVm>
    {
        private readonly ITestTaskDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetNoteListQueryHandler(ITestTaskDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<ProductListVm>Handle(GetProductListQuery request,
            CancellationToken cancellationToken)
        {
            var ProductQuery = await _dbContext.Products
                .Where(product => product.Id == request.Id)
                .ProjectTo<ProductLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new ProductListVm { Products = ProductQuery };

        }
    }
}
