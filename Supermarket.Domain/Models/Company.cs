using System;
using System.ComponentModel.DataAnnotations;

namespace Supermarket.Domain.Models
{
    /// <summary>
    /// 供应商信息表
    /// </summary>
    public class Company : Entity
    {
        /// <summary>
        /// 名称
        /// </summary>
        [MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// 直接联系人
        /// </summary>
        [MaxLength(20)]
        public string Director { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        [MaxLength(20)]
        public string Phone { get; set; }

        /// <summary>
        /// 传真
        /// </summary>
        [MaxLength(20)]
        public string Fax { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [MaxLength(50)]
        public string Address { get; set; }

        /// <summary>
        /// 合作时间
        /// </summary>
        public DateTime CooperationTime { get; set; }
    }
}