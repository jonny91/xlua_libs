# xlua_libs
xlua集成一些库

会根据情况更新xLua 或者 其他Lib的版本。

如有需要，请提交issue.

## xLua

版本号 2.1.13



## Libs



- protobuf（0.3.1)

  https://github.com/starwing/lua-protobuf

  P.S.在入口类中添加

```csharp
LuaEnv.LuaEnv.AddBuildin("pb", XLua.LuaDLL.Lua.LoadLuaProtobuf);
```


## TODO
- [x] iOS测试项目
- [ ] Android测试项目
- [ ] Windows测试项目
- [ ] json工具
