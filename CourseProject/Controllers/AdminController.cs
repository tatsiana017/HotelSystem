using CourseProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;

namespace CourseProject.Controllers
{


    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        int pageSize = 10;
        

        [HttpGet]
        public ActionResult Index(int page = 1)
        {
            var hotel = db.Hotels.ToList();
            int pageSize = 3;
            //ViewBag.StatusMessage = TempData["Message"];
            //var hotel = db.Hotels.ToList();
            IEnumerable<Hotels> hotelPerPages = hotel.Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = hotel.Count };
            ViewmodelHotel ivm = new ViewmodelHotel { PageInfo = pageInfo, Hotel = hotelPerPages };
            return View(ivm);
        }
        
        [HttpGet]
        public ActionResult Clients(int page = 1)
        {
            //int pageNum = (page ?? 1);


            //ViewBag.StatusMessage = TempData["Message"];
            //var client = db.Client.ToList();
            var user = db.Users.ToList();
            //ViewBag.AspNetUsers = db.Users.ToList();

            //return View(client.ToPagedList(page, pageSize));

            int pageSize = 10; // количество объектов на страницу
            IEnumerable<ApplicationUser> phonesPerPages = user.Skip((page - 1) * pageSize).Take(pageSize);
            //IEnumerable<ApplicationUser> usersPerPages = user.Skip((page - 1) * pageSize).Take(pageSize);
           // PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = client.Count };
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = user.Count };
            ClientViewModel ivm = new ClientViewModel { PageInfo = pageInfo,  Users= phonesPerPages };
            return View(ivm);

        }

        [HttpGet]
        public ActionResult Sheduler()
        {
            ViewBag.StatusMessage = TempData["Message"];
            return View();
        }

        [HttpGet]
        public ActionResult Task()
        {
            ViewBag.StatusMessage = TempData["Message"];
            return View();
        }

        [HttpGet]
        public ActionResult CreateHotel()
        {
            return PartialView("CreateHotel");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateHotel(HotelViewModel hotelView, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid & Image != null)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(Image.InputStream))
                {
                    imageData = binaryReader.ReadBytes(Image.ContentLength);
                }
                var Hotel = new Hotels
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = hotelView.Name,
                    Adress = hotelView.Address,
                    City = hotelView.City,
                    PhoneNumber = hotelView.PhoneNumber,
                    WebSite = hotelView.WebSite,
                    Rooms = new List<Rooms>(),
                    ImageData = imageData,
                    Description = hotelView.Description,
                    CountStar = hotelView.CountStar
                };
                db.Hotels.Add(Hotel);

                db.SaveChanges();
                TempData["Message"] = "Отель успешно добавлен.";
                return RedirectToAction("Index", "Admin");
               // return PartialView("Success");
            }
            //TempData["Message"] = "Ошибка добавления.";
            //return RedirectToAction("Index", "Admin");
            return PartialView(hotelView);
        }

        [HttpGet]
        public ActionResult CreateRoom()
        {
            ViewBag.Hotel = db.Hotels.ToList();
            ViewBag.Category = db.Category.ToList();
            return PartialView("CreateRoom");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRoom(RoomViewModel roomView, HttpPostedFileBase ImageRoom)
        {

            ViewBag.Hotel = db.Hotels.ToList();
            ViewBag.Category = db.Category.ToList();
            if (ModelState.IsValid & ImageRoom != null)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(ImageRoom.InputStream))
                {
                    imageData = binaryReader.ReadBytes(ImageRoom.ContentLength);
                }
                var Room = new Rooms
                {
                    Id = Guid.NewGuid().ToString(),
                    Number = int.Parse(roomView.Number),
                    Price = roomView.Price,
                    Status = roomView.Status,
                    Hotel = db.Hotels.Find(roomView.HotelId),
                    Category = db.Category.Find(roomView.CategoryId),
                    ImageData = imageData,
                    Description = roomView.Descriptions
                };
                db.Rooms.Add(Room);
                db.SaveChanges();
                TempData["Message"] = "Комната успешно добавлена.";
                return RedirectToAction("Index", "Admin");
            }
            // TempData["Message"] = "Ошибка добавления.";
            // return RedirectToAction("Index", "Admin");
            return PartialView(roomView);
        }

        //[HttpGet]
        //public ActionResult CreateHall()
        //{
        //    ViewBag.Hotel = db.Hotels.ToList();
        //    ViewBag.Category = db.Category.ToList();
        //    return PartialView("CreateHall");
        //}

        //[HttpPost]
        //public ActionResult CreateHall(HallViewModel hallView, HttpPostedFileBase Image)
        //{
        //    if (ModelState.IsValid & Image != null)
        //    {
        //        byte[] imageData = null;
        //        using (var binaryReader = new BinaryReader(Image.InputStream))
        //        {
        //            imageData = binaryReader.ReadBytes(Image.ContentLength);
        //        }
        //        var hall = new BanquetingHall
        //        {
        //            Id = Guid.NewGuid().ToString(),
        //            CountPlace = int.Parse(hallView.CountPlace),
        //            Price = hallView.Price,
        //            Name = hallView.Name,
        //            Hotel = db.Hotels.Find(hallView.HotelId),
        //            ImageData = imageData,
        //            Status=hallView.Status,
        //            Description=hallView.Description
        //        };
        //        db.BanquetingHall.Add(hall);
        //        db.SaveChanges();
        //        TempData["Message"] = "Зал успешно добавлен.";
        //        return RedirectToAction("Index", "Admin");
        //    }
        //    TempData["Message"] = "Ошибка добавления.";
        //    return RedirectToAction("Index", "Admin");
        //}

        [HttpGet]
        public ActionResult ListRoom(string Id)
        {
            var AllRooms = db.Rooms.Where(i => i.HotelId == Id).ToList();
            return PartialView(AllRooms);

        }

        //[HttpGet]
        //public ActionResult ListHall(string Id)
        //{
        //    var AllHall = db.BanquetingHall.Where(i => i.HotelId == Id).ToList();
        //    return PartialView(AllHall);

        //}

        [HttpPost]
        public ActionResult DeleteHotel(string Id)
        {
            db.Hotels.Remove(db.Hotels.Find(Id));           
            db.SaveChanges();
            TempData["Message"] = "Отель успешно удален.";
            return RedirectToAction("Index", "Admin");
        }

        [HttpPost]
        public ActionResult DeleteHotelRoom(string Id)
        {
            db.Rooms.Remove(db.Rooms.Find(Id));
            db.SaveChanges();
            TempData["Message"] = "Комната успешно удалена.";
            return RedirectToAction("Index", "Admin");
        }

        [HttpPost]
        public ActionResult DeleteClient(string Id)
        {
            db.Client.Remove(db.Client.Find(Id));
            db.SaveChanges();
            TempData["Message"] = "Клиент удален.";
            return RedirectToAction("Clients", "Admin");
        }

        [HttpPost]
        public ActionResult DeleteUser(string Id)
        {
            db.Users.Remove(db.Users.Find(Id));
            db.SaveChanges();
            TempData["Message"] = "Клиент удален.";
            return RedirectToAction("Clients", "Admin");
        }

        //[HttpPost]
        //public ActionResult DeleteHotelHall(string Id)
        //{
        //    //db.BanquetingHall
        //    //db.Booking.Remove(db.Booking.FirstOrDefault(i => i.EventId == db.Events.FirstOrDefault(x => x.HallId == Id).Id));
        //    //db.Events.Remove(db.Events.FirstOrDefault(x => x.HallId == Id));
        //    //db.BanquetingHall.Remove(db.BanquetingHall.Find(Id));
        //    db.SaveChanges();
        //    TempData["Message"] = "Зал успешно удалена.";
        //    return RedirectToAction("Index", "Admin");
        //}
    }
}