using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace DL
{
    public class ConnectDB
    {
        private string connectionString;
        private SqlConnection conn;

        public ConnectDB() { }

        public ConnectDB(string _connectionString)
        {
            this.connectionString = _connectionString;
        }

        public void OpenConnection()
        {
            try
            {
                conn = new SqlConnection(this.connectionString);
                conn.Open();
            }
            catch(Exception e)
            {
                throw e;
            }
            
        }

        public void CloseConnection()
        {
            try
            {
                this.conn.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public SqlConnection GetConn()
        {
            return this.conn;
        }



        //"INSERT INTO Mem_Basic(Mem_Na,Mem_Occ)  VALUES(@na,@occ);SELECT SCOPE_IDENTITY();"
        //"INSERT INTO Mem_Basic(Mem_Na,Mem_Occ) output INSERTED.ID VALUES(@na,@occ)"



            /// <summary>
            /// DUNG CHO CAC CAU SELECT
            /// </summary>
            /// <param name="stringQuery"></param>
            /// <param name="paras"> cac cot can su dung</param>
            /// <param name="values"> gia tri can truyen vao</param>
            /// <param name="arrTypes">cac kieu du lieu tuong ung</param>
            /// <returns></returns>
        public DataTable GetDataTable(string stringQuery, string[] paras, object[] values, SqlDbType[] arrTypes)
        {
            try
            {
                // open Connection
                this.OpenConnection();

                //tao cmd tu stringQuery va conn
                //cmd = new SqlCommand(stringQuery, conn);

                // tao sqlCommand tu connection
                SqlCommand cmd = this.conn.CreateCommand();
                //gan chuoi stringQuery cho cmd
                cmd.CommandText = stringQuery;


                for (int i = 0; i < paras.Length; i++)
                {
                    // Truyen tham so kieu 1
                    //SqlParameter parameter = new SqlParameter("@namePara", SqlDbType.Decimal);
                    //parameter.Value = 3;
                    //cmd.Parameters.Add(parameter);

                    //Truyen tham so kieu 2

                    //kieu date mac dinh la YYYY/MM/DD
                    if(arrTypes[i] == SqlDbType.Date)
                    {
                        cmd.Parameters.Add(paras[i], SqlDbType.Float).Value = (string)values[i];
                    }
                    else if(arrTypes[i] == SqlDbType.Float)
                    {
                        cmd.Parameters.Add(paras[i], SqlDbType.Float).Value = (float)values[i];
                    }
                    else if((SqlDbType)arrTypes[i] == SqlDbType.Int || (SqlDbType)arrTypes[i] == SqlDbType.Decimal)
                    {
                        cmd.Parameters.Add(paras[i], SqlDbType.Int).Value = (decimal)(values[i]);
                    }
                    else if((SqlDbType)arrTypes[i] == SqlDbType.BigInt)
                    {
                        cmd.Parameters.Add(paras[i], SqlDbType.BigInt).Value = (long)values[i];
                    }
                    else    // anything else is NVarchar
                    {
                        if (values[i] == null)
                        {
                            values[i] = "";
                        }
                        cmd.Parameters.Add(paras[i], SqlDbType.NVarChar).Value = (string)values[i];
                    }
                    
                }

                // Thuc hien truy van
                var reader = cmd.ExecuteReader();
                var dt = new DataTable();
                dt.Load(reader);

                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if(this.conn != null && this.conn.State == System.Data.ConnectionState.Open)
                {
                    this.CloseConnection();
                    conn.Dispose();
                    conn = null;
                }
            }
        }

        public DataTable GetDataTable(string stringQuery)
        {
            try
            {
                // open Connection
                this.OpenConnection();

                //tao cmd tu stringQuery va conn
                //cmd = new SqlCommand(stringQuery, conn);

                // tao sqlCommand tu connection
                SqlCommand cmd = this.conn.CreateCommand();
                //gan chuoi stringQuery cho cmd
                cmd.CommandText = stringQuery;

                // Thuc hien truy van
                var reader = cmd.ExecuteReader();
                var dt = new DataTable();
                dt.Load(reader);

                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (this.conn != null && this.conn.State == System.Data.ConnectionState.Open)
                {
                    this.CloseConnection();
                    conn.Dispose();
                    conn = null;
                }
            }
        }


        /// <summary>
        /// DUNG CHO CAC CAU INSERT, UPDATE tra ve ID vua insert hoac update
        /// </summary>
        /// <returns></returns>
        public int ExecuteQueryReturnID(string stringQuery, string[] paras, object[] values, SqlDbType[] arrTypes)
        {
            try
            {
                // open Connection
                this.OpenConnection();

                //tao cmd tu stringQuery va conn
                //cmd = new SqlCommand(stringQuery, conn);

                // tao sqlCommand tu connection
                SqlCommand cmd = this.conn.CreateCommand();
                //gan chuoi stringQuery cho cmd
                cmd.CommandText = stringQuery;


                for (int i = 0; i < paras.Length; i++)
                {
                    // Truyen tham so kieu 1
                    //SqlParameter parameter = new SqlParameter("@namePara", SqlDbType.Decimal);
                    //parameter.Value = 3;
                    //cmd.Parameters.Add(parameter);

                    //Truyen tham so kieu 2

                    //kieu date mac dinh la YYYY/MM/DD
                    if (arrTypes[i] == SqlDbType.Date)
                    {
                        cmd.Parameters.Add(paras[i], SqlDbType.Float).Value = (string)values[i];
                    }
                    else if (arrTypes[i] == SqlDbType.Float)
                    {
                        cmd.Parameters.Add(paras[i], SqlDbType.Float).Value = (float)values[i];
                    }
                    else if ((SqlDbType)arrTypes[i] == SqlDbType.Int || (SqlDbType)arrTypes[i] == SqlDbType.Decimal)
                    {
                        cmd.Parameters.Add(paras[i], SqlDbType.Int).Value = (int)(values[i]);
                    }
                    else if ((SqlDbType)arrTypes[i] == SqlDbType.BigInt)
                    {
                        cmd.Parameters.Add(paras[i], SqlDbType.BigInt).Value = (long)values[i];
                    }
                    else    // anything else is NVarchar
                    {
                        if (values[i] == null)
                        {
                            values[i] = "";
                        }
                        cmd.Parameters.Add(paras[i], SqlDbType.NVarChar).Value = (string)values[i];
                    }

                }

                int modified = (int)cmd.ExecuteScalar();
                if(modified != 0)
                {
                    return modified;
                }
                return 0;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (this.conn != null && this.conn.State == System.Data.ConnectionState.Open)
                {
                    this.CloseConnection();
                    conn.Dispose();
                    conn = null;
                }
            }
        }


        /// <summary>
        /// Dung cho cac cau INSERT, UPDATE, DELETE nhung tra ve so dong bi thay doi
        /// </summary>
        /// <param name="stringQuery"></param>
        /// <param name="paras"></param>
        /// <param name="values"></param>
        /// <param name="arrTypes"></param>
        /// <returns></returns>
        public int ExecuteQueryReturnNumberRowsEffected(string stringQuery, string[] paras, object[] values, SqlDbType[] arrTypes)
        {
            try
            {
                // open Connection
                this.OpenConnection();

                //tao cmd tu stringQuery va conn
                //cmd = new SqlCommand(stringQuery, conn);

                // tao sqlCommand tu connection
                SqlCommand cmd = this.conn.CreateCommand();
                //gan chuoi stringQuery cho cmd
                cmd.CommandText = stringQuery;


                for (int i = 0; i < paras.Length; i++)
                {
                    // Truyen tham so kieu 1
                    //SqlParameter parameter = new SqlParameter("@namePara", SqlDbType.Decimal);
                    //parameter.Value = 3;
                    //cmd.Parameters.Add(parameter);

                    //Truyen tham so kieu 2

                    //kieu date mac dinh la YYYY/MM/DD
                    if (arrTypes[i] == SqlDbType.Date)
                    {
                        cmd.Parameters.Add(paras[i], SqlDbType.Float).Value = (string)values[i];
                    }
                    else if (arrTypes[i] == SqlDbType.Float)
                    {
                        cmd.Parameters.Add(paras[i], SqlDbType.Float).Value = (float)values[i];
                    }
                    else if ((SqlDbType)arrTypes[i] == SqlDbType.Int || (SqlDbType)arrTypes[i] == SqlDbType.Decimal)
                    {
                        cmd.Parameters.Add(paras[i], SqlDbType.Int).Value = (decimal)(values[i]);
                    }
                    else if ((SqlDbType)arrTypes[i] == SqlDbType.BigInt)
                    {
                        cmd.Parameters.Add(paras[i], SqlDbType.BigInt).Value = (long)values[i];
                    }
                    else    // anything else is NVarchar
                    {
                        if(values[i] == null)
                        {
                            values[i] = "";
                        }
                        cmd.Parameters.Add(paras[i], SqlDbType.NVarChar).Value = (string)values[i];
                    }

                }

                int modified = (int)cmd.ExecuteNonQuery();
                if (modified != 0)
                {
                    return modified;
                }
                return 0;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (this.conn != null && this.conn.State == System.Data.ConnectionState.Open)
                {
                    this.CloseConnection();
                    conn.Dispose();
                    conn = null;
                }
            }
        }


        /// <summary>
        /// Chuyen doi tu DataReader sang DataTable
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private DataTable ConvertDataReaderToDataTabele(SqlDataReader dr)
        {
            try
            {
                DataTable dtSchema = dr.GetSchemaTable();
                DataTable dt = new DataTable();
                // You can also use an ArrayList instead of List<> 
                List<DataColumn> listCols = new List<DataColumn>();
                if (dtSchema != null)
                {
                    foreach (DataRow drow in dtSchema.Rows)
                    {
                        string columnName = System.Convert.ToString(drow["ColumnName"]);
                        DataColumn column = new DataColumn(columnName, (Type)(drow["DataType"]));
                        column.Unique = (bool)drow["IsUnique"];
                        column.AllowDBNull = (bool)drow["AllowDBNull"];
                        column.AutoIncrement = (bool)drow["IsAutoIncrement"];
                        listCols.Add(column);
                        dt.Columns.Add(column);
                    }
                }

                // Read rows from DataReader and populate the DataTable 
                while (dr.Read())
                {
                    DataRow dataRow = dt.NewRow();
                    for (int i = 0; i < listCols.Count; i++)
                    {
                        dataRow[((DataColumn)listCols[i])] = dr[i];
                    }

                    dt.Rows.Add(dataRow);
                }

                return dt;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public DataTable ExecuteQueryGetLastestID(string stringQuery)
        {
            try
            {
                // open Connection
                this.OpenConnection();

                //tao cmd tu stringQuery va conn
                //cmd = new SqlCommand(stringQuery, conn);

                // tao sqlCommand tu connection
                SqlCommand cmd = this.conn.CreateCommand();
                //gan chuoi stringQuery cho cmd
                cmd.CommandText = stringQuery;

                // Thuc hien truy van
                var reader = cmd.ExecuteReader();
                var dt = new DataTable();
                dt.Load(reader);

                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (this.conn != null && this.conn.State == System.Data.ConnectionState.Open)
                {
                    this.CloseConnection();
                    conn.Dispose();
                    conn = null;
                }
            }
        }

    }
}
