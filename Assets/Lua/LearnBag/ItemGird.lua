-- OOP
Object:subClass("ItemGird")
ItemGird.obj = nil
ItemGird.imgIcon = nil
ItemGird.Text = nil

-- 初始化
function ItemGird:Init(father, posX, posY)
    --实例化格子
    self.obj = ABMgr:LoadRes("ui", "Item")
    self.obj.transform:SetParent(father.content, false)
    --设置位置
    self.obj.transform.localPosition = Vector3(posX, posY, 0)
    --设置图标
    self.imgIcon = self.obj.transform:Find("Icon"):GetComponent(typeof(Image))
    self.Text = self.obj.transform:Find("Text"):GetComponent(typeof(Text))
end

-- data为道具数据
function ItemGird:InitData(bagData)
    
    local data = ItemData[bagData.id]
    local strs = string.split(data.icon, "_")

    local spriteAtlas = ABMgr:LoadRes("ui", strs[1], typeof(SpriteAtlas))
    self.imgIcon.sprite = spriteAtlas:GetSprite(strs[2])
    self.Text.text = bagData.num
end

function ItemGird:Destroy()
    GameObject.Destroy(self.obj)
    self.obj = nil
end
