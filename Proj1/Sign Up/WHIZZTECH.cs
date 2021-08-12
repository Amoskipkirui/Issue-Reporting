using System;
using System.IO;
using System.Data;
using System.Text;
using System.Web;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
//using System.Web.UI;
using System.Security;
using System.Security.Cryptography;
using System.Threading;

using SQL_KCA = System.Data.SqlClient;


namespace WHIZZTECH
{
    public class cConnect
    {
        private string mConnectionString = "";
        private SQL_KCA.SqlConnection mDB;

        /// <summary>
        /// Class Constructor
        /// initializes the connection [opens the database].
        /// </summary>
        public cConnect()
        {
            try
            {
                //this.mConnectionString = "Data Source=./;Initial Catalog=POS;Persist Security Info=True";
                //this.mConnectionString = @"Data Source=./;Initial Catalog=POS; User ID='WarrenMachani';Password='mother569'";
                //DateTime t1;
                //string mytime="9/25/2013 12:35:14 PM";
                //DateTime M1=Convert.ToDateTime(mytime);
                //t1 = System.DateTime.Now;
                ////string myTime = t1.ToString("ddMMyyyy");

                //if (M1 <= t1)
                //{

                //}
                //if (M1 >= t1)
                //{
                    //this.mConnectionString = @"Data Source=./;Initial Catalog=POS2; User ID='WarrenMachani';Password='mother.warren.machani.569'";//62.24.100.140
                this.mConnectionString = "Data Source=ATLHQPS\\SQLEXPRESS;Initial Catalog=EasyMa; User ID='atm';Password='atm'";
                    this.mDB = new SQL_KCA.SqlConnection(this.mConnectionString);
                    this.mDB.Open();
                //}
            }
            catch (Exception)
            {
                throw; /* bubble the error to the active document,
* where the error is caught and resolved */
            }
        }

        /// <summary>
        /// This method is used for reading purposes only.
        /// NB: Only for reading NOT writing.
        /// The database will have a shared lock.
        ///
        ///
        ///
        /// </summary>
        ///
        /// <param name="vSQL">SQL statement 2B executed.</param>
        /// <param name="vCryptographyDetails">
        /// the parameters used to encrypt the sql statement</param>
        /// <returns>
        /// returns a data reader containing the execution
        /// results of the sql select statement
        /// </returns>
        public SQL_KCA.SqlDataReader ReadDB(string vSQL)
        {
            SQL_KCA.SqlDataReader r = null;

            try
            {
                SQL_KCA.SqlCommand vCMD = new System.Data.SqlClient.SqlCommand(vSQL, this.mDB);
                r = vCMD.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception)
            {
                //string s = ex.Message;
                throw; /* bubble the error to the active document,
* where the error is caught and resolved */
            }
            return r;
        }

        /// <summary>
        /// DA: This method is used for reading purposes only.
        /// NB: Only for reading NOT writing.
        /// The database will have a shared lock.
        /// </summary> 
        /// <param name="vSQL">SQL statement 2B executed.</param>m>
        /// <returns>
        /// returns a data adapter containing the execution
        /// results of the sql select statement
        /// </returns>
        public SQL_KCA.SqlDataAdapter ReadDB2(string vSQL)
        {
            SQL_KCA.SqlDataAdapter r = null;

            try
            {
                r = new SQL_KCA.SqlDataAdapter(vSQL, this.mDB);
                r.AcceptChangesDuringFill = false;
                r.AcceptChangesDuringUpdate = false;

            }
            catch (Exception)
            {
                //string s = ex.Message;
                throw; /* bubble the error to the active document,
* where the error is caught and resolved */
            }
            return r;
        }

        /// <summary>
        /// This method is used to update/insert/delete
        /// records using the appropriate SQL Statements.
        /// The database will have an exclusive lock.
        ///
        ///
        ///
        /// </summary>
        ///
        /// <param name="vSQL">SQL Statement 2B executed</param>
        /// <param name="vCryptographyDetails">
        /// the parameters used to encrypt the sql statement</param>
        public void WriteDB(string vSQL)
        {
            DataSet vDS = new DataSet();

            try
            {
                vDS.EnforceConstraints = true;

                SQL_KCA.SqlDataAdapter vDA = new SQL_KCA.SqlDataAdapter
                (vSQL, this.mConnectionString);

                vDA.AcceptChangesDuringFill = true;
                vDA.Fill(vDS);
            }
            catch (Exception)
            {
                vDS.RejectChanges();
                vDS.Dispose();
                throw; /* bubble the error to the active document,
* where the error is caught and resolved */
            }
            finally
            {
                this.mDB.Close();
            }
        }

    }//end of cConnect

}
