xlua_libs

xlua集成一些库

会根据情况更新xLua 或者 其他Lib的版本。

如有需要，请提交issue.

## xLua

版本号 2.1.14



## Libs



- protobuf（0.3.1)

  https://github.com/starwing/lua-protobuf

  P.S.在入口类中添加

  ```csharp
  LuaEnv.LuaEnv.AddBuildin("pb", XLua.LuaDLL.Lua.LoadLuaProtobuf);
  ```
- rapidjson

  https://github.com/Tencent/rapidjson

  ```csharp
  LuaEnv.LuaEnv.AddBuildin("rapidjson", XLua.LuaDLL.Lua.LoadLuaProtobuf);
  ```


详细使用可以查看 Example 项目

