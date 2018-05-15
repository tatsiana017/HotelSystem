using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
//using Data;
using DayPilot.Web.Mvc.Json;
using DayPilot.Web.Mvc.Recurrence;
using CourseProject.Models;
using CourseProject.Controllers;

public class ReservationController : Controller
{

    public ActionResult Edit(string id)
    {
        DataRow dr = Db.GetReservation(id);

        if (dr == null)
        {
            throw new Exception("The task was not found");
        }

        return View(new
        {
            Id = id,
            //Text = dr["ReservationName"],
            Start = Convert.ToDateTime(dr["DateFrom"]).ToShortDateString(),
            End = Convert.ToDateTime(dr["DateTo"]).ToShortDateString(),
            Status = new SelectList(new SelectListItem[]
            {
                new SelectListItem { Text = "New", Value = "0"},
                new SelectListItem { Text = "Confirmed", Value = "1"},
                new SelectListItem { Text = "Arrived", Value = "2"},
                new SelectListItem { Text = "Checked out", Value = "3"}
            }, "Value", "Text", dr["ReservationStatus"]),
            Paid = new SelectList(new SelectListItem[]
            {
                new SelectListItem { Text = "0%", Value = "0"},
                new SelectListItem { Text = "50%", Value = "50"},
                new SelectListItem { Text = "100%", Value = "100"},
            }, "Value", "Text", dr["Paid"]),
            Resource = new SelectList(Db.GetRoomSelectList(), "Value", "Text", dr["RoomsId"])
        });
    }

    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult Edit(FormCollection form)
    {
        string id = form["Id"];
        //string name = form["Text"];
        DateTime start = Convert.ToDateTime(form["Start"]).Date.AddHours(12);
        DateTime end = Convert.ToDateTime(form["End"]).Date.AddHours(12);
        string resource = form["Resource"];
        int paid = Convert.ToInt32(form["Paid"]);
        int status = Convert.ToInt32(form["Status"]);

        DataRow dr = Db.GetReservation(id);

        if (dr == null)
        {
            throw new Exception("The task was not found");
        }

        Db.UpdateReservation(id, start, end, resource, status, paid);

        return JavaScript(SimpleJsonSerializer.Serialize("OK"));
    }

    public ActionResult Create()
    {
        return View(new
        {
            UserId = Request.QueryString["userId"],
            Name = Request.QueryString["name"],
            Surname = Request.QueryString["surname"],
            Phone = Request.QueryString["phone"],
            City = Request.QueryString["city"],
            Adress = Request.QueryString["adress"],
            //Paid = Request.QueryString["paid"],
            Start = Convert.ToDateTime(Request.QueryString["start"]).ToShortDateString(),
            End = Convert.ToDateTime(Request.QueryString["end"]).ToShortDateString(),
            Resource = new SelectList(Db.GetRoomSelectList(), "Value", "Text", Request.QueryString["resource"])
        });
    }

    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult Create(FormCollection form)
    {
        DateTime start = Convert.ToDateTime(form["Start"]).Date.AddHours(12);
        DateTime end = Convert.ToDateTime(form["End"]).Date.AddHours(12);
        //string paid = form["Paid"];
        string resource = form["Resource"];
        string name = form["Name"];
        string surname = form["Surname"];
        string phone = form["Phone"];
        string city = form["City"];
        string adress = form["Adress"];
        string userId = "";//form["UserId"];

        Db.CreateReservation(start, end,/* paid,*/  resource, name, surname, phone, city, adress, userId);
        return JavaScript(SimpleJsonSerializer.Serialize("OK"));
    }

    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult DeleteOrder(string id)
    {
        ApplicationDbContext db = new ApplicationDbContext();
        db.BookedRoom.Remove(db.BookedRoom.Find(id));
        db.SaveChanges();
        //TempData["Message"] = "Удалено";
        //return RedirectToAction("Sheduler", "");
        return JavaScript(SimpleJsonSerializer.Serialize("Бронь была успешно удалена из базы данных")); //Для красоты можно выводить частичное представление, оно подставится в модалку.
    }


}
