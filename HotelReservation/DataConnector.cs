using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace HotelReservation
{
    public class DataConnector
    {
        SqlConnection connection;
        SqlCommand cmd;
        string path = @"SERVER=DESKTOP-E16BFOH;Database=HotelReservation;Trusted_Connection=true;";

        public DataConnector() 
        {
            connection = new SqlConnection(path);
        }

        public void InsertRooms(Rooms r) 
        {
            string insert ="INSERT INTO Rooms(Room_No,Room_Type,AC_NonAC,Price,CheckOut)" +
                "values(@Room_No,@Room_Type,@AC_NonAC,@Price,@CheckOut)";
            cmd = new SqlCommand(insert,connection);
            cmd.Parameters.AddWithValue("@Room_No",r.RoomNo) ;
            cmd.Parameters.AddWithValue("@Room_Type",r.RoomType);
            cmd.Parameters.AddWithValue("@AC_NonAC",r.AC_NonAC);
            cmd.Parameters.AddWithValue("@Price",r.Price);
            cmd.Parameters.AddWithValue("@CheckOut",r.checkOut);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void updateCheckout(customerReservation cr,string c) 
        {
            string update = "update Rooms set CheckOut=@CheckOut where Room_No=@Room_No";
            cmd = new SqlCommand(update,connection);
            cmd.Parameters.AddWithValue("@Room_No",cr.RoomNo);
            cmd.Parameters.AddWithValue("@CheckOut",c);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public int countroom() 
        {
            string count = "SELECT COUNT(Room_No)FROM ROOMS";
            cmd = new SqlCommand(count,connection);
            connection.Open();
            int c =Convert.ToInt32( cmd.ExecuteScalar());
            connection.Close();

            return c;
        }

        public List<Rooms>  selectroom() 
        {
            string select = "SELECT * FROM ROOMS where CheckOut='CheckOut'";
            cmd = new SqlCommand(select,connection);

            List<Rooms> ls = new List<Rooms>();
            connection.Open();
            SqlDataReader sr=cmd.ExecuteReader();
            while (sr.Read())
            {
                Rooms r = new Rooms()
                {
                    ID = Convert.ToInt64(sr["ID"]),
                    RoomNo = Convert.ToString(sr["Room_No"]),
                    RoomType=sr["Room_Type"].ToString(),
                    AC_NonAC=sr["AC_NonAC"].ToString(),
                    checkOut=sr["CheckOut"].ToString(),
                    Price=Convert.ToInt64(sr["Price"])

                };
                ls.Add(r);
            }
            connection.Close();
            return ls;
        }

        public List<Rooms> Selectallroom()
        {
            string select = "SELECT * FROM ROOMS ";
            cmd = new SqlCommand(select, connection);

            List<Rooms> ls = new List<Rooms>();
            connection.Open();
            SqlDataReader sr = cmd.ExecuteReader();
            while (sr.Read())
            {
                Rooms r = new Rooms()
                {
                    ID = Convert.ToInt64(sr["ID"]),
                    RoomNo = Convert.ToString(sr["Room_No"]),
                    RoomType = sr["Room_Type"].ToString(),
                    AC_NonAC = sr["AC_NonAC"].ToString(),
                    checkOut = sr["CheckOut"].ToString(),
                    Price = Convert.ToInt64(sr["Price"].ToString())
                };
                ls.Add(r);
            }
            connection.Close();
            return ls;
        }

        public List<Rooms> Selectroomtype(string a) 
        {
            string select = "select ID,Room_No from Rooms where Room_Type=@Room_Type and CheckOut=@CheckOut";
            cmd = new SqlCommand(select,connection);
            cmd.Parameters.AddWithValue("@Room_Type",a);
            cmd.Parameters.AddWithValue("@CheckOut","CheckOut");
            List<Rooms> ls = new List<Rooms>();
            connection.Open();
            SqlDataReader reader=cmd.ExecuteReader();
            while (reader.Read())
            {
                Rooms rr = new Rooms()
                {
                    ID = Convert.ToInt64(reader["ID"]),
                    RoomNo = Convert.ToString(reader["Room_No"])
                };
                ls.Add(rr);
            }
            connection.Close();
            return ls;
        }

        public void deleteroom(Rooms r) 
        {
            string delete = "Delete From Rooms where ID=@ID";
            cmd = new SqlCommand(delete,connection);
            cmd.Parameters.AddWithValue("@ID",r.ID);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void updateroom(Rooms r)
        {
            string update = "UPDATE Rooms SET Room_No=@Room_No,Room_Type=@Room_Type,AC_NonAC=@AC_NonAC,Price=@Price,CheckOut=@CheckOut where ID=@ID";
            cmd = new SqlCommand(update,connection);
            cmd.Parameters.AddWithValue("@Room_No",r.RoomNo);
            cmd.Parameters.AddWithValue("@Room_Type", r.RoomType);
            cmd.Parameters.AddWithValue("@AC_NonAC", r.AC_NonAC);
            cmd.Parameters.AddWithValue("@Price", r.Price);
            cmd.Parameters.AddWithValue("@ID", r.ID);
            cmd.Parameters.AddWithValue("@CheckOut", r.checkOut);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

        }

        


        //CustomerReservation


        public void insertRes(customerReservation cr) 
        {
            string insert = "INSERT INTO Customer (Name,Mobile_No,Nationality,Gender,Date_Of_Birth,Id_No,Address,CheckIN_Date,CheckOut_Date,RoomNo,Price)" +
                "VALUES (@Name,@Mobile_No,@Nationality,@Gender,@Date_Of_Birth,@Id_No,@Address,@CheckIN_Date,@CheckOut_Date,@RoomNo,@Price)";
            if (cr.CheckOut==null)
            {
                insert = insert.Replace("@CheckOut_Date","Null");
            }
            cmd = new SqlCommand(insert,connection);
            cmd.Parameters.AddWithValue("@Name",cr.Name);
            cmd.Parameters.AddWithValue("@Mobile_No",cr.MobileNo);
            cmd.Parameters.AddWithValue("@Gender",cr.Gender);
            cmd.Parameters.AddWithValue("@Nationality",cr.Nationality);
            cmd.Parameters.AddWithValue("@Date_Of_Birth",cr.DateOfBirth);
            cmd.Parameters.AddWithValue("@Id_No",cr.ID_No);
            cmd.Parameters.AddWithValue("@Address",cr.Address);
            cmd.Parameters.AddWithValue("@CheckIN_Date",cr.CheckIn);
            cmd.Parameters.AddWithValue("@RoomNo",cr.RoomNo);
            cmd.Parameters.AddWithValue("@Price",cr.Price=0);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void updatecustomerList(customerReservation cr) 
        {
            string update = "UPDATE Customer SET CheckOut_Date=@CheckOut_Date,Price=@Price WHERE ID=@ID";
            cmd = new SqlCommand(update,connection);
            cmd.Parameters.AddWithValue("CheckOut_Date",cr.CheckOut);
            cmd.Parameters.AddWithValue("@Price",cr.Price);
            cmd.Parameters.AddWithValue("@ID",cr.ID);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public List<customerReservation> SelectCutomer() 
        {
            string select = "Select c.*,r.Room_Type,r.AC_NonAC from Customer as c Join Rooms as r on c.RoomNo=r.Room_No ";
            cmd = new SqlCommand(select,connection);

            List<customerReservation> ls = new List<customerReservation>();
            connection.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                customerReservation c = new customerReservation()
                {
                    ID = Convert.ToInt64(reader["ID"]),
                    Name = reader["Name"].ToString(),
                    MobileNo = Convert.ToInt64(reader["Mobile_No"]),
                    Nationality = reader["Nationality"].ToString(),
                    Gender = reader["Gender"].ToString(),
                    ID_No = reader["Id_No"].ToString(),
                    Address = reader["Address"].ToString(),
                    DateOfBirth = Convert.ToDateTime(reader["Date_Of_Birth"]),
                    CheckIn = Convert.ToDateTime(reader["CheckIN_Date"]),
                    RoomNo = reader["RoomNo"].ToString(),
                    RoomType = reader["Room_Type"].ToString(),
                    Price = Convert.ToInt64(reader["Price"]),
                    ac = reader["AC_NonAC"].ToString()
                    
                };
                if (reader["CheckOut_Date"].ToString()=="")
                {
                    c.CheckOut = null;
                    
                }
                else
                {
                    c.CheckOut = Convert.ToDateTime(reader["CheckOut_Date"].ToString());
                }
                ls.Add(c);
            }
            connection.Close();
            return ls;
        }

        //Search

        public List<customerReservation> searchresult(string a) 
        {
            string select = "Select c.*,r.Room_Type from Customer as c Join Rooms as r on c.RoomNo=r.Room_No where Name like '" + @a+"%' or RoomNo like '"+@a+"%'";
            cmd = new SqlCommand(select,connection);
            cmd.Parameters.AddWithValue("@a", a);
           
            List<customerReservation> ls = new List<customerReservation>();
            connection.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                customerReservation c = new customerReservation()
                {
                    ID = Convert.ToInt64(reader["ID"]),
                    Name = reader["Name"].ToString(),
                    MobileNo = Convert.ToInt64(reader["Mobile_No"]),
                    Nationality = reader["Nationality"].ToString(),
                    Gender = reader["Gender"].ToString(),
                    ID_No = reader["Id_No"].ToString(),
                    Address = reader["Address"].ToString(),
                    DateOfBirth = Convert.ToDateTime(reader["Date_Of_Birth"]),
                    CheckIn = Convert.ToDateTime(reader["CheckIN_Date"]),
                    RoomNo = reader["RoomNo"].ToString(),
                    RoomType = reader["Room_Type"].ToString(),
                    Price = Convert.ToInt64(reader["Price"])
                };
                if (reader["CheckOut_Date"].ToString() == "")
                {
                    c.CheckOut = null;

                }
                else
                {
                    c.CheckOut = Convert.ToDateTime(reader["CheckOut_Date"].ToString());
                }
                ls.Add(c);
            }
            connection.Close();
            return ls;
        }


        public void deletecustomer(customerReservation c) 
        {
            string delete = "DELETE FROM Customer WHERE ID=@ID";
            cmd = new SqlCommand(delete,connection);
            cmd.Parameters.AddWithValue("@ID",c.ID);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void updatecustomer(customerReservation cr)
        {
            string update = "UPDATE Customer SET Name=@Name,Mobile_No=@Mobile_No,Nationality=@Nationality,Gender=@Gender" +
                ",Date_Of_Birth=@Date_Of_Birth,Id_No=@Id_No,Address=@Address,CheckIN_Date=@CheckIN_Date,CheckOut_Date=@CheckOut_Date,RoomNo=@RoomNo,Price=@Price WHERE ID=@ID";
            if (cr.CheckOut==null)
            {
                update = update.Replace("@CheckOut_Date","Null");
            }
            cmd = new SqlCommand(update,connection);

            cmd.Parameters.AddWithValue("@ID",cr.ID);
            cmd.Parameters.AddWithValue("@Name",cr.Name);
            cmd.Parameters.AddWithValue("@Mobile_No", cr.MobileNo);
            cmd.Parameters.AddWithValue("@Nationality", cr.Nationality);
            cmd.Parameters.AddWithValue("@Gender", cr.Gender);
            cmd.Parameters.AddWithValue("@Date_Of_Birth", cr.DateOfBirth);
            cmd.Parameters.AddWithValue("@Id_No", cr.ID_No);
            cmd.Parameters.AddWithValue("@Address", cr.Address);
            cmd.Parameters.AddWithValue("@CheckIN_Date", cr.CheckIn);
            if (cr.CheckOut!=null)
            {
                cmd.Parameters.AddWithValue("@CheckOut_Date", cr.CheckOut);
            }
            cmd.Parameters.AddWithValue("@RoomNo", cr.RoomNo);
            cmd.Parameters.AddWithValue("@Price", cr.Price);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        

    }
}
