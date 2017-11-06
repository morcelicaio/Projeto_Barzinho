using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotecoADS_Visual_vers0 {
    public class Venda {
        private int codVenda;
        private int codMesa;
        private String dataVenda;
        private String horaAbreVenda;
        private String horaFechaVenda;
        private double valorTotal;

        public int CodigoDaVenda {
            set {
                codVenda = value;
            }
            get {
                return codVenda;
            }
        }

        public int CodigoDaMesa {
            set {
                codMesa = value;
            }
            get {
                return codMesa;
            }
        }

        public String DataDaVenda {
            set {
                dataVenda = value;
            }
            get {
                return dataVenda;
            }
        }

        public String HoraDeAbreVenda {
            set {
                horaAbreVenda = value;
            }
            get {
                return horaAbreVenda;
            }
        }

        public String HoraDeFechaVenda {
            set {
                horaFechaVenda = value;
            }
            get {
                return horaFechaVenda;
            }
        }

        public double ValorTotalVenda {
            set {
                valorTotal = value;
            }
            get {
                return valorTotal;
            }
        }
    }
}
