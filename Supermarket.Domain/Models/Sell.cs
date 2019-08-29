using Supermarket.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Supermarket.Domain.Models
{
    //销售记录表
    public class Sell : Entity
    {
        //商品编号
        [MaxLength(50)]
        public string GoodsId { get; set; }

        /// <summary>
        /// 操作者
        /// </summary>
        public OperatorEnum Operator { get; set; }

        /// <summary>
        /// 售价
        /// </summary>
        public decimal SellPrice { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int GoodsNum { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(500)]
        public string Remarks { get; set; }
    }
}