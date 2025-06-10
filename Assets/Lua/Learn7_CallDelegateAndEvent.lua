print('lua call C# delegate')
local obj=CS.Learn7()

local func = function () 
    print('lua func')
end

-- delegate
--第一次添加委托引用的函数，不能使用 -- obj.del=obj.del+func （del为nil）

obj.del=func
obj.del=obj.del+func

-- 不建议 不方便减少引用
obj.del =obj.del + function ()
    print('temp')
end
obj.del()

obj.del=obj.del-func
obj.del=obj.del-func

obj.del()

obj.del=nil
obj.del=func
obj.del()
local funcf= function (f)
    print('float' .. f)
end
obj.del2=funcf
obj.del2(2)

-- event
print('lua call C# event')
local func2 = function ()
    print('lua func2')
end
--调用事件使用 :
--增加
obj:eventAction('+',func2)
obj:eventAction('+',func2)
obj:eventAction('+' ,function ()
    print('func')
end)
obj:DoEvent()
obj:eventAction('-',func2)
obj:DoEvent()

-- obj.eventAction=nil 不能使用（事件不能在外部置空）
print('清空事件')
obj:ClearEvent()
obj:DoEvent()