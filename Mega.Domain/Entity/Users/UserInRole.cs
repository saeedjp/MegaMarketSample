using Mega.Domain.Entities.Commons;
using Mega.Domain.Entity.Users;

public class UserInRole : BaseEntity
{
    public int Id { get; set; }
    public virtual User User { get; set; }
    public int UserId { get; set; }
    public virtual Role Role { get; set; }
    public int RoleId { get; set; }
}

