using EventManagementApi.Core.Domain.Common;
using EventManagementApi.Core.Domain.Enums;

namespace EventManagementApi.Core.Domain.Entities;

public class Place : IEntity, IAuditable<Place>
{
    public int Id { get; set; }

    public string Name { get; set; }
    public string Address { get; set; }
    public List<Seat> Seats { get; set;}
    public List<Event> Events { get; set;}

    public int? CreatorId { get; set; }
    public User? Creator { get; set; }
    public DateTime? CreateDate { get; set; }
    public int? ModifierId { get; set; }
    public User? Modifier { get; set; }
    public DateTime? ModifyDate { get; set; }
    public bool IsDeleted { get; set; }

    public Place SetCreationCredentials(int? userId)
    {
        CreatorId = userId;
        CreateDate = DateTime.UtcNow.AddHours(4);

        return this;
    }

    public Place SetCredentials(int? userId)
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

    public Place SetModifyCredentials(int? userId)
    {
        ModifierId = userId;
        ModifyDate = DateTime.UtcNow.AddHours(4);

        return this;
    }
}