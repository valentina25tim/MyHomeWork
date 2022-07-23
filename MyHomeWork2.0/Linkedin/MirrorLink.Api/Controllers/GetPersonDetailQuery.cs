using MediatR;

namespace MirrorLink.Api.Controllers
{
    internal class GetPersonDetailQuery : IRequest<object>
    {
        public int Id { get; set; }
    }
}