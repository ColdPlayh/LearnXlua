-- 玩家信息
PlayerData={}

PlayerData.equips={}
PlayerData.items={}
PlayerData.gems={}

function PlayerData:Init()
    table.insert(self.equips,{id=1,num=12})
    table.insert(self.equips,{id=2,num=11})
    table.insert(self.items,{id=3,num=14})
    table.insert(self.items,{id=4,num=12})
    table.insert(self.gems,{id=5,num=11})
    table.insert(self.gems,{id=6,num=123})
end