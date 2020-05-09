using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CRUDFirma.Classes
{
    class SQLiteKunde
    {
        public static SQLiteConnection sqlconn = new SQLiteConnection("Data Source=.\\dbVerwaltung.db");
        public static SQLiteCommand sqlcmd;
        public static DataTable sqlDt = new DataTable();
        public static DataSet DS = new DataSet();
        public static SQLiteDataAdapter DA;


        public static DataTable LoadData()
        {
            sqlDt.Clear();
            sqlconn.Open();
            sqlcmd = sqlconn.CreateCommand();
            sqlcmd.CommandText = "Select tblKunden.KundeID, tblKunden.Firma, tblKunden.Titel," +
                                 "tblKunden.Anrede, tblKunden.Vorname, tblKunden.Nachname, tblKunden.Strasse, " +
                                 "tblKunden.Telefon, tblKunden.Mail, tblPLZ.PLZ, tblPLZ.Ort, tblPLZ.Land " +
                                 "From tblKunden Inner Join tblPLZ On tblPLZ.PLZ_ID = tblKunden.PLZ_ID";

            using (DA = new SQLiteDataAdapter(sqlcmd.CommandText, sqlconn))
            {
                DA.Fill(sqlDt);
                sqlconn.Close();
                return sqlDt;
            }
        }

        public static void AddData(params string[] arrParam)
        {
            try
            {
                sqlconn.Open();
                sqlcmd = sqlconn.CreateCommand();
                sqlcmd.CommandText = "INSERT INTO Kunden (Firma, Titel, Anrede, Vorname, Nachname, Strasse, PLZ_ID)" +
                                        "VALUES (@newFirma, @newTitel, @newAnrede, @newVorname, @newNachname, @newStrasse, " +
                                        "(SELECT PLZ_ID FROM tblPLZ WHERE PLZ='@PLZ' AND Ort='@Ort'))";
                sqlcmd.Parameters.AddWithValue("@newFirma", arrParam[0]);
                sqlcmd.Parameters.AddWithValue("@newTitel", arrParam[1]);
                sqlcmd.Parameters.AddWithValue("@newAnrede", arrParam[2]);
                sqlcmd.Parameters.AddWithValue("@newVorname", arrParam[3]);
                sqlcmd.Parameters.AddWithValue("@newNachname", arrParam[4]);
                sqlcmd.Parameters.AddWithValue("@newStrasse", arrParam[5]);
                sqlcmd.Parameters.AddWithValue("@newPLZ", arrParam[6]);
                sqlcmd.Parameters.AddWithValue("@newOrt", arrParam[7]);
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public static void Update(params string[] arrParam)
        {
            //try
            //{
            sqlconn.Open();
            sqlcmd = sqlconn.CreateCommand();
            sqlcmd.CommandText = "UPDATE Kunden set Vorname=@newVorname, Nachname=@newNachname, " +
                                    "Strasse=@newStrasse, PLZ=@newPLZ, Ort=@newOrt " +
                                    "WHERE KundeID=@ID";
            sqlcmd.Parameters.AddWithValue("@ID", arrParam[0]);
            sqlcmd.Parameters.AddWithValue("@newVorname", arrParam[1]);
            sqlcmd.Parameters.AddWithValue("@newNachname", arrParam[2]);
            sqlcmd.Parameters.AddWithValue("@newStrasse", arrParam[3]);
            sqlcmd.Parameters.AddWithValue("@newPLZ", arrParam[4]);
            sqlcmd.Parameters.AddWithValue("@newOrt", arrParam[5]);
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
        }
    }
}
