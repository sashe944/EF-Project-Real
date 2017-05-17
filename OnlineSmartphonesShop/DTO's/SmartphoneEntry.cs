
using OnlineSmartPhoneShop_CommonFiles.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineSmartphonesShop.DTO_s
{
    public class SmartphoneEntry
    {
        [Required]
        [StringLength(255)]
        [Display(Name = "Phone name")]
        public string Name { get; set; }
        [Required]
        [StringLength(255)]
        public string Price { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name = "Image Url")]
        public string ImgURL { get; set; }
        [Required]
        public string Description { get; set; }
       // [Required]
        [StringLength(50)]

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString =
       "{0:yyyy-MM-dd}",
        ApplyFormatInEditMode = true)]
        public string Date { get; set; }

        [Required]
        [ValidTime]
        [StringLength(50)]
        public string Time { get; set; }

        public DateTime GetDate()
        {
            return DateTime.Parse(string.Format($"{this.Date} {this.Time}"));
        }
    }
}