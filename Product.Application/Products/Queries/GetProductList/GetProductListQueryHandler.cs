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
            var productQuery = _dbContext.Products.ProjectTo<ProductLookupDto>(_mapper.ConfigurationProvider);
            if (!string.IsNullOrEmpty(request.Name))
            {
                productQuery = productQuery.Where(p => p.Name.Contains(request.Name));
            }

            return new ProductListVm { Products = productQuery.ToList() };
        }
    }
}
