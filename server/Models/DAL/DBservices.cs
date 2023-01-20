using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using exe1HW.Models;
using Microsoft.AspNetCore.Mvc;

//using RuppinProj.Models;

/// <summary>
/// DBServices is a class created by me to provides some DataBase Services
/// </summary>
public class DBservices
{
    public SqlDataAdapter da;
    public DataTable dt;

    public DBservices()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    //--------------------------------------------------------------------------------------------------
    // This method creates a connection to the database according to the connectionString name in the web.config 
    //--------------------------------------------------------------------------------------------------
    public SqlConnection connect(String conString)
    {

        // read the connection string from the configuration file
        IConfigurationRoot configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json").Build();
        string cStr = configuration.GetConnectionString("myProjDB");
        SqlConnection con = new SqlConnection(cStr);
        con.Open();
        return con;
    }

    //--------------------------------------------------------------------------------------------------
    // This method inserts a user to the user table 
    //--------------------------------------------------------------------------------------------------
    public int Insert(User user)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateCommandWithStoredProcedureAddUser("spAddUser", con, user);           // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }
    //--------------------------------------------------------------------------------------------------
    // This method inserts a vacation to the vacation table 
    //--------------------------------------------------------------------------------------------------
    public int Insert(Vacation vacation)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateCommandWithStoredProcedureAddVacation("spAddVacation", con, vacation);           // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }
    //--------------------------------------------------------------------------------------------------
    // This method inserts a flat to the flat table 
    //--------------------------------------------------------------------------------------------------
    public int Insert(Flat flat)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateCommandWithStoredProcedureAddFlat("spAddFlat", con, flat);           // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }
    ////--------------------------------------------------------------------------------------------------
    //// This method read all users  from user table 
    ////--------------------------------------------------------------------------------------------------
   
