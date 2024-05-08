namespace LetsFish.Application.Core.Database;

internal interface IDbRecord
{
    public string CreatedBy { get; set; } 
    public DateTime CreatedDate { get; set; }
    public string ModifiedBy { get; set; }
    public DateTime ModifiedDate { get; set; }
    public bool Inactive { get; set; }
}
