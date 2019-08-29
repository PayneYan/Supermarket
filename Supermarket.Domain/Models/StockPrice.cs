using System.ComponentModel.DataAnnotations;

namespace Supermarket.Domain.Models
{
    public class StockPrice : Entity
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

        //供应商最新进价
        public decimal GoodsSellPrice { get; set; }
    }
}