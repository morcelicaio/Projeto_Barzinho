using System;
using System.Collections.Generic;

namespace BotecoADS_Visual_vers0 {
    public class GerenciaBar {
        private List<Mesa> mesasDoBar = new List<Mesa>(); //usado para carregar as mesas criadas no formulário FrmMenuInicial
        List<Produto> produtos = new List<Produto>(); // produtos cadastrados ficam nessa lista.
        private List<Venda> vendasAtivas = new List<Venda>(); // quando se abre uma venda ela se torna uma venda ativa.
        private List<Venda> vendasFinalizadas = new List<Venda>(); // fechou a venda remove de vendas ativas e add aqui.
        List<ItensDaVenda> itensVenda = new List<ItensDaVenda>();
        List<ItensDaVenda> porcoesNaCozinha = new List<ItensDaVenda>(); // porcoes pedidas e estao em aberto.
        List<ItensDaVenda> porcoesServidas = new List<ItensDaVenda>(); //porcoes que ja foram entregues nas mesas.        

        public List<Mesa> MesasDoBar {
            get {
                return mesasDoBar;
            }
        }

        public List<Venda> VendasAtivas {
            get {
                return vendasAtivas;
            }
        }

        public List<Venda> VendasFinalizadas {
            get {
                return vendasFinalizadas;
            }
        }

        public void travarTela() {
            Console.WriteLine("\nPressione enter para continuar.");
            Console.ReadLine();
            Console.Clear();
        }
            
            //Vai ser usado para criar as mesas a partir do formulário FrmMenuInicial.
        public void criarMesas() {
            Mesa m1 = new Mesa(); //criando a mesa     
            m1.CodigoMesa = 1;    //Setando o código da mesa
            mesasDoBar.Add(m1);        //Adicionando a mesa na lista de mesas do bar. 

            Mesa m2 = new Mesa();
            m2.CodigoMesa = 2;
            mesasDoBar.Add(m2);
            Mesa m3 = new Mesa();
            m3.CodigoMesa = 3;
            mesasDoBar.Add(m3);
            Mesa m4 = new Mesa();
            m4.CodigoMesa = 4;
            mesasDoBar.Add(m4);
            Mesa m5 = new Mesa();
            m5.CodigoMesa = 5;
            mesasDoBar.Add(m5);
            Mesa m6 = new Mesa();
            m6.CodigoMesa = 6;
            mesasDoBar.Add(m6);
        }                

        public int cadastrarProduto(Produto p, int codIncrementoProd) {
            bool permitirCadastro = true;

            //Testando se já existe um produto cadastrado com o mesmo código.
            //No primeiro cadastro o tamanho do array é 0 então o cadastro é permitido.
            for (int i = 0; i < produtos.Count; i++) {
                //if (p.CodigoProduto == produtos[i].CodigoProduto) {//verificando  se o codigo do produto 
                    permitirCadastro = false;                       //é igual a outro já cadastrado.
                //}
            }

            if (p.QtdeProduto <= 0) {
                Console.WriteLine("\nInsira uma quantidade positiva para o estoque!");
                permitirCadastro = false;
            }   else if (p.ValorUnitarioDoProduto <= 0) {
                    Console.WriteLine("\nInsira um preço unitário positivo para o produto!");
                    permitirCadastro = false;
                }

            //Verificando permissão de cadastro.
            if (permitirCadastro == true) {
                Console.WriteLine("Produto " + p.NomeDoProduto + " cadastrado!");
                codIncrementoProd++; //Sempre que um produto é cadastrado o código do próximo produto a ser cadastrado
                                     //é imcrementado por essa variável para não haver produtos cadastrados com o 
                                     //mesmo código. 
                produtos.Add(p);
                travarTela();
            } else {
                Console.WriteLine("Não foi possível cadastrar. Informe as informações do produto corretamente!\n");
            }
            return codIncrementoProd;
        }

        /*
        public Produto buscarProduto(int codProduto) {
            for (int i = 0; i < produtos.Count; i++) {
                //if (codProduto == produtos[i].CodigoProduto) {
                    Produto p = produtos[i];
                    return p;
                //}
            }

            return null;
        }*/

