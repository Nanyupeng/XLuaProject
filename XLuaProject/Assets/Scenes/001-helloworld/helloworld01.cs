using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
public class helloworld01 : MonoBehaviour
{
    private LuaEnv luaEnv;
    private void Start()
    {
        luaEnv = new LuaEnv();
        luaEnv.DoString("print('helloworld!')");
    }

    private void OnDestroy()
    {
        luaEnv.Dispose();
    }
}
