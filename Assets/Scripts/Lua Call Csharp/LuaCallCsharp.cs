
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using XLua;

#region  Learn1_Func
//自定义类
public class Test
{
    public void Speak(string str)
    {
        Debug.Log($"unity's func: {str}");
    }
}
namespace ColdPlay
{

    public class Test2
    {
        public void Speak2(string str)
        {
            Debug.Log($"unity's func: {str}");
        }
    }
}

public class LuaCallCsharp : MonoBehaviour
{

}
#endregion

#region  Learn2_Enum

public enum E_MyEnum
{
    Idle,
    Move,
    Atk,
}

#endregion

#region  Learn3_Collection


public class Learn3
{
    public int[] array = { 1, 2, 3, 4, 5 };
    public List<int> list = new List<int>();

    public Dictionary<int, string> dic = new Dictionary<int, string>();

}

#endregion

#region  Learn4_Extension
public class Learn4
{
    public string name = "coldplay";
    public void Speak(string str)
    {
        Debug.Log(str);
    }
    public static void Eat()
    {
        Debug.Log("eat");
    }
}
//如果想让lua调用静态拓展方法，需要加Attribute
//建议在Lua中使用的类都加上该特性，可以提升性能
//如果不使用该特性，lua会通过反射的机制调用该方法，效果较低
[LuaCallCSharp]
public static class Tools
{
    public static void Move(this Learn4 learn4)
    {
        Debug.Log(learn4.name);
    }
}
#endregion

#region  Learn5_RefAndOut

public class Learn5
{
    public int RefFunc(int a, ref int b, ref int c, int d)
    {
        b = a + b;
        c = c + d;
        return 100;
    }
    public int OutFunc(int a, out int b, out int c, int d)
    {
        b = a;
        c = d;
        return 200;
    }
    public int RefOutFunc(int a, out int b, ref int c, int d)
    {
        b = a * 100;
        c = a * d;
        return 300;
    }
}

#endregion

#region  Learn6_Overload

public class Learn6
{
    public int Calc()
    {
        return 100;
    }
    public int Calc(int a, int b)
    {
        return a + b;
    }
    public int Calc(int a)
    {
        return a;
    }
    public float Calc(float a)
    {
        return a;
    }
}

#endregion

#region Learn7_DelegateAndEvent 

public class Learn7
{
    public UnityAction del;
    public event UnityAction eventAction;

    public UnityAction<float> del2;

    public void DoEvent()
    {
        eventAction?.Invoke();
    }
    public void ClearEvent()
    {
        eventAction = null;
    }

}

#endregion


#region  Learn8_Two-dimensional Array

public class Learn8
{
    public int[,] array = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };
}
#endregion

#region Learn9_NullAndNil
[LuaCallCSharp]
public static class Learn9
{
    /// <summary>
    /// 使用静态扩展方法 让lua具备判断UnityEngine.Object == null
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static bool IsNull(this UnityEngine.Object obj)
    {
        return obj == null;
    }
}
#endregion

#region  Learn10_Call Third-party Libraries


public static class Learn10
{
    //dll等不可修改类加特性
    [CSharpCallLua]
    public static List<Type> csharpCallLuaList = new List<Type>()
    {
        typeof(UnityAction<float>),
        typeof(System.Collections.IEnumerator),

    };
    //包括LuaCallC#
    [LuaCallCSharp]
    public static List<Type> luaCallCsharpList = new List<Type>()
    {
        typeof(GameObject)
    };

}

#endregion

#region  Learn12_Generic
public class Learn12
{
    public interface ITest
    {

    }
    public class TestFather
    {

    }
    public class TestChild : TestFather,ITest
    {

    }

    public void TestFun1<T>(T a, T b) where T : TestFather
    {
        Debug.Log("有参数有约束的泛型");
    }
    public void TestFun2<T>(T a)
    {
        Debug.Log("有参数无约束的泛型");
    }
    public void TestFun3<T>() where T : TestFather
    {
        Debug.Log("无参数有约束的泛型");
    }
    public void TestFun4<T>(T a) where T : ITest
    {
        Debug.Log("有参数有约束(接口)的泛型");
    }
    
    
    

}
#endregion

