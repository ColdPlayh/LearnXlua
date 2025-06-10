print('Main')
function IsNull(obj)
    if obj == nil or obj:Equals(nil) then
        return true;
    end
    return false
end
-- 即使是在lua脚本使用require 也会使用xlua的customloader
-- C#CallLua 部分
-- require('Test')
-- LuaCallC# 部分
-- require('Learn1_CallClass')
-- require('Learn2_CallEnum')
-- require('Learn3_CallCollection')
-- require('Learn4_CallExtensionFunc')
-- require('Learn5_CallRefOut')
-- require('Learn6_CallOverloadFunc')
-- require('Learn7_CallDelegateAndEvent')
-- require('Learn8_TwoDimensionalArray')
-- require('Learn9_nullAndnil')
-- require('Learn10_UIAndTdLib')
-- require('Learn11_CallCoroutine')
require('Learn12_CallGeneric')

