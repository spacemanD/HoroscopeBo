using Core.Enums;
using DAL.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string LanguageCode { get; set; }

        public int CurrentStatus { get; set; }

        public bool? Sex { get; set; }

        public Zodiacs? Zodiac { get; set; }

        public TimeSpan? ReceiveTime { get; set; }
    }
}
