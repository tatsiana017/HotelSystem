﻿//using System;
//using System.Linq;
//using System.Web.Mvc;

//using CourseProject.Models;
//using CourseProject.Controllers;


//namespace ITechArt.Blog.Controllers
//{
//    public class CommentController : Controller
//    {
//        static int currentPostId;
//        private ApplicationDbContext db = new ApplicationDbContext();
        //public ActionResult CommentPart(int id = 0)
        //{
        //    var commentsList = db.Comments.Where(c => c.HotelId == id.ToString()).ToList();
        //    currentPostId = id;
        //    if (commentsList.Count() <= 0)
        //    {
        //        return HttpNotFound();
        //    }
        //    return PartialView(CreateCommentList.CreateViewListComment(commentsList));
        //}

        //public ActionResult Delete(int id)
        //{
        //    Comments comm = db.Comments.Find(id);
        //    if (comm != null)
        //    {
        //        return PartialView("Delete", comm);
        //    }
        //    return View("Index", "Home", null);
        //}
        //[HttpPost]
        //[Authorize(Roles = ProjectConst.Admin)]
        //[ActionName("Delete")]
        //public ActionResult DeleteRecord(int id)
        //{
        //    Comments comm = db.Comments.Find(id);
        //    if (comm != null)
        //    {
        //        db.Comments.Remove(comm);
        //        db.SaveChanges();
        //    }
        //    return RedirectToAction("Details", "Post", new { id = comm.HotelId });
        //}


        //public ActionResult CommentCountPart(int id = 0)
        //{
        //    int commentCount = db.Comments.Where(p => p.HotelId == id.ToString()).Count();
        //    return PartialView(commentCount);
        //}

        //TODO Добавить функционал по комментариям.
        //[HttpGet]
        //[Authorize]
        //public ActionResult AddComment()
        //{
        //    return PartialView();
        //}

        //[HttpPost]
        //[Authorize]
        //public ActionResult AddComment(Comments cvm)
        //{
        //   // var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());

        //    var comment = new Comments
        //    {

        //        Text = cvm.Text,
        //        Note = cvm.Note,
        //        UserId = user.Id,

        //    };
            //comment.
            //comment.AuthorId = db.User.Where(a => a.Email == User.Identity.Name).First().Id;
            //comment.CommentOn = DateTime.Now;
            //comment.ParentId = 0;
            //comment.Seed = 0;
            //comment.UserImagePath = "/Images/U1.png";
            //comment.PostId = currentPostId;
            //comment.Text = cvm.Text;
            //db.Comments.Add(comment);
            //db.SaveChanges();
            //return RedirectToAction("Details", "Post", new { id = comment.HotelId });
        //}
//    }
//}