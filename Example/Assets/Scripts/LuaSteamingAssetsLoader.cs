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
        string path;
        if (Application.platform == RuntimePlatform.Android)
        {
            path = Application.streamingAssetsPath + Path.DirectorySeparatorChar +
                   "Lua" + Path.DirectorySeparatorChar +
                   filePath + ".lua.txt";
        }
        else
        {
            path = "file:///" + Application.streamingAssetsPath + Path.DirectorySeparatorChar +
                   "Lua" + Path.DirectorySeparatorChar +
                   filePath + ".lua.txt";
        }

        WWW www = new WWW(path);
        while (true)
        {
            //完成或者报错了
            if (www.isDone || !string.IsNullOrEmpty(www.error))
            {
                System.Threading.Thread.Sleep(50);
                if (!string.IsNullOrEmpty(www.error)) //有错误
                {
                    return null;
                }
                else //加载完成
                {
                    return www.bytes;
                }
            }
        }
    }
}