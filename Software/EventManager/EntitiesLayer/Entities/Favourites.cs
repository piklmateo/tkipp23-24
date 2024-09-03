using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.Entities
{
    public class Favourites
    {
        public int Id { get; set; }
        public int Id_Events { get; set; }
        public int Id_Users { get; set; }

        [ForeignKey("Id_Events")]
        public virtual Event Event { get; set; }

        [ForeignKey("Id_Users")]
        public virtual User User { get; set; }
    }
}
