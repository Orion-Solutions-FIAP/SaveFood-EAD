﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaveFood.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
    }
}