        //listando os produtos que já estão cadastrados .. OK
        public void listarProdutos() {
            if (produtos.Count > 0) {
                for (int i = 0; i < produtos.Count; i++) {
                    //Console.WriteLine("Código do produto: " + produtos[i].CodigoProduto);
                    Console.WriteLine("Nome: " + produtos[i].NomeDoProduto);
                    Console.WriteLine("Tipo: " + produtos[i].TipoDoProduto);
                    Console.WriteLine("Quantidade no estoque: " + produtos[i].QtdeProduto);
                    Console.WriteLine("Valor unitário: " + produtos[i].ValorUnitarioDoProduto + "\n");
                }

            } else {
                Console.WriteLine("Ainda não existem produtos cadastrados!");
            }
            travarTela();
        }

        //Ok
        public double buscarValorDoProduto(int codigoProduto) {
            double valor = 0;
            for (int i = 0; i < produtos.Count; i++) {
                //if (codigoProduto == produtos[i].CodigoProduto) {
                    valor = produtos[i].ValorUnitarioDoProduto;
                //}
            }
            return valor;
        }

        // OK 
        public bool validarEstoque(int qtdConsumo, int codigoProduto) {
            bool validacao = false;

            for (int i = 0; i < produtos.Count; i++) {
                //if (codigoProduto == produtos[i].CodigoProduto) {
                    if (qtdConsumo <= produtos[i].QtdeProduto) {
                        produtos[i].QtdeProduto = produtos[i].QtdeProduto - qtdConsumo;
                        validacao = true;
                    }   else {
                            Console.WriteLine("Estoque insuficiente para esta quantidade do produto.");
                            validacao = false;
                        }
                //}
            }
            return validacao;
        }

        //Ok.
        //verifica se a mesa existe.
        public bool validarMesa(int numeroMesa) {
            bool mesaValida = true;
            if (numeroMesa <= 0 || numeroMesa > 6) {
                Console.WriteLine("\nEssa mesa não existe. Informe uma mesa válida.");
                mesaValida = false;
                travarTela();
            }
            return mesaValida;

        }

        //Ok.
        public bool validarAberturaDaVenda(int numeroMesa) {
            bool mesaLivre = true;
            //verificando se o nro da mesa já está em alguma venda ativa.
            for (int i = 0; i < vendasAtivas.Count; i++) {
                if (numeroMesa == vendasAtivas[i].CodigoDaMesa) {
                    Console.WriteLine("Já existe uma venda para esta mesa. Escolha outra mesa.");
                    mesaLivre = false;
                }
            }

            if (mesaLivre) {
                if (numeroMesa > 0 && numeroMesa < 6) {
                    Console.WriteLine("Mesa aberta!. A venda está ativa no momento.");
                    mesaLivre = true;
                } else {
                    Console.WriteLine("A mesa informada não existe. Informe um número de mesa válido.");
                    mesaLivre = false;
                }
            }

            if (!mesaLivre) {
                travarTela();
            }

            return mesaLivre;
        }

        //inserindo uma venda na lista de vendas ativas.  OK
        public void inserirVendaAtiva(Venda v) {
            vendasAtivas.Add(v);
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine("Vendas ativas no momento:\n");
            for (int i = 0; i < vendasAtivas.Count; i++) {
                Console.WriteLine("Código da venda: " + vendasAtivas[i].CodigoDaVenda);
                Console.WriteLine("Número da mesa: " + vendasAtivas[i].CodigoDaMesa);
            }
            travarTela();
        }

        // (Testar mais). Verificando se na hora de fechar a venda, nenhuma 
        //porção para esta venda está em aberto na cozinha.
        public bool permitirVenda(int numeroMesa) {
            bool permissao = true;

            for (int i = 0; i < vendasAtivas.Count; i++) {
                if (vendasAtivas[i].CodigoDaMesa == numeroMesa) { // pegando a mesa
                    for (int j = 0; j < porcoesNaCozinha.Count; j++) {
                        if (porcoesNaCozinha[j].CodigoVenda == vendasAtivas[i].CodigoDaVenda) { //comparando se a 
                                                                                                //porção é a da mesma venda.
                            permissao = false;
                        }
                    }
                }
            }

            if (!permissao) {
                Console.WriteLine("Não é possível fechar a venda.\nExiste uma porção sendo feita na cozinha para esta venda neste momento.\nEntregue a porção antes de fechar a venda!");
                travarTela();
            }

            return permissao;
        }

