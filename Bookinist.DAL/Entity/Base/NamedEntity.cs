﻿using System.ComponentModel.DataAnnotations;

namespace Bookinist.DAL.Entity.Base;

public abstract class NamedEntity
{
    [Required]
    public string Name { get; set; }

}