using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Application.Products.Queries.GetProductInfo
{
    public class GetProductInfoQuery: IRequest<ProductInfoVm>
    {
        public Guid Id { get; set; }
    }
}
