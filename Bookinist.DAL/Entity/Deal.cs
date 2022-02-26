﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Bookinist.DAL.Entity;

public class Deal : Base.Entity
{
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
    public virtual Book Book { get; set; }
    public virtual Seller Seller { get; set; }
    public virtual Buyer Buyer  { get; set; }

    public override string ToString() => $"Сделка по продаже {Book}: {Seller}, {Buyer}, {Price:C}";

}