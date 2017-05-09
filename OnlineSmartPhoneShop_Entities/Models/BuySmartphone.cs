using OnlineSmartPhoneShop_CommonFiles;
using System;
using System.ComponentModel.DataAnnotations;


namespace OnlineSmartPhoneShop_Entities.Models
{
    public class BuySmartphone
    {
        public BuySmartphone()
        { }

        public BuySmartphone(string smartphoneName,
            double price,
            string imgUrl,
            DateTime boughtOnDate,
            CustomId id=null)
            : this(id)
        {
            this.SmartphoneName = smartphoneName;
            this.Price = price;
            this.ImgURL = imgUrl;
        }
        public BuySmartphone(CustomId id)
        {
            this.Id = string.IsNullOrEmpty(Convert.ToString(id)) ? new CustomId().ToString() : id.ToString();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        public string SmartphoneName { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public string ImgURL { get; set; }

        [Required]
        public DateTime BoughtOnDate { get; set; }
    }
}
