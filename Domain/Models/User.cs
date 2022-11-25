﻿using System.ComponentModel.DataAnnotations;

namespace Shared.Models;

public class User
{
    [Key]
    public int Id { get; set; }
    [MaxLength(51)]
    public string UserName { get; set; }
    public string? Email { get; set; }
    public string Password { get; set; }
    
    public ICollection<Post>? Posts { get; set; }
}