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

        public ClientData()
        {
            Address = new Address();
        }

        public ClientData(string firstName, string lastName, string phoneNumber, Address address)
        {
            FirstName = firstName.Trim();
            LastName = lastName.Trim();
            PhoneNumber = phoneNumber.Trim();
            Address = address;
        }

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
