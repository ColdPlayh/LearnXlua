print('lua nil compare to C# null ')

-- 例：判断一个GameObject是否有Rigidbody,没有则AddComponent

GameObject = CS.UnityEngine.GameObject
Rigidbody=CS.UnityEngine.Rigidbody

local obj = GameObject("测试添加组件")
local rig= obj:GetComponent(typeof(Rigidbody))

print(rig)
-- nil和null无法进行 '==' 比较
if(rig==nil) then
    print('== add rigidbody')
    rig=obj:AddComponent(typeof(Rigidbody))
end

-- function IsNull(obj)
--     if obj == nil or obj:Equals(nil) then
--         return true;
--     end
--     return false
-- end
-- if(IsNull(rig)) then
--      print('equals add rigidbody')
--     rig=obj:AddComponent(typeof(Rigidbody))
-- end
if rig:IsNull() then
    print('c# static extension func determine null')
    rig=obj:AddComponent(typeof(Rigidbody))
end
print(rig)
