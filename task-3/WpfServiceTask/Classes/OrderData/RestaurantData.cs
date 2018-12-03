using System;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace WpfServiceTask.Classes.OrderData
{ 
    [Serializable]
    public class RestaurantData
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public Address Address { get; set; }

        public RestaurantData()
        {
            Address = new Address();
        }

        public RestaurantData(string name, Address address)
        {
            Name = name;
            Address = address;
        }

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

        public XElement ToXml()
        {
            return new XElement(
                "RestaurantData",
                new XAttribute("Name", Name),
                Address.ToXml());
        }
    }
}
