using LanguageExt;
using MediatR;
using Slowary.Application.Common.Models;
using Slowary.Application.Responses.Signs;

namespace Slowary.Application.Queries.Signs
{
    public class GetPagedSignsQuery : IRequest<Option<PaginatedList<SignResponse>>>
    {
        public int PageIndex { get; }
        
        public GetPagedSignsQuery(int pageIndex)
        {
            PageIndex = pageIndex;
        }
    }
}