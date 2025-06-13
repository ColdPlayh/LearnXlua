-- OOP UIPanel基类

Object:subClass("BasePanel")
BasePanel.panelObj = nil
BasePanel.controls = {}
--避免重复Init添加事件
BasePanel.isInitEvent = false
function BasePanel:Init(name)
    if (self.panelObj == nil) then
        self.panelObj = ABMgr:LoadRes("ui", name, typeof(GameObject))
        self.panelObj.transform:SetParent(Canvas, false)
        print(self.panelObj)
        local allControls = self.panelObj:GetComponentsInChildren(typeof(UIBehaviour))
        -- 同名怎么办？
        -- 避免无用规则，拼面板命名按照规范 如btn_ img_ text_ tog_
        for i = 0, allControls.Length - 1 do
            local controlName = allControls[i].name
            if string.find(controlName, "btn") ~= nil or
                string.find(controlName, "img") ~= nil or
                string.find(controlName, "tog") ~= nil or
                string.find(controlName, "sv") ~= nil or
                string.find(controlName, "text") ~= nil
            then
                -- 借助反射获取类名
                local typeName = allControls[i]:GetType().Name
                -- 避免一个对象挂载多个组件，覆盖的问题
                -- 存储方式 {btnRole={[Image=组件,Button=组件},
                --          togEquip={Toggle=组件}}
                if self.controls[controlName] ~= nil then
                    self.controls[controlName][typeName] = allControls[i]
                else
                    self.controls[controlName] = { [typeName] = allControls[i] }
                end
            end
        end
    end
end

-- 根据对象名（依附的GameObject的name）和type获取一个组件
function BasePanel:GetControl(name, type)
    if self.controls[name] ~= nil then
        local sameNameControls = self.controls[name]
        if sameNameControls[type] ~= nil then
            return sameNameControls[type]
        end
    end
    return nil
end

function BasePanel:Show(name)
    self:Init(name)
    self.panelObj:SetActive(true)
end

function BasePanel:Hide()
    self.panelObj:SetActive(false)
end
