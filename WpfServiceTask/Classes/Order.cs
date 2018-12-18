using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using WpfServiceTask.Classes.OrderData;

namespace WpfServiceTask.Classes
{
    /// <summary>
    /// Represents an order.
    /// </summary>
    [Table("Orders")]
    public class Order
    {
        /// <summary>
        /// Holds an id of the order.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Contains client personal information.
        /// </summary>
        public virtual ClientData ClientData { get; set; } = new ClientData();

        /// <summary>
        /// Represents shop data.
        /// </summary>
        public virtual RestaurantData RestaurantData { get; set; } = new RestaurantData();

        /// <summary>
        /// Holds an information about ordered goods.
        /// </summary>
        public virtual GoodsData GoodsData { get; set; } = new GoodsData();
    }
}
