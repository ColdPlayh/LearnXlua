print("*********XLua调用C# 静态拓展方法***********")
Learn4=CS.Learn4

Learn4.Eat()

local obj=Learn4()
obj:Speak("speak")
--静态拓展方法和成员方法调用方式相同
obj:Move()