        //Ok
        public void listarVendasAtivas() {
            if (vendasAtivas.Count > 0) {
                Console.WriteLine("Vendas ativas no momento:\n");
                for (int i = 0; i < vendasAtivas.Count; i++) {
                    Console.WriteLine("Número da mesa: " + vendasAtivas[i].CodigoDaMesa + "\n");
                    Console.WriteLine("Código da venda: " + vendasAtivas[i].CodigoDaVenda);
                    Console.WriteLine("Data da venda: " + vendasAtivas[i].DataDaVenda);
                    Console.WriteLine("Hora da abertura da mesa: " + vendasAtivas[i].HoraDeAbreVenda);
                    Console.WriteLine("Valor total da venda: R$ " + vendasAtivas[i].ValorTotalVenda + "\n");
                }
            } else {
                Console.WriteLine("Não existem vendas ativas no momento!");
            }
            travarTela();
        }

        public bool verificarPorcoesNaCozinha() {
            bool existePorcaoNaCozinha = false;

            if (porcoesNaCozinha.Count <= 0) {
                Console.WriteLine("Não existem porções em andamento na cozinha.");
                travarTela();
            } else {
                existePorcaoNaCozinha = true;
            }

            return existePorcaoNaCozinha;
        }

        /*
        public bool validarCodigoDaPorcao(int codPorcao) {
            bool codigoValido = false;
            //trazendo o objeto para verificar depois se a instância é uma porcao ou um produto comum.
            //Produto p = buscarProduto(codPorcao); //buscar produto retorna o objeto através do código dele.

            if (p == null) {
                Console.WriteLine("Insira o código de um produto cadastrado. Tente novamente!");
                //verificando se o produto não é uma porção
            } else if (!(p is Porcao)) { // se não é uma instância de porção
                Console.WriteLine("O código digitado não é de uma porção. Tente novamente!");
            } else {
                codigoValido = true;
            }

            if (!codigoValido) {
                travarTela();
            }

            return codigoValido;
        }
        */
        //(Realizar mais testes aqui)
        // Verificando se a porção é realmente da mesa informada.
        // pois pode ter porções de mesas diferentes em aberto na cozinha.
        public bool verificarPorcoesNaMesa(int codMesa, int codPorcao) {
            bool porcaoNaMesaCerta = false;
            List<ItensDaVenda> itensDessaVenda = new List<ItensDaVenda>();

            itensDessaVenda = retornarItensDaVenda(codMesa);

            for (int i = 0; i < itensDessaVenda.Count; i++) {
                if (codPorcao == itensDessaVenda[i].CodigoProduto) {
                    porcaoNaMesaCerta = true;
                }
            }

            if (!porcaoNaMesaCerta) {
                Console.WriteLine("Esta porção não pertence a esta mesa!. Escolha a porção correta.");
            }

            travarTela();
            return porcaoNaMesaCerta;
        }

        // (Realizar mais testes)
        public bool listarPorcoesDaMesa(int numeroMesa) {
            int codVenda;
            bool existePorcao = false;

            codVenda = buscarVendaAtiva(numeroMesa);

            Console.WriteLine("\nPorções desta mesa na cozinha:\n");
            for (int i = 0; i < porcoesNaCozinha.Count; i++) {
                if (porcoesNaCozinha[i].CodigoVenda == codVenda) {
                    for (int j = 0; j < produtos.Count; j++) {
                        //if (porcoesNaCozinha[i].CodigoProduto == produtos[j].CodigoProduto) {
                            Console.WriteLine("Código da porção: " + porcoesNaCozinha[i].CodigoProduto);
                            Console.WriteLine("Nome da porção: " + produtos[j].NomeDoProduto);
                            Console.WriteLine("Valor Unitário: R$" + produtos[j].ValorUnitarioDoProduto + "\n");
                            existePorcao = true;
                        //}
                    }
                }
            }

            if (!existePorcao) {
                Console.Clear();
                Console.WriteLine("Não existem porções na cozinha para esta mesa.");
            }

            travarTela();
            return existePorcao;
        }

