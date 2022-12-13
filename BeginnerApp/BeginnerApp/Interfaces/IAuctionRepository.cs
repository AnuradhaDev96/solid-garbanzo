using BeginnerApp.Models;
using System.Collections.Generic;

namespace BeginnerApp.Interfaces
{
    public interface IAuctionRepository
    {
        IEnumerable<Auction> GetAuctions();

    }
}