    public List<Object> getvagPrice(int month)
    {
        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        //String cStr = BuildUpdateCommand(student);      // helper method to build the insert string

        cmd = CreateCommandWithStoredProceduregetvagPrice("spGetAvgPriceByMonth", con,month);             // create the command


        List<Object> list = new List<Object>();

        try
        {


            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dataReader.Read())
            {



                list.Add(new
                {
                    city = dataReader["city"].ToString(),
                    avg =(double)dataReader["avgprice"]

                });

            }

            return list;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }
    }








    public List<User> Readusers()
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        //String cStr = BuildUpdateCommand(student);      // helper method to build the insert string

        cmd = CreateCommandWithStoredProcedureReadallUser("spGetUsers", con);             // create the command


        List<User> list = new List<User>();

        try
        {


            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dataReader.Read())
            {

                User user = new User();
                user.FirstName = dataReader["FirstName"].ToString();
                user.FamilyName = dataReader["FamilyName"].ToString();
                user.Email = dataReader["Email"].ToString();
                user.Password = dataReader["password"].ToString();
                user.IsActive = (bool)dataReader["isActive"];
                user.IsAdmin = (bool)dataReader["isAdmin"];

                list.Add(user);
            }

            return list;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }


    ////--------------------------------------------------------------------------------------------------
    //// This method read a user by email from user table 
    ////--------------------------------------------------------------------------------------------------
    public List<User> Read(string email, string password)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        //String cStr = BuildUpdateCommand(student);      // helper method to build the insert string

        cmd = CreateCommandWithStoredProcedureReadUser("spGetUserByEmail", con, email, password);             // create the command


        List<User> list = new List<User>();

        try
        {


            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dataReader.Read())
            {

                User user = new User();
                user.FirstName = dataReader["FirstName"].ToString();
                user.FamilyName = dataReader["FamilyName"].ToString();
                user.Email = dataReader["Email"].ToString();
                user.Password = dataReader["password"].ToString();
                user.IsActive = (bool)dataReader["isActive"];
                user.IsAdmin = (bool)dataReader["isAdmin"];

                list.Add(user);
            }

            return list;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }
    ////--------------------------------------------------------------------------------------------------
    //// This method read all vacation from vacation table 
    ////--------------------------------------------------------------------------------------------------
    public List<Vacation> ReadVaction()
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        //String cStr = BuildUpdateCommand(student);      // helper method to build the insert string

        cmd = CreateCommandWithStoredProcedureReadVacations("spGetVacations", con);             // create the command


        List<Vacation> list = new List<Vacation>();

        try
        {


            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dataReader.Read())
            {

                Vacation vacation = new Vacation();
                vacation.Id= Convert.ToInt32(dataReader["id"]);
                vacation.UserEmail = dataReader["UserEmail"].ToString();
                vacation.FlatId = Convert.ToInt32(dataReader["FlatId"]);
                vacation.StartDate = Convert.ToDateTime(dataReader["StartDate"]);
                vacation.Enddate = Convert.ToDateTime(dataReader["EndDate"]);

                list.Add(vacation);
            }

            return list;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }
    ////--------------------------------------------------------------------------------------------------
    //// This method read all flat form db flat table 
    ////--------------------------------------------------------------------------------------------------
    public List<Flat> Read()
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        //String cStr = BuildUpdateCommand(student);      // helper method to build the insert string

        cmd = CreateCommandWithStoredProcedureReadFlat("spGetFlats", con);             // create the command


        List<Flat> list = new List<Flat>();

        try
        {


            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dataReader.Read())
            {

                Flat flat = new Flat();
                flat.Id = Convert.ToInt32(dataReader["Id"]);
                flat.City = dataReader["City"].ToString();
                flat.Address = dataReader["Address"].ToString();
                flat.Price = Convert.ToDouble(dataReader["Price"]);
                flat.NumberOfRooms = Convert.ToDouble(dataReader["NumberOfRooms"]);

                list.Add(flat);
            }

            return list;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }
    //--------------------------------------------------------------------------------------------------
    // This method delete a flat 
    //--------------------------------------------------------------------------------------------------
    public List<Flat> DeleteFlat(int id)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateCommandWithStoredProcedureDeleteFlat("spDeleteFlat", con, id);           // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return Read();
        }
        catch (Exception ex)
        {
            return new List<Flat>();

        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    //--------------------------------------------------------------------------------------------------
    // This method delete a vacation 
    //--------------------------------------------------------------------------------------------------
    public List<Vacation> DeleteVacation(int  id)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateCommandWithStoredProcedureDeleteVacation("spDeleteVacation", con, id);           // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return ReadVaction();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
            
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }
    //--------------------------------------------------------------------------------------------------
    // This method delete a user 
    //--------------------------------------------------------------------------------------------------
    public List<User> Delete (string email)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateCommandWithStoredProcedureDeleteUser("spDeleteUser", con, email);           // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return Readusers();
        }
        catch (Exception ex)
        {
            return new List<User>();
            
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }



    //--------------------------------------------------------------------------------------------------
    // This method update a user 
    //--------------------------------------------------------------------------------------------------
    public int Update(User user)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateCommandWithStoredProcedureUpdateUser("spUpdateUser", con, user);           // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            //return Readusers();
            return numEffected;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }
    //--------------------------------------------------------------------------------------------------
    // This method update a user for admin page
    //--------------------------------------------------------------------------------------------------
    public List<User> UpdateAdmin(User user)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateCommandWithStoredProcedureUpdateUser("spUpdateUser", con, user);           // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return Readusers();
            
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }
    //--------------------------------------------------------------------------------------------------
    // This method update a vacation 
    //--------------------------------------------------------------------------------------------------
    public List<Vacation> UpdateVaction(Vacation vacation)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateCommandWithStoredProcedureUpdateVacation("spUpdateVacation", con, vacation);           // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return ReadVaction();
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }
    //--------------------------------------------------------------------------------------------------
    // This method update a vacation 
    //--------------------------------------------------------------------------------------------------
    public List<Flat> UpdateFlat(Flat flat)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateCommandWithStoredProcedureUpdateFlat("spUpdateFlat", con, flat);           // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return Read();
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }


    private SqlCommand CreateCommandWithStoredProceduregetvagPrice(string spName, SqlConnection con, int month)
    {
        SqlCommand cmd = new SqlCommand(); // create the command Object

        cmd.Connection = con;              // assign the connection to the command Object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be stored procedure
        cmd.Parameters.AddWithValue("@month", month);
       
        return cmd;
    }


    private SqlCommand CreateCommandWithStoredProcedureAddUser(string spName, SqlConnection con, User user)
    {
        SqlCommand cmd = new SqlCommand(); // create the command Object

        cmd.Connection = con;              // assign the connection to the command Object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be stored procedure
        cmd.Parameters.AddWithValue("@firstName", user.FirstName);
        cmd.Parameters.AddWithValue("@lastName", user.FamilyName);
        cmd.Parameters.AddWithValue("@email", user.Email);
        cmd.Parameters.AddWithValue("@password", user.Password);
        cmd.Parameters.AddWithValue("@isactive", user.IsActive);
        cmd.Parameters.AddWithValue("@isadmin", user.IsAdmin);
        return cmd;
    }

    private SqlCommand CreateCommandWithStoredProcedureAddVacation(string spName, SqlConnection con, Vacation vacation)
    {
        SqlCommand cmd = new SqlCommand(); // create the command Object

        cmd.Connection = con;              // assign the connection to the command Object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be stored procedure
        cmd.Parameters.AddWithValue("@userEmail", vacation.UserEmail);
        cmd.Parameters.AddWithValue("@faltId", vacation.FlatId);
        cmd.Parameters.AddWithValue("@startDate", vacation.StartDate);
        cmd.Parameters.AddWithValue("@endDate", vacation.Enddate);
        return cmd;
    }

    private SqlCommand CreateCommandWithStoredProcedureAddFlat(string spName, SqlConnection con, Flat flat)
    {
        SqlCommand cmd = new SqlCommand(); // create the command Object

        cmd.Connection = con;              // assign the connection to the command Object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be stored procedure
        cmd.Parameters.AddWithValue("@city", flat.City);
        cmd.Parameters.AddWithValue("@address", flat.Address);
        cmd.Parameters.AddWithValue("@numberOfRooms", flat.NumberOfRooms);
        cmd.Parameters.AddWithValue("@price", flat.Price);
        return cmd;
    }
    private SqlCommand CreateCommandWithStoredProcedureUpdateUser(string spName, SqlConnection con, User user)
    {
        SqlCommand cmd = new SqlCommand(); // create the command Object

        cmd.Connection = con;              // assign the connection to the command Object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be stored procedure
        cmd.Parameters.AddWithValue("@firstName", user.FirstName);
        cmd.Parameters.AddWithValue("@lastName", user.FamilyName);
        cmd.Parameters.AddWithValue("@email", user.Email);
        cmd.Parameters.AddWithValue("@password", user.Password);
        cmd.Parameters.AddWithValue("@isactive", user.IsActive);
        cmd.Parameters.AddWithValue("@isadmin", user.IsAdmin);
        return cmd;
    }
    

         private SqlCommand CreateCommandWithStoredProcedureDeleteFlat(string spName, SqlConnection con, int id)
    {
        SqlCommand cmd = new SqlCommand(); // create the command Object

        cmd.Connection = con;              // assign the connection to the command Object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be stored procedure
        cmd.Parameters.AddWithValue("@id", id);

        return cmd;
    }
    private SqlCommand CreateCommandWithStoredProcedureDeleteVacation(string spName, SqlConnection con, int id)
    {
        SqlCommand cmd = new SqlCommand(); // create the command Object

        cmd.Connection = con;              // assign the connection to the command Object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be stored procedure
        cmd.Parameters.AddWithValue("@id", id);

        return cmd;
    }
    private SqlCommand CreateCommandWithStoredProcedureDeleteUser(string spName, SqlConnection con, string email)
    {
        SqlCommand cmd = new SqlCommand(); // create the command Object

        cmd.Connection = con;              // assign the connection to the command Object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be stored procedure
        cmd.Parameters.AddWithValue("@email", email);

        return cmd;
    }

    private SqlCommand CreateCommandWithStoredProcedureReadallUser(string spName, SqlConnection con)
    {
        SqlCommand cmd = new SqlCommand(); // create the command Object

        cmd.Connection = con;              // assign the connection to the command Object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be stored procedure


        return cmd;
    }
    private SqlCommand CreateCommandWithStoredProcedureReadUser(string spName, SqlConnection con, string email, string password)
    {
        SqlCommand cmd = new SqlCommand(); // create the command Object

        cmd.Connection = con;              // assign the connection to the command Object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be stored procedure
        cmd.Parameters.AddWithValue("@email", email);
        cmd.Parameters.AddWithValue("@password", password);

        return cmd;
    }

    private SqlCommand CreateCommandWithStoredProcedureReadFlat(string spName, SqlConnection con)
    {
        SqlCommand cmd = new SqlCommand(); // create the command Object

        cmd.Connection = con;              // assign the connection to the command Object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be stored procedure

        return cmd;
    }
    private SqlCommand CreateCommandWithStoredProcedureReadVacations(string spName, SqlConnection con)
    {
        SqlCommand cmd = new SqlCommand(); // create the command Object

        cmd.Connection = con;              // assign the connection to the command Object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be stored procedure

        return cmd;
    }

    private SqlCommand CreateCommandWithStoredProcedureUpdateVacation(string spName, SqlConnection con, Vacation vacation)
    {
        SqlCommand cmd = new SqlCommand(); // create the command Object

        cmd.Connection = con;              // assign the connection to the command Object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be stored procedure
        cmd.Parameters.AddWithValue("@id", vacation.Id);
        cmd.Parameters.AddWithValue("@userEmail", vacation.UserEmail);
        cmd.Parameters.AddWithValue("@faltId", vacation.FlatId);
        cmd.Parameters.AddWithValue("@startDate", vacation.StartDate);
        cmd.Parameters.AddWithValue("@endDate", vacation.Enddate);

        return cmd;
    }
    private SqlCommand CreateCommandWithStoredProcedureUpdateFlat(string spName, SqlConnection con, Flat flat)
    {
        SqlCommand cmd = new SqlCommand(); // create the command Object

        cmd.Connection = con;              // assign the connection to the command Object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be stored procedure
        cmd.Parameters.AddWithValue("@id", flat.Id);
        cmd.Parameters.AddWithValue("@city", flat.City);
        cmd.Parameters.AddWithValue("@address", flat.Address);
        cmd.Parameters.AddWithValue("@price", flat.Price);
        cmd.Parameters.AddWithValue("@numberOfRooms", flat.NumberOfRooms);

        return cmd;
    }



}
