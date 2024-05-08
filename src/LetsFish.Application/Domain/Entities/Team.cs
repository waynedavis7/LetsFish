using LetsFish.Application.Core.Database;

namespace LetsFish.Application.Domain.Entities;

public class Team : IDbRecord
{
    public int TeamId { get; set; }
    [MaxLength(200)]
    public string TeamName { get; set; } = string.Empty;
    [MaxLength(100)]
    public string CreatedBy { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }
    [MaxLength(100)]
    public string ModifiedBy { get; set; } = string.Empty;
    public DateTime ModifiedDate { get; set; }
    public bool Inactive { get; set; }

    public virtual ICollection<Angler>? Anglers { get; set; } 
}
