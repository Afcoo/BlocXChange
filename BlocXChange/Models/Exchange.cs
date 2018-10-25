using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlocXChange.Models
{
    public class Exchange
    {
        [Key]
        public int ExchangeDataNo { get; set; }

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
    }
}
