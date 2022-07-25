using HualioCodingChallenge.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HualioCodingChallenge.Core.Domain
{
    public class HualioCodingChallengeDBContext : DbContext
    {
        public HualioCodingChallengeDBContext(DbContextOptions<HualioCodingChallengeDBContext> options) : base(options)
        { }

        public DbSet<Product> Products { get; set; }

    }
}
