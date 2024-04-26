using System;
using System.Collections.Generic;

namespace ProjectBan_Hang_ASP.Models;

public partial class TAnhChiTietSp
{
    public string MaChiTietSp { get; set; } = null!;

    public string TenFileAnh { get; set; } = null!;

    public short? ViTri { get; set; }

    public virtual TChiTietSanPham MaChiTietSpNavigation { get; set; } = null!;
}
