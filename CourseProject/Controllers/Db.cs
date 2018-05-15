using CourseProject.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;


public static class Db
{

    public static DataTable GetRooms()
    {
        SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [Rooms] order by [Number]", ConfigurationManager.ConnectionStrings["daypilot"].ConnectionString);
        DataTable dt = new DataTable();
        da.Fill(dt);

        return dt;
    }

    public static IEnumerable<SelectListItem> GetRoomSelectList()
    {
        //var allRooms = GetRooms();
        //var tempList = allRooms.AsEnumerable().Select(u => new SelectListItem
        //{

        //    //Value = u.Field<string>("Id"),
        //    Value = u.Field<string>("Id"),
        //    Text = Convert.ToString(u.Field<int>("Number"))
        //});
        //return tempList;
        return GetRooms().AsEnumerable().Select(u => new SelectListItem
        {

            Value = u.Field<string>("Id"),
            Text = Convert.ToString(u.Field<int>("Number"))
        });
    }

    public static DataRow GetReservation(string id)
    {
        SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM BookedRooms WHERE Id = @id", ConfigurationManager.ConnectionStrings["daypilot"].ConnectionString);
        da.SelectCommand.Parameters.AddWithValue("id", id);

        DataTable dt = new DataTable();
        da.Fill(dt);

        if (dt.Rows.Count > 0)
        {
            return dt.Rows[0];
        }
        return null;
    }

    public static DataTable GetReservations()
    {
        //SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM BookedRooms ", ConfigurationManager.ConnectionStrings["daypilot"].ConnectionString);
        SqlDataAdapter da = new SqlDataAdapter("SELECT BookedRooms.* FROM BookedRooms", ConfigurationManager.ConnectionStrings["daypilot"].ConnectionString);
        DataTable dt = new DataTable();
        da.Fill(dt);

        return dt;
        //using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["daypilot"].ConnectionString))
        //{
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand("SELECT BookedRooms.*, Clients.Surname FROM BookedRooms inner join Clients on BookedRooms.ClientId=Clients.Id", con);
        //    SqlDataReader dr = cmd.ExecuteReader();

        //    var tb = new DataTable();
        //    tb.Load(dr);
        //    cmd.ExecuteNonQuery();
        //    return tb;
        //}


    }

    //public static DataTable GetReservations1()
    //{
    //    SqlDataAdapter da = new SqlDataAdapter("SELECT BookedRooms.*, AspNetUser.Surname FROM BookedRooms inner join Clients on BookedRooms.ClientId=Clients.Id", ConfigurationManager.ConnectionStrings["daypilot"].ConnectionString);
    //    DataTable dt = new DataTable();
    //    da.Fill(dt);

    //    return dt;

    //}



