using AutoMapper;
using MediatR;
using Warehouse.Application.Services.Repositories;

namespace Warehouse.Application.Features.Items.Commands.Update;

public class UpdateItemCommand:IRequest<UpdateItemResponse>
{
    public Guid Id { get; set; }
    public string ItemCode { get; set; }
    public string ItemName { get; set; }
    public string Description { get; set; }

    public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand,UpdateItemResponse>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public UpdateItemCommandHandler(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<UpdateItemResponse> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            var product = await _itemRepository.GetById(x => x.Id == request.Id);

            product.ItemCode = request.ItemCode;
            product.ItemName = request.ItemName;
            product.Description = request.Description;

            var productToReturn = await _itemRepository.UpdateAsync(product);

            return _mapper.Map<UpdateItemResponse>(productToReturn);
        }
    }
}