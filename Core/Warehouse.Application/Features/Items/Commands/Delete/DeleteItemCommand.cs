using AutoMapper;
using MediatR;
using Warehouse.Application.Services.Repositories;
using Warehouse.Domain.Entities;

namespace Warehouse.Application.Features.Items.Commands.Delete;

public class DeleteItemCommand: IRequest<DeleteItemResponse>
{
    public Guid Id { get; set; }

    public class DeleteItemCommandHandler: IRequestHandler<DeleteItemCommand,DeleteItemResponse> 
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public DeleteItemCommandHandler(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<DeleteItemResponse> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            Item? item = await _itemRepository.GetById(predicate: b => b.Id == request.Id);

            await _itemRepository.DeleteAsync(item);

            DeleteItemResponse response = _mapper.Map<DeleteItemResponse>(item);
            return response;
        }
    }
}