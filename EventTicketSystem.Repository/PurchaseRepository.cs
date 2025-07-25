﻿
using EventTicketSystem.Data;
using EventTicketSystem.Entity;
using Microsoft.EntityFrameworkCore; 
namespace EventTicketSystem.Repository
{
    public class PurchaseRepository
    {
        private readonly AppDbContext _context; 

        public PurchaseRepository(AppDbContext context) 
        {
            _context = context;
        }

        public Purchase PurchaseTicket(Purchase purchase)
        {
            _context.Purchases.Add(purchase);
            _context.SaveChanges();
            return purchase;
        }

        public List<Purchase> GetPurchasesByUserId(int userId)
        {
            return _context.Purchases.Where(p => p.UserId == userId).ToList();
        }

        public bool IsFirstPurchase(int userId)
        {
            return !_context.Purchases.Any(p => p.UserId == userId);
        }
    }
}