    public static void MoveReservation(string id, DateTime start, DateTime end, string resource)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["daypilot"].ConnectionString))
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE [BookedRooms] SET [DateFrom] = @start, [DateTo] = @end, [RoomsId] = @resource WHERE [Id] = @id", con);
            cmd.Parameters.AddWithValue("id", id);
            cmd.Parameters.AddWithValue("start", start);
            cmd.Parameters.AddWithValue("end", end);
            cmd.Parameters.AddWithValue("resource", resource);
            cmd.ExecuteNonQuery();
        }
    }

    public static void CreateReservation(DateTime start, DateTime end, string resource,/*string paid,*/ string name, string surname, string phone, string city, string adress, string userId)
    {
        using (ApplicationDbContext db = new ApplicationDbContext())
        {

            if (String.IsNullOrEmpty(userId))// == null)
            {
                string clientId = Guid.NewGuid().ToString();
                db.Client.Add(new Client
                {
                    Id = clientId,
                    Name = name,
                    Surname = surname,
                    PhoneNum = phone,
                    City = city,
                    Adress =  adress
                });
                db.BookedRoom.Add(new BookedRoom
                {
                    Id = Guid.NewGuid().ToString(),
                    DateTo = end,
                    DateFrom = start,
                    ClientId = clientId,
                    Paid = "0",
                    ReservationStatus = "0",
                    RoomsId = resource
                });
                db.SaveChanges();
            }
            else
            {
                db.BookedRoom.Add(new BookedRoom
                {
                    Id = Guid.NewGuid().ToString(),
                    DateTo = end,
                    DateFrom = start,
                    UserId = userId,
                    Paid = "0",
                    ReservationStatus = "0",
                    RoomsId = resource
                });
                db.SaveChanges();
            }
        }

        //using (ApplicationDbContext db = new ApplicationDbContext())
        //{
        //    db.BookedRoom.Add(new BookedRoom
        //    {
        //        Id = Guid.NewGuid().ToString(),
        //        DateTo = end,
        //        DateFrom = start,
        //        ReservationStatus = "0",
        //        RoomsId = resource
        //    });
        //    db.SaveChanges();
        //}

        //using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["daypilot"].ConnectionString))
        //{
        //    con.Open();
        //    //SqlCommand cmd1 = new SqlCommand("INSERT INTO [Clients] ([Name], [Surname], [PhoneNum]) VALUES (@name, @surname, @phone)", con);
        //    //cmd1.Parameters.AddWithValue("name", name);
        //    //cmd1.Parameters.AddWithValue("surname", surname);
        //    //cmd1.Parameters.AddWithValue("phone", phone);


        //    SqlCommand cmd = new SqlCommand("INSERT INTO [BookedRooms] ([DateTo], [DateFrom], [RoomsId], [ClientId]) VALUES (@start, @end, @resource, 0)", con);
        //    cmd.Parameters.AddWithValue("Id", "Id");
        //    cmd.Parameters.AddWithValue("start", start);
        //    cmd.Parameters.AddWithValue("end", end);
        //    cmd.Parameters.AddWithValue("resource", resource);

        //    //cmd1.ExecuteNonQuery();
        //    cmd.ExecuteNonQuery();
        //}
    }

    public static void UpdateReservation(string id, DateTime start, DateTime end, string resource, int status, int paid)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["daypilot"].ConnectionString))
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE [BookedRooms] SET [DateFrom] = @start, [DateTo] = @end, [RoomsId] = @resource, [ReservationStatus] = @status, [Paid] = @paid WHERE [Id] = @id", con);

            cmd.Parameters.AddWithValue("id", id);
            cmd.Parameters.AddWithValue("start", start);
            cmd.Parameters.AddWithValue("end", end);
            cmd.Parameters.AddWithValue("resource", resource);
            cmd.Parameters.AddWithValue("paid", paid);
            cmd.Parameters.AddWithValue("status", status);

            cmd.ExecuteNonQuery();

        }

    }

    public static DataTable GetRoomsFiltered(string roomFilter)
    {

        SqlDataAdapter da = new SqlDataAdapter("SELECT Rooms.Id, Rooms.Number, Rooms.Price, Hotels.Name FROM Rooms inner join Hotels on Rooms.HotelId=Hotels.Id ", ConfigurationManager.ConnectionStrings["daypilot"].ConnectionString);
        //da.SelectCommand.Parameters.AddWithValue("beds", roomFilter);
        DataTable dt = new DataTable();
        da.Fill(dt);

        return dt;
    }

    public static bool IsFree(string id, DateTime start, DateTime end, string resource)
    {
        // event with the specified id will be ignored

        SqlDataAdapter da = new SqlDataAdapter("SELECT count(Id) as count FROM [BookedRooms] WHERE NOT (([DateFrom] <= @start) OR ([DateTo] >= @end)) AND Id = @resource AND Id <> @id", ConfigurationManager.ConnectionStrings["daypilot"].ConnectionString);
        da.SelectCommand.Parameters.AddWithValue("id", id);
        da.SelectCommand.Parameters.AddWithValue("start", start);
        da.SelectCommand.Parameters.AddWithValue("end", end);
        da.SelectCommand.Parameters.AddWithValue("resource", resource);
        DataTable dt = new DataTable();
        da.Fill(dt);

        int count = Convert.ToInt32(dt.Rows[0]["count"]);
        return count == 0;
    }
}


