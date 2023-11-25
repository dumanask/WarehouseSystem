using AutoMapper;
using MediatR;
using Warehouse.Application.Services.Repositories;
using Warehouse.Domain.Entities;

namespace Warehouse.Application.Features.Items.Commands.UpdateList;

public class UpdateItemsInListCommand: IRequest<List<UpdateItemsInListResponse>>
{
    public List<Item> Items { get; set; }

    public class UpdateItemsInListCommandHandler : IRequestHandler<UpdateItemsInListCommand, List<UpdateItemsInListResponse>>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public UpdateItemsInListCommandHandler(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<List<UpdateItemsInListResponse>> Handle(UpdateItemsInListCommand request, CancellationToken cancellationToken)
        {
            var updateResponses = new List<UpdateItemsInListResponse>();

            foreach (var item in request.Items)
            {
                var Item = await _itemRepository.GetById(x => x.Id == item.Id);

                Item.ItemCode = item.ItemCode;
                Item.ItemName = item.ItemName;
                Item.Description = item.Description;

                var ItemToReturn = await _itemRepository.UpdateAsync(Item);

                var response = _mapper.Map<UpdateItemsInListResponse>(ItemToReturn);

                updateResponses.Add(response);
            }

            return updateResponses;
        }
    }
}