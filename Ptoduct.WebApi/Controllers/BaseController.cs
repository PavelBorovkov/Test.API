using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace TestTask.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controllers]/[action]")]
    public abstract class BaseController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator =>
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
       }
}
