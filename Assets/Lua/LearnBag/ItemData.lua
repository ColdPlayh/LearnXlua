-- 读取json TextAsset
local txt=ABMgr:LoadRes("json","ItemData",typeof(TextAsset))
-- 获取内容
local itemList=Json.decode(txt.text)
-- 转Table,类似于字典
ItemData={}
for _,value in pairs(itemList) do
    ItemData[value.id]=value
end

-- for key,value in pairs(ItemData) do
--     print(key,value)
-- end