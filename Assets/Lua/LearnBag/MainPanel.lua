BasePanel:subClass("MainPanel")

--变量声明
--重写父类方法
function MainPanel:Init(name)
    --调用父类Init 注意用.
    self.base.Init(self, name)
    if self.isInitEvent==false then
        print(self:GetControl("btnRole", "Image"))
        self:GetControl("btnRole", "Button").onClick:AddListener(
            function()
                self:BtRoleClick()
            end
        )
        self.isInitEvent=true
    end
end

function MainPanel:BtRoleClick()
    BagPanel:Show("BagPanel")
end
