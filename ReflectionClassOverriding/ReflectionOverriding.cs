using System;
using System.Reflection;

namespace ReflectionClassOverriding
{
    public class ReflectionOverriding
    {
        /// <summary>
        /// Target interface class that we want ro override it.Default is "Behavior".
        /// .If you have your own interface you need to set the name of interface in this variable.
        /// </summary>
        public string ComponentName = "Behavior";

        Assembly EngineAssmbly;
        int OverridingCount = 0;
        bool Started = false;

        object[] Objects;
        public Type[] AssmblyTyps;
        public Type[] MainRunnTimeAssmblyTyps;

        public ReflectionOverriding(Assembly ProjectAssmbly)
        {
            EngineAssmbly = ProjectAssmbly;
        }

        void Start()
        {
            GetAssmebly();
        }
        void GetAssmebly()
        {
            AssmblyTyps = EngineAssmbly.GetTypes();

            foreach (var item in AssmblyTyps)
            {
                try
                {
                    if (item.GetInterface(ComponentName) != null)
                    {
                        string name = item.GetInterface(ComponentName).Name;

                        if (name != string.Empty)
                        {
                            OverridingCount++;
                        }
                    }

                }
                catch { }
            }

            Objects = new object[OverridingCount];
            MainRunnTimeAssmblyTyps = new Type[OverridingCount];
            int i = 0;

            foreach (var item in AssmblyTyps)
            {
                try
                {
                    Type TargetClass = item.GetInterface(ComponentName);

                    if (TargetClass != null)
                    {
                        string name = TargetClass.Name;

                        if (name != string.Empty)
                        {
                            MainRunnTimeAssmblyTyps[i] = item;
                            Objects[i] = Activator.CreateInstance(item);
                            i++;
                        }
                    }
                }
                catch { }
            }
        }
        void CallMethod (object obj ,Type ty , string methodname)
        {
            ty.GetMethod(methodname, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static).Invoke(obj, null);
        }

        /// <summary>
        /// Calling function of marked classes.
        /// Note:Only can calling functions that the class of the function inherits our target interface.
        /// </summary>
        /// <param name="methodName">Name of the function.</param>
        public void SendMessage(string methodName)
        {
            if (!Started)
            {
                Start();
                Started = true;
            }

            for (int i = 0; i < OverridingCount; i++)
            {
                try
                {
                    CallMethod(Objects[i], MainRunnTimeAssmblyTyps[i], methodName);
                }
                catch { }
            }
        }
    }
}