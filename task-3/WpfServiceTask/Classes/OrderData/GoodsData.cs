using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace WpfServiceTask.Classes.OrderData
{
    [Serializable]
    public class GoodsData
    {
        [XmlAttribute]
        public uint OrderNumber { get; set; }
        [XmlAttribute]
        public double Price { get; set; }

        public GoodsData() { }
        public GoodsData(uint orderNumber, double price)
        {
            OrderNumber = orderNumber;
            Price = price;
        }


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

        public XElement ToXml()
        {
            return new XElement(
                "GoodsData",
                new XAttribute("OrderNumber", OrderNumber),
                new XAttribute("Price", Price));
        }
    }
}
