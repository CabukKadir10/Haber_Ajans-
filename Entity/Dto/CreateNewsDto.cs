﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto
{
    public class CreateNewsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public string Districh { get; set; } //semt
        public string Destcription { get; set; } //açıklama
        public string Status { get; set; } //haber durumu onay bekleme
        public DateTime Date { get; set; } // yükleme tarihi
        public bool IsDeleted { get; set; } = false; //silindi mi
        public int UserId { get; set; }
    }
}
