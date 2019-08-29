using System.ComponentModel.DataAnnotations;

namespace Supermarket.Domain.Models
{
    public class User : Entity
    {
        /// <summary>
        /// 真实姓名
        /// </summary>
        [MaxLength(10)]
        public string RealName { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [MaxLength(30)]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [MaxLength(30)]
        public string Password { get; set; }
        
        /// <summary>
        /// 权限
        /// </summary>
        [MaxLength(10)]
        public string UserRight { get; set; }
    }
}