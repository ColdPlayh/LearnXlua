
using UnityEngine;
using UnityEngine.UI;



public class Main_Bag : MonoBehaviour
{    void Start()
    {
        LuaMgr.GetInstance().Init();
        LuaMgr.GetInstance().DoLuaFile("Main_Bag");
       
    }
}
