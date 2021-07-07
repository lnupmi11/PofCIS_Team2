﻿using System;
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
    /// Class to represent a goods data.
    /// </summary>
    [Table("Goods")]
    public class GoodsData
    {
        /// <summary>
        /// Holds an id of goods data.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Code a code of goods.
        /// </summary>
        [Required]
        public int OrderNumber { get; set; }

        /// <summary>
        /// Weight of goods.
        /// </summary>
        [Required]
        public double Price { get; set; }
    }
}
