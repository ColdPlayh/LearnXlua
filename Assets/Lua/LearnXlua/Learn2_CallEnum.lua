print("*********XLua调用C#枚举***********")

--别名
GameObject=CS.UnityEngine.GameObject
Debug=CS.UnityEngine.Debug
Vector3=CS.UnityEngine.Vector3
PrimitiveType=CS.UnityEngine.PrimitiveType

--使用Unity自带枚举
local go=GameObject.CreatePrimitive(PrimitiveType.Cube)

--自定义枚举
--不存在实例化
E_MyEnum=CS.E_MyEnum

local c=E_MyEnum.Idle
print(c)

--枚举转换
local a =E_MyEnum.__CastFrom(1)
print(a)
local b =E_MyEnum.__CastFrom("Atk")
print(b)

