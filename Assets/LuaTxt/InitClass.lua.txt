require("SplitTools")
Json=require("JsonUtility")
require("Object")

-- Unity Category
GameObject=CS.UnityEngine.GameObject
Resources=CS.UnityEngine.Resources
Transform=CS.UnityEngine.Transfrom
RectTransform=CS.UnityEngine.RectTransfrom
SpriteAtlas=CS.UnityEngine.U2D.SpriteAtlas
Vector3=CS.UnityEngine.Vector3
Vector2=CS.UnityEngine.Vector2
TextAsset=CS.UnityEngine.TextAsset

-- Unity UI Category
UI=CS.UnityEngine.UI
Image=UI.Image
Text=UI.Text;
Button=UI.Button
Toggle=UI.Toggle
ScrollRect=UI.ScrollRect
UIBehaviour=CS.UnityEngine.EventSystems.UIBehaviour
-- 存储Canvas
Canvas=GameObject.Find("Canvas").transform

--my class Category

ABMgr=CS.ABMgr.GetInstance()

