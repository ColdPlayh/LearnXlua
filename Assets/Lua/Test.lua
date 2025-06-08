print('Test')
testNumber=1
testBool=true
testFloat = 1.2
testString = "lua string variable"

local testLocal=10
testFun =function()
    print('无参数无返回值方法')
end
testFun2=function(a)
    print('有参数有返回值')
    return a+1
end
testFun3 =function(a)
    print("多返回值")
    return a+1,10,false,"123",a
end
testFun4 =function (a,...)
    print('变长参数' .. a)
    arg={...}
    for k,v in pairs(arg) do
        print(k,v)
    end  
end