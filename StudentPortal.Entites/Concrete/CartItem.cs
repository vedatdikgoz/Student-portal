﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentPortal.Core.Entities;

namespace StudentPortal.Entites.Concrete
{
    public class CartItem:IEntity
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }
        
    }
}
