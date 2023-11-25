using AutoMapper;
using MediatR;
using Warehouse.Application.Services.Repositories;
using Warehouse.Domain.Entities;

namespace Warehouse.Application.Features.Items.Commands.DeleteList;

public class DeleteItemsInListCommand: IRequest<List<DeleteItemsInListResponse>>
{ 
    public List<Guid> Ids { get; set; }

    public class DeleteItemsInListCommandHandler : IRequestHandler<DeleteItemsInListCommand,List<DeleteItemsInListResponse>>
    {
        

        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public DeleteItemsInListCommandHandler(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<List<DeleteItemsInListResponse>> Handle(DeleteItemsInListCommand request,
            CancellationToken cancellationToken)
        {
            var deletedItems = new List<Item>();

            foreach (var id in request.Ids)
            {
                var item = await _itemRepository.GetById(x => x.Id == id);
                if (item != null)
                {
                    deletedItems.Add((Item) item);
                }
            }

            await _itemRepository.DeleteRangeAsync(deletedItems);

            return _mapper.Map<List<DeleteItemsInListResponse>>(deletedItems);
        }
    }
}