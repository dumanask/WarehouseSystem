namespace Warehouse.Application.Features.Items.Queries.GetItemById;

public class GetItemByItemIdResponse
{
    public Guid Id { get; set; }
    public string ItemCode { get; set; }
    public string ItemName { get; set; }
}