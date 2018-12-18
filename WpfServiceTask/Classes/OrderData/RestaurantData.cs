using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace WpfServiceTask.Classes.OrderData
{
    /// <summary>
    /// Class to represent a shop data.
    /// </summary>
    [Table("Restaurants")]
    public class RestaurantData
    {
        /// <summary>
        /// Holds an id of shop data.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// A name of the shop.
        /// </summary>
        [Required, MaxLength(256)]
        public string Name { get; set; }

        /// <summary>
        /// An address of the shop.
        /// </summary>
        public virtual Address Address { get; set; } = new Address();
    }
}
