using System.IO;
using UnityEngine;
using XLua;
/// <summary>
/// 自定义Loader
/// </summary>
public class Learn2_Loader : MonoBehaviour
{
    void Start()
    {
        LuaEnv env = new LuaEnv();
        //使用CustomLoader修改加载lua脚本的路径
        //当有Loader返回路径不对的时候，会尝试所有的Loader
        env.AddLoader(MyCustomLoader);
        env.DoString("require('Main')");
    }

    private byte[] MyCustomLoader(ref string fillPath)
    {

        string path = Application.dataPath + "/Lua/" + fillPath + ".lua";
        Debug.Log($"load lua file from path: {path}");

        if (!File.Exists(path))
        {
            Debug.LogError("Lua File is not found");
            return null;
        }
        return File.ReadAllBytes(path);

    }
}
