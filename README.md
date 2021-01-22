xlua_libs

xlua集成一些库

会根据情况更新xLua 或者 其他Lib的版本。

如有需要，请提交issue.

## xLua

版本号 2.1.15



## Libs



- protobuf（0.3.1)

  https://github.com/starwing/lua-protobuf

  P.S.在入口类中添加

  ```c#
  LuaEnv.LuaEnv.AddBuildin("pb", XLua.LuaDLL.Lua.LoadLuaProtobuf);
  ```
- rapidjson

  https://github.com/Tencent/rapidjson

  ```c#
  LuaEnv.LuaEnv.AddBuildin("rapidjson", XLua.LuaDLL.Lua.LoadLuaProtobuf);
  ```                 
  
- socket.http

  官方xlua 仅仅导出socket.core 没有导出http相关的类库
  https://github.com/diegonehab/luasocket
  ```c#  
  //关联入口函数
  #if (!UNITY_SWITCH && !UNITY_WEBGL) || UNITY_EDITOR
  	LuaEnvSingleton.LuaEnv.AddBuildin("mime.core", XLua.LuaDLL.Lua.LoadMimeCore);
  #endif      
  //将http 相关lua文件(Example/Assets/Lua/socket)放入xlua加载路径
  ...
  ```
  


详细使用可以查看 Example 项目

