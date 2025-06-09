using UnityEngine;

/*
1.lua没有办法直接访问C#
2.需要先使用C#脚本调用lua
*/
public class Main : MonoBehaviour
{
    void Start()
    {
        LuaMgr.GetInstance().Init();
        LuaMgr.GetInstance().DoLuaFile("Main");
    }
}
