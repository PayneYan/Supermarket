using System.ComponentModel.DataAnnotations;

namespace Supermarket.Domain.Models
{
    /// <summary>
    /// 商品信息表
    /// </summary>
    public class Goods : Entity
    {
        /// <summary>
        /// 类型编号
        /// </summary>
        [MaxLength(50)]
        public string TypeId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [MaxLength(20)]
        public string Name { get; set; }

        /// <summary>
        /// 计量单位
        /// </summary>
        [MaxLength(20)]
        public string Unit { get; set; }

        /// <summary>
        /// 规格
        /// </summary>
        [MaxLength(20)]
        public string Norm { get; set; }

        /// <summary>
        /// 售价
        /// </summary>
        public decimal SellPrice { get; set; }

        /// <summary>
        /// 库存量
        /// </summary>
        public int GoodNum { get; set; }

         /// <summary>
        /// 报警量
        /// </summary>
        public int AlarmNum { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(500)]
        public string Remarks { get; set; }
    }
}