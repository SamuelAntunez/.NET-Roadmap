using System;
using System.Collections.Generic;

namespace DesignPatterns.Models.Models;

public partial class Beer
{
    public int BeerId { get; set; }

    public string Name { get; set; } = null!;

    public string Style { get; set; } = null!;
}
