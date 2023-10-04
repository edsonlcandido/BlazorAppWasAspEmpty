using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace BlazorAppWasAspEmpty.Shared.Models
{
    public class Daily
    {
        public int Código { get; set; }
        public string Produto { get; set; }
        public string Segmento { get; set; }
        public string Tipo { get; set; }
        public string Cliente { get; set; }
        public string Rev { get; set; }
        public DateTime? DataDefinicao { get; set; } 
        public DateTime? DataEntregaPrevista { get; set; }   
        public DateTime? DataEntregaReal { get; set; }
        public  string Projeto_Aplicacao { get; set; }
        public string Responsavel { get; set; }
        public string CRM { get; set; }
        public string Status { get; set; }
        public string AnaliseCredito { get; set; }
        public DateTime? DataAprovacao { get; set; }
        public string Pendencia { get; set; }
        public string? PV { get; set; }
    }
    
    public class DailyAccessRepository
    {
        public DailyAccessRepository()
        {
            
        }
        private static string _connectionString
        {
            get { return @$"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Data\Dailly.accdb"; }
        } 

        public static IEnumerable<Daily> GetAll()
        {
            OleDbConnection conn = new OleDbConnection(_connectionString);
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;
            cmd.CommandText = $@"SELECT dbDM.Código, dbDM.Produto, dbDM.Segmento, dbDM.Tipo, 
                    dbDM.Cliente, dbDM.Rev, dbDM.[Data de definição], dbDM.[Data de entrega prevista], 
                    dbDM.[Data de entrega real], dbDM.[Projeto/Aplicação], dbDM.Responsável, dbDM.CRM, 
                    dbDM.Status, dbDM.[Análise de crédito], dbDM.[Data de aprovação Ac], dbDM.Pendencia, 
                    dbDM.PV " +
                "FROM dbDM " +
                "WHERE(Status = 'Aberto') OR (Status = 'Não registrado') " +
                "ORDER BY dbDM.[Data de entrega prevista];";
            conn.Open();
            OleDbDataReader reader = cmd.ExecuteReader();
            List<Daily> dailies = new List<Daily>();
            while (reader.Read())
            {
                Daily daily = new Daily();
                daily.Código = reader.GetInt32("Código");
                daily.Produto = reader.GetString("Produto");
                daily.Segmento = reader.GetString("Segmento");
                daily.Tipo = reader.GetString("Tipo");
                daily.Cliente = reader.GetString("Cliente");
                daily.Rev = reader.GetString("Rev");
                daily.DataDefinicao = reader.IsDBNull("Data de definição") ? null : reader.GetDateTime("Data de definição");
                daily.DataEntregaPrevista = reader.IsDBNull("Data de entrega prevista") ? null : reader.GetDateTime("Data de entrega prevista");
                daily.DataEntregaReal = reader.IsDBNull("Data de entrega real") ? null : reader.GetDateTime("Data de entrega real");
                daily.Projeto_Aplicacao = reader.GetString("Projeto/Aplicação");
                daily.Responsavel = reader.GetString("Responsável");
                daily.CRM = reader.GetString("CRM");
                daily.Status = reader.GetString("Status");
                daily.AnaliseCredito = reader.GetString("Análise de crédito");
                daily.DataAprovacao = reader.IsDBNull("Data de aprovação Ac") ? null: reader.GetDateTime("Data de aprovação Ac");
                daily.Pendencia = reader.GetString("Pendencia");
                daily.PV = reader.GetString("PV");
                dailies.Add(daily);
            }
            conn.Close();
            return dailies;
        }
    }
}
