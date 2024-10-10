using EventManagementApi.Core.Domain.Common;
using EventManagementApi.Core.Domain.Enums;

namespace EventManagementApi.Core.Domain.Entities;

public class Seat : IEntity, IAuditable<Seat>
{
    public int Id { get; set; }

    public int Row { get; set; }
    public int NumberOfSeats { get; set; }
    public decimal Price { get; set; }

    public int PlaceId { get; set; }
    public Place Place { get; set; }
    

    public int? CreatorId { get; set; }
    public User? Creator { get; set; }
    public DateTime? CreateDate { get; set; }
    public int? ModifierId { get; set; }
    public User? Modifier { get; set; }
    public DateTime? ModifyDate { get; set; }
    public bool IsDeleted { get; set; }

    public Seat SetCreationCredentials(int? userId)
    {
        CreatorId = userId;
        CreateDate = DateTime.UtcNow.AddHours(4);

        return this;
    }

    public Seat SetCredentials(int? userId)
    {
        if(CreateDate == null)
        {
            SetCreationCredentials(userId);
        }
        else
        {
            SetModifyCredentials(userId);
        }

        return this;
    }

    public Seat SetModifyCredentials(int? userId)
    {
        ModifierId = userId;
        ModifyDate = DateTime.UtcNow.AddHours(4);

        return this;
    }
}