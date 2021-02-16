using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities.Base
{
    public abstract class BaseEntity : BaseDto
    {
        [Key]
        public int Id { get; set; }
    }
}
