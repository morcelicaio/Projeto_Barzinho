namespace BotecoADS_Visual_vers0 {
    partial class FrmCadastrarProduto {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCadastrarProduto));
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tfQtdProduto = new System.Windows.Forms.TextBox();
            this.tfNomeProduto = new System.Windows.Forms.TextBox();
            this.lbQtdProd = new System.Windows.Forms.Label();
            this.lbNomeProd = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.tfValorProduto = new System.Windows.Forms.TextBox();
            this.btnCadastrarProduto = new System.Windows.Forms.Button();
            this.rbPorcao = new System.Windows.Forms.RadioButton();
            this.rbProdutoComum = new System.Windows.Forms.RadioButton();
            this.lbValorProd = new System.Windows.Forms.Label();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(16, 13);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(422, 100);
            this.panel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(60, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(291, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cadastrar Produto";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tfQtdProduto
            // 
            this.tfQtdProduto.BackColor = System.Drawing.SystemColors.Menu;
            this.tfQtdProduto.Location = new System.Drawing.Point(178, 103);
            this.tfQtdProduto.Name = "tfQtdProduto";
            this.tfQtdProduto.Size = new System.Drawing.Size(99, 20);
            this.tfQtdProduto.TabIndex = 5;            
            this.tfQtdProduto.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tfQtdProduto_KeyUp);
            // 
            // tfNomeProduto
            // 
            this.tfNomeProduto.BackColor = System.Drawing.SystemColors.Menu;
            this.tfNomeProduto.Location = new System.Drawing.Point(178, 54);
            this.tfNomeProduto.Name = "tfNomeProduto";
            this.tfNomeProduto.Size = new System.Drawing.Size(227, 20);
            this.tfNomeProduto.TabIndex = 4;
            this.tfNomeProduto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tfNomeProduto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tfNomeProduto_KeyPress);
            // 
            // lbQtdProd
            // 
            this.lbQtdProd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbQtdProd.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbQtdProd.Location = new System.Drawing.Point(12, 100);
            this.lbQtdProd.Name = "lbQtdProd";
            this.lbQtdProd.Size = new System.Drawing.Size(141, 23);
            this.lbQtdProd.TabIndex = 2;
            this.lbQtdProd.Text = "Quantidade :";
            this.lbQtdProd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbNomeProd
            // 
            this.lbNomeProd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbNomeProd.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNomeProd.Location = new System.Drawing.Point(12, 51);
            this.lbNomeProd.Name = "lbNomeProd";
            this.lbNomeProd.Size = new System.Drawing.Size(141, 23);
            this.lbNomeProd.TabIndex = 1;
            this.lbNomeProd.Text = "Nome :";
            this.lbNomeProd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Khaki;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(14, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(452, 400);
            this.panel1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.tfValorProduto);
            this.panel3.Controls.Add(this.btnCadastrarProduto);
            this.panel3.Controls.Add(this.tfQtdProduto);
            this.panel3.Controls.Add(this.rbPorcao);
            this.panel3.Controls.Add(this.lbNomeProd);
            this.panel3.Controls.Add(this.rbProdutoComum);
            this.panel3.Controls.Add(this.tfNomeProduto);
            this.panel3.Controls.Add(this.lbQtdProd);
            this.panel3.Controls.Add(this.lbValorProd);
            this.panel3.Controls.Add(this.btnVoltar);
            this.panel3.Location = new System.Drawing.Point(16, 119);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(422, 261);
            this.panel3.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 23);
            this.label2.TabIndex = 9;
            this.label2.Text = "Tipo de Produto:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tfValorProduto
            // 
            this.tfValorProduto.BackColor = System.Drawing.SystemColors.Menu;
            this.tfValorProduto.Location = new System.Drawing.Point(178, 154);
            this.tfValorProduto.Name = "tfValorProduto";
            this.tfValorProduto.Size = new System.Drawing.Size(100, 20);
            this.tfValorProduto.TabIndex = 6;
            this.tfValorProduto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tfValorProduto_KeyPress);
            // 
            // btnCadastrarProduto
            // 
            this.btnCadastrarProduto.BackColor = System.Drawing.Color.Khaki;
            this.btnCadastrarProduto.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadastrarProduto.Image = ((System.Drawing.Image)(resources.GetObject("btnCadastrarProduto.Image")));
            this.btnCadastrarProduto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCadastrarProduto.Location = new System.Drawing.Point(178, 202);
            this.btnCadastrarProduto.Name = "btnCadastrarProduto";
            this.btnCadastrarProduto.Size = new System.Drawing.Size(227, 39);
            this.btnCadastrarProduto.TabIndex = 8;
            this.btnCadastrarProduto.Text = "Cadastrar Produto";
            this.btnCadastrarProduto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCadastrarProduto.UseVisualStyleBackColor = false;
            this.btnCadastrarProduto.Click += new System.EventHandler(this.btnCadastrarProduto_Click);
            // 
            // rbPorcao
            // 
            this.rbPorcao.AutoSize = true;
            this.rbPorcao.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPorcao.Location = new System.Drawing.Point(333, 21);
            this.rbPorcao.Name = "rbPorcao";
            this.rbPorcao.Size = new System.Drawing.Size(72, 19);
            this.rbPorcao.TabIndex = 11;
            this.rbPorcao.TabStop = true;
            this.rbPorcao.Text = "Porção";
            this.rbPorcao.UseVisualStyleBackColor = true;
            // 
            // rbProdutoComum
            // 
            this.rbProdutoComum.AutoSize = true;
            this.rbProdutoComum.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbProdutoComum.Location = new System.Drawing.Point(178, 20);
            this.rbProdutoComum.Name = "rbProdutoComum";
            this.rbProdutoComum.Size = new System.Drawing.Size(130, 19);
            this.rbProdutoComum.TabIndex = 10;
            this.rbProdutoComum.TabStop = true;
            this.rbProdutoComum.Text = "Produto Comum";
            this.rbProdutoComum.UseVisualStyleBackColor = true;
            // 
            // lbValorProd
            // 
            this.lbValorProd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbValorProd.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbValorProd.Location = new System.Drawing.Point(12, 151);
            this.lbValorProd.Name = "lbValorProd";
            this.lbValorProd.Size = new System.Drawing.Size(141, 23);
            this.lbValorProd.TabIndex = 3;
            this.lbValorProd.Text = "Valor Unitário :";
            this.lbValorProd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnVoltar
            // 
            this.btnVoltar.BackColor = System.Drawing.Color.Khaki;
            this.btnVoltar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar.Image = ((System.Drawing.Image)(resources.GetObject("btnVoltar.Image")));
            this.btnVoltar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVoltar.Location = new System.Drawing.Point(12, 202);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(107, 39);
            this.btnVoltar.TabIndex = 7;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // FrmCadastrarProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(480, 428);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCadastrarProduto";
            this.Text = "Cadastro de Produto";
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tfQtdProduto;
        private System.Windows.Forms.TextBox tfNomeProduto;
        private System.Windows.Forms.Label lbQtdProd;
        private System.Windows.Forms.Label lbNomeProd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCadastrarProduto;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.TextBox tfValorProduto;
        private System.Windows.Forms.Label lbValorProd;
        private System.Windows.Forms.RadioButton rbPorcao;
        private System.Windows.Forms.RadioButton rbProdutoComum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
    }
}