        //OK
        //setando a hora da entrega da porção.
        public void inserirDataEntrega(int codigoPorcao) {
            for (int i = 0; i < porcoesNaCozinha.Count; i++) {
                if (porcoesNaCozinha[i].CodigoProduto == codigoPorcao) {
                    porcoesNaCozinha[i].HoraDaEntrega = DateTime.Now.ToShortTimeString();
                    Console.WriteLine("\nPorção entregue com sucesso.");
                    Console.WriteLine("Hora de entrega da porcao: " + porcoesNaCozinha[i].HoraDaEntrega);

                    //adicionando a porção que estava sendo preparada na cozinha às porções 
                    //que já estão entregues na mesa.
                    porcoesServidas.Add(porcoesNaCozinha[i]);
                    //excluindo da cozinha a porção que acabou de ser servida.
                    porcoesNaCozinha.Remove(porcoesNaCozinha[i]);
                }
            }
            travarTela();
        }

        // usado na comparacao de porcao pedida com outras porcoes pedidas de outras mesas.
        public ItensDaVenda retornarItemDaVenda(int codProduto) {
            ItensDaVenda item = null;


            //percorrendo os itens das vendas ativas
            for (int i = 0; i < itensVenda.Count; i++) {
                //Pegando o objeto itemDaVenda que tem o código igual o codigo passado por parâmetro.
                if (codProduto == itensVenda[i].CodigoProduto) {
                    item = itensVenda[i];
                }
            }

            return item;
        }

        //Retornando uma lista com os itens da mesa informada.
        public List<ItensDaVenda> retornarItensDaVenda(int numeroDaMesa) {
            List<ItensDaVenda> itensDessaVenda = new List<ItensDaVenda>();

            for (int i = 0; i < VendasAtivas.Count; i++) {
                //pegando a mesa passada por parâmetro
                if (numeroDaMesa == VendasAtivas[i].CodigoDaMesa) {
                    //percorrendo a lista com os itens de todas as vendas.
                    for (int j = 0; j < itensVenda.Count; j++) {

                        //criando uma lista apenas com os itens desta mesa.
                        if (VendasAtivas[i].CodigoDaVenda == itensVenda[j].CodigoVenda) {
                            itensDessaVenda.Add(itensVenda[j]);
                        }
                    }
                }
            }

            return itensDessaVenda;
        }

        //Ok
        public int buscarVendaAtiva(int codigoMesa) {
            for (int i = 0; i < vendasAtivas.Count; i++) {
                if (codigoMesa == vendasAtivas[i].CodigoDaMesa) {
                    return vendasAtivas[i].CodigoDaVenda;
                }
            }
            // Se buscar a venda e não encontrar, será retornado um valor 
            //negativo que será tratado no programa principal.
            Console.WriteLine("\nNão existe uma venda aberta nesta mesa!\nAbra a venda primeiro.");
            travarTela();
            return -1;
        }

        // método usando sobrecarga. Não recebe parâmetro.
        // Está sendo usado na hora de fechar a venda.
        public bool buscarVendaAtiva() {
            bool existeVenda = false;
            if (vendasAtivas.Count > 0) {
                existeVenda = true;
                listarVendasAtivas();
            } else {
                Console.WriteLine("Não existe nenhuma venda ativa no momento.");
                travarTela();
            }

            return existeVenda;
        }

        //OK
        //Como o visual studio está configurado em br, os valores são inseridos
        //usando a virgula e não o ponto. Ex: Não usar 8.50 ... Usar 8,50
        public void atualizarValorTotalVenda(int codigoVenda, double precoCalculado) {
            for (int i = 0; i < vendasAtivas.Count; i++) {
                if (codigoVenda == vendasAtivas[i].CodigoDaVenda) {
                    vendasAtivas[i].ValorTotalVenda = (vendasAtivas[i].ValorTotalVenda + precoCalculado);
                    Console.WriteLine("Valor Total da venda: R$ " + vendasAtivas[i].ValorTotalVenda);
                }
            }
        }

