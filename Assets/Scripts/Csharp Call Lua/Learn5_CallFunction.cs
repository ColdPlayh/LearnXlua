
using System;
using UnityEngine;
using UnityEngine.Events;
using XLua;

//无参无返回值不需要添加，会自动处理
public delegate void CustomCall();

//对于有参数或者有返回值的委托，需要添加CSharpCallLua 属性
//注意：加上该特性后，需要重新使用Xlua的GenerateCode
[CSharpCallLua]
public delegate int CustomCall2(int a);
[CSharpCallLua]
public delegate int CustomCall3(int a, out int b, out bool c, out string d, out int e);
[CSharpCallLua]
public delegate int CustomCall4(int a, ref int b, ref bool c, ref string d, ref int e);

public delegate void CustomCall5(string a, params object[] args);
public class Learn5_CallFunction : MonoBehaviour
{
    void Start()
    {
        LuaMgr.GetInstance().Init();
        LuaMgr.GetInstance().DoLuaFile("Main");

        //获取函数的方式共有四种
        //使用委托获取lua中的方法
        // CustomCall call = LuaMgr.GetInstance().Global.Get<CustomCall>("testFun");
        // call();
        // UnityAction unityAction = LuaMgr.GetInstance().Global.Get<UnityAction>("testFun");
        // unityAction();
        Action action = LuaMgr.GetInstance().Global.Get<Action>("testFun");
        action();
        //LuaFunction（少使用，额外gc）
        // LuaFunction lf = LuaMgr.GetInstance().Global.Get<LuaFunction>("testFun");
        // lf.Call();

        CustomCall2 call2 = LuaMgr.GetInstance().Global.Get<CustomCall2>("testFun2");
        Debug.Log("有参有返回" + call2(10));
        Func<int, int> sFun = LuaMgr.GetInstance().Global.Get<Func<int, int>>("testFun2");
        Debug.Log("有参有返回" + sFun(20));

        LuaFunction lf2 = LuaMgr.GetInstance().Global.Get<LuaFunction>("testFun2");
        Debug.Log("有参有返回" + lf2.Call(30)[0]);

        #region  多返回值

        CustomCall3 call3 = LuaMgr.GetInstance().Global.Get<CustomCall3>("testFun3");

        //out 必须在方法返回前被赋值
        int b;
        bool c;
        string d;
        int e;
        Debug.Log("第一个返回值" + call3(100, out b, out c, out d, out e) + $",{b},{c},{d},{e}");

        CustomCall4 call4 = LuaMgr.GetInstance().Global.Get<CustomCall4>("testFun3");
        //ref需要先初始化，在作为参数传入，可以通过引用在方法中修改原有数
        int b1 = 0;
        bool c1 = false;
        string d1 = "1";
        int e1 = 0;
        Debug.Log("第一个返回值" + call4(200, ref b, ref c, ref d, ref e) + $",{b1},{c1},{d1},{e1}");

        LuaFunction lf3 = LuaMgr.GetInstance().Global.Get<LuaFunction>("testFun3");
        object[] objects = lf3.Call(300);
        for (int i = 0; i < objects.Length; i++)
        {
            Debug.Log(objects[i]);
        }

        #endregion

        #region  变长参数
        CustomCall5 call5 = LuaMgr.GetInstance().Global.Get<CustomCall5>("testFun4");
        call5("1", 1, 2, 3, 4, 5);

        LuaFunction lf5 = LuaMgr.GetInstance().Global.Get<LuaFunction>("testFun4");
        lf5.Call("2", 1, 2, 3, 4);
        #endregion
    }
}