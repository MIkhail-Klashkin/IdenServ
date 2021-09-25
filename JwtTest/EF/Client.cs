using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtTest.EF
{
    public class Client
    {
        public int Id { get; set; }
        [InverseProperty("Client")]
        public virtual User User { get; set; }
        public virtual List<Quest> Orders { get; set; }

    }
}
