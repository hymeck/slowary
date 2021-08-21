using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LanguageExt;
using MediatR;
using Slowary.Application.Common.Dao.Signs;
using Slowary.Application.Common.Models;
using Slowary.Application.Responses.Signs;
using Slowary.Application.Services;
using Slowary.Domain.Entities;

namespace Slowary.Application.Queries.Signs
{
    public class GetPagedSignsQueryHandler : IRequestHandler<GetPagedSignsQuery, Option<PaginatedList<SignResponse>>>
    {
        private readonly IAsyncSignPaginator _paginator;
        private readonly ISignPaginationConfProvider _paginationConf;
        private readonly IMapper _mapper;

        public GetPagedSignsQueryHandler(IAsyncSignPaginator paginator, ISignPaginationConfProvider paginationConf, IMapper mapper)
        {
            _paginator = paginator;
            _paginationConf = paginationConf;
            _mapper = mapper;
        }

        public async Task<Option<PaginatedList<SignResponse>>> Handle(GetPagedSignsQuery request,
            CancellationToken cancellationToken)
        {
            var perPage = _paginationConf.SignsPerPageCount;
            var items = await _paginator.GetPaginatedList(request.PageIndex, perPage);
            return items.Match(
                source => FromPaginator(source.Items, source.TotalItemsCount, request.PageIndex, perPage),
                Option<PaginatedList<SignResponse>>.None);
        }

        private IList<SignResponse> ApplyMapping(IList<Sign> signs) =>
            _mapper.Map<IList<Sign>, IList<SignResponse>>(signs);

        private PaginatedList<SignResponse> FromPaginator(IList<Sign> items, int total, int page, int perPage) =>
            new(ApplyMapping(items), total, page, perPage);
    }
}