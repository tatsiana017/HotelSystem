using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourseProject.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {

            // Обратите внимание, что authenticationType должен совпадать с типом, определенным в CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Здесь добавьте утверждения пользователя
            return userIdentity;
        }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
    }

    //public class HotelClient
    //{
    //    public string ID { get; set; }
    //    public string Surname { get; set; }
    //    public string Name { get; set; }
    //    public string PhoneNumber { get; set; }
    //    public string Country { get; set; }
    //    public string City { get; set; }
    //    public string Adress { get; set; }
    //    public int CountGuest { get; set; }
    //    public DateTime Birthday { get; set; }
    //    public int CountChild { get; set; }
    //    public string UserId { get; set; }
    //    public ApplicationUser User { get; set; }
    //}

    //public class Favorite
    //{
    //    public string Id { get; set; }
    //    public string UserId { get; set; }
    //    public ApplicationUser User { get; set; }
    //    public string RoomsId { get; set; }
    //    public Rooms Rooms { get; set; }
    //    public string HallId { get; set; }
    //    public BanquetingHall Hall { get; set; }
    //}

    public class BookedRoom
    {
        public string Id { get; set; }
        public DateTime DateTo { get; set; }
        public DateTime DateFrom { get; set; }
        public string RoomsId { get; set; }
        public Rooms Rooms { get; set; }
        public string ClientId { get; set; }
        public Client Client { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public string Paid { get; set; }
        public string ReservationStatus { get; set; }
    }

    //public class Booking
    //{
    //    public string Id { get; set; }
    //    public string Check { get; set; }
    //    public string UserId { get; set; }
    //    public ApplicationUser User{ get; set; }
    //    public string EventId { get; set; }
    //    public Events Event { get; set; }
    //    public string BookedRoomId { get; set; }
    //    public BookedRoom BookedRoom { get; set; }
    //}


    public class Hotels
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public string WebSite { get; set; }
        public byte[] ImageData { get; set; }
        public string Description { get; set; }
        public int CountStar { get; set; }
        //public string UserAdminId { get; set; }
        //public virtual ApplicationUser UserAdmin { get; set; }
        public virtual ICollection<Rooms> Rooms { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }

        
        //public virtual ICollection<BanquetingHall> Halls { get; set; }
        //[Required]
        //public virtual HotelCategory Category { get; set; }
    }

    public class Rooms
    {
        public string Id { get; set; }
        public string HotelId { get; set; }
        public Hotels Hotel { get; set; }
        public string CategoryId { get; set; }
        public virtual Category Category { get; set; }
        //public virtual HotelCategory Category { get; set; }
        public int Number { get; set; }
        public string Price { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public byte[] ImageData { get; set; }
    }

    //public class HotelCategory
    //{
    //    public string Id { get; set; }
    //    public string HotelNameCategory { get; set; }
    //    public string CategoryId { get; set; }
    //    public virtual Category Category { get; set; }
    //}

    public class Category
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Rooms> Rooms { get; set; }
    }

    public class Client
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string PhoneNum { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
    }

    public class Comments
    {

        public string Id { get; set; }
        public int Note { get; set; }
        public string Text { get; set; }
        public string HotelId { get; set; }
        public Hotels Hotel { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime DateComm { get; set; }
    }


    //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    //public class Event
    //{
    //    public int Id { get; set; }
    //    public DateTime Start { get; set; }
    //    public DateTime End { get; set; }
    //    public string Text { get; set; }
    //}

    //public class BanquetingHall
    //{
    //    public string Id { get; set; }
    //    public string Name { get; set; }
    //    public int CountPlace { get; set; }
    //    public string Price { get; set; }
    //    public string HotelId { get; set; }
    //    public string Status { get; set; }
    //    public string Description { get; set; }
    //    public Hotels Hotel { get; set; }
    //    public byte[] ImageData { get; set; }
    //}

    //public class Events
    //{
    //    public string Id { get; set; }
    //    public DateTime DateTo { get; set; }
    //    public DateTime DateFrom { get; set; }
    //    public string HallId { get; set; }
    //    public BanquetingHall Hall { get; set; }
    //}



    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        //public DbSet<HotelClient> HotelClient { get; set; }
        public DbSet<Hotels> Hotels { get; set; }
        public DbSet<Rooms> Rooms { get; set; }
        public DbSet<Category> Category { get; set; }
       // public DbSet<Event> Events { get; set; }
        //public DbSet<BanquetingHall> BanquetingHall { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<BookedRoom> BookedRoom { get; set; }
        public DbSet<Comments> Comments { get; set; }
        //public DbSet<Favorite> Favorite { get; set; }
       // public DbSet<Event> Event { get; set; }


        public ApplicationDbContext()
            : base("daypilot", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
