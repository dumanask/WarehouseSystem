using AutoMapper;
using MediatR;
using Warehouse.Application.Services.Repositories;

namespace Warehouse.Application.Features.Items.Queries.GetItemById;

public class GetItemByItemIdQuery : IRequest<GetItemByItemIdResponse>
{
    public Guid Id { get; set; }
    public class GetItemByItemIdQueryHandler : IRequestHandler<GetItemByItemIdQuery, GetItemByItemIdResponse>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;
        public GetItemByItemIdQueryHandler(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<GetItemByItemIdResponse> Handle(GetItemByItemIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _itemRepository.GetById(x => x.Id == request.Id);

            var response = _mapper.Map<GetItemByItemIdResponse>(data);

            return response;
        }
    }
}