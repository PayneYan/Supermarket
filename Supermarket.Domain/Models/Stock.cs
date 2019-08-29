using Supermarket.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Supermarket.Domain.Models
{
    /// <summary>
    /// 入库记录表
    /// </summary>
    public class Stock : Entity
    {
        /// <summary>
        /// 商品编号
        /// </summary>
        [MaxLength(50)]
        public string GoodsId { get; set; }
        /// <summary>
        /// 供应商编号
        /// </summary>
        [MaxLength(50)]
        public string ConmpanyId { get; set; }
        /// <summary>
        /// 操作员
        /// </summary>
        public OperatorEnum Operator { get; set; }
        /// <summary>
        /// 进价
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int GoodsNum { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(500)]
        public string Remark { get; set; }
    }
}