﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.BlogModules.Queries
{
    public class BlogGetAllDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string ImageUrl { get; set; }
        public string CategoryName { get; set; }
        public int BlogCategoryId { get; set; }
    }
}
