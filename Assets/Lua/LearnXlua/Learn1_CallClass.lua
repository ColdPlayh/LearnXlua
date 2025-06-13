print("*********XLua调用C#类***********")
--[[
CS.命名空间.类名
对于Unity类即为：CS.UnityEngine.GameObject
]]
local go1=CS.UnityEngine.GameObject()
local go2=CS.UnityEngine.GameObject("ColdPlay")

--节约性能，定义全局变量存储(本质上就是Table)（别名）
GameObject=CS.UnityEngine.GameObject
Debug=CS.UnityEngine.Debug
Vector3=CS.UnityEngine.Vector3
local go3=GameObject("ColdPlay2")

--静态对象、方法，使用.调用
local go4=GameObject.Find("ColdPlay")
Debug.Log( go4.transform.position);
print(go4.transform.position)

--使用对象中的成员方法 必须使用:调用 传入self
go4.transform:Translate(Vector3.right)
Debug.Log(go4.transform.position)

--使用自定义无命名空间的类（不继承Mono）
local test=CS.Test()
test:Speak("speak")
--使用自定义有命名空间的类（不继承Mono）
local test2=CS.ColdPlay.Test2()
test2:Speak2("speak2")

--自定义类（Mono）
local go5=GameObject("AddComponent")
--使用AddComponent加入
--Xlua不支持无参泛型，需利用Xlua提供的typeof添加Mono脚本
go5:AddComponent(typeof(CS.LuaCallCsharp))

