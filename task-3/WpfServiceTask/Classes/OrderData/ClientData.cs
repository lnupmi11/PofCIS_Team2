using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace WpfServiceTask.Classes.OrderData
{
    /// <summary>
    /// Class for client data
    /// </summary>
    [Serializable]
    public class ClientData
    {
        [XmlAttribute]
        public string FirstName { get; set; }
        [XmlAttribute]
        public string LastName { get; set; }
        [XmlAttribute]
        public string PhoneNumber { get; set; }
        [XmlAttribute]
        public Address Address { get; set; }
        /// <summary>
        /// Default Constructor
        /// </summary>
        public ClientData()
        {
            Address = new Address();
        }
        /// <summary>
        /// Constructor with params
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="address"></param>
        public ClientData(string firstName, string lastName, string phoneNumber, Address address)
        {
            FirstName = firstName.Trim();
            LastName = lastName.Trim();
            PhoneNumber = phoneNumber.Trim();
            Address = address;
        }

        /// <summary>
        /// Constructor which create Object using XmlNode
        /// </summary>
        /// <param name="node"></param>
        public ClientData(XmlNode node)
        {
            if (node == null)
            {
                throw new NullReferenceException("can't parse ClientData class");
            }

            if (node.Attributes == null)
            {
                throw new NullReferenceException("can't parse ClientData attributes");
            }

            FirstName = node.Attributes["FirstName"].Value;
            LastName = node.Attributes["LastName"].Value;
            PhoneNumber = node.Attributes["PhoneNumber"].Value;

            var addressNode = node.SelectSingleNode("Address");
            if (addressNode == null)
            {
                throw new NullReferenceException("can't parse ClientData.Address");
            }

            Address = new Address(addressNode.Attributes);
        }
        /// <summary>
        /// Method to convert ClientData object to XML
        /// </summary>
        /// <returns></returns>
        public XElement ToXml()
        {
            return new XElement(
                "ClientData",
                new XAttribute("FirstName", FirstName),
                new XAttribute("LastName", LastName),
                new XAttribute("PhoneNumber", PhoneNumber),
                Address.ToXml()
                );
        }



    }
}

