using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IMatching
{
    Image TrainImage { get; set; }
    string Name { get; }
    void CreateModel();
    void FindModel(Image image, out double x, out double y, out double angle);
    void Reset();
}