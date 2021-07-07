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
    [Table("Addresses")]
    public class Address
    {
        /// <summary>
        /// An id of the address.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// A name of the city.
        /// </summary>
        [Required, MaxLength(256)]
        public string City { get; set; }

        /// <summary>
        /// A name of the street.
        /// </summary>
        [Required, MaxLength(256)]
        public string Street { get; set; }

        /// <summary>
        /// A number of building.
        /// </summary>
        [Required]
        public int BuildingNumber { get; set; }
    }
}
