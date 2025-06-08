using UnityEngine;

/// <summary>
/// 获取Lua脚本的变量
/// </summary>
public class Learn4_CallVariable : MonoBehaviour
{
    void Start()
    {
        LuaMgr.GetInstance().Init();

        LuaMgr.GetInstance().DoLuaFile("Main");

        //无法获取local
        //int local = LuaMgr.GetInstance().Global.Get<int>("testLocal");
        //Debug.Log("testLocal:" + local);

        int i = LuaMgr.GetInstance().Global.Get<int>("testNumber");
        Debug.Log("testNumber:" + i);
        i = 10;
        //修改lua中的值
        LuaMgr.GetInstance().Global.Set("testNumber", 55);
        int i2 = LuaMgr.GetInstance().Global.Get<int>("testNumber");
        Debug.Log("testNumber_i2:" + i2);

        bool b = LuaMgr.GetInstance().Global.Get<bool>("testBool");
        Debug.Log("testBool:" + b);
        //虽然Lua只有number，但C#可以用实际类型获取
        float f = LuaMgr.GetInstance().Global.Get<float>("testFloat");
        Debug.Log("testFloat:" + f);
        //支持自动类型转换 double = float
        double d = LuaMgr.GetInstance().Global.Get<double>("testFloat");
        Debug.Log("testFloat_double:" + d);

        string s = LuaMgr.GetInstance().Global.Get<string>("testString");
        Debug.Log("testString:" + s);
        //值拷贝
        // s = "123";
        // string s2 = LuaMgr.GetInstance().Global.Get<string>("testString");
        // Debug.Log("testString:" + s2);
    }

}