using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlocXChange.Models
{
    public class Game
    {
        [Key]
        public int GameNo { get; set; }
        
        [Required]
        public string GameID { get; set; }

        [Required]
        public string GamePassword { get; set; }

        /// <summary>
        /// 게임을 생성할 때 자동으로 생성되는 고유 코드
        /// 게임에 참가할 때 입력 필요
        /// </summary>
        [Required]
        public string GameKey { get; set; }

        /// <summary>
        /// 게임이 시작된 시간
        /// </summary>
        [Required]
        public DateTime InitialTime { get; set; }
        
        /// <summary>
        /// 게임이 중간에 일시정지된 경우, 일시중지된 시간을 기록
        /// </summary>
        [Required]
        public long SuspendedTicks { get; set; }
    }
}
