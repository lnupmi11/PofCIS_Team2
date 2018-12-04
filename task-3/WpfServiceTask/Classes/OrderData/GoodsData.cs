using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace WpfServiceTask.Classes.OrderData
{
    /// <summary>
    /// Class for goods data
    /// </summary>
    [Serializable]
    public class GoodsData
    {
        [XmlAttribute]
        public uint OrderNumber { get; set; }
        [XmlAttribute]
        public double Price { get; set; }
        /// <summary>
        /// Default constructor
        /// </summary>
        public GoodsData() { }
        /// <summary>
        /// Constructor with params
        /// </summary>
        /// <param name="orderNumber"></param>
        /// <param name="price"></param>
        public GoodsData(uint orderNumber, double price)
        {
            OrderNumber = orderNumber;
            Price = price;
        }

        /// <summary>
        /// Constructor which use XmlAttributeCollection to create an object
        /// </summary>
        /// <param name="source"></param>
        public GoodsData(XmlAttributeCollection source)
        {
            if (source == null)
            {
                throw new NullReferenceException("can't parse GoodsData");
            }

            if (!uint.TryParse(source["OrderNumber"].Value, out var orderNumber))
            {
                throw new InvalidDataException("GoodsData.Code must be of type 'uint'");
            }

            OrderNumber = orderNumber;
            if (!double.TryParse(source["Price"].Value, out var price))
            {
                throw new InvalidDataException("GoodsData.Weight must be of type 'uint'");
            }

            Price = price;
        }
        /// <summary>
        /// Method to convert GoodsData object to XML
        /// </summary>
        /// <returns></returns>
        public XElement ToXml()
        {
            return new XElement(
                "GoodsData",
                new XAttribute("OrderNumber", OrderNumber),
                new XAttribute("Price", Price));
        }
    }
}

