

#define MySQL
#define FIREBASE

#if MySQL
using DbConnection = MySql.Data.MySqlClient.MySqlConnection;
using DbConnectionStringBuilder = MySql.Data.MySqlClient.MySqlConnectionStringBuilder;
using DbCommand = MySql.Data.MySqlClient.MySqlCommand;
#elif MSSQL
using DbConnection = System.Data.SqlClient.SqlConnection;
using DbConnectionStringBuilder = System.Data.SqlClient.SqlConnectionStringBuilder;
#endif




namespace MVeresiyeDL;


public static class DL
{

# if FIREBASE
#elif MySQL      
#endif



    static DbConnection conn = new(new DbConnectionStringBuilder()
    {
#if MySQL
        Server = "localhost", 
        UserID = "root", 
        Password = "5545228936Zm",
        Database = "veresiye",
     
#endif
    }.ConnectionString);

    public static int KisiEkle(String kid, string ad, string soyad, string telefon, string mail, string adres,
        out string error)
    {
        try
        {
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            string komut = "KisiEkle";
            DbCommand com = new DbCommand(komut, conn)
            {
                CommandType = System.Data.CommandType.StoredProcedure

            };
            com.Parameters.AddWithValue("in_kid", kid);
            com.Parameters.AddWithValue("in_ad", ad);
            com.Parameters.AddWithValue("in_soyad", soyad);
            com.Parameters.AddWithValue("in_telefon", telefon);
            com.Parameters.AddWithValue("in_mail", mail);
            com.Parameters.AddWithValue("in_adres", adres);
            error = "";
            return com.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
            error = ex.Message;
            return -1;
        }
        finally
        {
            if (conn.State != System.Data.ConnectionState.Closed)
            {
                conn.Close();
            }
        }
    }

    public static int KisiDuzenle(String kid, string ad, string soyad, string telefon, string mail, string adres,
      out string error)
    {
        try
        {
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            string komut = "KisiDuzenle";
            DbCommand com = new DbCommand(komut, conn)
            {
                CommandType = System.Data.CommandType.StoredProcedure

            };
            com.Parameters.AddWithValue("in_kid", kid);
            com.Parameters.AddWithValue("in_ad", ad);
            com.Parameters.AddWithValue("in_soyad", soyad);
            com.Parameters.AddWithValue("in_telefon", telefon);
            com.Parameters.AddWithValue("in_mail", mail);
            com.Parameters.AddWithValue("in_adres", adres);
            error = "";
            return com.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
            error = ex.Message;
            return -1;
        }
        finally
        {
            if (conn.State != System.Data.ConnectionState.Closed)
            {
                conn.Close();
            }
        }
    }

    public static int KisiSil(String kid, out string error)
    {
        try
        {
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            string komut = "KisiSil";
            DbCommand com = new DbCommand(komut, conn)
            {
                CommandType = System.Data.CommandType.StoredProcedure,

            };
            com.Parameters.AddWithValue("in_kid", kid);

            error = "";
            return com.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
            error = ex.Message;
            return -1;
        }
        finally
        {
            if (conn.State != System.Data.ConnectionState.Closed)
            {
                conn.Close();
            }
        }
    }


    public static int GirdiEkle(String gid, String kid, float miktar, DateTime tarih, string aciklama,
      out string error)
    {
        try
        {
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            string komut = "GirdiEkle";
            DbCommand com = new DbCommand(komut, conn)
            {
                CommandType = System.Data.CommandType.StoredProcedure

            };
            com.Parameters.AddWithValue("in_gid", gid);
            com.Parameters.AddWithValue("in_kid", kid);
            com.Parameters.AddWithValue("in_miktar", miktar);
            com.Parameters.AddWithValue("in_tarih", tarih);
            com.Parameters.AddWithValue("in_aciklama", aciklama);

            error = "";
            return com.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
            error = ex.Message;
            return -1;
        }
        finally
        {
            if (conn.State != System.Data.ConnectionState.Closed)
            {
                conn.Close();
            }
        }
    }


    public static int GirdiDuzenle(String gid, float miktar, DateTime tarih, string aciklama,
     out string error)
    {
        try
        {
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            string komut = "GirdiDuzenle";
            DbCommand com = new DbCommand(komut, conn)
            {
                CommandType = System.Data.CommandType.StoredProcedure

            };
            com.Parameters.AddWithValue("in_gid", gid);
            com.Parameters.AddWithValue("in_miktar", miktar);
            com.Parameters.AddWithValue("in_tarih", tarih);
            com.Parameters.AddWithValue("in_aciklama", aciklama);

            error = "";
            return com.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
            error = ex.Message;
            return -1;
        }
        finally
        {
            if (conn.State != System.Data.ConnectionState.Closed)
            {
                conn.Close();
            }
        }
    }

    public static int GirdiSil(String gid, out string error)
    {
        try
        {
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            string komut = "GirdiSil";
            DbCommand com = new DbCommand(komut, conn)
            {
                CommandType = System.Data.CommandType.StoredProcedure

            };
            com.Parameters.AddWithValue("in_gid", gid);

            error = "";
            return com.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
            error = ex.Message;
            return -1;
        }
        finally
        {
            if (conn.State != System.Data.ConnectionState.Closed)
            {
                conn.Close();
            }
        }
    }

    public static List<(string kid,
                        string ad,
                        string soyad,
                        string telefon,
                        string mail,
                        string adres)> TumKisiler(out string error)
    {

        var liste = new List<(string, string, string, string, string,string)>();

        try
        {
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            string komut = "TumKisiler";
            DbCommand com = new DbCommand(komut, conn)
            {
                CommandType = System.Data.CommandType.StoredProcedure

            };
            

            error = "";
            var dr = com.ExecuteReader();
            {
                while (dr.Read())
                {
                    liste.Add(
                        (dr[0].ToString(),
                        dr[1].ToString(),
                        dr[2].ToString(),
                        dr[3].ToString(),
                        dr[4].ToString(),
                        dr[5].ToString())
                        );
                }
                return liste;
            }

        }
        catch (Exception ex)
        {
           
            error = ex.Message;
            return null;
        }
        finally
        {
            if (conn.State != System.Data.ConnectionState.Closed)
            {
                conn.Close();
            }
        }

        
    }

    public static List<(string gid,
                        string kid,
                        float miktar,
                        DateTime tarih,
                        string aciklama)> TumGirdiler(out string error)
    {
        var liste = new List<(string, string, float, DateTime, string)>();

        try
        {
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            string komut = "TumGirdiler";
            DbCommand com = new DbCommand(komut, conn)
            {
                CommandType = System.Data.CommandType.StoredProcedure

            };


            error = "";
            var dr = com.ExecuteReader();
            {
                while (dr.Read())
                {
                    liste.Add(
                        (dr[0].ToString(),
                        dr[1].ToString(),
                        (float)dr[2],
                       (DateTime) dr[3],
                        dr[4].ToString())
                        );
                }
                return liste;
            }

        }
        catch (Exception ex)
        {

            error = ex.Message;
            return null;
        }
        finally
        {
            if (conn.State != System.Data.ConnectionState.Closed)
            {
                conn.Close();
            }
        }
    }
        
}

