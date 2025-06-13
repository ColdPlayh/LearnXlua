print("*********XLua调用C# overload func***********")

Learn6=CS.Learn6
local obj =Learn6()

print(obj:Calc())
print(obj:Calc(1,1))

-- 虽然支持调用C#重载函数
-- lua只有number
-- 对于C#多精度的重载函数支持不好
print(obj:Calc(1))
print(obj:Calc(1.2))

--解决 借助反射，效率低（尽量不用）
--得到指定函数信息
local m1=typeof(CS.Learn6):GetMethod("Calc",{typeof(CS.System.Int32)})
local m2=typeof(CS.Learn6):GetMethod("Calc",{typeof(CS.System.Single)})

--使用xlua提供的方法转换为方法，一般一个方法转化一次

local f1=xlua.tofunction(m1)
local f2=xlua.tofunction(m2)
-- LUA: 10.199999809265 语言float精度不同
print(f1(obj,10))
print(f2(obj,10.2))
