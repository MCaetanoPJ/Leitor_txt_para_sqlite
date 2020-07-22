/*
 * Created by SharpDevelop.
 * User: Omnia
 * Date: 11/03/2020
 * Time: 15:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Importar_TXT_para_SQLite
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button Selecionar_Arquivo;
		private System.Windows.Forms.Button Iniciar_Importacao;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.TextBox TXT_Tela;
		private System.Windows.Forms.Button BTN_Delete_Dados_Tabela;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.TextBox TXT_Contador_de_linhas;
		private System.Windows.Forms.Label label3;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.Selecionar_Arquivo = new System.Windows.Forms.Button();
			this.Iniciar_Importacao = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.TXT_Tela = new System.Windows.Forms.TextBox();
			this.BTN_Delete_Dados_Tabela = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.TXT_Contador_de_linhas = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(771, 82);
			this.label1.TabIndex = 0;
			this.label1.Text = "Software para criar a gramatica do Modo Ditado da SERENA\r\nSistema Desenvolvido pa" +
	"ra importar as Palavras do Arquivo (.TXT) e adicionar ao SQLite";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Selecionar_Arquivo
			// 
			this.Selecionar_Arquivo.Location = new System.Drawing.Point(12, 120);
			this.Selecionar_Arquivo.Name = "Selecionar_Arquivo";
			this.Selecionar_Arquivo.Size = new System.Drawing.Size(163, 50);
			this.Selecionar_Arquivo.TabIndex = 1;
			this.Selecionar_Arquivo.Text = "Selecionar Arquivo (.TXT)";
			this.Selecionar_Arquivo.UseVisualStyleBackColor = true;
			this.Selecionar_Arquivo.Click += new System.EventHandler(this.Selecionar_ArquivoClick);
			// 
			// Iniciar_Importacao
			// 
			this.Iniciar_Importacao.Location = new System.Drawing.Point(231, 120);
			this.Iniciar_Importacao.Name = "Iniciar_Importacao";
			this.Iniciar_Importacao.Size = new System.Drawing.Size(163, 50);
			this.Iniciar_Importacao.TabIndex = 2;
			this.Iniciar_Importacao.Text = "Iniciar Importação para SQLite";
			this.Iniciar_Importacao.UseVisualStyleBackColor = true;
			this.Iniciar_Importacao.Click += new System.EventHandler(this.Iniciar_ImportacaoClick);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(332, 510);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(180, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "Desenvolvido por Marcos Caetano";
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// TXT_Tela
			// 
			this.TXT_Tela.Location = new System.Drawing.Point(12, 184);
			this.TXT_Tela.Multiline = true;
			this.TXT_Tela.Name = "TXT_Tela";
			this.TXT_Tela.ReadOnly = true;
			this.TXT_Tela.Size = new System.Drawing.Size(382, 312);
			this.TXT_Tela.TabIndex = 4;
			// 
			// BTN_Delete_Dados_Tabela
			// 
			this.BTN_Delete_Dados_Tabela.Location = new System.Drawing.Point(644, 120);
			this.BTN_Delete_Dados_Tabela.Name = "BTN_Delete_Dados_Tabela";
			this.BTN_Delete_Dados_Tabela.Size = new System.Drawing.Size(139, 50);
			this.BTN_Delete_Dados_Tabela.TabIndex = 6;
			this.BTN_Delete_Dados_Tabela.Text = "Limpar Dados da Tabela";
			this.BTN_Delete_Dados_Tabela.UseVisualStyleBackColor = true;
			this.BTN_Delete_Dados_Tabela.Click += new System.EventHandler(this.BTN_Delete_Dados_TabelaClick);
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(413, 184);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(375, 312);
			this.dataGridView1.TabIndex = 7;
			// 
			// TXT_Contador_de_linhas
			// 
			this.TXT_Contador_de_linhas.Location = new System.Drawing.Point(12, 502);
			this.TXT_Contador_de_linhas.Name = "TXT_Contador_de_linhas";
			this.TXT_Contador_de_linhas.ReadOnly = true;
			this.TXT_Contador_de_linhas.Size = new System.Drawing.Size(107, 20);
			this.TXT_Contador_de_linhas.TabIndex = 9;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(125, 505);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 10;
			this.label3.Text = "Palavras Lidas";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 542);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.TXT_Contador_de_linhas);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.BTN_Delete_Dados_Tabela);
			this.Controls.Add(this.TXT_Tela);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.Iniciar_Importacao);
			this.Controls.Add(this.Selecionar_Arquivo);
			this.Controls.Add(this.label1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainForm";
			this.Text = "Importar_TXT_para_SQLite";
			this.Load += new System.EventHandler(this.MainFormLoad);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
