using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using WpfServiceTask.Classes.OrderData;

namespace WpfServiceTask.Classes
{
    [Serializable]
    public class Order
    {
        [XmlAttribute]
        public int Id { get; set; }
    
        public ClientData ClientData { get; set; }
   
        public RestaurantData RestaurantData { get; set; }
      
        public GoodsData GoodsData { get; set; }

        public Order(XmlNode node)
        {
            if (node.Attributes == null)
            {
                throw new InvalidDataException("invaliid xml node content");
            }

            if (!int.TryParse(node.Attributes["Id"].Value, out var id))
            {
                throw new InvalidDataException("Order.Id must be of type 'uint'");
            }

            Id = id;

            ClientData = new ClientData(node.SelectSingleNode("ClientData"));
            RestaurantData = new RestaurantData(node.SelectSingleNode("RestaurantData"));
            var goodData = node.SelectSingleNode("GoodsData");
            if (goodData == null)
            {
                return;
            }

            GoodsData = new GoodsData(goodData.Attributes);
        }

        public Order()
        {
            ClientData = new ClientData();
            RestaurantData = new RestaurantData();
            GoodsData = new GoodsData();
        }

        public Order(int id, ClientData clientData, RestaurantData restaurantData, GoodsData goodsData)
        {
            Id = id;
            ClientData = clientData;
            RestaurantData = restaurantData;
            GoodsData = goodsData;
        }

        public XElement ToXml()
        {
            return new XElement("Order",
                new XAttribute("Id", Id),
                ClientData.ToXml(),
                GoodsData.ToXml(),
                RestaurantData.ToXml());
        }

        public static void EditXmlNode(ref XmlNode node, Order newOrd)
        {
            if (node == null)
            {
                throw new NullReferenceException("can't edit node");
            }

            if (node.Attributes != null)
            {
                node.Attributes["Id"].Value = newOrd.Id.ToString();
            }

            var clientData = node.SelectSingleNode("ClientData");

            if (clientData == null)
            {
                throw new NullReferenceException("can't edit ClientData");
            }

            if (clientData.Attributes == null)
            {
                throw new NullReferenceException("can't edit ClientData.Attributes");
            }

            clientData.Attributes["FirstName"].Value = newOrd.ClientData.FirstName;
            clientData.Attributes["LastName"].Value = newOrd.ClientData.LastName;
            clientData.Attributes["PhoneNumber"].Value = newOrd.ClientData.PhoneNumber;

            var clientAddress = clientData.SelectSingleNode("Address");

            if (clientAddress == null)
            {
                throw new NullReferenceException("can't edit ClientData.Address");
            }

            if (clientAddress.Attributes == null)
            {
                throw new NullReferenceException("can't edit ClientData.Address.Attributes");
            }

            clientAddress.Attributes["City"].Value = newOrd.ClientData.Address.City;
            clientAddress.Attributes["Street"].Value = newOrd.ClientData.Address.Street;
            clientAddress.Attributes["BuildingNumber"].Value = newOrd.ClientData.Address.BuildingNumber.ToString();

            var restaurantData = node.SelectSingleNode("RestaurantData");

            if (restaurantData == null)
            {
                throw new NullReferenceException("can't edit Order.RestaurantData");
            }

            if (restaurantData.Attributes == null)
            {
                throw new NullReferenceException("can't edit Order.RestaurantData.Attributes");
            }

            restaurantData.Attributes["Name"].Value = newOrd.RestaurantData.Name;

            var restaurantAddress = restaurantData.SelectSingleNode("Address");

            if (restaurantAddress == null)
            {
                throw new NullReferenceException("can't edit RestaurantData.Adress");
            }

            if (restaurantAddress.Attributes == null)
            {
                throw new NullReferenceException("can't edit Order.Address.Attributes");
            }

            restaurantAddress.Attributes["City"].Value = newOrd.RestaurantData.Address.City;
            restaurantAddress.Attributes["Street"].Value = newOrd.RestaurantData.Address.Street;
            restaurantAddress.Attributes["BuildingNumber"].Value = newOrd.RestaurantData.Address.BuildingNumber.ToString();

            var goodsData = node.SelectSingleNode("GoodsData");

            if (goodsData == null)
            {
                throw new NullReferenceException("can't edit Order.GoodsData");
            }

            if (goodsData.Attributes == null)
            {
                throw new NullReferenceException("can't edit Order.Address.Attributes");
            }

            goodsData.Attributes["OrderNumber"].Value = newOrd.GoodsData.OrderNumber.ToString();
            goodsData.Attributes["Price"].Value = newOrd.GoodsData.Price.ToString(CultureInfo.CurrentCulture);
        }
    }
}
