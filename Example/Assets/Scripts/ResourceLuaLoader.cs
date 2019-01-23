//=========================================
//Author: 洪金敏
//Create Date: 2019/01/23 00:44:10
//Description: 
//=========================================

using UnityEngine;

public class ResourceLuaLoader
{
    public static byte[] Loader(ref string filepath)
    {
        var textAsset = Resources.Load<TextAsset>("Lua/" + filepath + ".lua");
        if (textAsset)
        {
            return textAsset.bytes;
        }
        else
        {
            return null;
        }
    }
}