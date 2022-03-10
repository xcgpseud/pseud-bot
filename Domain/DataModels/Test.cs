using Domain.DataModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DataModels
{
    public class Test : IModel
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public DateTime DateCreated { get; set; }
    }
}
