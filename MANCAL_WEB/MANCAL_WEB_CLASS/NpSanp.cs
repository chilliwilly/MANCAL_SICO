using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MANCAL_WEB_CLASS
{
    public class NpSanp
    {
        public String sanp_nro_caso { get; set; }
        public String sanp_np_caso { get; set; }
        public String sanp_va_caso { get; set; }
        public String sanp_total_caso { get; set; }

        public NpSanp(String sanp_nro_caso, String sanp_np_caso, String sanp_va_caso, String sanp_total_caso)
        {
            this.sanp_nro_caso = sanp_nro_caso;
            this.sanp_np_caso = sanp_np_caso;
            this.sanp_va_caso = sanp_va_caso;
            this.sanp_total_caso = sanp_total_caso;
        }

        public NpSanp() { }
    }
}
