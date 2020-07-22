/*
 * Created by SharpDevelop.
 * User: Omnia
 * Date: 11/03/2020
 * Time: 15:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

//Import usado pelo SQLite
using System.Data;
using System.Data.SQLite;
using System.Threading;

namespace Importar_TXT_para_SQLite
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		private Thread thread;
		delegate void SetTextCallback(string texto);//Usado para passar informação da thread para o metodo do BD
		delegate void SetValueCallback(string valor);
		
		private SQLiteConnection Conexao = new SQLiteConnection("Data Source=Dicionario.db");//Cria e Acessa o Banco de Dados
		string Endereco_arquivo_txt = "";
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
			CriarTabelas();
			Atualiza_Tabela();
		}
		void Selecionar_ArquivoClick(object sender, EventArgs e)
		{
			try{
				openFileDialog1.Title = "Selecionar Arquivo para Importar";
				openFileDialog1.Filter = "Text File (*.TXT)|*.TXT|" +
										"Text File (*.TXT)|*.TXT";//filtrar por .TXT
				DialogResult dr = openFileDialog1.ShowDialog();
				if (dr == System.Windows.Forms.DialogResult.OK)
	            {
					Endereco_arquivo_txt = openFileDialog1.FileName;//Endereço do arquivo selecionado
					TXT_Tela.AppendText("\n\rArquivo de Texto (.TXT) selecionado...\n\r");
				}
			}
			catch(Exception ex){
				MessageBox.Show("Houve um erro selecionar o arquivo de Texto  \nMotivo: "+ex.Message);
			}
			
		}
		void Iniciar_ImportacaoClick(object sender, EventArgs e)
		{
			Escrever_Tela("Iniciando Importação para a Base de Dados...");
			CriarTabelas();
			
			thread = new Thread(new ThreadStart(Ler_Arquivo_de_Texto));//Criando a Thread
			thread.IsBackground = true;//permite rodar a thread em segundo plano
			thread.Start();//inicia a thread criada
		}
		void BTN_Delete_Dados_TabelaClick(object sender, EventArgs e)
		{
			try{
			string SQL_Delete = "delete from Dicionario";
			Conectar();
			SQLiteCommand Comando = new SQLiteCommand(SQL_Delete,Conexao);
			Comando.ExecuteNonQuery();//Executa comandos SQL sem exibir resultado
			Desconectar();
			Atualiza_Tabela();
			TXT_Tela.Clear();
			MessageBox.Show("Tabela Limpa");
			}
			catch(Exception ex){
				MessageBox.Show("Houve um erro ao Limpar a Tabela dentro do Banco de Dados \nMotivo: "+ex.Message);
			}
		}
		
		private void Conectar()
		{
			try{
				Conexao.Open();
			}
			catch(Exception Erro_Conectar){
				MessageBox.Show("Erro ao Abrir a Conexão: \n"+Erro_Conectar.Message+"\n Status da Conexao: "+Conexao.State);
			}
		}
		private void Desconectar()
		{
			try{
				Conexao.Close();
			}
			catch(Exception Erro_Desconectar){
				MessageBox.Show("Erro ao Fechar a Conexão: \n"+Erro_Desconectar.Message+"\n Status da Conexao: "+Conexao.State);
			}
		}
		private void CriarTabelas()
		{
			try
            {
				Conectar();
                using (var commando = Conexao.CreateCommand())
                {
                    commando.CommandText = "CREATE TABLE IF NOT EXISTS Dicionario(" +
                    	"Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, " +
                    	"Palavra TEXT)";
                    commando.ExecuteNonQuery();
                    Desconectar();  
                }
            }
            catch(Exception ex){
				MessageBox.Show("Houve um erro ao criar a Tabela dentro do Banco de Dados \nMotivo: "+ex.Message);
			}
		}
		private void Atualiza_Tabela()
		{			
			try{
				Conectar();
				DataTable dt = new DataTable();
				string SQL = "select id,Palavra from Dicionario";
				SQLiteDataAdapter da = new SQLiteDataAdapter(SQL,Conexao);
				da.Fill(dt);
				dataGridView1.DataSource = dt.DefaultView;
				Desconectar();
			}
			catch(Exception ex){
				MessageBox.Show("Erro ao atualizar a tela com os valores importados \nMotivo: "+ex.Message);
			}
		}
		private void Escrever_Tela(string texto)
		{
			TXT_Tela.AppendText("\n\r"+texto+"\n\r");
		}
		
		private void Ler_Arquivo_de_Texto()
		{
			try{
				Thread.Sleep(1000);
				int counter = 0;
				string line;
				
				System.IO.StreamReader file = new System.IO.StreamReader(Endereco_arquivo_txt);  
				while((line = file.ReadLine()) != null)  
				{   
				    if (this.TXT_Tela.InvokeRequired)
	            	{
						SetTextCallback d = new SetTextCallback(Inserir_Texto_no_banco);//Define o metodo de destino
		                this.Invoke(d, new object[] { line });//Define o que sera enviado ao metodo
		                
		                SetValueCallback b = new SetValueCallback(Escrever_Tela_contador);//Define o metodo de destino
		                this.Invoke(b, new object[] { counter.ToString() });//Define o que sera enviado ao metodo
	            	}
		            else
		            {
		                this.TXT_Tela.Text = line;
		            }
				    counter++;  
				} 
				Atualiza_Tabela();
				file.Dispose();
			}
			catch(Exception ex){
				MessageBox.Show("Houve um erro durante a leitura do arquivo de texto (.TXT) \nMotivo: "+ex.Message);
			}
		}//Executa dentro da Thread
		private void Inserir_Texto_no_banco(string Texto)
		{
			string SQL_Create = "insert into Dicionario(Palavra) values('"+Texto+ "')";
			Conectar();
			SQLiteCommand Comando = new SQLiteCommand(SQL_Create,Conexao);
			Comando.ExecuteNonQuery();
			Comando.Dispose();
			Desconectar();
			Escrever_Tela("Adicionado ao banco ------> "+Texto);
		}//Recebe valores da thread pelo delegate
		private void Escrever_Tela_contador(string valor)
		{
			TXT_Contador_de_linhas.Clear();
			TXT_Contador_de_linhas.Text = valor;
		}//Recebe valores da thread pelo delegate
	}
}
