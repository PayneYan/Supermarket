using System;
using System.ComponentModel.DataAnnotations;

namespace Supermarket.Domain
{
    public class Entity
    {
        /// <summary>
        /// 编号
        /// </summary>
        [Key]
        [MaxLength(50)]
        public string Id { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        [MaxLength(10)]
        public string CreateUser { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }

        /// <summary>
        /// 更新人
        /// </summary>
        [MaxLength(10)]
        public string UpdateUser { get; set; }
    }
}