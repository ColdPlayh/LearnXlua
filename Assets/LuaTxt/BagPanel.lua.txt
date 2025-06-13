BasePanel:subClass("BagPanel")
BagPanel.content = nil

--当前显示的Slot
BagPanel.items = {}

BagPanel.nowType = -1


function BagPanel:Init(name)
    --为什么第一个参数传self?
    self.base.Init(self, name)
    if self.isInitEvent == false then
        --获取其他组件
        local sv = self:GetControl("svBag","ScrollRect")
    
        self.content=sv.transform:Find("Viewport"):Find("Content")
        --添加监听
        self:GetControl("btnClose", "Button").onClick:AddListener(
            function()
                self:Hide()
            end
        )
        self:GetControl("togEquip", "Toggle").onValueChanged:AddListener(

            function(value)
                if value == true then
                    self:ChangeType(1)
                end
            end
        )
        self:GetControl("togItem", "Toggle").onValueChanged:AddListener(

            function(value)
                if value == true then
                    self:ChangeType(2)
                end
            end
        )
        self:GetControl("togGem", "Toggle").onValueChanged:AddListener(
            function(value)
                if value == true then
                    self:ChangeType(3)
                end
            end
        )

        self.isInitEvent = true
    end
end

function BagPanel:Show(name)
    self.base.Show(self,name)
    if self.nowType == -1 then
        self:ChangeType(1)
    end
end


-- 1装备 2道具 3宝石
function BagPanel:ChangeType(type)
    --不同类型切换页面
    if (self.nowType == type) then
        return
    end

    self.nowType = type
    print(type)
    --删除之前的格子
    for i = 1, #self.items do
        self.items[i]:Destroy()
    end
    self.items = {}
    local nowItems = nil
    --获取背包数据
    if type == 1 then
        nowItems = PlayerData.equips
    elseif type == 2 then
        nowItems = PlayerData.items
    elseif type == 3 then
        nowItems = PlayerData.gems
    end
    --创建格子
    for i = 1, #nowItems do
        local itemGird = ItemGird:new()
        print("创建格子")
        itemGird:Init(self, (i - 1) % 4 * 125, math.floor((i - 1) / 4) * 125)
        itemGird:InitData(nowItems[i])
        table.insert(self.items, itemGird)
    end
end
