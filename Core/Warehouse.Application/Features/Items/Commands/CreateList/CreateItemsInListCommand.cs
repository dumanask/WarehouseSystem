using AutoMapper;
using MediatR;
using Warehouse.Application.Services.Repositories;
using Warehouse.Domain.Entities;

namespace Warehouse.Application.Features.Items.Commands.CreateList;

public class CreateItemsInListCommand: IRequest<List<CreateItemsInListResponse>>
{
    public List<Item> Items { get; set; }

    // id'nin arrayden silinmesi gerekiyor. Silinince calisiyor.

    public class CreateItemsInListCommandHandler: IRequestHandler<CreateItemsInListCommand,List<CreateItemsInListResponse>>
    {
        private readonly IItemRepository _ItemRepository;
        private readonly IMapper _mapper;

        public CreateItemsInListCommandHandler(IItemRepository ItemRepository, IMapper mapper)
        {
            _ItemRepository = ItemRepository;
            _mapper = mapper;
        }

        public async Task<List<CreateItemsInListResponse>> Handle(CreateItemsInListCommand request, CancellationToken cancellationToken)
        {
            var createResponses = new List<CreateItemsInListResponse>();

            foreach (var item in request.Items)
            {
                var Item = _mapper.Map<Item>(item);
                Item.Id = Guid.NewGuid();

                var createResponse = await _ItemRepository.AddAsync(Item);

                var response = _mapper.Map<CreateItemsInListResponse>(createResponse);

                createResponses.Add(response);
            }

            return createResponses;

        }
    }
    
}