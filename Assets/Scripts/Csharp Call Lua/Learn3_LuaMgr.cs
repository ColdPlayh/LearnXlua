using UnityEngine;

public class Learn3_LuaMgr : MonoBehaviour {
    void Start()
    {
        LuaMgr.GetInstance().Init();

        LuaMgr.GetInstance().DoLuaFile("Main");
    }
}