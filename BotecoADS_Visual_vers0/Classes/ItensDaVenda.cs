using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotecoADS_Visual_vers0 {
    public class ItensDaVenda {
        private int codVenda;
        private int codProduto;
        private int qtdConsumida;
        private String horaPedido;
        private String horaEntrega;

        public int CodigoVenda {
            set {
                codVenda = value;
            }
            get {
                return codVenda;
            }
        }

        public int CodigoProduto {
            set {
                codProduto = value;
            }
            get {
                return codProduto;
            }
        }

        public int QtdeConsumida {
            set {
                qtdConsumida = value;
            }
            get {
                return qtdConsumida;
            }
        }

        public String HoraDoPedido {
            set {
                horaPedido = value;
            }
            get {
                return horaPedido;
            }
        }

        public String HoraDaEntrega {
            set {
                horaEntrega = value;
            }
            get {
                return horaEntrega;
            }
        }

    }
}
