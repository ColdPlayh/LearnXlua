print("*********XLua调用C# ref out***********")

Learn5 = CS.Learn5

local obj = Learn5()

-- ref会以多返回值返回
-- a为函数返回值，b,c为ref
-- ref参数需要初始化
local a, b, c = obj:RefFunc(1, 0, 0, 1)
-- local a, b, c = obj:RefFunc(1, 1) 后面的参数会默认用0补
print('call ref' .. ':' .. a .. ':' .. b .. ':' .. c)

-- out参数可以不初始化
-- 传入的为 a和d
local d, e, f = obj:OutFunc(1, 1)
print('call out' .. ':' .. d .. ':' .. e .. ':' .. f)

-- 传入的为 a,c,d
local g, h, i = obj:RefOutFunc(20, 1, 200)
print('call ref out' .. ':' .. g .. ':' .. h .. ':' .. i)
