using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLoopProc
{
	/// <summary>
	/// 게임 루프 처리에 필요한 인터페이스
	/// </summary>
	public interface GameLoopProcInterface
	{
		/// <summary>
		/// 루프가 진행중인지 여부
		/// </summary>
		public bool LoopIs { get; set; }

		/// <summary>
		/// 루프가 시작되면 호출되는 함수
		/// </summary>
		public int FPS { get; set; }

		/// <summary>
		/// 루프를 시작 시킬 함수
		/// </summary>
		public Task Start();
		/// <summary>
		/// 루프를 정지시킬때 호출되는 함수
		/// </summary>
		public void Stop();
	}
}
