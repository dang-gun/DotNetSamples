using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLoopProc
{
	/// <summary>
	/// 게임 루프에 필요한 인터페이스
	/// </summary>
	public interface GameLoopInterface
	{
		/// <summary>
		/// 루프가 시작되면 호출되는 함수
		/// </summary>
		public Task Start();
		/// <summary>
		/// 루프중 1회 업데이트때 호출되는 함수
		/// </summary>
		public void Update();
		/// <summary>
		/// 루프를 정지시킬때 호출되는 함수
		/// </summary>
		public void Stop();

		/// <summary>
		/// 루프가 완전히 정지했을때 발생하는 이벤트
		/// </summary>
		public void StopCompleted();
	}
}
