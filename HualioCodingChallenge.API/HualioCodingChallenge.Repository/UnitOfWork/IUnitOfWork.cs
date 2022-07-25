using System;
using System.Collections.Generic;
using System.Text;

namespace HualioCodingChallenge.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        int Complete();
    }
}
