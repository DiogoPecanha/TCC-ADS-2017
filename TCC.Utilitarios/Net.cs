using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TCC.Utilitarios {
    public class Net {
        public string GetIpHost() {
            string nome = Dns.GetHostName();

            IPAddress[] ip = Dns.GetHostAddresses(nome);
            if (ip.Length > 2)
                return ip[2].ToString();
            return "";
        }
    }
}
