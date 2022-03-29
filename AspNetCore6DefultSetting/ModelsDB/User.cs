namespace ModelsDB
{
	public class User
	{
		/// <summary>
		/// 
		/// </summary>
		public int Id { get; set; }
		
		/// <summary>
		/// Sign-in Name
		/// </summary>
		public string SignName { get; set; } = string.Empty;
		/// <summary>
		/// Sign-in Password
		/// </summary>
		public string Password { get; set; } = string.Empty;
	}
}
