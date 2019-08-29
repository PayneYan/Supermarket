using System.ComponentModel.DataAnnotations;

namespace Supermarket.Domain.Models
{
    public class GoodsType : Entity
    {

        /// <summary>
        /// 名称
        /// </summary>
        [MaxLength(50)]
        public string TypeName { get; set; }
    }
}