using ModelsDB;

namespace WebApi_JwtAuth.Models
{
	public class ApiResultModel
    {
        /// <summary>
        /// 성공여부
        /// </summary>
        public bool Complete { get; set; } = false;

        /// <summary>
        /// 메시지
        /// </summary>
        public string Message { get; set; } = string.Empty;
    }
}
