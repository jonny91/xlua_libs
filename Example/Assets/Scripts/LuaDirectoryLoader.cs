//=========================================
//Author: 洪金敏
//Create Date: 2019/01/15 16:44:32
//Description: 
//=========================================

using System.IO;
using System.Text;
using UnityEngine;

public class LuaDirectoryLoader
{
    public static byte[] Loader(ref string filePath)
    {
        var path = Application.dataPath + Path.DirectorySeparatorChar + "Lua" +
                   Path.DirectorySeparatorChar + filePath + ".lua";

        if (File.Exists(path))
        {
            var streamReader = new StreamReader(path);
            var fileStr = streamReader.ReadToEnd();
            streamReader.Close();
            return Encoding.UTF8.GetBytes(fileStr);
        }
        else
        {
            return null;
        }
    }
}