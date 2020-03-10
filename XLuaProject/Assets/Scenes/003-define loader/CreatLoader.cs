using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
public class CreatLoader : MonoBehaviour
{
    LuaEnv luaEnv;
    private void Start()
    {
        luaEnv = new LuaEnv();
        //luaEnv.DoString("require 'helloworld'");
        luaEnv.DoString("require 'helloworld'");
        luaEnv.AddLoader(MyLoader);

        luaEnv.Dispose();
    }

    byte[] MyLoader(ref string filePath)
    {
        print(filePath);
        string s = "print(10+20)";
        return System.Text.Encoding.UTF8.GetBytes(s);
    }
}
