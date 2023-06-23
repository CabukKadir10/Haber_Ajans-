using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Setting : IEntity
    {
        public int Id { get; set; }
        public bool IsMaintenance { get; set; } = false;
        public string Description { get; set; }
    }
}
