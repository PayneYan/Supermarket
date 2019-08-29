using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Supermarket.Domain.Enums
{
    public enum OperatorEnum
    {
        [Display(Name="管理员")]
        Admin,
        [Display(Name = "收银员")]
        Cashier,
        [Display(Name = "其他人")]
        Others
    }
}
