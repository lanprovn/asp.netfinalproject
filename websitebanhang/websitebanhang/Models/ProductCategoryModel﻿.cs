﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using websitebanhang.Context;

namespace websiteBanHang.Models
{
    public class ProductCategoryModel
    {
        public List<tb_Product> ListProduct { get; set; }
        public List<tb_Category> ListCategory { get; set; }
    }
}