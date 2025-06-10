print('lua use two-dimensional array')

local obj=CS.Learn8()

print("row:" .. obj.array:GetLength(0) .. " col:" .. obj.array:GetLength(1))
-- 不能使用 obj.array[0][0] 或 obj.array{0,1}

print(obj.array:GetValue(0,0))


for i=0,obj.array:GetLength(0)-1 do
    for j=0,obj.array:GetLength(1)-1 do
        print(obj.array:GetValue(i,j))
    end
end