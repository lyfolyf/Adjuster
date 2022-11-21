using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bing.Viewer;

namespace 拼接
{
    [Serializable]
    public class RoiStorage : IList<System.Drawing.RectangleF>
    {
        List<System.Drawing.RectangleF> rects = new List<System.Drawing.RectangleF>();
        public static RoiStorage LoadConfig(string path)
        {
            //var path = $@"{Environment.CurrentDirectory}\SysConfig.cfg";
            if (System.IO.File.Exists(path))
                return Serialize.JsonDeserializeObject<RoiStorage>(path);
            else
                return default(RoiStorage);
        }

        public void SaveConfig(string path)
        {
            //var path = $@"{Environment.CurrentDirectory}\SysConfig.cfg";
            Serialize.JsonSerialize(path, this);
        }
        public System.Drawing.RectangleF this[int index]
        {
            get
            {
                return rects[index];
            }

            set
            {
                rects[index] = value;
            }
        }

        public int Count
        {
            get
            {
                return rects.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void Add(System.Drawing.RectangleF item)
        {
            rects.Add(item);
        }

        public void Clear()
        {
            rects.Clear();
        }

        public bool Contains(System.Drawing.RectangleF item)
        {
            return rects.Contains(item);
        }

        public void CopyTo(System.Drawing.RectangleF[] array, int arrayIndex)
        {
            rects.CopyTo(array, arrayIndex);
        }

        public IEnumerator<System.Drawing.RectangleF> GetEnumerator()
        {
            return rects.GetEnumerator();
        }

        public int IndexOf(System.Drawing.RectangleF item)
        {
            return rects.IndexOf(item);
        }

        public void Insert(int index, System.Drawing.RectangleF item)
        {
            rects.Insert(index, item);
        }

        public bool Remove(System.Drawing.RectangleF item)
        {
            return rects.Remove(item);
        }

        public void RemoveAt(int index)
        {
            rects.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return rects.GetEnumerator();
        }
    }
}
