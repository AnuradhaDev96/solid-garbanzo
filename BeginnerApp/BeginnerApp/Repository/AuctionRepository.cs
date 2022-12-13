using BeginnerApp.Data;
using BeginnerApp.Interfaces;
using BeginnerApp.Models;
using System.Collections.Generic;

namespace BeginnerApp.Repository
{
    public class AuctionRepository : IAuctionRepository
    {
        private readonly ApplicationDbContext _context;

        public AuctionRepository()
        {
        }

        public AuctionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Auction> GetAuctions()
        {
            IEnumerable<Auction> objAuctionList = _context.Auctions;
            return objAuctionList;
        }
    }
}
