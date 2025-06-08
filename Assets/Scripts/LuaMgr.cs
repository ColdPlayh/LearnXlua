using UnityEngine;
using System.IO;
using XLua;
using System;
using UnityEngine.UI;

public class LuaMgr : BaseManager<LuaMgr>
{
    private LuaEnv luaEnv;
    /// <summary>
    /// _G表
    /// </summary>
    public LuaTable Global =>  luaEnv.Global;


    /// <summary>
    /// 初始化
    /// </summary>
    public void Init()
    {
        if (luaEnv != null) return;
        luaEnv = new LuaEnv();

        luaEnv.AddLoader(MyCustomLoader);
        luaEnv.AddLoader(MyCustomABLoader);

    }
    /// <summary>
    /// 执行脚本
    /// </summary>
    /// <param name="str">脚本字符串</param>
    public void DoString(string str)
    {
        if (luaEnv == null)
        {
            Debug.LogError("LuaEnv instance is null");
        }
        luaEnv.DoString(str);
    }
    /// <summary>
    /// 执行lua文件
    /// </summary>
    /// <param name="fileName">脚本文件名</param>
    public void DoLuaFile(string fileName)
    {
        DoString($"require '{fileName}'");
    }

    public void Tick()
    {
        luaEnv.Tick();
    }
    /// <summary>
    /// 释放
    /// </summary>
    public void Dispose()
    {
        luaEnv.Dispose();
        luaEnv = null;
    }
    //自定义加载器
    private byte[] MyCustomLoader(ref string fillPath)
    {

        string path = Application.dataPath + "/Lua/" + fillPath + ".lua";
        // Debug.Log($"load lua file from path: {path}");

        if (!File.Exists(path))
        {
            Debug.LogError("Lua file not found");
            return null;
        }
        return File.ReadAllBytes(path);

    }
    //从AB包中加载lua文件
    private byte[] MyCustomABLoader(ref string fillPath)
    {
        TextAsset textAsset = ABMgr.GetInstance().LoadRes<TextAsset>("lua", fillPath + ".lua");
        if (textAsset == null)
        {
            Debug.LogError("lua file {fillPath} not found in AssetBundle");
        }
        return textAsset.bytes;
    }
}