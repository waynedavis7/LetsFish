﻿using LetsFish.Application.Core.Database;

namespace LetsFish.Application.Domain.Entities;

public class Captain : IDbRecord
{
    public int CaptainId { get; set; }
    [MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;
    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;
    [MaxLength(200)]
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    [MaxLength(100)]
    public string CreatedBy { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }
    [MaxLength(100)]
    public string ModifiedBy { get; set; } = string.Empty;
    public DateTime ModifiedDate { get; set; }
    public bool Inactive { get; set; }

}
