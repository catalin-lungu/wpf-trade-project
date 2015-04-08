using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using SqliteORM;

namespace KmK_Business.Model
{
    [Table("AdminDB")]
    class AdminDB
    {
        [Column("id")]
        public long Id { get; set; }
        [Column("username")]
        public string UserName { get; set; }
        [Column("password")]
        public string Password { get; set; }



    }
}
