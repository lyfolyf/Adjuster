using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Adjuster.Tools
{
    public static class AsmLoader
    {
        /// <summary>
        /// 从文件实例化对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static T GetInstance<T>(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException($"文件{fileName}未找到！");
            }
            Assembly asm;
            T instance = default(T);
            try
            {
                //先将插件拷贝到内存缓冲
                byte[] addinStream = System.IO.File.ReadAllBytes(fileName);
                asm = Assembly.Load(addinStream);
            }
            catch
            {
                return default(T);
            }
            Type[] myType = asm.GetTypes();
            for (int i = 0; i < myType.Length; i++)
            {
                if (typeof(T).IsAssignableFrom(myType[i]))
                {
                    if (myType[i].IsAbstract)
                    { return default(T); }
                    instance = (T)Activator.CreateInstance(myType[i]);
                    break;
                }
            }
            return instance;
        }
        public static void LoadDlls<T>(string path, Action<T, Type, string> action)
        {
            string[] dlls = Directory.GetFiles(path, "*.dll");
            foreach (string item in dlls)
            {
                //加载程序集
                Assembly asm;
                try
                {
                    //先将插件拷贝到内存缓冲
                    byte[] addinStream = System.IO.File.ReadAllBytes(item);
                    asm = Assembly.Load(addinStream);
                }
                catch (Exception ex)
                {
                    continue;
                }

                //开始得到类型
                Type[] myType = asm.GetTypes();
                //遍历type数组，找到实现接口的非抽象类
                for (int i = 0; i < myType.Length; i++)
                {
                    if (typeof(T).IsAssignableFrom(myType[i]))
                    {
                        if (myType[i].IsAbstract)
                        { return; }

                        //创建对象
                        T instance = (T)Activator.CreateInstance(myType[i]);
                        action(instance, myType[i], item);
                    }
                }
            }
        }

        public static List<Type> LoadPlugs<T>(string path)
        {
            List<Type> plugsList = new List<Type>();
            string[] dlls = Directory.GetFiles(path, "*.dll");
            foreach (string item in dlls)
            {
                //加载程序集
                Assembly asm;
                try
                {
                    //先将插件拷贝到内存缓冲
                    byte[] addinStream = System.IO.File.ReadAllBytes(item);
                    asm = Assembly.Load(addinStream);
                }
                catch (Exception ex)
                {
                    continue;
                }

                //开始得到类型
                Type[] myType = asm.GetTypes();
                //遍历type数组，找到实现接口的非抽象类
                for (int i = 0; i < myType.Length; i++)
                {
                    if (typeof(T).IsAssignableFrom(myType[i]))
                    {
                        if (myType[i].IsAbstract)
                        { continue; }

                        //创建对象
                        //T instance = (T)Activator.CreateInstance(myType[i]);
                        plugsList.Add(myType[i]);
                    }
                }
            }

            return plugsList;
        }

        public static T CreateInstance<T>(Type type)
        {
            T instance = (T)Activator.CreateInstance(type);
            return instance;
        }
    }


}