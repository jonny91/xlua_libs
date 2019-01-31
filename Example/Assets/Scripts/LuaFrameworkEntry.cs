//=========================================
//Author: 洪金敏
//Create Date: 2019/01/15 16:44:41
//Description: 
//=========================================

using System.IO;
using UnityEngine;
using XLua;

public class LuaFrameworkEntry : LuaMonoBehaviour
{
    protected override void Awake()
    {
        LuaEnv.AddLoader(LuaSteamingAssetsLoader.Loader);
//        LuaEnv.AddLoader(ResourceLuaLoader.Loader);
//        LuaEnv.AddLoader(LuaDirectoryLoader.Loader);

        LuaEnv.AddBuildin("pb", XLua.LuaDLL.Lua.LoadLuaProtobuf);
        LuaEnv.AddBuildin("rapidjson", XLua.LuaDLL.Lua.LoadRapidJson);

        base.Awake();
    }
}