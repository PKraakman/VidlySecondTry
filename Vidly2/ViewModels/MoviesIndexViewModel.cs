﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly2.Models;

namespace Vidly2.ViewModels
{
    public class MoviesIndexViewModel
    {
        public List<Movie> Movies { get; set; }
        public List<Movie> movies { get; set; }
    }
}