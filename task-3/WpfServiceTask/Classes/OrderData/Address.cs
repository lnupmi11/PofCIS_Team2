using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace WpfServiceTask.Classes.OrderData
{
    /// <summary>
    /// Class for address 
    /// </summary>
    [Serializable]
    public class Address
    {
        [XmlAttribute]
        public string City { get;set;}
        [XmlAttribute]
        public string Street { get;set;}
        [XmlAttribute]
        public uint BuildingNumber { get;set;}
   
        /// <summary>
        /// Default constructor
        /// </summary>
        public Address()
        {
        }
        /// <summary>
        /// Constuctor with params
        /// </summary>
        /// <param name="city"></param>
        /// <param name="street"></param>
        /// <param name="buildingNumber"></param>
        public Address(string city, string street, uint buildingNumber)
        {
            City = city.Trim();
            Street = street.Trim();
            BuildingNumber = buildingNumber;
        }
        /// <summary>
        /// Constructor which use XmlAttributeCollection to create an object
        /// </summary>
        /// <param name="source"></param>
        public Address(XmlAttributeCollection source)
        {
            if (source == null)
            {
                throw new NullReferenceException("can't parse Address");
            }

            City = source["City"].Value;
            Street = source["Street"].Value;
            if (!uint.TryParse(source["BuildingNumber"].Value, out var buidingNumber))
            {
                throw new InvalidDataException("Address.BuildingNumber must be of type 'uint'");
            }

            BuildingNumber = buidingNumber;
        }
        /// <summary>
        /// Method to convert Address object to XML
        /// </summary>
        /// <returns></returns>
        public XElement ToXml()
        {
            return new XElement(
                "Address",
                new XAttribute("City", City),
                new XAttribute("Street", Street),
                new XAttribute("BuildingNumber", BuildingNumber));
        }
    }
}

