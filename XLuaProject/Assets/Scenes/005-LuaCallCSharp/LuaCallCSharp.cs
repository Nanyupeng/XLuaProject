using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
public class LuaCallCSharp : MonoBehaviour
{
    LuaEnv luaEnv;
    private void Awake()
    {
        luaEnv = new LuaEnv();
        luaEnv.DoString("require 'LuaCallCSharp'");
    }

    private void OnDestroy()
    {
        luaEnv.Dispose();
    }
}
