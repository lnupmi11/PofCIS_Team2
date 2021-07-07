using System;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace WpfServiceTask.Classes.OrderData
{ 
    /// <summary>
    /// Class for restaurant
    /// </summary>
    [Serializable]
    public class RestaurantData
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public Address Address { get; set; }
        /// <summary>
        /// Default Constructor
        /// </summary>
        public RestaurantData()
        {
            Address = new Address();
        }
        /// <summary>
        /// Constructor with params
        /// </summary>
        /// <param name="name"></param>
        /// <param name="address"></param>
        public RestaurantData(string name, Address address)
        {
            Name = name;
            Address = address;
        }
        /// <summary>
        /// Constructor which create Object using XmlNode
        /// </summary>
        /// <param name="node"></param>
        public RestaurantData(XmlNode node)
        {
            if (node == null)
            {
                throw new NullReferenceException("can't parse RestaurantData");
            }

            var attributes = node.Attributes;
            if (attributes == null)
            {
                throw new NullReferenceException("can't parse RestaurantData.Name");
            }

            Name = attributes["Name"].Value;
            var address = node.SelectSingleNode("Address");
            if (address == null)
            {
                throw new NullReferenceException("can't parse ShopData.Address");
            }

            Address = new Address(address.Attributes);
        }
        /// <summary>
        /// Method to convert RestaurantData object to XML
        /// </summary>
        /// <returns></returns>
        public XElement ToXml()
        {
            return new XElement(
                "RestaurantData",
                new XAttribute("Name", Name),
                Address.ToXml());
        }
    }
}

