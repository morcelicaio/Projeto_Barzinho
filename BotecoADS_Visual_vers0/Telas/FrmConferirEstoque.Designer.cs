namespace BotecoADS_Visual_vers0 {
    partial class FrmConferirEstoque {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConferirEstoque));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tfBuscarProduto = new System.Windows.Forms.TextBox();
            this.lbBuscarProd = new System.Windows.Forms.Label();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.dgvListarProdutos = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.colunaValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaQtd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Código = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rbProduto = new System.Windows.Forms.RadioButton();
            this.rbPorcao = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListarProdutos)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Khaki;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tfBuscarProduto);
            this.panel1.Controls.Add(this.lbBuscarProd);
            this.panel1.Controls.Add(this.btnVoltar);
            this.panel1.Controls.Add(this.dgvListarProdutos);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(643, 542);
            this.panel1.TabIndex = 1;
            // 
            // tfBuscarProduto
            // 
            this.tfBuscarProduto.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tfBuscarProduto.ForeColor = System.Drawing.Color.Silver;
            this.tfBuscarProduto.Location = new System.Drawing.Point(212, 205);
            this.tfBuscarProduto.Name = "tfBuscarProduto";
            this.tfBuscarProduto.Size = new System.Drawing.Size(291, 23);
            this.tfBuscarProduto.TabIndex = 30;
            this.tfBuscarProduto.Text = "Digite o nome do produto aqui";
            this.tfBuscarProduto.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tfBuscarProduto_MouseClick);
            this.tfBuscarProduto.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tfBuscarProduto_KeyUp);
            // 
            // lbBuscarProd
            // 
            this.lbBuscarProd.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbBuscarProd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbBuscarProd.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBuscarProd.ForeColor = System.Drawing.Color.White;
            this.lbBuscarProd.Image = ((System.Drawing.Image)(resources.GetObject("lbBuscarProd.Image")));
            this.lbBuscarProd.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbBuscarProd.Location = new System.Drawing.Point(20, 183);
            this.lbBuscarProd.Name = "lbBuscarProd";
            this.lbBuscarProd.Size = new System.Drawing.Size(186, 44);
            this.lbBuscarProd.TabIndex = 29;
            this.lbBuscarProd.Text = "Buscar Produto";
            this.lbBuscarProd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnVoltar
            // 
            this.btnVoltar.BackColor = System.Drawing.Color.Khaki;
            this.btnVoltar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar.Image = ((System.Drawing.Image)(resources.GetObject("btnVoltar.Image")));
            this.btnVoltar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVoltar.Location = new System.Drawing.Point(20, 496);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(107, 39);
            this.btnVoltar.TabIndex = 28;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // dgvListarProdutos
            // 
            this.dgvListarProdutos.AllowUserToAddRows = false;
            this.dgvListarProdutos.AllowUserToDeleteRows = false;
            this.dgvListarProdutos.BackgroundColor = System.Drawing.Color.Khaki;
            this.dgvListarProdutos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvListarProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListarProdutos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Código,
            this.colunaNome,
            this.colunaQtd,
            this.colunaValor});
            this.dgvListarProdutos.Location = new System.Drawing.Point(20, 233);
            this.dgvListarProdutos.Name = "dgvListarProdutos";
            this.dgvListarProdutos.ReadOnly = true;
            this.dgvListarProdutos.Size = new System.Drawing.Size(600, 256);
            this.dgvListarProdutos.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(20, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(600, 83);
            this.panel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(24, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(548, 53);
            this.label1.TabIndex = 0;
            this.label1.Text = "Produtos Cadastrados";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // colunaValor
            // 
            this.colunaValor.HeaderText = "Valor Unitário R$";
            this.colunaValor.Name = "colunaValor";
            this.colunaValor.ReadOnly = true;
            this.colunaValor.Width = 111;
            // 
            // colunaQtd
            // 
            this.colunaQtd.HeaderText = "Quantidade no Estoque";
            this.colunaQtd.Name = "colunaQtd";
            this.colunaQtd.ReadOnly = true;
            this.colunaQtd.Width = 143;
            // 
            // colunaNome
            // 
            this.colunaNome.HeaderText = "Nome";
            this.colunaNome.Name = "colunaNome";
            this.colunaNome.ReadOnly = true;
            this.colunaNome.Width = 252;
            // 
            // Código
            // 
            this.Código.HeaderText = "Código";
            this.Código.Name = "Código";
            this.Código.ReadOnly = true;
            this.Código.Width = 50;
            // 
            // rbProduto
            // 
            this.rbProduto.AutoSize = true;
            this.rbProduto.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbProduto.Location = new System.Drawing.Point(12, 19);
            this.rbProduto.Name = "rbProduto";
            this.rbProduto.Size = new System.Drawing.Size(128, 19);
            this.rbProduto.TabIndex = 31;
            this.rbProduto.TabStop = true;
            this.rbProduto.Text = "Produto comum";
            this.rbProduto.UseVisualStyleBackColor = true;
            this.rbProduto.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rbProduto_MouseClick);
            // 
            // rbPorcao
            // 
            this.rbPorcao.AutoSize = true;
            this.rbPorcao.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPorcao.Location = new System.Drawing.Point(157, 19);
            this.rbPorcao.Name = "rbPorcao";
            this.rbPorcao.Size = new System.Drawing.Size(72, 19);
            this.rbPorcao.TabIndex = 32;
            this.rbPorcao.TabStop = true;
            this.rbPorcao.Text = "Porção";
            this.rbPorcao.UseVisualStyleBackColor = true;
            this.rbPorcao.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rbPorcao_MouseClick);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Location = new System.Drawing.Point(20, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(260, 29);
            this.label2.TabIndex = 33;
            this.label2.Text = "Selecione o tipo de produto";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbProduto);
            this.groupBox1.Controls.Add(this.rbPorcao);
            this.groupBox1.Location = new System.Drawing.Point(303, 106);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(251, 56);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            // 
            // FrmConferirEstoque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(668, 566);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmConferirEstoque";
            this.Text = "Verificar o Estoque";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListarProdutos)).EndInit();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tfBuscarProduto;
        private System.Windows.Forms.Label lbBuscarProd;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.DataGridView dgvListarProdutos;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbPorcao;
        private System.Windows.Forms.RadioButton rbProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Código;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaQtd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaValor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}