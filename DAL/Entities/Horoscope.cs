using Core.Enums;
using DAL.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Horoscope : BaseEntity
    {
        public Zodiacs? Zodiac { get; set; }

        public string Text { get; set; }

        public DateTime Date { get; set; }

        public HoroscopeTypes Type { get; set; }
    }
}