        // PODE-SE TAMBÉM DEIXAR ESTA LISTA NA PRÓPRIA CLASSE ITEM DA VENDA
        // SERÁ CRIADA UMA LISTA ÚNICA PARA CADA VENDA A CADA INSERÇÃO.
        // AQUI É UMA LISTA CONTENDO TODAS OS ITENS DE TODAS AS VENDAS EM UMA ÚNICA LISTA.
        public void adicionarItemNaVenda(ItensDaVenda item) {
            itensVenda.Add(item);
        }

        //OK
        public void adicionarItemNaVenda2(int numeroMesa, Produto pro, int qtdConsumo) {
            //bool validacaoEstoque;
            //double valorProduto, calculaPreco;

            //validacaoEstoque = validarEstoque(qtdConsumo, pro.CodigoProduto);
            //if (validacaoEstoque) {
                ItensDaVenda item = new ItensDaVenda();
                item.CodigoVenda = buscarVendaAtiva(numeroMesa);
                //item.CodigoProduto = pro.CodigoProduto;
                item.QtdeConsumida = qtdConsumo;
                item.HoraDoPedido = DateTime.Now.ToShortTimeString();

                //verificando qual é a instância do objeto.
                //Hora ele pode ser apenas um produto hora ele pode ser uma porção
                //que herda de produto.
                if (pro is Produto && !(pro is Porcao)) {
                    item.HoraDaEntrega = DateTime.Now.ToShortTimeString();
                }   else {
                        //lista com as porcoes que ainda estão na cozinha. 
                        //O tempo de entrega ainda nao foi setado aqui.
                        porcoesNaCozinha.Add(item);
                }

                adicionarItemNaVenda(item);
                //valorProduto = buscarPrecoProduto(pro.CodigoProduto);
                //calculaPreco = valorProduto * qtdConsumo;
                //atualizarValorTotalVenda(item.CodigoVenda, calculaPreco);
                travarTela();
            }
        }

        //public List<ItemDaVenda> listarItensDaVenda() {
          //  return itensVenda;
        //}

         /*Funcionando OK
        public void fecharVenda(int codMesa) {
            for (int i = 0; i < vendasAtivas.Count; i++) {
                if (codMesa == vendasAtivas[i].CodigoDaMesa) {
                    vendasAtivas[i].HoraDeFechaVenda = DateTime.Now.ToShortTimeString();

                    //Depois que a venda é finalizada ela é adicionada à lista de vendas finalizadas
                    vendasFinalizadas.Add(vendasAtivas[i]);
                    //Após a venda estar na lista de vendas finalizadas, ela é removida da lista de vendas ativas.
                    vendasAtivas.Remove(vendasAtivas[i]);
                    Console.WriteLine("Venda finalizada com sucesso!");
                    travarTela();
                }
            }
        }*/

    /*
        //Ok
        public double buscarPrecoProduto(int codigoProduto) {
            for (int i = 0; i < produtos.Count; i++) {
                if (codigoProduto == produtos[i].CodigoProduto) {
                    Console.WriteLine("achou o produto");
                    return produtos[i].ValorUnitarioDoProduto;
                }
            }
            return 0;
        }

        // Ok
        public void listarVendasFinalizadas() {
            if (vendasFinalizadas.Count > 0) {
                for (int i = 0; i < vendasFinalizadas.Count; i++) {
                    Console.WriteLine("Número da mesa: " + vendasFinalizadas[i].CodigoDaMesa);
                    Console.WriteLine("Código da venda: " + vendasFinalizadas[i].CodigoDaVenda);
                    Console.WriteLine("Data da venda: " + vendasFinalizadas[i].DataDaVenda);
                    Console.WriteLine("Hora de abertura da mesa: " + vendasFinalizadas[i].HoraDeAbreVenda);
                    Console.WriteLine("Hora de fechamento da mesa: " + vendasFinalizadas[i].HoraDeFechaVenda);
                    Console.WriteLine("Valor total da venda: R$ " + vendasFinalizadas[i].ValorTotalVenda);
                }

            }   else {
                    Console.WriteLine("Nenhuma venda foi finalizada até o momento.");
                }
            travarTela();
        }*/
}
