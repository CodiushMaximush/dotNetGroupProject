using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GroupProject.Search
{
    class clsSearchSQL
    {
        /// <summary>
        /// Data access class for SQL queries.
        /// </summary>
        clsDataAccess DataAccess;

        /// <summary>
        /// Constructor for SearchSQL class.
        /// </summary>
        public clsSearchSQL()
        {
            string sConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Directory.GetCurrentDirectory() + "\\Group Project DB\\Invoice.mdb";
            DataAccess = new clsDataAccess(sConnectionString);
        }

        /// <summary>
        /// Get list of all invoices.
        /// </summary>
        /// <returns>List of Invoices.</returns>
        public List<Invoices> GetAllInvoices()
        {
            try
            {
                List<Invoices> Invoices = new List<Invoices>();

                int rowsAffected = 0;
                string query = "SELECT * " +
                    "FROM Invoices";
                DataRowCollection rows = DataAccess.ExecuteSQLStatement(query, ref rowsAffected).Tables[0].Rows;
                foreach (DataRow row in rows)
                {
                    Invoices.Add(new Invoices(int.Parse(row.ItemArray[0].ToString()), DateTime.Parse(row.ItemArray[1].ToString()), decimal.Parse(row.ItemArray[2].ToString())));
                }

                return Invoices;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Get invoice with a given number.
        /// </summary>
        /// <returns>Invoice with InvoiceNum equal to parameter.</returns>
        public List<Invoices> GetInvoiceByNumber(int num)
        {
            try
            {
                List<Invoices> Invoices = new List<Invoices>();

                int rowsAffected = 0;
                string query = "SELECT InvoiceNum " +
                    "FROM Invoices WHERE InvoiceNum = " + num.ToString();
                DataRowCollection rows = DataAccess.ExecuteSQLStatement(query, ref rowsAffected).Tables[0].Rows;
                foreach (DataRow row in rows)
                {
                    Invoices.Add(new Invoices((int)row.ItemArray[0], DateTime.Parse(row.ItemArray[1].ToString()), (decimal)row.ItemArray[2]));
                }

                return Invoices;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Get invoices with a given date.
        /// </summary>
        /// <returns>List of invoice dates equal to parameter.</returns>
        public List<Invoices> GetInvoicesByDate(DateTime date)
        {
            try
            {
                List<Invoices> Invoices = new List<Invoices>();
                string parsedDate = date.ToString("d", CultureInfo.CreateSpecificCulture("en-US"));

                int rowsAffected = 0;
                string query = "SELECT InvoiceDate " +
                    "FROM Invoices WHERE InvoiceDate = #" + parsedDate + "#";
                DataRowCollection rows = DataAccess.ExecuteSQLStatement(query, ref rowsAffected).Tables[0].Rows;
                foreach (DataRow row in rows)
                {
                    Invoices.Add(new Invoices((int)row.ItemArray[0], DateTime.Parse(row.ItemArray[1].ToString()), (decimal)row.ItemArray[2]));
                }

                return Invoices;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Get invoices with a given total cost.
        /// </summary>
        /// <returns>List of invoice total costs.</returns>
        public List<Invoices> GetInvoicesByCost(decimal cost)
        {
            try
            {
                List<Invoices> Invoices = new List<Invoices>();

                int rowsAffected = 0;
                string query = "SELECT * " +
                    "FROM Invoices WHERE TotalCost = " + cost.ToString();
                DataRowCollection rows = DataAccess.ExecuteSQLStatement(query, ref rowsAffected).Tables[0].Rows;
                foreach (DataRow row in rows)
                {
                    Invoices.Add(new Invoices((int)row.ItemArray[0], DateTime.Parse(row.ItemArray[1].ToString()), (decimal)row.ItemArray[2]));
                }

                return Invoices;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Get invoices with a given number and date.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="date"></param>
        /// <returns>List of invoices with number and date equal to parameters.</returns>
        public List<Invoices> GetInvoicesByNumAndDate(int num, DateTime date) 
        {
            try
            {
                List<Invoices> Invoices = new List<Invoices>();
                string parsedDate = date.ToString("d", CultureInfo.CreateSpecificCulture("en-US"));

                int rowsAffected = 0;
                string query = "SELECT * " +
                    "FROM Invoices " +
                    "WHERE InvoiceNum = " + num.ToString() + " " +
                    "AND InvoiceDate = '#" + parsedDate + "#'";
                DataRowCollection rows = DataAccess.ExecuteSQLStatement(query, ref rowsAffected).Tables[0].Rows;
                foreach (DataRow row in rows)
                {
                    Invoices.Add(new Invoices((int)row.ItemArray[0], DateTime.Parse(row.ItemArray[1].ToString()), (decimal)row.ItemArray[2]));
                }

                return Invoices;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Get list of invoices with a given number, date, and cost.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="date"></param>
        /// <param name="cost"></param>
        /// <returns>List of invoices with number, date, and cost equal to parameters.</returns>
        public List<Invoices> GetInvoicesByNumAndDateAndCost(int num, DateTime date, decimal cost)
        {
            try
            {
                List<Invoices> Invoices = new List<Invoices>();
                string parsedDate = date.ToString("d", CultureInfo.CreateSpecificCulture("en-US"));

                int rowsAffected = 0;
                string query = "SELECT * " +
                    "FROM Invoices " +
                    "WHERE InvoiceNum = " + num.ToString() + " " +
                    "AND InvoiceDate = '#" + parsedDate + "#' " +
                    "AND TotalCost = " + cost.ToString();
                DataRowCollection rows = DataAccess.ExecuteSQLStatement(query, ref rowsAffected).Tables[0].Rows;
                foreach (DataRow row in rows)
                {
                    Invoices.Add(new Invoices((int)row.ItemArray[0], DateTime.Parse(row.ItemArray[1].ToString()), (decimal)row.ItemArray[2]));
                }

                return Invoices;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Get list of invoices with a given date and cost.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="cost"></param>
        /// <returns>List of invoices with date and cost equal to parameters.</returns>
        public List<Invoices> GetInvoicesByDateAndCost(DateTime date, decimal cost)
        {
            try
            {
                List<Invoices> Invoices = new List<Invoices>();
                string parsedDate = date.ToString("d", CultureInfo.CreateSpecificCulture("en-US"));

                int rowsAffected = 0;
                string query = "SELECT * " +
                    "FROM Invoices " +
                    "WHERE InvoiceDate = '#" + parsedDate + "#' " +
                    "AND TotalCost = " + cost.ToString();
                DataRowCollection rows = DataAccess.ExecuteSQLStatement(query, ref rowsAffected).Tables[0].Rows;
                foreach (DataRow row in rows)
                {
                    Invoices.Add(new Invoices((int)row.ItemArray[0], DateTime.Parse(row.ItemArray[1].ToString()), (decimal)row.ItemArray[2]));
                }

                return Invoices;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Get list of costs of invoices.
        /// </summary>
        /// <returns></returns>
        public List<decimal> GetCosts()
        {
            try
            {
                List<decimal> costs = new List<decimal>();

                int rowsAffected = 0;
                string query = "SELECT TotalCost " +
                    "FROM Invoices";
                DataRowCollection rows = DataAccess.ExecuteSQLStatement(query, ref rowsAffected).Tables[0].Rows;
                foreach (DataRow row in rows)
                {
                    costs.Add((decimal)row.ItemArray[0]);
                }

                return costs;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
