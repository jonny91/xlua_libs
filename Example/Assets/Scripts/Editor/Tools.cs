//=========================================
//Author: 洪金敏
//Create Date: 2019/01/23 00:12:52
//Description: 
//=========================================

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class Tools : Editor
{
    [MenuItem("Tools/MoveLuaToSA")]
    public static void MoveLuaFileToStreamingAssetHandler()
    {
        var luaSourceFolder = Application.dataPath + Path.DirectorySeparatorChar + "Lua";
        var luaTargetFolder = Application.dataPath + Path.DirectorySeparatorChar + "StreamingAssets"
                              + Path.DirectorySeparatorChar + "Lua";

        //移除旧的文件
        var targetDirectoryInfo = new DirectoryInfo(luaTargetFolder);
        foreach (var fileInfo in targetDirectoryInfo.GetFiles())
        {
            fileInfo.Delete();
        }

        //新lua文件拷贝到StreamingAssets文件夹
        var directoryInfo = new DirectoryInfo(luaSourceFolder);
        foreach (var fileInfo in directoryInfo.GetFiles())
        {
            if (fileInfo.Extension != ".meta")
            {
                var targetLuaFileName = luaTargetFolder + Path.DirectorySeparatorChar + fileInfo.Name + ".txt";
                File.Copy(fileInfo.FullName, targetLuaFileName, true);
            }
        }

        AssetDatabase.Refresh();
    }
}