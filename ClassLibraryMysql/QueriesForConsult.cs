using ClassLibraryLogger;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryMysql
{
    public class QueriesForConsult : Database
    {
        private async Task<DataTable> FirstBulk()
        {
            using (SqlConnection sqlConnection = new SqlConnection(GetSettingsConenction()))
            {
                try
                {
                    await sqlConnection.OpenAsync();
                    SqlCommand command = new SqlCommand("GT99_Monitor_de_Replicas1", sqlConnection);
                    command.CommandTimeout = SQL_TIMEOUT_EXECUTION_COMMAND;
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
                catch (Exception ex)
                {
                    Logger.WriteToLog("Metodo: " + ex.TargetSite + ", Error: " + ex.Message.ToLower());
                    throw;
                }
            }
        }

        private async Task<DataTable> SecondBulk()
        {
            using (SqlConnection sqlConnection = new SqlConnection(GetSettingsConenction()))
            {
                try
                {
                    await sqlConnection.OpenAsync();
                    SqlCommand command = new SqlCommand("GT99_Monitor_de_Replicas2", sqlConnection);
                    command.CommandTimeout = SQL_TIMEOUT_EXECUTION_COMMAND;
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
                catch (Exception ex)
                {
                    Logger.WriteToLog("Metodo: " + ex.TargetSite + ", Error: " + ex.Message.ToLower());
                    throw;
                }
            }
        }

        public async Task<DataTable> GetStoresTableInfo()
        {
            DataTable dataTableFirst = await FirstBulk();
            DataTable dataTableSecond = await SecondBulk();
            if(dataTableFirst.Columns.Count != 0)
            {
                ; 
            }
            else if (dataTableSecond.Columns.Count != 0)
            {
                ;
            }
            else
            {
                throw new Exception("Data vacia error de conexion.");
            }

            dataTableFirst.Merge(dataTableSecond);

            return dataTableFirst;
        }
    }
}
