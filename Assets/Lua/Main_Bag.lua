print("-learn xlua bag")

require("InitClass")
-- 道具信息
require("ItemData")
-- 1.本地存储 Json PlayerPrefs 二进制等
-- 2.服务器获取
require("PlayerData")
-- 初始化玩家数据
PlayerData:Init()

require("BasePanel")

require("MainPanel")

--初始化MainPanel

require("ItemGird")
require("BagPanel")


MainPanel:Show("MainPanel")

print("end")