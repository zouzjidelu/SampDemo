using System;
using System.ComponentModel.DataAnnotations;

namespace MVCTemplateSample.Models
{
    public class UserModel
    {
        public int ID { get; set; }

        [ScaffoldColumn(false)]
        public string UserName { get; set; }
       
        public string PassWord { get; set; }

        public DateTime CreateTime { get; set; }
    }
}