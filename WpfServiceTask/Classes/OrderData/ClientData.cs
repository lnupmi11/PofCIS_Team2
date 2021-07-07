using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace WpfServiceTask.Classes.OrderData
{
    [Table("Clients")]
    public class ClientData
    {
        /// <summary>
        /// Holds an id of client data.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The first name of a client.
        /// </summary>
        [Required, MaxLength(256)]
        public string FirstName { get; set; }

        /// <summary>
        /// The second name of a client.
        /// </summary>
        [Required, MaxLength(256)]
        public string LastName { get; set; }

        /// <summary>
        /// Client's phone number.
        /// </summary>
        [Required, MaxLength(13)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Client's address.
        /// </summary>
        public virtual Address Address { get; set; } = new Address();
    }
}
