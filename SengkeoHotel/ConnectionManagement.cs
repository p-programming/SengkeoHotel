using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SengkeoHotel
{
    class ConnectionManagement
    {
        private string ServerName = "DESKTOP-MQQPSHU\\SQLEXPRESS";
        private string DatabaseName = "ProjectSengKeo";
        private string stringConnection = "";
        private System.Data.SqlClient.SqlConnection connection = null;
        private System.Data.SqlClient.SqlDataAdapter adapter = null;
        private System.Data.SqlClient.SqlDataReader reader = null;
        private System.Data.SqlClient.SqlCommand command = null;
        private System.Data.SqlClient.SqlCommandBuilder commandBuilder = null;
        private System.Data.DataSet dataSet = null;
        private System.Data.DataTable dataTable = null;
        private QUERY select_model = null;


        private string INSERT = "INSERT INTO ";
        private string DELETE = "DELETE FROM ";
        private string UPDATE = "UPDATE ";
        private string CONDITION_FIELD = "";
        private dynamic CONDITION_VALUE = "";
        private double increaseTableName = 0;
        public ConnectionManagement()
        {
            stringConnection = $"Data Source={ServerName};Initial Catalog={DatabaseName};Integrated Security=True";
            connection = new SqlConnection();
            adapter = new SqlDataAdapter();
            command = new SqlCommand();
            commandBuilder = new SqlCommandBuilder();
            dataSet = new DataSet();
            dataTable = new DataTable();
        }
        //@gets and sets
        public void Adapter(SqlDataAdapter adapter)
        {
            this.adapter = adapter;
        }
        public SqlDataAdapter Adapter()
        {
            return adapter;
        }
        public void Command(SqlCommand command)
        {
            this.command = command;

        }
        public SqlCommand Command()
        {
            return command;
        }
        public void DataSet(DataSet dataSet)
        {
            this.dataSet = dataSet;
        }
        public DataSet DataSet()
        {
            return dataSet;
        }
        public void DataTable(DataTable dataTable)
        {
            this.dataTable = dataTable;
        }
        public DataTable DataTable()
        {
            return dataTable;
        }
        public void Reader(SqlDataReader reader)
        {
            this.reader = reader;
        }
        public SqlDataReader Reader()
        {
            return reader;
        }
        public void setUpdateCondition(string field, dynamic value)
        {
            CONDITION_FIELD = field;
            CONDITION_VALUE = value;
        }
        //@end gets and sets

        public SqlConnection getConnection()
        {
            if (connection.ConnectionString == "")
            {
                connection.ConnectionString = stringConnection;
            }
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
            connection.Open();
            return connection;
        }

        public void closeConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
        //@Command
        public SqlCommand getCommand(string q, CommandType type)
        {
            command.CommandText = q;
            command.CommandType = type;
            command.Connection = getConnection();
            return command;
        }
        public void setParametersWithValue(string key, dynamic value)
        {
            command.Parameters.AddWithValue(key, value);
        }
        public void setParameters(string key, dynamic value, SqlDbType type)
        {
            command.Parameters.Add(key, type);
            command.Parameters[key].Value = value;
        }
        public void setParameters(string key, dynamic value, SqlDbType type, int size)
        {
            command.Parameters.Add(key, type, size);
            command.Parameters[key].Value = value;
        }
        //@End Command

        public SqlDataAdapter getAdapterWithCommand(SqlCommand cmd)
        {
            adapter = new SqlDataAdapter(cmd);
            return adapter;
        }

        public DataTable getDataSetAdapterFill(string tbName)
        {
            try
            {
                ClearTables(tbName, dataSet);
                adapter.Fill(dataSet, tbName);
                ClearParametersCommand();
                return dataSet.Tables[tbName];
            }
            catch (Exception ex)
            {
                throw new ConnectionManagerException(string.Format("Unable to get data from adapter caused by {0}", ex.Message), ex.InnerException);
            }
        }

        public dynamic CommandExecute(CommandExecuteType execType)
        {
            try
            {
                dynamic result = 0;
                switch (execType)
                {
                    case CommandExecuteType.NonQuery:
                        result = command.ExecuteNonQuery();
                        break;
                    case CommandExecuteType.NonQueryAsync:
                        result = command.ExecuteNonQueryAsync();
                        break;
                    case CommandExecuteType.Reader:
                        result = command.ExecuteReader();
                        break;
                    case CommandExecuteType.ReaderAsync:
                        result = command.ExecuteReaderAsync();
                        break;
                    case CommandExecuteType.Scalar:
                        result = command.ExecuteScalar();
                        break;
                    case CommandExecuteType.ScalarAsync:
                        result = command.ExecuteScalarAsync();
                        break;
                }
                ClearParametersCommand();
                return result;
            }
            catch (Exception ex)
            {
                throw new ConnectionManagerException(string.Format("Unable to execute command caused by {0}", ex.Message), ex.InnerException);
            }
        }
        /// <summary>
        /// DB MODEL
        /// </summary>
        public ConnectionManagement Table(string table_name)
        {
            select_model = new QUERY(table_name);
            return this;
        }
        public ConnectionManagement SelectAll()
        {
            select_model.SELECT_ALL_MODEL();
            return this;
        }
        public ConnectionManagement Select(string fields)
        {
            select_model.SELECT_MODEL(fields);
            return this;
        }
        public ConnectionManagement Join(string join_table, string column_left, string operand, string column_right)
        {
            select_model.INNER_JOIN_MODEL(join_table, column_left, operand, column_right);
            return this;
        }
        public ConnectionManagement Where(string field, string operand, dynamic value)
        {
            select_model.WHERE_MODEL(field, operand, value);
            return this;
        }

        public ConnectionManagement OrWhere(string field, string operand, dynamic value)
        {
            select_model.OR_WHERE_MODEL(field, operand, value);
            return this;
        }
        //(dateTime.Value.ToString("yyyy-MM-dd hh:mm:ss.fff"));
        public ConnectionManagement WhereBetween(string field, dynamic start_value, dynamic end_value)
        {
            select_model.WHERE_BETWEEN_MODEL(field, start_value, end_value);
            return this;
        }

        public ConnectionManagement OrWhereBetween(string field, dynamic start_value, dynamic end_value)
        {
            select_model.OR_WHERE_BETWEEN_MODEL(field, start_value, end_value);
            return this;
        }

        public ConnectionManagement OrderBy(string field, string value)
        {
            select_model.ORDER_BY_MODEL(field, value);
            return this;
        }

        public ConnectionManagement GroupBy(string fields)
        {
            select_model.GROUP_BY_MODEL(fields);
            return this;
        }


        public DataTable Get()
        {
            getAdapterWithCommand(getCommand(select_model.GET(), CommandType.Text));
            increaseTableName++;
            return getDataSetAdapterFill(select_model.TableName() + "_" + increaseTableName.ToString());
        }
        public long Count()
        {
            return Get().Rows.Count;
        }

        /// <summary>
        /// END DB MODEL
        /// </summary>


        public dynamic Create(string Fields, params dynamic[] Values)
        {
            string q;
            string[] tokens, Params;
            int limit, ins, index;
            if (Values.Length <= 0)
            {
                throw new ConnectionManagerException(string.Format("The Values of query create cannot be empty"));
            }
            //@get table name and fields
            string myString = Fields.Replace(" ", String.Empty).Trim().Replace(Environment.NewLine, String.Empty);
            tokens = myString.Split(':');
            if (tokens.Length <= 0)
            {
                throw new ConnectionManagerException(string.Format("The Fields of query create is incorrect form"));
            }
            //@set inset sql query
            q = INSERT + tokens[0] + " (" + tokens[1] + ") VALUES (";
            Params = tokens[1].Split(',');
            if (Params.Length != Values.Length)
            {
                throw new ConnectionManagerException(string.Format("The Fields and Values Length of query create are not equals"));
            }
            //@set parameters
            limit = Params.Length - 1;
            ins = 0;
            foreach (string param in tokens[1].Split(','))
            {
                q += "@" + param + (ins < limit ? "," : ");");
                ins++;
            }
            getCommand(q, CommandType.Text);
            index = 0;
            //@set  values
            foreach (dynamic value in Values)
            {
                setParametersWithValue(Params[index], value);
                index++;
            }
            return CommandExecute(CommandExecuteType.NonQuery);
        }

        public dynamic Update(string Fields, params dynamic[] Values)
        {
            string q;
            string[] tokens, Params;
            int limit, ins, index;
            if (Values.Length <= 0)
            {
                throw new ConnectionManagerException(string.Format("The Values of query update cannot be empty"));
            }
            //@get table name
            string myString = Fields.Replace(" ", String.Empty).Trim().Replace(Environment.NewLine, String.Empty);
            tokens = myString.Split(':');
            if (tokens.Length <= 0)
            {
                throw new ConnectionManagerException(string.Format("The Fields of query update is incorrect form"));
            }
            //@set inset sql query
            q = UPDATE + tokens[0] + " SET ";
            Params = tokens[1].Split(',');
            if (Params.Length != Values.Length)
            {
                throw new ConnectionManagerException(string.Format("The Fields and Values Length of query update are not equals"));
            }
            //@set parameters
            limit = Params.Length - 1;
            ins = 0;
            foreach (string param in tokens[1].Split(','))
            {
                q += param + "=@" + param + (ins < limit ? "," : (CONDITION_FIELD.Equals("") ? ";" : " WHERE " + CONDITION_FIELD + "=@" + CONDITION_FIELD + ";"));
                ins++;
            }
            getCommand(q, CommandType.Text);
            index = 0;
            //@set  values
            foreach (dynamic value in Values)
            {
                setParametersWithValue(Params[index], value);
                index++;
            }
            if (!CONDITION_FIELD.Equals(""))
            {
                setParametersWithValue(CONDITION_FIELD, CONDITION_VALUE);
                ClearUpdateCondition();
            }
            return CommandExecute(CommandExecuteType.NonQuery);
        }

        public dynamic Delete(string Fields, string Value)
        {
            string q;
            string[] tokens;
            string myString = Fields.Replace(" ", String.Empty).Trim().Replace(Environment.NewLine, String.Empty);
            tokens = myString.Split(':');
            if (tokens.Length <= 0)
            {
                throw new ConnectionManagerException(string.Format("The Fields of query delete is incorrect form"));
            }
            //@set inset sql query
            q = DELETE + tokens[0] + " WHERE " + tokens[1] + "=@" + tokens[1] + ";";
            getCommand(q, CommandType.Text);
            setParametersWithValue(tokens[1], Value);
            return CommandExecute(CommandExecuteType.NonQuery);
        }

        public bool Exists(string table_name, string check_column, string check_value)
        {
            string q = "SELECT " + check_column + " FROM " + table_name + " WHERE " + check_column + "=@" + check_column;
            setParametersWithValue("@" + check_column, check_value);
            getAdapterWithCommand(getCommand(q, CommandType.Text));
            increaseTableName++;
            if (getDataSetAdapterFill("check" + table_name + "_" + increaseTableName.ToString()).Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        //@clear
        private void ClearUpdateCondition()
        {
            CONDITION_FIELD = "";
            CONDITION_VALUE = "";
        }
        public void ClearParametersCommand()
        {
            command.Parameters.Clear();
        }
        public void ClearTables(string tbName, DataSet Ds)
        {
            if (Ds.Tables[tbName] != null)
            {
                Ds.Tables[tbName].Clear();
            }
        }
        /// <summary>
        /// HELPER FUNCTIONS
        /// </summary>
        public int ConvertStringToInt(string d)
        {
            int res;
            return (int.TryParse(d, out res)) ? res : -1;
        }
        public string ConvertStringToDateStringFormat(string dateString)
        {
            DateTime s = DateTime.Parse(dateString);
            return s.ToString("yyyy-MM-dd");
        }
        public string ConvertStringToDateStringFormat(string date, string format)
        {
            DateTime s = DateTime.Parse(date);
            return s.ToString(format);
        }
        public void ShowInformationMessage(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void ShowErrorMessage(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void ShowWarningMessage(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public DialogResult ShowActionMessage(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icons)
        {
            return MessageBox.Show(message, title, buttons, icons);
        }
        /// <summary>
        /// END HELPER FUNCTIONS
        /// </summary>
    }
    /// <summary>
    /// QUERY MODEL
    /// SELECT JOINS WHERE CAUSES
    /// </summary>
    /// <remarks>RETURE QUERIES STRING</remarks>

    public class QUERY
    {
        private string total_select = "SELECT";
        private string table_name = "";
        private string total_wheres = "";
        private string total_joins = "";
        private string total_query = "";
        private string groups_by = "";
        private string order_by = "";

        public string TableName()
        {
            return table_name;
        }
        private string escape(string value)
        {
            return value.Replace("'", "''");
        }
        private dynamic escapeValue(dynamic value)
        {
            if (value is String || value is string || value is char || value is Char || value is object || value is Object)
            {
                return $"'{ escape(value) }'";
            }
            return value;
        }
        private dynamic MatchLikeCondition(dynamic value)
        {
            Match match = Regex.Match(value, @"\b'.+(\w+).*", RegexOptions.IgnoreCase);
            if (match.Success)
            {
                return escape(match.Value.Substring(1, match.Value.Length - 2));//SUBSTRING START AT POSTITION 1 AND END POSITION WITH LENGTH - 2 TO REMOVE SINGEL QUATE.
            }
            return "";
        }
        private string escapeValueForLike(string value)
        {
            string val = MatchLikeCondition(value);
            if (val.Equals(""))
            {
                return value;
            }
            return $"N'{ value.Replace(value, val) }'";//N SUPPORT FOR NVARCHAR NON ENGLISH
        }

        public QUERY(string table_name)
        {
            this.table_name = table_name;
        }
        public QUERY SELECT_ALL_MODEL()
        {
            total_select = $"SELECT * FROM { escape(table_name) }";
            return this;
        }

        public QUERY SELECT_MODEL(string fields)
        {
            total_select = $"SELECT {  escape(fields) } FROM { escape(table_name) }";
            return this;
        }
        public QUERY INNER_JOIN_MODEL(string inner_table, string column_left, string operand, string column_right)
        {
            total_joins += $" INNER JOIN {escape(inner_table)} ON {escape(column_left)}{ escape(operand) }{ escape(column_right) } ";
            return this;
        }
        public QUERY LEFT_JOIN_MODEL(string inner_table, string column_left, string operand, string column_right)
        {
            total_joins += $" LEFT JOIN {escape(inner_table)} ON {escape(column_left)}{ escape(operand) }{ escape(column_right) } ";
            return this;
        }
        public QUERY RIGHT_JOIN_MODEL(string inner_table, string column_left, string operand, string column_right)
        {
            total_joins += $" RIGHT JOIN {escape(inner_table)} ON {escape(column_left)}{ escape(operand) }{ escape(column_right) } ";
            return this;
        }

        public QUERY WHERE_MODEL(string field_name, string operand, dynamic value)
        {
            if (total_wheres.Equals(""))
            {
                if (operand.ToLower().Equals("like"))
                {
                    total_wheres += $" WHERE {escape(field_name)} {escape(operand)} { escapeValueForLike(value) } ";
                }
                else
                {
                    total_wheres += $" WHERE {escape(field_name)} {escape(operand)}{ escapeValue(value) } ";
                }

            }
            else
            {
                if (operand.ToLower().Equals("like"))
                {
                    total_wheres += $" AND {escape(field_name)} {escape(operand)} { escapeValueForLike(value) } ";
                }
                else
                {
                    total_wheres += $" AND {escape(field_name)} {escape(operand)}{ escapeValue(value) } ";
                }
            }

            return this;
        }
        public QUERY OR_WHERE_MODEL(string field_name, string operand, dynamic value)
        {
            if (total_wheres.Equals(""))
            {
                if (operand.ToLower().Equals("like"))
                {
                    total_wheres += $" WHERE {escape(field_name)} {escape(operand)} { escapeValueForLike(value) } ";
                }
                else
                {
                    total_wheres += $" WHERE {escape(field_name)} {escape(operand)}{ escapeValue(value) } ";
                }
            }
            else
            {
                if (operand.ToLower().Equals("like"))
                {
                    total_wheres += $" OR {escape(field_name)} {escape(operand)} { escapeValueForLike(value) } ";
                }
                else
                {
                    total_wheres += $" OR {escape(field_name)} {escape(operand)}{ escapeValue(value) } ";
                }
            }
            return this;
        }

        public QUERY WHERE_DATE_MODEL()
        {
            return this;
        }

        public QUERY WHERE_BETWEEN_MODEL(string field_name, dynamic start_value, dynamic end_value)
        {
            if (total_wheres.Equals(""))
            {
                total_wheres += $" WHERE {escape(field_name)} BETWEEN {escapeValue(start_value)} and { escapeValue(end_value) } ";
            }
            else
            {
                total_wheres += $" AND {escape(field_name)} BETWEEN {escapeValue(start_value)} and { escapeValue(end_value) } ";
            }
            return this;
        }

        public QUERY OR_WHERE_BETWEEN_MODEL(string field_name, dynamic start_value, dynamic end_value)
        {
            if (total_wheres.Equals(""))
            {
                total_wheres += $" WHERE {escape(field_name)} BETWEEN {escapeValue(start_value)} AND { escapeValue(end_value) } ";
            }
            else
            {
                total_wheres += $" OR {escape(field_name)} BETWEEN {escapeValue(start_value)} AND { escapeValue(end_value) } ";
            }
            return this;
        }


        public QUERY WHERE_NOT_IN_MODEL()
        {
            return this;
        }

        public QUERY WHERE_IN_MODEL()
        {
            return this;
        }

        public QUERY WHERE_RAW_MODEL()
        {
            return this;
        }

        public QUERY GROUP_BY_MODEL(string fields_name)
        {
            groups_by = $" GROUP BY { escape(fields_name) }";
            return this;
        }

        public QUERY ORDER_BY_MODEL(string field_name, string value)
        {
            order_by = $" ORDER BY {  escape(field_name) } { escape(value) } ";
            return this;
        }

        public string GET()
        {
            total_query = $" {total_select} {total_joins} {total_wheres} {groups_by} {order_by}";
            ClearQUERY();
            Console.WriteLine("QUERY LOG RESULT SQL SERVER SYNTAX: " + total_query);
            return total_query;
        }
        private void ClearQUERY()
        {
            total_select = "";
            total_joins = "";
            total_wheres = "";
        }
    }
    public class ConnectionManagerException : Exception
    {
        /// <summary>
        /// @ConnectionManagerException
        /// </summary>
        public ConnectionManagerException()
          : base()
        {
        }

        /// <summary>
        /// Create the exception with description
        /// </summary>
        /// <param name="message">Exception description</param>
        public ConnectionManagerException(String message)
          : base(message)
        {
        }

        /// <summary>
        /// Create the exception with description and inner cause
        /// </summary>
        /// <param name="message">Exception description</param>
        /// <param name="innerException">Exception inner cause</param>
        public ConnectionManagerException(String message, Exception innerException)
          : base(message, innerException)
        {
        }

        /// <summary>
        /// Create the exception from serialized data.
        /// Usual scenario is when exception is occured somewhere on the remote workstation
        /// and we have to re-create/re-throw the exception on the local machine
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Serialization context</param>
        protected ConnectionManagerException(SerializationInfo info, StreamingContext context)
          : base(info, context)
        {
        }                
    }
    public enum CommandExecuteType
    {
        NonQuery = 0,
        NonQueryAsync = 1,
        Reader = 2,
        ReaderAsync = 3,
        Scalar = 4,
        ScalarAsync = 5
    }
}
