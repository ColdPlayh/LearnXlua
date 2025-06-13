print("*********XLua调用C# Array List Dic***********")

local obj= CS.Learn3()

--Array
--长度 不能使用#
--C#中的数组  索引从0开始
print(obj.array.Length)
print(obj.array[0])

for i=0,obj.array.Length-1 do
    print("i:" .. obj.array[i])
end

--lua创建C#数组
local array=CS.System.Array.CreateInstance(typeof(CS.System.Int32),10)
print(array)
print("array.Length:" .. array.Length)


--List

obj.list:Add(1)
obj.list:Add(2)
obj.list:Add(3)
print(obj.list)
print(obj.list.Count)
for i = 0, obj.list.Count-1, 1 do
    print(obj.list[i])
end

--lua创建List对象
--老版本：
local list1=CS.System.Collections.Generic["List`1[System.String]"]()
print(list1)
list1:Add("123")
print(list1[0])
--新版本（lua>2.1.12）:
local List_String=CS.System.Collections.Generic.List(CS.System.String)
local list2=List_String()
print(list2)
list2:Add("321")
print(list2[0])

--Dictionary

obj.dic:Add(1,"123")
print(obj.dic[1])
for key, value in pairs(obj.dic) do
    print(key,value)
end
--lua创建Dic
local Dic_String_Vector3=CS.System.Collections.Generic.Dictionary(CS.System.String,CS.UnityEngine.Vector3)
local dic=Dic_String_Vector3()

dic:Add("2",CS.UnityEngine.Vector3.right)
print(dic)



-- lua中创建的字典 无法使用[]访问
-- 使用 dic:get_Item("123")
print(dic["2"])
--两个返回值 bool和 out value(lua直接多返回值即可)
print(dic:TryGetValue("2"))

print(dic:get_Item("2"))
dic:set_Item("2",CS.UnityEngine.Vector3.left)
print(dic:get_Item("2"))
--由于是Vector3是struct，所以有默认值
dic:set_Item("2",nil)


print(dic:get_Item("2"))
for key, value in pairs(dic) do
    print(key,value)
end



