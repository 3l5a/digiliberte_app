﻿using Microsoft.EntityFrameworkCore;


namespace Entities;

[Index("Name", IsUnique = true)]
public class Brand
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int ModelId { get; set; }

    public Model Model { get; set; }
}
