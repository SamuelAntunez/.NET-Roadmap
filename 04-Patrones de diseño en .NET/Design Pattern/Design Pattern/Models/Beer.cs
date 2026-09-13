using System;
using System.Collections.Generic;

namespace Design_Pattern.Models;

public partial class Brand
{
    public int BrandId { get; set; }

    public string Name { get; set; } = null!;

    public string Style { get; set; } = null!;
}
