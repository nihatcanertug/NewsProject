﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsProject.UI.Areas.Admin.Data.DTOs
{
    public class NewsArticleDTO
    {

        public int Id { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        public string ImagePath { get; set; }
        public int CategoryId { get; set; }
        public int AppUserId { get; set; }
    }
}