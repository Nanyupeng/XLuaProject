using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
public class helloworld02 : MonoBehaviour
{
    private LuaEnv luaEnv;
    private void Start()
    {
        luaEnv = new LuaEnv();
        //第一种方式
        //TextAsset textAsset = Resources.Load<TextAsset>("helloworld.lua");
        //luaEnv.DoString(textAsset.text); //DOString 用于执行lua方法的函数
        //第二种方式
        luaEnv.DoString("require 'helloworld'");//使用lua中的require关键字 搜索helloworld脚本 并执行里面的方法
        luaEnv.Dispose();
    }
}
