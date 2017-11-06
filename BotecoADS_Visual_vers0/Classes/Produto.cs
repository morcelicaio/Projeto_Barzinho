using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotecoADS_Visual_vers0 {
    public class Produto {
        private int codProduto;
        private string nomeProduto;
        private string tipoProduto;
        private int qtdProduto;
        private double valorUnitarioProduto;

        //Tirei o cod Produto do construtor pois no banco estou salvando usando o auto incremento.
        //Não precisa fazer o controle de qual código está no momento.

        //Construtor de Produto.
        //Sempre que uma instância de produto é criada é necessário passar
        //as características do produto como parâmetros.
        /*
        public Produto(string nomeP, int qtdP, double valorP) {
            //this.codProduto = codP;
            this.nomeProduto = nomeP;
            this.qtdProduto = qtdP;
            this.valorUnitarioProduto = valorP;
        }
        */
        public int CodigoProduto {
            set {
                codProduto = value;
            }
            get {
                return codProduto;
            }
        }
        
        public string NomeDoProduto {
            set {
                nomeProduto = value;
            }
            get {
                return nomeProduto;
            }
        }

        public string TipoDoProduto {
            set {
                tipoProduto = value;
            }
            get {
                return tipoProduto;
            }
        }

        public int QtdeProduto {
            set {
                qtdProduto = value;
            }
            get {
                return qtdProduto;
            }
        }

        public double ValorUnitarioDoProduto {
            set {
                valorUnitarioProduto = value;
            }
            get {
                return valorUnitarioProduto;
            }
        }
        //método sobrescrito. Não está sendo usado.
        public override string ToString() {
            return "Sou um produto genérico.";
        }
    }
}
