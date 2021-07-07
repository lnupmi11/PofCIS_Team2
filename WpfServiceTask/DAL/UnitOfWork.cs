﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfServiceTask.Classes;
using WpfServiceTask.Classes.OrderData;
using WpfServiceTask.DAL.Interfaces;

namespace WpfServiceTask.DAL
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        /// <summary>
        /// Contains order context instance.
        /// </summary>
        private readonly OrderContext _context;

        /// <summary>
        /// Orders field is used to manage table 'Orders' in the database.
        /// </summary>
        public GenericRepository<Order> Orders { get; }

        /// <summary>
        /// Clients field is used to manage table 'Clients' in the database.
        /// </summary>
        public GenericRepository<ClientData> Clients { get; }

        /// <summary>
        /// Shops field is used to manage table 'Shops' in the database.
        /// </summary>
        public GenericRepository<RestaurantData> Restaurants { get; }

        /// <summary>
        /// Goods field is used to manage table 'Goods' in the database.
        /// </summary>
        public GenericRepository<GoodsData> Goods { get; }

        /// <summary>
        /// Addresses field is used to manage table 'Addresses' in the database.
        /// </summary>
        public GenericRepository<Address> Addresses { get; }

        /// <summary>
        /// A variable which shows whether context is disposed or not.
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// Default constructor that instantiates UnitOfWork object. 
        /// </summary>
        public UnitOfWork()
        {
            _context = new OrderContext();
            Orders = new GenericRepository<Order>(_context);
            Clients = new GenericRepository<ClientData>(_context);
            Restaurants = new GenericRepository<RestaurantData>(_context);
            Goods = new GenericRepository<GoodsData>(_context);
            Addresses = new GenericRepository<Address>(_context);
        }

        /// <summary>
        /// Retrieves all orders from database.
        /// </summary>
        /// <returns>Orders list.</returns>
        public IEnumerable<Order> GetOrders()
        {
            return _context.Orders
                .Include(g => g.GoodsData)
                .Include(s => s.RestaurantData).Include(restaurant => restaurant.RestaurantData.Address)
                .Include(c => c.ClientData).Include(client => client.ClientData.Address);
        }

        /// <summary>
        /// Deletes order from database completely.
        /// </summary>
        /// <param name="id">Order id.</param>
        public void DeleteOrder(int id)
        {
            var order = Orders.GetById(id);
            Addresses.Delete(order.ClientData.Address);
            Addresses.Delete(order.RestaurantData.Address);
            Goods.Delete(order.GoodsData);
            Clients.Delete(order.ClientData);
            Restaurants.Delete(order.RestaurantData);
            Orders.Delete(order);
        }

        /// <summary>
        /// Saves context changes.
        /// </summary>
        public void Save()
        {
            _context.SaveChanges();
        }

        /// <summary>
        /// Disposes context using disposing parameter.
        /// </summary>
        /// <param name="disposing">Sets disposing state.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            _disposed = true;
        }

        /// <summary>
        /// Implements Dispose method.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
