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
        //从AB包加载
        // luaEnv.AddLoader(MyCustomABLoader);
        //从Lua文件夹加载
        luaEnv.AddLoader(MyCustomLoaderLearnBag);
        //从LearnXlua加载
         luaEnv.AddLoader(MyCustomLoaderLearnXlua);
        
        

    }
    /// <summary>
    /// 执行脚本
    /// </summary>
    /// <param name="str">脚本字符串</param>
    public void DoString(string str)
    {
        if (luaEnv == null)
        {
            Debug.Log("LuaEnv instance is null");
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
    private byte[] MyCustomLoaderLearnBag(ref string fillPath)
    {

        string path = Application.dataPath + "/Lua/LearnBag/" + fillPath + ".lua";
        Debug.Log($"load lua file from path: {path}");

        if (!File.Exists(path))
        {
            Debug.Log("Lua file not found:" + path);
            return null;
        }
        return File.ReadAllBytes(path);
        

    }
    //sub
    private byte[] MyCustomLoaderLearnXlua(ref string fillPath)
    {

        string path = Application.dataPath + "/Lua/LearnXlua/" + fillPath + ".lua";
        Debug.Log($"load lua file from path: {path}");

        if (!File.Exists(path))
        {
            Debug.Log("Lua file not found:" + path);
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
            Debug.Log("lua file {fillPath} not found in AssetBundle");
            return null;
        }
        Debug.Log($"load lua file from AssetBundle lua name {fillPath}");
        return textAsset.bytes;
    }
}