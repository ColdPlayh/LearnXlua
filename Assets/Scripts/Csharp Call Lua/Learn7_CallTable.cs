using UnityEngine;
using UnityEngine.Events;


/// <summary>
/// 使用自定义类映射Table，变量名需一致
/// </summary>
public class CallLuaClass
{
    //变量名需和lua保持一致
    //必须是public,private和protected无法赋值
    public int testInt;
    public bool testBool;
    public float testFloat;
    public string testString;

    public UnityAction testFunc;
    public TestInClass testInTable;
    //Table映射类中的内容可多可少

    public int testInt2 = 1;
    public void Test()
    {
        Debug.Log($"testInt value is {testInt}");
    }
}
public class TestInClass
{
    public int testInInt;
}
public class Learn7_CallTable : MonoBehaviour
{
    void Start()
    {
        LuaMgr.GetInstance().Init();
        LuaMgr.GetInstance().DoLuaFile("Main");
        //仍然是值拷贝
        CallLuaClass callLuaClass = LuaMgr.GetInstance().Global.Get<CallLuaClass>("testTable");
        Debug.Log(callLuaClass.testInt2);
        callLuaClass.Test();
        Debug.Log(callLuaClass.testInTable.testInInt);
    }
}
