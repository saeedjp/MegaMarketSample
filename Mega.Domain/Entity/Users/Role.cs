using Mega.Domain.Entities.Commons;
using System.Collections.Generic;

public class Role : BaseEntity
{
    //public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<UserInRole> UserInRole { get; set; }
}


