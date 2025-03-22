using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace StaApplication.Models
{
    public class Karyawan
    {
        public string IDKaryawan { get; set; }
        public string NmKaryawan { get; set; }
        [DataType(DataType.Date)]
        public DateOnly TglMasukKerja {  get; set; }
        public int Usia {  get; set; }
    }
}
