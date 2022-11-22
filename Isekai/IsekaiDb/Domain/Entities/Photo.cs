using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsekaiDb.Domain.Entities
{
    public class Photo
    {
        public Guid PhotoId { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public byte[] Data { get; set; }
    }
}
