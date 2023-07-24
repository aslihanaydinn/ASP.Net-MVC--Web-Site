using System;
using System.Collections.Generic;

namespace AltunkayaBurada.Models;

public partial class Mahmoodtable
{
    public int Id { get; set; }

    public string UrunAdi { get; set; } = null!;

    public DateTime EklenmeTarihi { get; set; }

    public DateTime SontuketimTarihi { get; set; }
}
