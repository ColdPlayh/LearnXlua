
using System.Collections.Generic;
using UnityEngine;

#region  Learn1
//自定义类
public class Test
{
    public void Speak(string str)
    {
        Debug.Log($"unity's func: {str}");
    }
}
namespace ColdPlay
{

    public class Test2
    {
        public void Speak2(string str)
        {
            Debug.Log($"unity's func: {str}");
        }
    }
}

public class LuaCallCsharp : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Unity's Mono");
    }
}
#endregion

#region  Learn2

public enum E_MyEnum
{
    Idle,
    Move,
    Atk,
}

#endregion

#region  Learn3

public class Learn3
{
    public int[] array = { 1,2,3,4,5};
    public List<int> list = new List<int>();

    public Dictionary<int, string> dic = new Dictionary<int, string>();

}

#endregion