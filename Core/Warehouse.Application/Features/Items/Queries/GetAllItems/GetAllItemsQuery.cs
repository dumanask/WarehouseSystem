using AutoMapper;
using MediatR;
using Warehouse.Application.Features.Items.Queries.GetAllProducts;
using Warehouse.Application.Services.Repositories;

namespace Warehouse.Application.Features.Items.Queries.GetAllItems;

public class GetAllItemsQuery: IRequest<List<GetAllItemsResponse>>
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllItemsQuery, List<GetAllItemsResponse>>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;
        public GetAllProductsQueryHandler(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }
            
        public async Task<List<GetAllItemsResponse>> Handle(GetAllItemsQuery request, CancellationToken cancellationToken)
        {
            var data = await _itemRepository.GetListAsync();

            var response = _mapper.Map<List<GetAllItemsResponse>>(data);

            return response;

        }
    }
}