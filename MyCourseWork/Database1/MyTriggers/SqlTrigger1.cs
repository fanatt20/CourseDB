using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.SqlServer.Server;

public partial class Triggers
{
    const byte _endAtColumnIndexInAbsenceRegister = 4;
    const byte _startAtColumnIndexInAbsenceRegister = 3;
    // Enter existing table or view for the target and uncomment the attribute line
    [Microsoft.SqlServer.Server.SqlTrigger(Name = "AbsenceUpdateAudit", Target = "AbsenceRegister", Event = "FOR INSERT,UPDATE")]
    public static void SqlTrigger1()
    {

        using (SqlConnection connection = new SqlConnection(@"context connection=true"))
        {

            SqlCommand command;
            SqlDataReader reader;
            DateTime startAt = DateTime.Now.Date, endAt = DateTime.Now.Date;
            // Open the connection.
            connection.Open();
            try
            {
                // Get the current transaction and roll it back.
                Transaction trans = Transaction.Current;
                trans.Rollback();
            }
            catch (Exception ex) { };
            // Get the inserted value.
            //command = new SqlCommand(@"SELECT StartAt,EndAt FROM INSERTED", connection);

            //reader = command.ExecuteReader();
            //while (reader.Read())
            //{
            //    if (SqlContext.TriggerContext.IsUpdatedColumn(_startAtColumnIndexInAbsenceRegister))
            //        startAt = reader.GetDateTime(0);
            //    if (SqlContext.TriggerContext.IsUpdatedColumn(_endAtColumnIndexInAbsenceRegister))
            //        endAt = reader.GetDateTime(1);
            //    if (startAt.CompareTo(endAt) < 0)
            //    {
            //        try
            //        {
            //            // Get the current transaction and roll it back.
            //            Transaction trans = Transaction.Current;
            //            trans.Rollback();
            //        }
            //        catch (SqlException ex) { }
            //    }

            //}

            //reader.Close();
            connection.Close();
        }


    }
}

