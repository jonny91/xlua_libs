//=========================================
//Author: 洪金敏
//Create Date: 2019/01/23 00:44:15
//Description: 
//=========================================

using UnityEngine;
using System;
using XLua;

[LuaCallCSharp]
public class LuaMonoBehaviour : MonoBehaviour
{
    [SerializeField]
    private string _luaFilePath;

    public BehaviourInjection[] Injections;
    internal static readonly LuaEnv LuaEnv = new LuaEnv();

    private LuaTable _scriptEnv;

    private Action _luaStart;
    private Action _luaUpdate;
    private Action _luaOnDestroy;

    private static float _lastGcTime = 0;
    private const float GcInterval = 1; //1 second 

    protected virtual void Awake()
    {
        var meta = LuaEnv.NewTable();
        meta.Set("__index", LuaEnv.Global);
        ScriptEnv.SetMetaTable(meta);
        meta.Dispose();

        ScriptEnv.Set("self", this);
        foreach (var injection in Injections)
        {
            ScriptEnv.Set(injection.Name, injection.Value);
        }

        var content = LuaEnv.DoString(string.Format(@"
local content = require '{0}'
return content",
                _luaFilePath),
            "LuaMonoBehaviour", ScriptEnv);

        if (content != null)
        {
            LuaTable luaTable = (LuaTable) content[0];

            var contentMeta = LuaEnv.NewTable();
            contentMeta.Set("__index", ScriptEnv);
            luaTable.SetMetaTable(contentMeta);

            contentMeta.Dispose();

            var luaAwake = luaTable.Get<Action>("awake");
            _luaStart = luaTable.Get<Action>("start");
            _luaUpdate = luaTable.Get<Action>("update");
            _luaOnDestroy = luaTable.Get<Action>("destroy");

            if (luaAwake != null)
            {
                luaAwake();
            }
        }
    }

    protected virtual void Start()
    {
        if (_luaStart != null)
        {
            _luaStart();
        }
    }

    protected virtual void Update()
    {
        if (_luaUpdate != null)
        {
            _luaUpdate();
        }

        if (Time.time - _lastGcTime > GcInterval)
        {
            if (LuaEnv != null)
            {
                LuaEnv.Tick();
            }

            _lastGcTime = Time.time;
        }
    }

    protected virtual void OnDestroy()
    {
        if (_luaOnDestroy != null)
        {
            _luaOnDestroy();
        }

        if (ScriptEnv != null)
        {
            ScriptEnv.Dispose();
            _scriptEnv = null;
        }

        _luaStart = null;
        _luaUpdate = null;
        _luaOnDestroy = null;
    }

    public LuaTable ScriptEnv
    {
        get
        {
            if (_scriptEnv == null)
            {
                _scriptEnv = LuaEnv.NewTable();
            }

            return _scriptEnv;
        }
    }
}