using CourseProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;


namespace CourseProject.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        int pageSize = 9;

        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            ViewBag.Category = new SelectList(db.Category, "Id", "Name");
            //ViewBag.Hotels = new SelectList(db.Hotels, "Id", "CountStar");
            var room = db.Rooms.ToList();
            ViewBag.Sortable = db.Hotels.ToList().Select(i => i.City);
            ViewBag.Message = TempData["Message"];
            return View(room.ToPagedList(pageNumber, pageSize));

        }



        public ActionResult SearchHotel()
        {
            ViewBag.Hotels = db.Hotels.ToList();
            ViewBag.Sortable = db.Hotels.ToList().Select(i => i.City);
            ViewBag.Message = TempData["Message"];
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult GetInfo(string Id)
        {

            return View(db.Hotels.Find(Id));
        }

        [HttpPost]
        public ActionResult BookingRoom(string Id, int? page)
        {
            int pageNumber = (page ?? 1);
            var room = db.Hotels.Find(Id).Rooms.ToList();
            return View(room.ToPagedList(pageNumber, pageSize));
        }

        //[HttpPost]
        //public ActionResult BookingHall(string Id)
        //{
        //    ViewBag.BanquetingHall = db.Hotels.Find(Id).Halls.ToList();
        //    return View();
        //}

        [HttpGet]
        public ActionResult BookingRoomModal(string Id)
        {
            BookingViewModel bookingViewModel = new BookingViewModel { RoomId = db.Rooms.Find(Id).Id };
            return PartialView(bookingViewModel);
        }

        [HttpGet]
        public ActionResult AddCommentsModal(string Id)
        {

            ViewBag.Id = Id;
            AddCommentsViewModel addCommentsView = new AddCommentsViewModel { HotelId = db.Hotels.Find(Id).Id };
            //Comments comments = new Comments { HotelId = db.Hotels.Find(Id).Id };

            return PartialView(addCommentsView);
        }



        //[HttpGet]
        //public ActionResult BookingHallModal(string Id)
        //{
        //    BookingViewModel bookingViewModel = new BookingViewModel { RoomId = db.BanquetingHall.Find(Id).Id };
        //    return PartialView(bookingViewModel);
        //}

        [HttpPost]
        public ActionResult SearchHotel(string Id, int? page)
        {
            // int pageNumber = (page ?? 1);
            ViewBag.Hotels = db.Hotels.Where(i => i.Name.Contains(Id) == true).ToList();
            if (ViewBag.Hotels != null)
            {
                ViewBag.Sortable = db.Hotels.ToList().Select(i => i.City);
                return View();

            }
            TempData["Message"] = "Ничего не найдено";
            return RedirectToAction("SearchHotel");
        }

        [HttpGet]
        public ActionResult SearchHotelList(int? page)
        {
            //int pageNumber = (page ?? 1);
            ViewBag.Sortable = db.Hotels.ToList().Select(i => i.City);
            return View();
        }


        [HttpGet]
        public ActionResult Sortable(string Id)
        {
            if (Id == "allId") ViewBag.Hotels = db.Hotels.ToList();
            else ViewBag.Hotels = db.Hotels.Where(i => i.City == Id).ToList();
            return PartialView();

        }
        //[HttpPost]
        //public ActionResult SearchHotelByName(string Id)
        //{
        //    var hotel = db.Hotels.FirstOrDefault(i => i.Name == Id);
        //    if(hotel!=null)
        //    {
        //        return View(hotel);
        //    }
        //    TempData["Message"] = "Ничего не найдено";
        //    return RedirectToAction("SearchHotel");
        //}

        //[HttpPost]
        //public ActionResult Hotel(RegisterHotelModel model)
        //{
        //    Hotels hotel = new Hotels
        //    {
        //        Id = Guid.NewGuid().ToString(),
        //        Name = model.Name

        //    }
        //    db.Hotels.Add(hotel);
        //    db.SaveChanges();
        //    return View();
        //}


        [HttpPost]
        public ActionResult SearchRoom(string name, string Category, string CountStar)//, string Price, string Note)
        {

            if (name == "" && Category == "" && CountStar == "") return RedirectToAction("Index");
            if (name != "" && Category == "" && CountStar == "") { ViewBag.Rooms = db.Rooms.Where(i => i.Hotel.Name.Contains(name)).ToList(); return View(); }
            if (name == "" && Category != "" && CountStar == "")
            { ViewBag.Rooms = db.Rooms.Where(i => i.CategoryId == Category).ToList(); return View(); }
            if (name == "" && Category == "" && CountStar != "")
            { int count = Int32.Parse(CountStar); ViewBag.Rooms = db.Rooms.Where(i => i.Hotel.CountStar == count).ToList(); return View(); }
            if (name != "" && Category != "" && CountStar == "")
            { ViewBag.Rooms = db.Rooms.Where(i => i.Hotel.Name.Contains(name)).Where(i => i.CategoryId == Category).ToList(); return View(); }
            if (name != "" && Category == "" && CountStar != "")
            { int count = Int32.Parse(CountStar); ViewBag.Rooms = db.Rooms.Where(i => i.Hotel.CountStar == count && i.Hotel.Name.Contains(name)).ToList(); return View(); }
            if (name == "" && Category != "" && CountStar != "")
            { ViewBag.Rooms = db.Rooms.Where(i => i.Hotel.CountStar == int.Parse(CountStar)).Where(i => i.CategoryId == Category).ToList(); return View(); }
            if (name != "" && Category != "" && CountStar != "")
            { ViewBag.Rooms = db.Rooms.Where(i => i.Hotel.CountStar == int.Parse(CountStar)).Where(i => i.CategoryId == Category && i.Hotel.Name.Contains(name)).ToList(); return View(); }
            return RedirectToAction("Index");

            //string[] prices = Price.Split('-');
            // int startPrice = Int32.Parse(prices[0]);
            //int endPrice = Int32.Parse(prices[1]);
            //int cs = Int32.Parse(CountStar);
            // int pr = Int32.Parse(Price);

            //var allroom = db.Rooms.Where(m => m.Hotel.Name.Contains(name) && m.CategoryId == Category && m.Hotel.CountStar == cs ).ToList();
            //if (allroom != null)
            //{
            //    return View();
            //}
            //TempData["Message"] = "non";
            //return RedirectToAction("Index");
            //return PartialView(allroom);
        }

        [HttpGet]
        public ActionResult ListComments(string Id)
        {
            var AllComments = db.Comments.Where(i => i.HotelId == Id).ToList();
            return PartialView(AllComments);

        }
    }
}