namespace QuanLySachKT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sach")]
    public partial class Sach
    {
        [Key]
        public int MaSach { get; set; }

        [Required]
        [StringLength(50)]
        public string TenSach { get; set; }

        [Required]
        [StringLength(50)]
        public string LinhVu { get; set; }

        [Required]
        [StringLength(200)]
        public string CacTacGia { get; set; }

        [Required]
        [StringLength(50)]
        public string NhaXB { get; set; }

        public int? NamXB { get; set; }

        public int? LanTaiBan { get; set; }
    }
}
