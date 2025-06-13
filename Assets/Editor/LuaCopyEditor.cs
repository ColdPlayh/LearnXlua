using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class LuaCopyEditor : Editor
{
    [MenuItem("XLua/lua to lua.txt")]
    public static void CopyLuaToTxt()
    {
        string luaPath = Application.dataPath + "/Lua";
        if (!Directory.Exists(luaPath)) return;

        string[] excludePaths = new[]
        {
        Path.Combine(luaPath, "LearnLua"),
        Path.Combine(luaPath, "LearnXlua")

        };
        var files = FileHelper.GetFilesWithExclusions(luaPath, "*.lua", excludePaths);
        Debug.Log("找到lua文件:");
        foreach (var file in files)
        {
            Debug.Log($"- {file}");
        }
        string newPath = Application.dataPath + "/LuaTxt/";
        if (!Directory.Exists(newPath))
        {
            Directory.CreateDirectory(newPath);
        }
        else
        {
            var deleteFiles = FileHelper.GetFilesWithExclusions(newPath, "*.txt", null);
            Debug.Log($"deleted old file in {newPath}");
            for (int i = 0; i < deleteFiles.Length; i++)
            {
                File.Delete(deleteFiles[i]);
                Debug.Log($"-delete file: {deleteFiles[i]}}}");
            }
        }
        string newFilePath;
        List<string> luaTxtFiles = new List<string>();
        Debug.Log($"copy lua to lua.txt ");
        for (int i = 0; i < files.Length; i++)
        {
            newFilePath = newPath + Path.GetFileName(files[i]) + ".txt";
            luaTxtFiles.Add(newFilePath);
            Debug.Log($"copy {files[i]} to {newFilePath} ");
            File.Copy(files[i], newFilePath);
        }

        AssetDatabase.Refresh();
        //刷新后在设置AssetBundle

        foreach (var luaTxtFile in luaTxtFiles)
        {
            // Assets/开始
            AssetImporter importer = AssetImporter.GetAtPath(luaTxtFile.Substring(luaTxtFile.IndexOf("Assets")));
            if (importer != null)
            {
                importer.assetBundleName = "lua";
            }
         }
            
    }
}
public static class FileHelper
{
    public static string[] GetFilesWithExclusions(string path, string searchPattern, string[] excludePaths)
    {
        var result = new List<string>();
        // 检查当前目录是否在排除列表中
        if (excludePaths!=null&&excludePaths.Any(ep => path.Contains(ep)))
            return result.ToArray();

        // 添加当前目录中的文件
        result.AddRange(Directory.GetFiles(path, searchPattern));

        // 递归处理子目录
        foreach (var dir in Directory.GetDirectories(path))
        {
            result.AddRange(GetFilesWithExclusions(dir, searchPattern, excludePaths));
        }

        return result.ToArray();
    }
}
