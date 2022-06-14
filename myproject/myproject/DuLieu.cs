using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myproject
{
     class DuLieu
    {
        private string filename;
        private string path;
        private string asqtime;
        private string updatetime;
        private string version;
        private byte[] anh;
        public DuLieu(string filename, string path, string asqtime, string updatetime, string version, byte
            [] anh)
        {

            this.filename = filename;
            this.path = path;
            this.asqtime = asqtime;
            this.updatetime = updatetime;
            this.version = version;
            this.anh = anh;

        }
        public string FileName { get => filename; set => filename = value; }
        public string Path { get => path; set => path = value; }
        public string ASQTime { get => asqtime; set => asqtime = value; }
        public string Updatetime { get => updatetime; set => updatetime = value; }

        public string Version { get => version; set => version = value; }
        public byte[] Anh { get => anh; set => anh = value; }
    }
}
