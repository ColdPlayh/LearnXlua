using UnityEngine;
using XLua;

/// <summary>
/// 不推荐使用LuaTable,效率低
/// </summary>
public class Learn9_CallLuaTable : MonoBehaviour
{
    void Start()
    {
        LuaMgr.GetInstance().Init();
        LuaMgr.GetInstance().DoLuaFile("Main");

        LuaTable table = LuaMgr.GetInstance().Global.Get<LuaTable>("testTable");
        Debug.Log(table.Get<int>("testInt"));
        Debug.Log(table.Get<bool>("testBool"));

        Debug.Log(table.Get<float>("testFloat"));

        Debug.Log(table.Get<string>("testString"));

        table.Get<LuaFunction>("testFunc").Call();

        //引用拷贝
        table.Set("testInt", 1000);
        LuaTable table2 = LuaMgr.GetInstance().Global.Get<LuaTable>("testTable");
        Debug.Log(table2.Get<int>("testInt"));

        //显示释放
        table.Dispose();
        table2.Dispose();

    }
}