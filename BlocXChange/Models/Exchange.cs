using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlocXChange.Models
{
    public class Exchange
    {
        [Key]
        public int DataNo { get; set; }

        /// <summary>
        /// 거래가 생성되었을 때, 판매자의 고유번호
        /// </summary>
        [Required]
        public int Seller { get; set; }

        /// <summary>
        /// 거래가 생성되었을 때, 구매자의 고유번호
        /// </summary>
        [Required]
        public int Buyer { get; set; }

        /// <summary>
        /// 거래가 생성되었을 때, 거래 금액
        /// </summary>
        [Required]
        public int Value { get; set; }

        [Required]
        public int GameNo { get; set; }

        [ForeignKey("GameNo")]
        public virtual Game Game { get; set; }
    }
}
