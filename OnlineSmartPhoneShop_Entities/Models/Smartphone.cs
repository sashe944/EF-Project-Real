using OnlineSmartPhoneShop_CommonFiles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSmartPhoneShop_Entities.Models
{
    public class Smartphone
    {
        public Smartphone()
        { }

        public Smartphone(string name,
           string price,
           string imgUrl,
           string description,
           DateTime boughtOnDate,
           TimeSpan time,
           CustomId id = null)
        {
            this.Id = id;
            this.Price = price;
            this.ImgURL = imgUrl;
            this.Description = description;
            this.BoughtOnDate = boughtOnDate;
            this.Time = time;

        }
        public Smartphone(CustomId id)
        {
            this.Id = string.IsNullOrEmpty(Convert.ToString(id)) ? new CustomId().ToString() : id.ToString();
        }
        [Key]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Price { get; set; }

        [Required]
        public string ImgURL { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime BoughtOnDate { get; set; }

        [Required]
        public TimeSpan Time { get; set; }
    }
}
