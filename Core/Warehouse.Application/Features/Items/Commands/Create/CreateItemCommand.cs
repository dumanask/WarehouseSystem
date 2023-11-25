using AutoMapper;
using MediatR;
using Warehouse.Application.Services.Repositories;
using Warehouse.Domain.Entities;

namespace Warehouse.Application.Features.Items.Commands.Create;

public class CreateItemCommand : IRequest<CreateItemResponse>
{
    public string ItemCode { get; set; }
    public string ItemName { get; set; }
    public string Description { get; set; }

    public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, CreateItemResponse>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;


        public CreateItemCommandHandler(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<CreateItemResponse> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            var item = _mapper.Map<Item>(request);
            item.Id = Guid.NewGuid();

            var itemToReturn = await _itemRepository.AddAsync(item);
            return _mapper.Map<CreateItemResponse>(itemToReturn);

        }
    }
    
}