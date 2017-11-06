namespace BotecoADS_Visual_vers0.Telas {
    partial class FrmItensDaVenda {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmItensDaVenda));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.dgvItensDaVenda = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.colunaCodVenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaNroMesa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaTipoProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaNomeProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaQtd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaValorUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItensDaVenda)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Khaki;
            this.panel1.Controls.Add(this.btnVoltar);
            this.panel1.Controls.Add(this.dgvItensDaVenda);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(960, 435);
            this.panel1.TabIndex = 0;
            // 
            // btnVoltar
            // 
            this.btnVoltar.BackColor = System.Drawing.Color.Khaki;
            this.btnVoltar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar.Image = ((System.Drawing.Image)(resources.GetObject("btnVoltar.Image")));
            this.btnVoltar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVoltar.Location = new System.Drawing.Point(24, 383);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(107, 39);
            this.btnVoltar.TabIndex = 4;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // dgvItensDaVenda
            // 
            this.dgvItensDaVenda.BackgroundColor = System.Drawing.Color.Khaki;
            this.dgvItensDaVenda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItensDaVenda.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colunaCodVenda,
            this.colunaNroMesa,
            this.colunaTipoProduto,
            this.colunaNomeProduto,
            this.colunaQtd,
            this.colunaValorUnitario});
            this.dgvItensDaVenda.Location = new System.Drawing.Point(24, 112);
            this.dgvItensDaVenda.Name = "dgvItensDaVenda";
            this.dgvItensDaVenda.Size = new System.Drawing.Size(914, 265);
            this.dgvItensDaVenda.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(24, 14);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(914, 81);
            this.panel2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Arial Unicode MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(33, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(841, 44);
            this.label1.TabIndex = 0;
            this.label1.Text = "Itens da Venda";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.UseCompatibleTextRendering = true;
            // 
            // colunaCodVenda
            // 
            this.colunaCodVenda.HeaderText = "Cod. Venda";
            this.colunaCodVenda.Name = "colunaCodVenda";
            this.colunaCodVenda.Width = 90;
            // 
            // colunaNroMesa
            // 
            this.colunaNroMesa.HeaderText = "N° da Mesa";
            this.colunaNroMesa.Name = "colunaNroMesa";
            this.colunaNroMesa.Width = 90;
            // 
            // colunaTipoProduto
            // 
            this.colunaTipoProduto.HeaderText = "Tipo do Produto";
            this.colunaTipoProduto.Name = "colunaTipoProduto";
            this.colunaTipoProduto.Width = 130;
            // 
            // colunaNomeProduto
            // 
            this.colunaNomeProduto.HeaderText = "Nome do Produto";
            this.colunaNomeProduto.Name = "colunaNomeProduto";
            this.colunaNomeProduto.Width = 315;
            // 
            // colunaQtd
            // 
            this.colunaQtd.HeaderText = "Quantidade consumida";
            this.colunaQtd.Name = "colunaQtd";
            this.colunaQtd.Width = 145;
            // 
            // colunaValorUnitario
            // 
            this.colunaValorUnitario.HeaderText = "Valor Unitário R$";
            this.colunaValorUnitario.Name = "colunaValorUnitario";
            // 
            // FrmItensDaVenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(984, 459);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmItensDaVenda";
            this.Text = "FrmItensDaVenda";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItensDaVenda)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvItensDaVenda;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaCodVenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaNroMesa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaTipoProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaNomeProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaQtd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaValorUnitario;
    }
}