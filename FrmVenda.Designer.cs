﻿using System.Drawing;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace TOP_Games
{
    partial class FrmVenda
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOk = new System.Windows.Forms.Button();
            this.btnAddProdutos = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnFinalizarCompra = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnSubtrair = new System.Windows.Forms.Button();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.lblQuantidade = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.lblValorUnitario = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblProduto = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtTotalRecebido = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTroco = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvVendas = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chbJogo = new System.Windows.Forms.CheckBox();
            this.chbArtigo = new System.Windows.Forms.CheckBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendas)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(213)))), ((int)(((byte)(108)))));
            this.btnOk.FlatAppearance.BorderSize = 0;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Location = new System.Drawing.Point(301, 67);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(46, 35);
            this.btnOk.TabIndex = 25;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnAddProdutos
            // 
            this.btnAddProdutos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(210)))), ((int)(((byte)(240)))));
            this.btnAddProdutos.FlatAppearance.BorderSize = 0;
            this.btnAddProdutos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddProdutos.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddProdutos.Location = new System.Drawing.Point(12, 484);
            this.btnAddProdutos.Name = "btnAddProdutos";
            this.btnAddProdutos.Size = new System.Drawing.Size(116, 67);
            this.btnAddProdutos.TabIndex = 24;
            this.btnAddProdutos.Text = "Adicionar Produtos";
            this.btnAddProdutos.UseVisualStyleBackColor = false;
            this.btnAddProdutos.Click += new System.EventHandler(this.btnAddProdutos_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(78)))), ((int)(((byte)(93)))));
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(162, 484);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(116, 67);
            this.btnCancelar.TabIndex = 23;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnFinalizarCompra
            // 
            this.btnFinalizarCompra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(235)))), ((int)(((byte)(176)))));
            this.btnFinalizarCompra.FlatAppearance.BorderSize = 0;
            this.btnFinalizarCompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinalizarCompra.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinalizarCompra.Location = new System.Drawing.Point(12, 557);
            this.btnFinalizarCompra.Name = "btnFinalizarCompra";
            this.btnFinalizarCompra.Size = new System.Drawing.Size(266, 67);
            this.btnFinalizarCompra.TabIndex = 22;
            this.btnFinalizarCompra.Text = "Finalizar Compra";
            this.btnFinalizarCompra.UseVisualStyleBackColor = false;
            this.btnFinalizarCompra.Click += new System.EventHandler(this.btnFinalizarCompra_Click);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btnSubtrair);
            this.panel7.Controls.Add(this.btnAdicionar);
            this.panel7.Controls.Add(this.lblQuantidade);
            this.panel7.Controls.Add(this.label13);
            this.panel7.Location = new System.Drawing.Point(12, 340);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(266, 79);
            this.panel7.TabIndex = 21;
            // 
            // btnSubtrair
            // 
            this.btnSubtrair.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(131)))), ((int)(((byte)(121)))));
            this.btnSubtrair.FlatAppearance.BorderSize = 0;
            this.btnSubtrair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubtrair.Image = global::TOP_Games.Properties.Resources.minus;
            this.btnSubtrair.Location = new System.Drawing.Point(220, 30);
            this.btnSubtrair.Name = "btnSubtrair";
            this.btnSubtrair.Size = new System.Drawing.Size(43, 40);
            this.btnSubtrair.TabIndex = 5;
            this.btnSubtrair.UseVisualStyleBackColor = false;
            this.btnSubtrair.Click += new System.EventHandler(this.btnSubtrair_Click);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(131)))), ((int)(((byte)(121)))));
            this.btnAdicionar.FlatAppearance.BorderSize = 0;
            this.btnAdicionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdicionar.Image = global::TOP_Games.Properties.Resources.plus;
            this.btnAdicionar.Location = new System.Drawing.Point(171, 30);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(43, 40);
            this.btnAdicionar.TabIndex = 2;
            this.btnAdicionar.UseVisualStyleBackColor = false;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // lblQuantidade
            // 
            this.lblQuantidade.AutoSize = true;
            this.lblQuantidade.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblQuantidade.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblQuantidade.Location = new System.Drawing.Point(0, 30);
            this.lblQuantidade.Name = "lblQuantidade";
            this.lblQuantidade.Size = new System.Drawing.Size(0, 37);
            this.lblQuantidade.TabIndex = 1;
            this.lblQuantidade.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Top;
            this.label13.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(0, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(153, 30);
            this.label13.TabIndex = 0;
            this.label13.Text = "QUANTIDADE";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label12);
            this.panel6.Controls.Add(this.lblValorUnitario);
            this.panel6.Controls.Add(this.label11);
            this.panel6.Location = new System.Drawing.Point(12, 268);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(266, 66);
            this.panel6.TabIndex = 20;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Left;
            this.label12.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(0, 30);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(39, 30);
            this.label12.TabIndex = 5;
            this.label12.Text = "R$";
            // 
            // lblValorUnitario
            // 
            this.lblValorUnitario.AutoSize = true;
            this.lblValorUnitario.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblValorUnitario.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblValorUnitario.Location = new System.Drawing.Point(266, 30);
            this.lblValorUnitario.Name = "lblValorUnitario";
            this.lblValorUnitario.Size = new System.Drawing.Size(0, 30);
            this.lblValorUnitario.TabIndex = 1;
            this.lblValorUnitario.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Top;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(0, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(188, 30);
            this.label11.TabIndex = 0;
            this.label11.Text = "VALOR UNITÁRIO";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lblProduto);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Location = new System.Drawing.Point(12, 147);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(404, 115);
            this.panel5.TabIndex = 19;
            // 
            // lblProduto
            // 
            this.lblProduto.AutoEllipsis = true;
            this.lblProduto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProduto.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblProduto.Location = new System.Drawing.Point(0, 30);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(404, 85);
            this.lblProduto.TabIndex = 1;
            this.lblProduto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(116, 30);
            this.label9.TabIndex = 0;
            this.label9.Text = "PRODUTO";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtTotalRecebido);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Location = new System.Drawing.Point(422, 521);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(280, 66);
            this.panel4.TabIndex = 18;
            // 
            // txtTotalRecebido
            // 
            this.txtTotalRecebido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.txtTotalRecebido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalRecebido.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtTotalRecebido.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalRecebido.Location = new System.Drawing.Point(0, 31);
            this.txtTotalRecebido.Name = "txtTotalRecebido";
            this.txtTotalRecebido.Size = new System.Drawing.Size(280, 35);
            this.txtTotalRecebido.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(184, 30);
            this.label7.TabIndex = 0;
            this.label7.Text = "TOTAL RECEBIDO";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.lblTroco);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(735, 521);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(280, 66);
            this.panel2.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(0, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 30);
            this.label2.TabIndex = 5;
            this.label2.Text = "R$";
            // 
            // lblTroco
            // 
            this.lblTroco.AutoSize = true;
            this.lblTroco.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblTroco.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTroco.Location = new System.Drawing.Point(280, 30);
            this.lblTroco.Name = "lblTroco";
            this.lblTroco.Size = new System.Drawing.Size(0, 30);
            this.lblTroco.TabIndex = 1;
            this.lblTroco.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 30);
            this.label5.TabIndex = 0;
            this.label5.Text = "TROCO";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.lblSubtotal);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(422, 448);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(596, 67);
            this.panel3.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(0, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 30);
            this.label4.TabIndex = 5;
            this.label4.Text = "R$";
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblSubtotal.Location = new System.Drawing.Point(398, 21);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(0, 30);
            this.lblSubtotal.TabIndex = 1;
            this.lblSubtotal.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 30);
            this.label3.TabIndex = 0;
            this.label3.Text = "TOTAL";
            // 
            // dgvVendas
            // 
            this.dgvVendas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVendas.Location = new System.Drawing.Point(422, 37);
            this.dgvVendas.Name = "dgvVendas";
            this.dgvVendas.Size = new System.Drawing.Size(596, 393);
            this.dgvVendas.TabIndex = 15;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chbJogo);
            this.panel1.Controls.Add(this.chbArtigo);
            this.panel1.Controls.Add(this.txtId);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(266, 104);
            this.panel1.TabIndex = 14;
            // 
            // chbJogo
            // 
            this.chbJogo.AutoSize = true;
            this.chbJogo.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbJogo.Location = new System.Drawing.Point(183, 71);
            this.chbJogo.Name = "chbJogo";
            this.chbJogo.Size = new System.Drawing.Size(80, 29);
            this.chbJogo.TabIndex = 3;
            this.chbJogo.Text = "Jogos";
            this.chbJogo.UseVisualStyleBackColor = true;
            this.chbJogo.CheckedChanged += new System.EventHandler(this.chbJogo_CheckedChanged);
            // 
            // chbArtigo
            // 
            this.chbArtigo.AutoSize = true;
            this.chbArtigo.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbArtigo.Location = new System.Drawing.Point(5, 71);
            this.chbArtigo.Name = "chbArtigo";
            this.chbArtigo.Size = new System.Drawing.Size(94, 29);
            this.chbArtigo.TabIndex = 2;
            this.chbArtigo.Text = "Artigos";
            this.chbArtigo.UseVisualStyleBackColor = true;
            this.chbArtigo.CheckedChanged += new System.EventHandler(this.chbArtigo_CheckedChanged);
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.txtId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtId.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId.Location = new System.Drawing.Point(0, 30);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(266, 35);
            this.txtId.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // FrmVenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(1030, 661);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnAddProdutos);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnFinalizarCompra);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.dgvVendas);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmVenda";
            this.Load += new System.EventHandler(this.FrmVenda_Load);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendas)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnAddProdutos;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnFinalizarCompra;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btnSubtrair;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Label lblQuantidade;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lblValorUnitario;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblProduto;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtTotalRecebido;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTroco;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvVendas;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chbJogo;
        private System.Windows.Forms.CheckBox chbArtigo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
    }
}