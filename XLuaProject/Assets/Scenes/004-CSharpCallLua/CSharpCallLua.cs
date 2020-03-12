using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
using LitJson;
using System;

public class CSharpCallLua : MonoBehaviour
{
    LuaEnv luaEnv;
    [CSharpCallLua]
    delegate void Add1(int a, int b);
    [CSharpCallLua]
    delegate int Add2(int a, int b);
    [CSharpCallLua]
    delegate int Add3(int a, int b, out int c, out int d);
    private void Start()
    {
        luaEnv = new LuaEnv();
        luaEnv.DoString("require 'CSharpCallLua'");

        //基础数据类型获取方式
        //string nan = luaEnv.Global.Get<string>("nan");
        //int wang = luaEnv.Global.Get<int>("wang");
        //bool isDie = luaEnv.Global.Get<bool>("isDie");
        //Debug.Log(nan);
        //Debug.Log(wang);
        //Debug.Log(isDie);

        //table表类型获取方式 使用class 或结构体Struct接收
        //Person person = luaEnv.Global.Get<Person>("person");
        //Debug.Log(person.name);
        //Debug.Log(person.age);
        //luaEnv.DoString("print(person.name)");

        //从json中读取数据转为Person类型 直接赋值
        //TextAsset textAsset = Resources.Load<TextAsset>("person");
        //JsonData jsonData = new JsonData();
        //Person2 person = JsonMapper.ToObject<Person2>(textAsset.text);
        //Debug.Log(person.name);
        //Debug.Log(person.age);

        //通过接口的方式获取
        //Iperson iperson = luaEnv.Global.Get<Iperson>("person");
        //iperson.name = "wangshimin";
        //Debug.Log(iperson.name);
        //luaEnv.DoString("print(person.name)");
        //iperson.eat(123,456);//arg 代表隐藏参数 表达式为 p.ear(p.123,456)

        //通过Dictionary和List获取数据
        //Dictionary<string, int> keyValuePairs = luaEnv.Global.Get<Dictionary<string, int>>("age");
        //int age;
        //if (keyValuePairs.TryGetValue("nan", out age))
        //    Debug.Log("nan 的年龄为:" + age);
        //Dictionary<string, object> keyValuePairs = luaEnv.Global.Get<Dictionary<string, object>>("person");
        //foreach (string key in keyValuePairs.Keys)
        //    print(key + "---" + keyValuePairs[key]);
        //--List
        //List<float> list = luaEnv.Global.Get<List<float>>("person");
        //foreach (float o in list)
        //    Debug.Log(o);

        //LuaTable类获取XluaTable数据
        //LuaTable luaTable = luaEnv.Global.Get<LuaTable>("person");
        //print(luaTable.Get<string>("name"));
        //print(luaTable.Get<string>("age"));
        //foreach (string item in luaTable.GetKeys())
        //{
        //    print(luaTable.GetInPath<string>(item));
        //}

        ////调用Lua中的函数  --映射到delegate
        //Action act = luaEnv.Global.Get<Action>("add");
        //act();
        //act = null;
        ////调用Lua中的函数 并且加入参数   --映射到delegate
        //Add1 act1 = luaEnv.Global.GetInPath<Add1>("add1");
        //act1(54, 65);
        //act1 = null;
        ////调用Lua中的函数 加入参数 并且有返回值   --映射到delegate
        //Add2 act2 = luaEnv.Global.GetInPath<Add2>("add2");
        //int sum = act2(54, 54);
        //Debug.Log(sum);
        //act2 = null;
        ////调用Lua中的函数 加入参数 并且有多个返回值    --映射到delegate
        //Add3 act3 = luaEnv.Global.GetInPath<Add3>("add3");
        //int sum1, a, b;
        //sum1 = act3(25, 89, out a, out b);
        //Debug.Log(sum1 + "---" + a + "---" + b);
        //act3 = null;


        //映射到LuaFunction、
        LuaFunction luaFunction = luaEnv.Global.GetInPath<LuaFunction>("add");
        luaFunction.Call();
        luaFunction = null;
        //映射到LuaFunction 带有参数与返回值
        LuaFunction luaFunction1 = luaEnv.Global.GetInPath<LuaFunction>("add3");
        object[] o = luaFunction1.Call(45,45);
        foreach (object index in o)
            print(index);
        luaFunction1 = null;
    }

    private void OnDestroy()
    {
        luaEnv.Dispose();
    }
}
[CSharpCallLua] //需要将Unity的API Level等级改为.Net 4.x
interface Iperson
{
    string name { get; set; }
    int age { get; set; }
    void eat(int min, int max);
}
struct Person
{
    public string name;
    public int age;
}

class Person2
{
    public string name;
    public int age;
}
