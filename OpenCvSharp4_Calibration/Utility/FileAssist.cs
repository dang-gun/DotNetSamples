using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility;

/// <summary>
/// 
/// </summary>
public class FileAssist
{
    public void ObjectToJson(string path, object obj)
    {
        string sJosn = JsonConvert.SerializeObject(obj);
        File.WriteAllText(path, sJosn);
    }

    public T? JsonToModel<T>(string path)
    {
        string sJosn = File.ReadAllText(path);
        T? radialDistortion
            = JsonConvert.DeserializeObject<T>(sJosn);

        return radialDistortion;
    }
}
