print('lua call generic func')

local obj = CS.Learn12()

-- 内部类
local child = CS.Learn12.TestChild()
local father = CS.Learn12.TestFather()

-- 支持有参数有约束泛型
-- 作为参数时候变相相当于传type
obj:TestFun1(child, father)
obj:TestFun1(father, child)

-- 不支持没有约束的泛型
-- obj:TestFun2(child)

-- 不支持没有参数的泛型
-- obj : TestFun3()
-- 不支持非class约束
-- obj:TestFun4(child)


--[[
如何使用不支持的泛型 （反射，少用，效率低），
且有使用限制
1.Mono可以使用
2.Il2cpp 支持T为引用类型
如果为值类型，必须是C#已经使用过同类型的泛型参数，lua才能使用
原因：Il2cpp 为AOT(引用类型 使用共享代码，所有引用类型用一份泛型实现，对于值类型只有目标泛型示例使用过，才会被生成) 
Mono为JIT（即时编译）
]]
--[[
1.得到通用函数
2.设置实际的类型
]]

--获取通用函数
local testFun2=xlua.get_generic_method(CS.Learn12,"TestFun2")
--设置类型
local testFun2_Real=testFun2(CS.System.Int32)
--调用
testFun2_Real(obj,12)


