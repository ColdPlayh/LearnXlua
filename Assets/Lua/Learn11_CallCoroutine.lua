print('lua call mono coroutine')

--使用xlua.util
util = require("xlua.util")


GameObject = CS.UnityEngine.GameObject
WaitForSeconds = CS.UnityEngine.WaitForSeconds

local obj = GameObject("Coroutine")
local mono = obj:AddComponent(typeof(CS.LuaCallCsharp))

fun = function()
    local a = 1
    while true do
        --不能使用C# yield return
        --每一秒打印一次a
        coroutine.yield(WaitForSeconds(1))
        if a>10 then
            mono :StopCoroutine(b)
        end
        print(a)
        a = a + 1
    end
end

-- 不能直接将lua函数直接传入
-- 借助xlua.util
-- 注意要添加 CsharpCallLua typeof(System.Collections.IEnumerator)
b=mono:StartCoroutine(util.cs_generator(fun))

-- 关闭携程