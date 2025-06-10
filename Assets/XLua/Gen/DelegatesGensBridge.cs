#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using System;


namespace XLua
{
    public partial class DelegateBridge : DelegateBridgeBase
    {
		
		public int __Gen_Delegate_Imp0(int p0)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                
                LuaAPI.xlua_pushinteger(L, p0);
                
                PCall(L, 1, 1, errFunc);
                
                
                int __gen_ret = LuaAPI.xlua_tointeger(L, errFunc + 1);
                LuaAPI.lua_settop(L, errFunc - 1);
                return  __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public int __Gen_Delegate_Imp1(int p0, out int p1, out bool p2, out string p3, out int p4)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                
                LuaAPI.xlua_pushinteger(L, p0);
                
                PCall(L, 1, 5, errFunc);
                
                p1 = LuaAPI.xlua_tointeger(L, errFunc + 2);
                p2 = LuaAPI.lua_toboolean(L, errFunc + 3);
                p3 = LuaAPI.lua_tostring(L, errFunc + 4);
                p4 = LuaAPI.xlua_tointeger(L, errFunc + 5);
                
                int __gen_ret = LuaAPI.xlua_tointeger(L, errFunc + 1);
                LuaAPI.lua_settop(L, errFunc - 1);
                return  __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public int __Gen_Delegate_Imp2(int p0, ref int p1, ref bool p2, ref string p3, ref int p4)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                
                LuaAPI.xlua_pushinteger(L, p0);
                LuaAPI.xlua_pushinteger(L, p1);
                LuaAPI.lua_pushboolean(L, p2);
                LuaAPI.lua_pushstring(L, p3);
                LuaAPI.xlua_pushinteger(L, p4);
                
                PCall(L, 5, 5, errFunc);
                
                p1 = LuaAPI.xlua_tointeger(L, errFunc + 2);
                p2 = LuaAPI.lua_toboolean(L, errFunc + 3);
                p3 = LuaAPI.lua_tostring(L, errFunc + 4);
                p4 = LuaAPI.xlua_tointeger(L, errFunc + 5);
                
                int __gen_ret = LuaAPI.xlua_tointeger(L, errFunc + 1);
                LuaAPI.lua_settop(L, errFunc - 1);
                return  __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp3(float p0)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                
                LuaAPI.lua_pushnumber(L, p0);
                
                PCall(L, 1, 0, errFunc);
                
                
                
                LuaAPI.lua_settop(L, errFunc - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
        
		static DelegateBridge()
		{
		    Gen_Flag = true;
		}
		
		public override Delegate GetDelegateByType(Type type)
		{
		
		    if (type == typeof(CustomCall2))
			{
			    return new CustomCall2(__Gen_Delegate_Imp0);
			}
		
		    if (type == typeof(CustomCall3))
			{
			    return new CustomCall3(__Gen_Delegate_Imp1);
			}
		
		    if (type == typeof(CustomCall4))
			{
			    return new CustomCall4(__Gen_Delegate_Imp2);
			}
		
		    if (type == typeof(UnityEngine.Events.UnityAction<float>))
			{
			    return new UnityEngine.Events.UnityAction<float>(__Gen_Delegate_Imp3);
			}
		
		    return null;
		}
	}
    
}