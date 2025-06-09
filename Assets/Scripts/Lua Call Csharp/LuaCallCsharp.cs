
using UnityEngine;
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