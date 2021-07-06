using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.OleDb;

namespace LibrarySystem
{
    #region Connection Extensions
    public static class Extensions
    {
        //Checking if the connection to the database is working.
        public static bool IsAvailable(this OleDbConnection con)
        {
            try
            {
                con.Open();
                con.Close();
            }
            catch (OleDbException)
            {
                return false;
            }
            return true;
        }

        //Boolean for checking table to save space and create table only when visitor borrowed something.
        public static bool TableExists(this OleDbConnection con, string table)
        {
            con.Open();
            bool exists = con.GetSchema("Tables", new string[4] { null, null, table, "TABLE" }).Rows.Count > 0;
            con.Close();
            return exists;
        }
    }
    #endregion

    #region Show Wait Cursor During Proccess
    public class RunProcess : IDisposable
    {
        private readonly Form form;
        private readonly Control formControl;
        private readonly bool closeForm;

        public RunProcess(object currentObject, bool closeObject = true)
        {
            if (currentObject is Form)
            {
                closeForm = closeObject;
                form = currentObject as Form; //Assigning the value for the placeholder to be able to use in the dispose call
                Cursor.Current = Cursors.WaitCursor;
                if ((form.Name == "LoginForm" || form.Name == "MainForm") && closeObject)
                {
                    form.Hide();
                }
            }
            else
            {
                formControl = currentObject as Control; //Assigning the value for the placeholder to be able to use in the dispose call
                formControl.Cursor = Cursors.WaitCursor; //Wait cursor applied to specific control
                formControl.Enabled = false; //User won't be able to click the control during the process
            }
        }

        public void Dispose() //Happens at the end of the using block.
        {
            if (form != null)
            {
                Cursor.Current = Cursors.Default;
                if ((form.Name == "LoginForm" || form.Name == "MainForm") && closeForm == true)
                {
                    form.Close();
                }
            }
            else
            {
                formControl.Cursor = Cursors.Default; //Set it back to mouse pointer
                formControl.Enabled = true; //User can finally click the control
            }
        }
    }
    #endregion

    public static class StringExtensions
    {
        public static string FirstCharToUpper(this string input)
        {
            switch (input)
            {
                case null: throw new ArgumentNullException(nameof(input));
                case "": throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
                default: return input.First().ToString().ToUpper() + input.Substring(1);
            }
        }
    }
}
