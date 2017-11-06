namespace BotecoADS_Visual_vers0 {
    partial class FrmRelatorioVendas {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRelatorioVendas));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvListarVendas = new System.Windows.Forms.DataGridView();
            this.Código = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaQtd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaHoraFechaMesa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaValorTotalenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListarVendas)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Khaki;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnVoltar);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.dgvListarVendas);
            this.panel1.Location = new System.Drawing.Point(12, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(884, 481);
            this.panel1.TabIndex = 2;
            // 
            // btnVoltar
            // 
            this.btnVoltar.BackColor = System.Drawing.Color.Khaki;
            this.btnVoltar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar.Image = ((System.Drawing.Image)(resources.GetObject("btnVoltar.Image")));
            this.btnVoltar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVoltar.Location = new System.Drawing.Point(18, 435);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(107, 39);
            this.btnVoltar.TabIndex = 2;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(18, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(844, 81);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Arial Unicode MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(33, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(772, 44);
            this.label1.TabIndex = 0;
            this.label1.Text = "Relatório de Vendas Finalizadas";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.UseCompatibleTextRendering = true;
            // 
            // dgvListarVendas
            // 
            this.dgvListarVendas.BackgroundColor = System.Drawing.Color.Khaki;
            this.dgvListarVendas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListarVendas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Código,
            this.colunaNome,
            this.colunaQtd,
            this.colunaValor,
            this.colunaHoraFechaMesa,
            this.colunaValorTotalenda});
            this.dgvListarVendas.Location = new System.Drawing.Point(18, 173);
            this.dgvListarVendas.Name = "dgvListarVendas";
            this.dgvListarVendas.Size = new System.Drawing.Size(844, 245);
            this.dgvListarVendas.TabIndex = 0;
            this.dgvListarVendas.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvListarVendas_CellMouseDoubleClick);
            // 
            // Código
            // 
            this.Código.HeaderText = "Código da Venda";
            this.Código.Name = "Código";
            this.Código.Width = 115;
            // 
            // colunaNome
            // 
            this.colunaNome.HeaderText = "N° da Mesa";
            this.colunaNome.Name = "colunaNome";
            this.colunaNome.Width = 88;
            // 
            // colunaQtd
            // 
            this.colunaQtd.HeaderText = "Data da Venda";
            this.colunaQtd.Name = "colunaQtd";
            this.colunaQtd.Width = 115;
            // 
            // colunaValor
            // 
            this.colunaValor.HeaderText = "Hora de Abertura da Mesa";
            this.colunaValor.Name = "colunaValor";
            this.colunaValor.Width = 158;
            // 
            // colunaHoraFechaMesa
            // 
            this.colunaHoraFechaMesa.HeaderText = "Hora de Fechamento da Mesa";
            this.colunaHoraFechaMesa.Name = "colunaHoraFechaMesa";
            this.colunaHoraFechaMesa.Width = 175;
            // 
            // colunaValorTotalenda
            // 
            this.colunaValorTotalenda.HeaderText = "Valor Total da Venda R$";
            this.colunaValorTotalenda.Name = "colunaValorTotalenda";
            this.colunaValorTotalenda.Width = 150;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(18, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(520, 40);
            this.label2.TabIndex = 3;
            this.label2.Text = "Dê um duplo clique na venda para ver os produtos consumidos";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmRelatorioVendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(908, 506);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmRelatorioVendas";
            this.Text = "FrmRelatorioVendas";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListarVendas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvListarVendas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Código;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaQtd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaValor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaHoraFechaMesa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaValorTotalenda;
        private System.Windows.Forms.Label label2;
    }
}