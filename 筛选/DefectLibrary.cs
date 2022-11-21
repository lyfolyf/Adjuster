using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 筛选
{
    [Serializable]
    public class DefectLibrary
    {
        private Dictionary<string, DefectList> dictDefectInfos = new Dictionary<string, DefectList>();
        private List<string> defectTypes = new List<string>();
        public List<string> DefectTypes
        {
            get { return defectTypes; }
            private set
            {
                defectTypes = value;
            }
        }
        public List<DefectInfo> List
        {
            get
            {
                List<DefectInfo> list = new List<DefectInfo>();
                foreach (var item in dictDefectInfos)
                {
                    list.AddRange(item.Value.List);
                }
                return list;
            }
        }

        public void AddDefectType(string type)
        {
            if (!defectTypes.Contains(type))
            {
                defectTypes.Add(type);
                DefectList defectList = new DefectList() { DefectType = type };
                dictDefectInfos.Add(type, defectList);
            }
        }
        public void RemoveDefectType(string type)
        {
            if (defectTypes.Contains(type))
            {
                defectTypes.Remove(type);
                if (dictDefectInfos.ContainsKey(type))
                    dictDefectInfos.Remove(type);
            }
        }
        public DefectList this[string key]
        {
            get
            {
                if (dictDefectInfos.ContainsKey(key))
                {
                    return dictDefectInfos[key];
                }
                else
                    return null;
            }
        }
        public DefectInfo GetDefectInfo(string file)
        {
            var info = (from DefectInfo k in dictDefectInfos where k.ImageFile == file select k).ToList();
            if (info.Count > 0)
            {
                return info[0];
            }
            return new DefectInfo();
        }

        public void AddNew(DefectInfo defectInfo)
        {
            var type = defectInfo.DefectType;
            if (!defectTypes.Contains(type))
            {
                AddDefectType(type);
            }
            dictDefectInfos[type].Add(defectInfo);
        }
        public void AddNew(string type, DefectInfo defectInfo)
        {
            if (!defectTypes.Contains(type))
            {
                AddDefectType(type);
            }
            dictDefectInfos[type].Add(defectInfo);
        }
        public void AddNew(string type, string imageFile, string description = "")
        {
            DefectInfo defectInfo = new DefectInfo() { DefectType = type, ImageFile = imageFile, Description = description };
            AddNew(type, defectInfo);
        }
        public void RemoveAt(DefectInfo defectInfo)
        {
            foreach (var item in dictDefectInfos)
            {
                item.Value.Remove(defectInfo);
            }
        }
        public void RemoveAt(string file)
        {
            foreach (var item in dictDefectInfos)
            {
                item.Value.Remove(file);
            }
        }

        public static DefectLibrary LoadConfig()
        {
            var path = $@"{Environment.CurrentDirectory}\DefectLibrary.dat";
            if (System.IO.File.Exists(path))
                return Serialize.BinaryDeserialize<DefectLibrary>(path);
            else
                return new DefectLibrary();
        }

        public void SaveConfig()
        {
            var path = $@"{Environment.CurrentDirectory}\DefectLibrary.dat";
            Serialize.BinarySerialize(path, this);
        }

        public void SaveTofile(string file)
        {
            using (StreamWriter sw = new StreamWriter(file, false, Encoding.UTF8))
            {
                sw.WriteLine("缺陷类型,注释,图像名称,坐标,图像旋转");
                foreach (var list in dictDefectInfos)
                {
                    foreach (var item in list.Value.List)
                    {
                        sw.WriteLine($"{item.DefectType},{item.Description},{item.ImageFile},X={item.PickPoint.X} Y={item.PickPoint.Y},{item.Rotate}");
                    }
                }
            }
        }
    }
    [Serializable]
    public class DefectList : IEnumerable, IEnumerator
    {
        string defectType = "Dent";
        List<DefectInfo> defectInfos = new List<DefectInfo>();
        public string DefectType
        {
            get { return defectType; }
            set
            {
                defectType = value;
            }
        }
        public int Count { get { return defectInfos.Count; } }
        private int cursor = 0;
        public object Current
        {
            get
            {
                return defectInfos[cursor];
            }
        }

        public List<DefectInfo> List
        {
            get
            {
                return defectInfos;
            }
        }

        public DefectInfo this[int index]
        {
            get
            {
                if (defectInfos == null || defectInfos.Count == 0)
                {
                    throw new Exception("List为Null或者长度为0！");
                }
                if (index < 0 || index >= defectInfos.Count)
                {
                    throw new IndexOutOfRangeException();
                }
                return defectInfos[index];
            }
            set
            {
                if (defectInfos == null || defectInfos.Count == 0)
                {
                    throw new Exception("List为Null或者长度为0！");
                }
                if (index < 0 || index >= defectInfos.Count)
                {
                    throw new IndexOutOfRangeException();
                }
                defectInfos[index] = value;
            }
        }
        public void Add(DefectInfo defectInfo)
        {
            if (!defectInfos.Contains(defectInfo))
            {
                defectInfos.Add(defectInfo);
            }
        }
        public void Remove(DefectInfo defectInfo)
        {
            if (defectInfos.Contains(defectInfo))
            {
                defectInfos.Remove(defectInfo);
            }
        }
        public void Remove(string file)
        {
            defectInfos.RemoveAll(k => k.ImageFile == file);
        }
        public IEnumerator GetEnumerator()
        {
            foreach (var item in defectInfos)
            {
                yield return item;
            }
            yield break;
        }

        public bool MoveNext()
        {
            if (cursor < defectInfos.Count - 1)
            {
                cursor++;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            cursor = 0;
        }
    }
}
