// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.Reflection;
using System.Text;



StringBuilder sbOut = new StringBuilder();

sbOut.AppendLine("-------- AssemblyName --------");

//이 프로그램의 어셈블리 정보
Assembly assembly = Assembly.GetExecutingAssembly();
//어셈블리 이름 정보
AssemblyName name = assembly.GetName();


DateTime dtVersion
	= new DateTime(2000, 1, 1)
		.AddDays(name.Version!.Build)
		.AddSeconds(name.Version.Revision * 2);

sbOut.AppendLine("Version : " + name.Version);
sbOut.AppendLine("Date time : " + dtVersion);

//string sVer = string.Format("{0}({1})", name.Version, dtVersion);
//string sVer = name.Version.ToString();
//string sVer = dtVersion.ToString();

sbOut.AppendLine();


sbOut.AppendLine("-------- FileVersionInfo --------");
sbOut.AppendLine();

//이 프로그램의 파일 정보
FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
FileInfo fi = new FileInfo(assembly.Location);

sbOut.AppendLine("Version : " + fvi.FileVersion);
sbOut.AppendLine("Date time : " + fi.LastWriteTime);


Console.WriteLine(sbOut.ToString());