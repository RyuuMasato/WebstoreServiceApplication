using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public enum UserType
    {
        [Description("User Account for administrative purposes.")]
        ADMIN,
        [Description("User account that represents the webstore.")]
        STORE,
        [Description("User account default.")]
        CUSTOMER
    }
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public UserType UserType { get; set; }
        public double Cash { get; set; }
        public virtual Inventory Inventory { get; set; }
        
    }
}
