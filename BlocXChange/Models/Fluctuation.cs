using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlocXChange.Models
{
    public class Fluctuation
    {
        [Key]
        public int FlucNo { get; set; }

        /// <summary>
        /// 주가를 변동시켜야 할 시간의 Ticks값
        /// </summary>
        [Required]
        public long FlucTimeTicks { get; set; }

        /// <summary>
        /// 주가 변동폭
        /// </summary>
        [Required]
        public int FlucValue { get; set; }

        [Required]
        public int GameNo { get; set; }

        [ForeignKey("GameNo")]
        public virtual Game Game { get; set; }
    }
}
