//=========================================
//Author: 洪金敏
//Create Date: 2019/01/23 00:45:18
//Description: 
//=========================================

using System.IO;
using UnityEngine;

public class LuaSteamingAssetsLoader
{
    public static byte[] Loader(ref string filePath)
    {
        var path = "file://" + Application.streamingAssetsPath + Path.DirectorySeparatorChar +
                   "Lua" + Path.DirectorySeparatorChar +
                   filePath + ".lua.txt";

        WWW www = new WWW(path);
        return www.bytes;
    }
}