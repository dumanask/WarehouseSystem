using AutoMapper;
using Warehouse.Application.Features.Items.Commands.Create;
using Warehouse.Application.Features.Items.Commands.CreateList;
using Warehouse.Application.Features.Items.Commands.Delete;
using Warehouse.Application.Features.Items.Commands.DeleteList;
using Warehouse.Application.Features.Items.Commands.Update;
using Warehouse.Application.Features.Items.Commands.UpdateList;
using Warehouse.Application.Features.Items.Queries.GetAllProducts;
using Warehouse.Application.Features.Items.Queries.GetItemById;
using Warehouse.Domain.Entities;

namespace Warehouse.Application.Features.Items.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Item, CreateItemCommand>().ReverseMap();
        CreateMap<Item, CreateItemResponse>().ReverseMap();
        CreateMap<Item, CreateItemsInListCommand>().ReverseMap();
        CreateMap<Item, CreateItemsInListResponse>().ReverseMap();
        CreateMap<Item, UpdateItemCommand>().ReverseMap();
        CreateMap<Item, UpdateItemResponse>().ReverseMap();
        CreateMap<Item, UpdateItemsInListCommand>().ReverseMap();
        CreateMap<Item, UpdateItemsInListResponse>().ReverseMap();
        CreateMap<Item, DeleteItemCommand>().ReverseMap();
        CreateMap<Item, DeleteItemResponse>().ReverseMap();
        CreateMap<Item, DeleteItemsInListCommand>().ReverseMap();
        CreateMap<Item, DeleteItemsInListResponse>().ReverseMap();
        CreateMap<Item, GetItemByItemIdResponse>()
            .ForMember(destinationMember: x => x.Id, memberOptions: opt => opt.MapFrom(x => x.Id)).ReverseMap();
        CreateMap<Item, GetAllItemsResponse>().ReverseMap();
    }
}