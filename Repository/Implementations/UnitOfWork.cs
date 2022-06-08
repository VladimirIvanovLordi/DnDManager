using Data.Context;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementations
{
    public class UnitOfWork : IDisposable
    {
        private DnDManagerDBContext context = new DnDManagerDBContext();

        private GenericRepository<Item> itemRepository;
        private GenericRepository<Player> playerRepository;
        private GenericRepository<Campaign> campaignRepository;

        public GenericRepository<Item> ItemRepository
        {
            get
            {

                if (this.itemRepository == null)
                {
                    this.itemRepository = new GenericRepository<Item>(context);
                }
                return itemRepository;
            }
        }
        public GenericRepository<Player> PlayerRepository
        {
            get
            {

                if (this.playerRepository == null)
                {
                    this.playerRepository = new GenericRepository<Player>(context);
                }
                return playerRepository;
            }
        }
        public GenericRepository<Campaign> CampaignRepository
        {
            get
            {

                if (this.campaignRepository == null)
                {
                    this.campaignRepository = new GenericRepository<Campaign>(context);
                }
                return campaignRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
