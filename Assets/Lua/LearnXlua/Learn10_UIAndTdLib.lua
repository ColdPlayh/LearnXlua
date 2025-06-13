GameObject = CS.UnityEngine.GameObject

UI = CS.UnityEngine.UI

local slider = GameObject.Find('Slider')
print(slider.name)
local sliderScript = slider:GetComponent(typeof(UI.Slider))
print(sliderScript)
sliderScript.onValueChanged:AddListener(
    function(p)
        print(p)
    end

)
