using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace 拼接
{
    public static class Serialize
    {
        /// <summary>
        /// Xml序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filename"></param>
        /// <param name="obj"></param>
        public static void XmlSerialize<T>(string filename, T obj)
        {

            try
            {
                if (System.IO.File.Exists(filename))
                    System.IO.File.Delete(filename);
                using (FileStream fileStream = new FileStream(filename, FileMode.Create))
                {
                    // 序列化为xml
                    XmlSerializer formatter = new XmlSerializer(typeof(T));
                    formatter.Serialize(fileStream, obj);
                    fileStream.Close();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
        /// <summary>
        /// Xml序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stream"></param>
        /// <param name="obj"></param>
        public static void XmlSerialize<T>(Stream stream, T obj)
        {

            try
            {
                using (stream)
                {
                    // 序列化为xml
                    XmlSerializer formatter = new XmlSerializer(typeof(T));
                    formatter.Serialize(stream, obj);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
        /// <summary>
        /// Xml反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static T XmlDeserailize<T>(string filename)
        {
            T obj;
            if (!System.IO.File.Exists(filename))
                throw new Exception("对反序列化之前,请先序列化");
            //Xml格式反序列化
            using (Stream stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(T));
                obj = (T)formatter.Deserialize(stream);
                stream.Close();
            }
            return obj;
        }
        /// <summary>
        /// Xml反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static T XmlDeserailize<T>(Stream stream)
        {
            using (stream)
            {
                T obj;
                XmlSerializer formatter = new XmlSerializer(typeof(T));
                obj = (T)formatter.Deserialize(stream);
                return obj;
            }
        }
        /// <summary>
        /// 二进制序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filename"></param>
        /// <param name="obj"></param>
        public static void BinarySerialize<T>(string filename, T obj)
        {
            try
            {
                //string filename = objname + ".ump";
                if (System.IO.File.Exists(filename))
                    System.IO.File.Delete(filename);
                using (FileStream fileStream = new FileStream(filename, FileMode.Create))
                {
                    // 用二进制格式序列化
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    binaryFormatter.Serialize(fileStream, obj);
                    fileStream.Close();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 二进制序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stream"></param>
        /// <param name="obj"></param>
        public static void BinarySerialize<T>(Stream stream, T obj)
        {
            try
            {
                // 用二进制格式序列化
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(stream, obj);
                stream.Close();
                stream.Dispose();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
        public static byte[] ObjectToBytes(object obj)
        {
            byte[] buff;
            using (MemoryStream ms = new MemoryStream())
            {
                IFormatter iFormatter = new BinaryFormatter();
                iFormatter.Serialize(ms, obj);
                buff = ms.GetBuffer();
            }
            return buff;
        }
        /// <summary>
        /// 二进制反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static T BinaryDeserialize<T>(string filename)
        {
            System.Runtime.Serialization.IFormatter formatter = new BinaryFormatter();
            //二进制格式反序列化
            T obj;
            if (!System.IO.File.Exists(filename))
                throw new Exception("在反序列化之前,请先序列化");
            using (Stream stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                obj = (T)formatter.Deserialize(stream);
                stream.Close();
            }
            return obj;

        }
        public static T DeepClone<T>(T raw)
        {
            T obj;
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(stream, raw);
                stream.Position = 0;
                obj = (T)binaryFormatter.Deserialize(stream);
                stream.Close();
            }
            return obj;
        }

        /// <summary>
        /// 二进制反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static T BinaryDeserialize<T>(Stream stream)
        {
            System.Runtime.Serialization.IFormatter formatter = new BinaryFormatter();
            //二进制格式反序列化
            T obj;
            obj = (T)formatter.Deserialize(stream);
            stream.Close();
            stream.Dispose();
            return obj;

        }

        public static string JsonSerialize<T>(T obj)
        {
            JsonSerializerSettings myJsonSerializerSettings = new JsonSerializerSettings();
            myJsonSerializerSettings.TypeNameHandling = TypeNameHandling.None;
            var resultJson = JsonConvert.SerializeObject(obj, Formatting.Indented, myJsonSerializerSettings);
            return resultJson;
        }
        public static string JsonSerialize<T>(string path, T obj)
        {
            JsonSerializerSettings myJsonSerializerSettings = new JsonSerializerSettings();
            myJsonSerializerSettings.TypeNameHandling = TypeNameHandling.None;
             //myJsonSerializerSettings.ContractResolver = new MyContractResolver();
            var resultJson = JsonConvert.SerializeObject(obj, Formatting.Indented, myJsonSerializerSettings);
            using (StreamWriter sw = new StreamWriter(path, false))
            {
                sw.Write(resultJson);
            }
            return resultJson;
        }
        public static T JsonDeserializeObject<T>(string jsonContent, bool isFile = true)
        {
            T obj;
            try
            {
                JsonSerializerSettings myJsonSerializerSettings = new JsonSerializerSettings();
                myJsonSerializerSettings.TypeNameHandling = TypeNameHandling.None;
                //myJsonSerializerSettings.ContractResolver = new MyContractResolver();
                //myJsonSerializerSettings.DefaultValueHandling=DefaultValueHandling.
                if (isFile)
                {
                    obj = JsonConvert.DeserializeObject<T>(File.ReadAllText(jsonContent), myJsonSerializerSettings);
                }
                else
                    obj = JsonConvert.DeserializeObject<T>(jsonContent, myJsonSerializerSettings);
                return obj;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        //public static T JsonDeserializeObject<T>(string jsonString)
        //{
        //    T obj;
        //    try
        //    {
        //        JsonSerializerSettings myJsonSerializerSettings = new JsonSerializerSettings();
        //        myJsonSerializerSettings.TypeNameHandling = TypeNameHandling.None;
        //        obj = JsonConvert.DeserializeObject<T>(jsonString, myJsonSerializerSettings);
        //        return obj;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}
    }

    public class MyContractResolver : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var props = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                            .Select(p => base.CreateProperty(p, memberSerialization))
                        .Union(type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                                   .Select(f => base.CreateProperty(f, memberSerialization)))
                        .ToList();
            props.ForEach(p => { p.Writable = true; p.Readable = true; });
            return props;
        }
    }
}
