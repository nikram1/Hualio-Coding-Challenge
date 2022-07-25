using HualioCodingChallenge.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HualioCodingChallenge.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HualioCodingChallengeDBContext _context;
        public IProductRepository Products { get; }

        public UnitOfWork(HualioCodingChallengeDBContext hualioCodingChallengeDBContext,
            IProductRepository productsRepository)
        {
            this._context = hualioCodingChallengeDBContext;
            this.Products = productsRepository;
        }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
