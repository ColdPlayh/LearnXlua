
using UnityEngine;
using UnityEngine.Events;
using XLua;

/// <summary>
/// 接口映射Table
/// </summary>
//1.如果使用接口映射表需使用Attribute
//2.属性和方法同样可少可多
//3.如果接口结构更改，需要清空Xlua代码，重新生成
[CSharpCallLua]
public interface CsharpCallInterface
{
    int testInt { get; set; }
    bool testBool { get; set; }

    float testFloat { get; set; }

    string testString { get; set; }

    UnityAction testFunc { get; set; }


}
public class Learn8_CallInterface : MonoBehaviour
{

    void Start()
    {
        LuaMgr.GetInstance().Init();
        LuaMgr.GetInstance().DoLuaFile("Main");
        CsharpCallInterface callLuaClass = LuaMgr.GetInstance().Global.Get<CsharpCallInterface>("testTable");
        callLuaClass.testFunc();
        Debug.Log(callLuaClass.testInt);
        callLuaClass.testInt = 10000;
        //使用接口映射Table 引用拷贝！
        CsharpCallInterface callLuaClass2 = LuaMgr.GetInstance().Global.Get<CsharpCallInterface>("testTable");
        Debug.Log(callLuaClass2.testInt);


    }

}
