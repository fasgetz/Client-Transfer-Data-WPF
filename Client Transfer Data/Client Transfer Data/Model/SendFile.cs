using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_Transfer_Data.Model
{
    public class SendFile
    {
        public string FileName { get; set; }
        public string Name { get; set; }
        public byte[] Data { get; set; }
    }
}
