﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalExam.Models
{
    public class EFItemRepository :IItemRepository
    {
        private ApplicationDbContext context;
        public EFItemRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Item> Items => context.Items;
    }
}
