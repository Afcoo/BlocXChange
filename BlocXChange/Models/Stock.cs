using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlocXChange.Models
{
    public class Stock
    {
        [Key]
        public int DataNo { get; set; }

        /// <summary>
        /// 게임 내에서 등장하는 회사의 고유 번호
        /// </summary>
        [Required]
        public int CompanyNo { get; set; }

        /// <summary>
        /// 고유 번호가 가르키는 회사의 주가
        /// </summary>
        [Required]
        public int StockValue { get; set; }

        [Required]
        public int GameNo { get; set; }

        [ForeignKey("GameNo")]
        public virtual Game Game { get; set; }
    }
}
