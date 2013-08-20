using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MittMvcProsjekt.Models
{
    public class Tidsskrift
    {
        public int Id { get; set; }
        public string Tittel { get; set; }
        public int KategoriId { get; set; }
        public virtual Kategori Kategori { get; set; }
    }
}