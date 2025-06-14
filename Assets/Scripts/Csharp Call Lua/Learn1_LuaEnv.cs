using UnityEngine;
using XLua;
/// <summary>
/// Lua解释器
/// </summary>
public class Learn1_LuaEnv : MonoBehaviour
{
    void Start()
    {
        //Lua解析器 能够让我们在Unity中执行Lua
        //一般情况下 保持全局唯一
        LuaEnv env = new LuaEnv();

        //执行Lua语言
        env.DoString("print('Hello World')");
        /*
        执行一个Lua脚本 Lua知识点 ：多脚本执行 require
        默认寻找脚本的路径 是在 Resources下 并且 因为在这里
        估计是通过 Resources.Load去加载Lua脚本  txt bytes等等
        所以Lua脚本 后缀要加一个txt 
        */                                                                                                                                      

        env.DoString("require('Main')");

        //清楚Lua中没有手动释放的对象 垃圾回收
        //帧更新中定时执行 或者 切场景时执行
        env.Tick();

        //销毁Lua解析器 
        env.Dispose();
    }

}
