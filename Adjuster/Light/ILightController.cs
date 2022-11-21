using Adjuster.Tools;

namespace Adjuster
{
    public interface ILightController : ILog
    {
        string Name { get; set; }
        bool Connect();
        bool Disconnect();
        bool TurnOff();
        bool TurnOn();
        bool SetIntensity(int channel, int value);
        int ReadIntensity(int channel);
        bool TurnOnChannel(int channel);
        bool TurnOffChannel(int channel);
        bool TurnOnMultiChannel(int channelNum, int[] chs);
        bool TurnOffMultiChannel(int channelNum, int[] chs);
        bool SetMultiIntensity(int[] channels, int[] intensitys);
        int[] ReadMultiIntensity(int[] channels);
        bool ApplyConfig(ILightConfig config);
        bool Connected { get; }
    }
}
