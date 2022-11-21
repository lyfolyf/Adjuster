using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace 拼接
{
    [Serializable]
    public class ImageStackingUnit
    {

        public ImageStackingUnit() { }

        public ImageStackingUnit(ImageStackingUnit imageStackingUnit)
        {
            keywords.Clear();
            keywords.AddRange(imageStackingUnit.keywords);
            DisplayName = imageStackingUnit.DisplayName;
            Pos = imageStackingUnit.Pos;
            Rotate = imageStackingUnit.Rotate;
        }

        public ImageStackingUnit Clone()
        {
            return new ImageStackingUnit(this);
        }
        private List<string> keywords = new List<string>();
        public string DisplayName { get; set; } = string.Empty;
        public Point Pos { get; set; } = new Point();
        public RotateFlipType Rotate { get; set; } = RotateFlipType.RotateNoneFlipNone;
        [JsonProperty]
        public List<string> Keywords
        {
            get { return keywords; }
            private set { keywords = value; }
        }

        public void AddKeyWord(string key)
        {
            if (!Keywords.Contains(key))
            {
                Keywords.Add(key);
            }
        }

        public void ClearWord()
        {
            Keywords.Clear();
        }

        public bool Matching(string str)
        {
            if (keywords.Count == 0)
                return false;
            bool match = true;
            foreach (var key in Keywords)
            {
                match &= str.Contains(key);
            }
            return match;
        }

        public void RemoveWord(string key)
        {
            if (Keywords.Contains(key))
            {
                Keywords.Remove(key);
            }
        }
    }

    [Serializable]
    public class Rule
    {
        private int hCount;
        [JsonProperty]
        private List<ImageStackingUnit> ImageStacking { get; set; } = new List<ImageStackingUnit>();
        private int vCount;

        public Rule()
        {
        }

        public Rule(Rule rule)
        {
            HCount = rule.hCount;
            VCount = rule.vCount;
            ImageStacking.Clear();
            foreach (var item in rule.ImageStacking)
            {
                ImageStacking.Add(item.Clone());
            }
        }

        public int HCount
        {
            get { return hCount; }
            set
            {
                hCount = value;
                InitList();
            }
        }

        public string Name { get; set; }

        public int VCount
        {
            get { return vCount; }
            set
            {
                vCount = value;
                InitList();
            }
        }
        public void AddKeyWordToAll(string key)
        {
            foreach (var unit in ImageStacking)
            {
                unit.AddKeyWord(key);
            }
        }

        public void RemoveKeyWordToAll(string key)
        {
            foreach (var unit in ImageStacking)
            {
                unit.RemoveWord(key);
            }
        }
        public void AddKeyWord(Point pos, string key)
        {
            if (FindUnit(pos, out ImageStackingUnit unit))
            {
                unit.AddKeyWord(key);
            }
        }

        public void ClearWord(Point pos)
        {
            if (FindUnit(pos, out ImageStackingUnit unit))
            {
                unit.ClearWord();
            }
        }

        public Rule Clone()
        {
            return new Rule(this);
        }

        public string GetDisplayName(Point pos)
        {
            if (FindUnit(pos, out ImageStackingUnit unit))
            {
                return unit.DisplayName;
            }
            return "notfind";
        }

        public RotateFlipType GetRotate(Point pos)
        {
            if (FindUnit(pos, out ImageStackingUnit unit))
            {
                return unit.Rotate;
            }
            return RotateFlipType.RotateNoneFlipNone;
        }

        public bool Matching(string str, out ImageStackingUnit unit)
        {
            bool match = false;
            unit = null;
            foreach (var unit1 in ImageStacking)
            {
                if (unit1.Matching(str))
                {
                    match = true;
                    unit = unit1;
                    break;
                }
            }
            return match;
        }

        public void RemoveKeyWord(Point pos, string key)
        {
            if (FindUnit(pos, out ImageStackingUnit unit))
            {
                unit.RemoveWord(key);
            }
        }

        public void SetDisplayName(Point pos, string displayName)
        {
            if (FindUnit(pos, out ImageStackingUnit unit))
            {
                unit.DisplayName = displayName;
            }
        }

        public void SetRotate(Point pos, RotateFlipType rotate)
        {
            if (FindUnit(pos, out ImageStackingUnit unit))
            {
                unit.Rotate = rotate;
            }
        }
        public void SetRotateToAll(RotateFlipType rotate)
        {
            foreach (var unit in ImageStacking)
            {
                unit.Rotate = rotate;
            }
        }
        public bool FindUnit(Point pos, out ImageStackingUnit unit)
        {
            if (ImageStacking.Count(k => k.Pos == pos) > 0)
            {
                unit = ImageStacking.First(k => k.Pos == pos);
                return true;
            }
            unit = null;
            return false;
        }

        private void InitList()
        {
            for (int x = 0; x < VCount; x++)
            {
                for (int y = 0; y < HCount; y++)
                {
                    Point p = new Point(x + 1, y + 1);
                    if (FindUnit(p, out ImageStackingUnit unit))
                    {
                    }
                    else
                    {
                        ImageStackingUnit stackingUnit = new ImageStackingUnit() { Pos = p, DisplayName = p.ToString() };
                        ImageStacking.Add(stackingUnit);
                    }
                }
            }
        }
    }

    [Serializable]
    public class RuleCollection
    {
        [JsonProperty]
        private Dictionary<string, Rule> Rules { get; set; } = new Dictionary<string, Rule>();
        [JsonIgnore]
        public List<string> RuleNames
        { get { return Rules.Keys.ToList(); } }

        public void ReName(string oldName, string newName)
        {
            if (FindRule(oldName, out Rule rule))
            {
                rule.Name = newName;
                Rules.Remove(oldName);
                Rules.Add(newName, rule);
            }
        }
        public void AddRule(Rule rule)
        {
            if (Rules.ContainsKey(rule.Name))
            {
                Rules[rule.Name] = rule;
            }
            else
            {
                Rules.Add(rule.Name, rule);
            }
        }

        public void AddRule(string ruleName)
        {
            if (!Rules.ContainsKey(ruleName))
            {
                Rules.Add(ruleName, new Rule { Name = ruleName });
            }
        }

        public bool FindRule(string ruleName, out Rule rule)
        {
            bool find = false;
            rule = null;
            if (Rules.ContainsKey(ruleName))
            {
                rule = Rules[ruleName];
                find = true;
            }

            return find;
        }

        public void Remove(string ruleName)
        {
            if (Rules.ContainsKey(ruleName))
            {
                Rules.Remove(ruleName);
            }
        }
    }
}