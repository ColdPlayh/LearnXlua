print("**********多脚本执行************")
print("**********全局变量和本地变量************")
--全局变量
a = 1
b = "123"
for i = 1,2 do
	c = "Cold"
end
print(c)
--本地（局部）变量的关键字 local
for i = 1,2 do
	local d = "Cold"
	print("循环中的d"..d)
end
print(d)
fun = function()
	local tt = "123123123"
end
fun()
print(tt)
local tt2 = "555"
print(tt2)

print("**********多脚本执行************")
--关键字 require("脚本名") require('脚本名')
require('TestRequire')
print(testA)
print(testLocalA)

print("**********脚本卸载************")
--如果是require加载执行的脚本 加载一次过后不会再被执行
require("TestRequire")
--package.loaded["脚本名"]
--返回值是boolean 意思是 该脚本是否被执行
print(package.loaded["TestRequire"])
--卸载已经执行过的脚本
package.loaded["TestRequire"] = nil
print(package.loaded["TestRequire"])

--require 执行一个脚本时  可以再脚本最后返回一个外部希望获取的内容
local testLA = require("TestRequire")
print(testLA)

print("**********大G表************")
--_G表是一个总表(table) 他将我们申明的所有全局的变量都存储在其中
for k,v in pairs(_G) do
	print(k,v)
end
--本地变量 加了local的变量时不会存到大_G表中