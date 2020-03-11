using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
using System.IO;
public class CreatLoader : MonoBehaviour
{
    LuaEnv luaEnv;
    private void Start()
    {
        luaEnv = new LuaEnv();
        //luaEnv.DoString("require 'helloworld'");
        luaEnv.AddLoader(MyLoader);

        luaEnv.DoString("require 'helloworld2'");

        luaEnv.Dispose();
    }

    byte[] MyLoader(ref string filePath)
    {
        print(filePath);
        //string s = "print(10+20)";
        //StreamReader streamReader = File.OpenText(Application.dataPath + "/Scenes/003-define loader/lua/" + filePath + ".lua.txt");
        //return System.Text.Encoding.UTF8.GetBytes(streamReader.ReadToEnd());

        //string luapath = Application.dataPath + "/Scenes/003-define loader/lua/" + filePath + ".lua.txt";
        //string stringReader = File.ReadAllText(luapath, Encoding.UTF8);
        //    return System.Text.Encoding.UTF8.GetBytes(stringReader);

        string luapath = Application.streamingAssetsPath + "/" + filePath + ".lua.txt";
        byte[] luabyte = File.ReadAllBytes(luapath);
        return luabyte;
    }

}
