using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CourseProject.Models
{
    public class HotelViewModel
    {
        //[Required(ErrorMessage = "Please input Name")]
        //[StringLength(20, ErrorMessage = "Некоректное название", MinimumLength = 3)]
        //[Display(Name = "Name")]
        //public string Name { get; set; }
        //[Required(ErrorMessage = "Please input Address")]
        //[StringLength(50, ErrorMessage = "Некоректный адрес", MinimumLength = 5)]
        //[Display(Name = "Address")]
        //public string Address { get; set; }
        //[Required(ErrorMessage = "Please input City")]
        //[StringLength(50, ErrorMessage = "Некоректный город", MinimumLength = 5)]
        //[Display(Name = "City")]
        //public string City { get; set; }
        //[Required(ErrorMessage = "Please input Phone Number")]
        //[StringLength(50, ErrorMessage = "Некоректный сайт", MinimumLength = 5)]
        //[Display(Name = "Phone Number")]
        //public string PhoneNumber { get; set; }
        //[Required(ErrorMessage = "Please input web site")]
        //[StringLength(50, ErrorMessage = "Некоректный сайт", MinimumLength = 5)]
        //[Display(Name = "web site")]
        //public string WebSite { get; set; }
        //[Required(ErrorMessage = "Please input description")]
        //[StringLength(1000, ErrorMessage = "Некоректное описание", MinimumLength = 5)]
        //[Display(Name = "description")]
        //public string Description { get; set; }
        //[Required(ErrorMessage = "Please input star")]
        //[Range(1, 5, ErrorMessage = "Недопустимое значение")]
        //[Display(Name = "CountStar")]
        //public int CountStar { get; set; }

        [Display(Name = "Name")]
        [Required]
        [StringLength(20, ErrorMessage = "Длина строки должна быть от 3 до 20 символов", MinimumLength = 3)]
        public string Name { get; set; }
        [Display(Name = "Address")]
        [Required]
        [StringLength(50, ErrorMessage = "Длина строки должна быть от 5 до 50 символов", MinimumLength = 5)]
        public string Address { get; set; }
        [Display(Name = "City")]
        [Required]
        [StringLength(50, ErrorMessage = "Длина строки должна быть от 5 до 50 символов", MinimumLength = 5)]
        public string City { get; set; }
        [Display(Name = "PhoneNumber")]
        [Required]
        [StringLength(12, ErrorMessage = "Некоректный номер", MinimumLength = 7)]
        public string PhoneNumber { get; set; }
        [Display(Name = "WebSite")]
        [Required]
        [StringLength(50, ErrorMessage = "Некоректный сайт", MinimumLength = 5)]
        public string WebSite { get; set; }
        [Display(Name = "Description")]
        [Required]
        [StringLength(1000, ErrorMessage = "Длина строки должна быть от 5 до 1000 символов", MinimumLength = 5)]
        public string Description { get; set; }
        [Display(Name = "Кол-во звезд")]
        [Required]
        [Range(1, 5, ErrorMessage = "Недопустимое значение")]
        public int CountStar { get; set; }

    }
    public class RoomViewModel
    {
        //[Required(ErrorMessage = "Please input Price")]
        //[StringLength(20, ErrorMessage = "The value must contain at least 3 characters", MinimumLength = 3)]
        //[Display(Name = "Price")]
        //public string Price { get; set; }
        //[StringLength(200, ErrorMessage = "The value must contain at least 5 characters", MinimumLength = 5)]
        //[Display(Name = "Descriptions")]
        //public string Descriptions { get; set; }
        //[Required(ErrorMessage = "Please input Number")]
        //[StringLength(4, ErrorMessage = "The value must contain at least 3 characters", MinimumLength = 1)]
        //[Display(Name = "Number")]
        //public string Number { get; set; }
        //[Required(ErrorMessage = "Please input Status")]
        //[StringLength(10, ErrorMessage = "The value must contain at least 5 characters", MinimumLength = 3)]
        //[Display(Name = "status")]
        //public string Status { get; set; }
        //public string HotelId { get; set; }
        //public string CategoryId { get; set; }

        [Display(Name = "Price")]
        [Required]
        [StringLength(5, ErrorMessage = "Некоректная стоимость", MinimumLength = 2)]
        public string Price { get; set; }
        //[Display(Name = "Description")]
        //[Required]
        //[StringLength(500, ErrorMessage = "Длина строки должна быть от 5 до 1000 символов", MinimumLength = 5)]
        //public string Description { get; set; }
        [Display(Name = "Descriptions")]
        [Required]
        [StringLength(1000, ErrorMessage = "Длина строки должна быть от 5 до 1000 символов", MinimumLength = 5)]
        public string Descriptions { get; set; }
        [Display(Name = "Number")]
        [Required]
        [StringLength(4, ErrorMessage = "Некоректный номер", MinimumLength = 2)]
        public string Number { get; set; }
        [Display(Name = "Status")]
        [Required]
        [StringLength(7, ErrorMessage = "Длина строки должна быть от 1 до 7 символов", MinimumLength = 1)]
        public string Status { get; set; }
        [Display(Name = "HotelId")]
        [Required(ErrorMessage = "Please input Status")]
        public string HotelId { get; set; }
        [Display(Name = "CategoryId")]
        [Required(ErrorMessage = "Please input Status")]
        public string CategoryId { get; set; }
    }

    //public class HallViewModel
    //{
    //    [Required(ErrorMessage = "Please input Name")]
    //    [StringLength(20, ErrorMessage = "The value must contain at least 3 characters", MinimumLength = 3)]
    //    [Display(Name = "Name")]
    //    public string Name { get; set; }
    //    [Required(ErrorMessage = "Please input CountPlace")]
    //    [StringLength(4, ErrorMessage = "The value must contain at least 3 characters", MinimumLength = 1)]
    //    [Display(Name = "CountPlace")]
    //    public string CountPlace { get; set; }
    //    [Required(ErrorMessage = "Please input Price")]
    //    [StringLength(20, ErrorMessage = "The value must contain at least 3 characters", MinimumLength = 3)]
    //    [Display(Name = "Price")]
    //    public string Price { get; set; }
    //    public string Status { get; set; }
    //    public string Description { get; set; }
    //    public string HotelId { get; set; }
    //}


    public class PageInfo
    {
        public int PageNumber { get; set; } // номер текущей страницы
        public int PageSize { get; set; } // кол-во объектов на странице
        public int TotalItems { get; set; } // всего объектов
        public int TotalPages  // всего страниц
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / PageSize); }
        }
    }
    public class ClientViewModel
    {
        //public IEnumerable<Client> Clients { get; set; }
        public IEnumerable<ApplicationUser> Users { get; set; }
        public PageInfo PageInfo { get; set; }
    }

    public class ViewmodelHotel
    {
        public IEnumerable<Hotels> Hotel { get; set; }
        public PageInfo PageInfo { get; set; }
    }

}