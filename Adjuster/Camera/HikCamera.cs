using MvCamCtrl.NET;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Adjuster.Camera
{
    internal class HikCamera
    {
        public HikCamera()
        {

        }
        public event Action DataBack;
        public event Action<double> DataTranslation;
        public event ImageTookEventHandler ImageTook;
        private MyCamera.cbOutputdelegate ImageCallback;
        public MyCamera.cbOutputExdelegate ImageCallbackEx;

        private MyCamera camera = new MyCamera();

        static MyCamera.MV_CC_DEVICE_INFO_LIST deviceList = new MyCamera.MV_CC_DEVICE_INFO_LIST();
        static Dictionary<CameraInfo, MyCamera.MV_CC_DEVICE_INFO> dicDevice = new Dictionary<CameraInfo, MyCamera.MV_CC_DEVICE_INFO>();

        private TriggerModeConstants triggerMode = TriggerModeConstants.Software;
        Queue<FrameEx> qFrames = new Queue<FrameEx>();

        //Queue<FrameEx> qFramesEx = new Queue<FrameEx>();
        private string _sn = "00234736208";

        object synLock = new object();
        object synLock2 = new object();
        private bool isGrey;
        // 彩色相机的时候才有用
        uint m_ImageBufSize = 0;
        IntPtr m_ImageBuf = IntPtr.Zero;
        bool g_IsNeedCalib = true;
        IntPtr g_pCalibBuf = IntPtr.Zero;
        IntPtr g_pDstData = IntPtr.Zero;
        uint g_nCalibBufSize = 0;
        uint g_nDstDataSize = 0;
        bool useLsc = false;
        string lscFile = string.Empty;
        bool closing = false;
        private bool allowClosing;

        private Stopwatch sw = new Stopwatch();


        private double elapsed = 0;
        /// <summary>
        /// 耗时
        /// </summary>
        public double Elapsed
        {
            get
            {
                return elapsed;
            }
        }

        public TriggerModeConstants TriggerMode
        {
            get
            {
                MyCamera.MVCC_ENUMVALUE mode = new MyCamera.MVCC_ENUMVALUE();
                camera.MV_CC_GetEnumValue_NET("TriggerMode", ref mode);

                MyCamera.MVCC_ENUMVALUE source = new MyCamera.MVCC_ENUMVALUE();
                camera.MV_CC_GetEnumValue_NET("TriggerSource", ref source);

                if (mode.nCurValue == 0 && source.nCurValue == 7)
                {
                    triggerMode = TriggerModeConstants.Off;
                }
                if (mode.nCurValue == 1 && source.nCurValue == 0)
                {
                    triggerMode = TriggerModeConstants.Extern;
                }
                if (mode.nCurValue == 1 && source.nCurValue == 7)
                {
                    triggerMode = TriggerModeConstants.Software;
                }
                return triggerMode;
            }
            set
            {
                triggerMode = value;
                switch (value)
                {
                    case TriggerModeConstants.Extern:
                        camera.MV_CC_SetEnumValue_NET("TriggerMode", 1);
                        // ch:触发源设为软触发 | en:Set trigger source as Software
                        //camera.MV_CC_SetEnumValue_NET("TriggerSource", 0);
                        // ch:触发源选择:0 - Line0; | en:Trigger source select:0 - Line0;
                        //           1 - Line1;
                        //           2 - Line2;
                        //           3 - Line3;
                        //           4 - Counter;
                        //           7 - Software;
                        camera.MV_CC_SetEnumValue_NET("TriggerSource", 0);
                        break;
                    case TriggerModeConstants.Software:
                        camera.MV_CC_SetEnumValue_NET("TriggerMode", 1);
                        camera.MV_CC_SetEnumValue_NET("TriggerSource", 7);
                        break;
                    case TriggerModeConstants.Off:
                        camera.MV_CC_SetEnumValue_NET("TriggerMode", 0);
                        camera.MV_CC_SetEnumValue_NET("TriggerSource", 7);
                        break;
                }
            }
        }


        public uint RatioR
        {
            get
            {
                MyCamera.MVCC_INTVALUE stParam = new MyCamera.MVCC_INTVALUE();
                int nRet = camera.MV_CC_GetBalanceRatioRed_NET(ref stParam);
                if (MyCamera.MV_OK == nRet)
                {
                    return stParam.nCurValue;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                int nRet = camera.MV_CC_SetBalanceRatioRed_NET(value);
            }
        }

        public uint RatioG
        {
            get
            {
                MyCamera.MVCC_INTVALUE stParam = new MyCamera.MVCC_INTVALUE();
                int nRet = camera.MV_CC_GetBalanceRatioGreen_NET(ref stParam);
                if (MyCamera.MV_OK == nRet)
                {
                    return stParam.nCurValue;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                int nRet = camera.MV_CC_SetBalanceRatioGreen_NET(value);
            }
        }

        public uint RatioB
        {
            get
            {
                MyCamera.MVCC_INTVALUE stParam = new MyCamera.MVCC_INTVALUE();
                int nRet = camera.MV_CC_GetBalanceRatioBlue_NET(ref stParam);
                if (MyCamera.MV_OK == nRet)
                {
                    return stParam.nCurValue;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                int nRet = camera.MV_CC_SetBalanceRatioBlue_NET(value);
            }
        }
        public double Exposure
        {
            get
            {
                MyCamera.MVCC_FLOATVALUE stParam = new MyCamera.MVCC_FLOATVALUE();
                int nRet = camera.MV_CC_GetFloatValue_NET("ExposureTime", ref stParam);
                if (MyCamera.MV_OK == nRet)
                {
                    return stParam.fCurValue;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                camera.MV_CC_SetEnumValue_NET("ExposureAuto", 0);
                int nRet = camera.MV_CC_SetFloatValue_NET("ExposureTime", (float)value);
                if (nRet != MyCamera.MV_OK)
                {

                }
            }
        }
        public double Gain
        {
            get
            {
                MyCamera.MVCC_FLOATVALUE stParam = new MyCamera.MVCC_FLOATVALUE();
                int nRet = camera.MV_CC_GetFloatValue_NET("Gain", ref stParam);
                if (MyCamera.MV_OK == nRet)
                {
                    return stParam.fCurValue;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                camera.MV_CC_SetEnumValue_NET("GainAuto", 0);
                int nRet = camera.MV_CC_SetFloatValue_NET("Gain", (float)value);
                if (nRet != MyCamera.MV_OK)
                {

                }
            }
        }

        public string SN
        {
            get { return _sn; }
            set
            {
                _sn = value;
                Create();
            }
        }

        public string Description { get; set; }
        public int Id { get; set; }
        public bool BGrabbing { get; set; } = false;

        public string Model { get; set; }

        public float FrameRate
        {
            get
            {
                MyCamera.MVCC_FLOATVALUE stParam = new MyCamera.MVCC_FLOATVALUE();
                camera.MV_CC_GetFloatValue_NET("ResultingFrameRate", ref stParam);
                return stParam.fCurValue;
            }
        }

        public bool Accessible { get; set; } = false;

        public string CameraName { get; set; } = "CCD1";
        /// <summary>
        ///设置/读取自动白平衡， 0: Off 2: Once 1: Continuous
        /// </summary>
        public uint BalanceWhiteAuto
        {
            set
            {
                if (value > 2)
                    return;
                camera.MV_CC_SetBalanceWhiteAuto_NET(value);
            }
            get
            {
                MyCamera.MVCC_ENUMVALUE stParam = new MyCamera.MVCC_ENUMVALUE();
                int nRet = camera.MV_CC_GetBalanceWhiteAuto_NET(ref stParam);
                if (MyCamera.MV_OK == nRet)
                {
                    return stParam.nCurValue;
                }
                else
                {
                    return 0;
                }
            }
        }

        public bool IsNeedLSCCalib
        {
            get { return g_IsNeedCalib; }
            set
            {
                g_IsNeedCalib = value;
            }
        }

        public bool UseLsc
        {
            get { return useLsc; }
            set
            {
                useLsc = value;
            }
        }

        public void RunBalanceWhiteAuto()
        {
            BalanceWhiteAuto = 2;
            TriggerOnce();
            BalanceWhiteAuto = 0;
        }
        public bool TriggerOnce()
        {
            sw.Restart();
            if (TriggerMode != TriggerModeConstants.Software)
            {
                camera.MV_CC_SetEnumValue_NET("TriggerMode", 1);
                camera.MV_CC_SetEnumValue_NET("TriggerSource", 7);
            }

            int nRet;
            //ch: 触发命令 | en:Trigger command
            nRet = camera.MV_CC_SetCommandValue_NET("TriggerSoftware");
            if (TriggerMode != TriggerModeConstants.Software)
            {
                TriggerMode = triggerMode;
            }
            if (MyCamera.MV_OK == nRet)
            {
                return true;
            }
            return false;
        }

        private void FrameMonitor()
        {
            while (!closing)
            {
                if (FrameCount() > 0)
                {
                    FrameEx frame = TakeFrame();

                    Bitmap image = null;
                    try
                    {
                        Stopwatch sw = new Stopwatch();
                        sw.Start();
                        image = GetImageEx(frame.Data, frame.FrameInfo);
                        sw.Stop();
                        DataTranslation?.Invoke(sw.ElapsedMilliseconds);
                    }
                    catch { }
                    // Convert frame into displayable image

                    if (null != image)
                    {
                        OnImageTook(new ImageTookEventArgs { CameraName = this.CameraName, Image = image, Success = true });
                    }
                    else
                    {
                        OnImageTook(new ImageTookEventArgs { CameraName = this.CameraName, Image = null, Success = false });
                    }

                    //Thread.Sleep(15);
                    //frame.Dispose();
                }
                else { Thread.Sleep(15); }
                if (closing)
                {
                    allowClosing = true;
                }
            }
        }
        private void PushFrame(FrameEx frame)
        {
            lock (synLock2)
            {
                qFrames.Enqueue(frame);
            }
        }

        private FrameEx TakeFrame()
        {
            lock (synLock2)
            {
                return qFrames.Dequeue();
            }
        }

        private int FrameCount()
        {
            lock (synLock2)
            {
                return qFrames.Count;
            }
        }

        private void OnImageTook(ImageTookEventArgs e)
        {
            ImageTook?.Invoke(this, e);
        }
        public T DeepCopyByBin<T>(T obj)
        {
            object retval;
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                //序列化成流
                bf.Serialize(ms, obj);
                ms.Seek(0, SeekOrigin.Begin);
                //反序列化成对象
                retval = bf.Deserialize(ms);
                ms.Close();
            }
            return (T)retval;
        }

        ~HikCamera()
        {
            if (BGrabbing)
                camera.MV_CC_StopGrabbing_NET();
            Close();
        }

        private bool Create()
        {
            if (dicDevice.Count == 0)
            {
                return false;
            }

            if (dicDevice.Count(k => k.Key.SN == SN) == 0)
            {
                return false;
            }
            var info = dicDevice.First(k => k.Key.SN == SN);
            MyCamera.MV_CC_DEVICE_INFO device = info.Value;
            //判断指定的设备是否可以访问
            uint nAccessMode = MyCamera.MV_ACCESS_Exclusive;
            bool accessible = MyCamera.MV_CC_IsDeviceAccessible_NET(ref device, nAccessMode);
            this.Accessible = accessible;
            if (Accessible)
            {
                Model = info.Key.Model;
                CameraName = info.Key.UserDefinedName;
                camera = new MyCamera();
                var nRet = camera.MV_CC_CreateDevice_NET(ref device);
                return nRet == 0;
            }
            return false;
        }

        public static List<CameraInfo> DeviceList()
        {
            List<CameraInfo> cameraInfoList = new List<CameraInfo>();
            dicDevice = new Dictionary<CameraInfo, MyCamera.MV_CC_DEVICE_INFO>();
            int nRet;
            // ch:创建设备列表 en:Create Device List
            nRet = MyCamera.MV_CC_EnumDevices_NET(MyCamera.MV_GIGE_DEVICE | MyCamera.MV_USB_DEVICE, ref deviceList);
            if (0 != nRet)
            {
                //ShowErrorMsg("Enumerate devices fail!", 0);
                return cameraInfoList;
            }

            // ch:在窗体列表中显示设备名 | en:Display device name in the form list
            for (int i = 0; i < deviceList.nDeviceNum; i++)
            {
                MyCamera.MV_CC_DEVICE_INFO device = (MyCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(deviceList.pDeviceInfo[i], typeof(MyCamera.MV_CC_DEVICE_INFO));

                CameraInfo cameraInfo = new CameraInfo();

                if (device.nTLayerType == MyCamera.MV_GIGE_DEVICE)
                {
                    IntPtr buffer = Marshal.UnsafeAddrOfPinnedArrayElement(device.SpecialInfo.stGigEInfo, 0);
                    MyCamera.MV_GIGE_DEVICE_INFO gigeInfo = (MyCamera.MV_GIGE_DEVICE_INFO)Marshal.PtrToStructure(buffer, typeof(MyCamera.MV_GIGE_DEVICE_INFO));
                    cameraInfo.SN = gigeInfo.chSerialNumber;
                    cameraInfo.UserDefinedName = gigeInfo.chUserDefinedName;
                    cameraInfo.Model = gigeInfo.chModelName;

                }
                else if (device.nTLayerType == MyCamera.MV_USB_DEVICE)
                {
                    IntPtr buffer = Marshal.UnsafeAddrOfPinnedArrayElement(device.SpecialInfo.stUsb3VInfo, 0);
                    MyCamera.MV_USB3_DEVICE_INFO usbInfo = (MyCamera.MV_USB3_DEVICE_INFO)Marshal.PtrToStructure(buffer, typeof(MyCamera.MV_USB3_DEVICE_INFO));
                    cameraInfo.SN = usbInfo.chSerialNumber;
                    cameraInfo.UserDefinedName = usbInfo.chUserDefinedName;
                    cameraInfo.Model = usbInfo.chModelName;

                }

                if (!dicDevice.ContainsKey(cameraInfo))
                {
                    dicDevice.Add(cameraInfo, device);
                }

                cameraInfoList.Add(cameraInfo);
            }
            return cameraInfoList;
        }

        public bool Open()
        {
            if (!Create())
            {
                return false;
            }
            //打开相机
            int nRet = camera.MV_CC_OpenDevice_NET();
            if (MyCamera.MV_OK != nRet)
            {
                camera.MV_CC_DestroyDevice_NET();
                System.Windows.Forms.MessageBox.Show($"Device open fail!, [{nRet}]");
                return false;
            }

            //设置连续触发
            nRet = camera.MV_CC_SetEnumValue_NET("AcquisitionMode", 2);//0:SingleFrame 
            //1:MultiFrame
            //2:Continuous

            if (MyCamera.MV_OK != nRet)
            {
                System.Windows.Forms.MessageBox.Show($"AcquisitionMode Continuous  failed!, [{nRet}]");
                return false;
            }
            //cbOutputExdelegate
            //注册回调函数
            //ImageCallback = new MyCamera.cbOutputdelegate(ImageCallbackFunc);
            //nRet = camera.MV_CC_RegisterImageCallBack_NET(ImageCallback, IntPtr.Zero);

            lscFile = $@"{SN}.lsc";
            NeedLscCalib();
            ImageCallbackEx = new MyCamera.cbOutputExdelegate(ImageCallbackFuncEx);
            nRet = camera.MV_CC_RegisterImageCallBackEx_NET(ImageCallbackEx, IntPtr.Zero);
            if (MyCamera.MV_OK != nRet)
            {
                System.Windows.Forms.MessageBox.Show($"Register image callback failed!, [{nRet}]");
                return false;
            }
            TriggerMode = TriggerModeConstants.Software;
            //
            //开始抓图
            nRet = camera.MV_CC_StartGrabbing_NET();
            if (MyCamera.MV_OK != nRet)
            {
                camera.MV_CC_DestroyDevice_NET();
                System.Windows.Forms.MessageBox.Show($"Trigger Fail!, [{nRet}]");
                return false;
            }
            closing = false;
            allowClosing = false;
            Thread thread = new Thread(FrameMonitor) { IsBackground = true };
            thread.Start();
            BGrabbing = true;
            return true;
        }
        public bool Close()
        {
            closing = true;
            while (!allowClosing)
            {
                Thread.Sleep(10);
            }
            try
            {
                int nRet = camera.MV_CC_StopGrabbing_NET();
                if (MyCamera.MV_OK != nRet)
                {
                    // System.Windows.Forms.MessageBox.Show($@"Stop Device [ SN={SN} ] Fail！ [ErrorCode={nRet}]");
                    return false;
                }
                BGrabbing = false;
                nRet = camera.MV_CC_CloseDevice_NET();
                if (MyCamera.MV_OK != nRet)
                {
                    // System.Windows.Forms.MessageBox.Show($@"Close Device [ SN={SN} ] Fail！ [ErrorCode={nRet}]");
                    return false;
                }
                //nRet = camera.MV_CC_DestroyDevice_NET();
                return true;
            }
            catch { return true; }
        }
        private void ImageCallbackFunc(IntPtr pData, ref MyCamera.MV_FRAME_OUT_INFO pFrameInfo, IntPtr pUser)
        {
            MyCamera.MV_FRAME_OUT_INFO cFrameInfo = pFrameInfo;
            //Frame frame = new Frame(pData, cFrameInfo);
            //PushFrame(frame);
        }
        private void ImageCallbackFuncEx(IntPtr pData, ref MyCamera.MV_FRAME_OUT_INFO_EX pFrameInfo, IntPtr pUser)
        {

            MyCamera.MV_FRAME_OUT_INFO_EX cFrameInfo = pFrameInfo;
            FrameEx frame = new FrameEx(pData, cFrameInfo);
            PushFrame(frame);
            sw.Stop();
            elapsed = sw.ElapsedMilliseconds;
            DataBack?.Invoke();
        }

        private Bitmap GetImage(IntPtr pData, MyCamera.MV_FRAME_OUT_INFO stFrameInfo)
        {
            isGrey = IsMonoData(stFrameInfo.enPixelType);

            IntPtr imageBuf = pData;
            if (isGrey)
            {
            }
            else
            {
                int len = stFrameInfo.nWidth * stFrameInfo.nHeight * 3;
                if (m_ImageBufSize != len)
                {
                    m_ImageBufSize = (uint)len;
                    if (m_ImageBuf != IntPtr.Zero)
                    {
                        Marshal.Release(m_ImageBuf);
                        m_ImageBuf = IntPtr.Zero;
                    }
                }

                if (m_ImageBuf == IntPtr.Zero)
                {
                    m_ImageBuf = Marshal.AllocHGlobal((int)m_ImageBufSize);
                }

                // 像素类型转换
                MyCamera.MV_PIXEL_CONVERT_PARAM stConverPixelParam = new MyCamera.MV_PIXEL_CONVERT_PARAM
                {
                    nWidth = stFrameInfo.nWidth,
                    nHeight = stFrameInfo.nHeight,
                    pSrcData = pData,
                    nSrcDataLen = stFrameInfo.nFrameLen,
                    enSrcPixelType = stFrameInfo.enPixelType,
                    enDstPixelType = isGrey ? MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono8 : MyCamera.MvGvspPixelType.PixelType_Gvsp_BGR8_Packed,
                    pDstBuffer = m_ImageBuf,
                    nDstBufferSize = m_ImageBufSize
                };

                int nRet = camera.MV_CC_ConvertPixelType_NET(ref stConverPixelParam);
                if (MyCamera.MV_OK == nRet)
                {
                    m_ImageBufSize = stConverPixelParam.nDstLen;
                }
                else
                {

                }
            }
            imageBuf = m_ImageBuf;

            Bitmap bitmap = new Bitmap(stFrameInfo.nWidth, stFrameInfo.nHeight, isGrey ? PixelFormat.Format8bppIndexed : PixelFormat.Format24bppRgb);
            if (isGrey)
            {
                ColorPalette cp = bitmap.Palette;
                for (int i = 0; i < 256; i++)
                {
                    cp.Entries[i] = Color.FromArgb(i, i, i);
                }
                bitmap.Palette = cp;
            }
            BitmapData bmpData = null;
            try
            {
                bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
                byte[] buffer = new byte[bmpData.Stride * bitmap.Height];
                Marshal.Copy(imageBuf, buffer, 0, bmpData.Stride * bitmap.Height);
                Marshal.Copy(buffer, 0, bmpData.Scan0, bmpData.Stride * bitmap.Height);
            }
            finally
            {
                bitmap.UnlockBits(bmpData);
            }
            return bitmap;
        }

        private Bitmap GetImageEx(IntPtr pData, MyCamera.MV_FRAME_OUT_INFO_EX pFrameInfo)
        {
            int nRet = MyCamera.MV_OK;
            //是否启用LSC矫正
            if (useLsc)
            {
                //判断是否需要标定
                if (true == IsNeedLSCCalib)
                {
                    //LSC标定
                    MyCamera.MV_CC_LSC_CALIB_PARAM stLSCCalib = new MyCamera.MV_CC_LSC_CALIB_PARAM();
                    stLSCCalib.nWidth = pFrameInfo.nWidth;
                    stLSCCalib.nHeight = pFrameInfo.nHeight;
                    stLSCCalib.enPixelType = pFrameInfo.enPixelType;
                    stLSCCalib.pSrcBuf = pData;
                    stLSCCalib.nSrcBufLen = pFrameInfo.nFrameLen;

                    if (g_pCalibBuf == IntPtr.Zero || g_nCalibBufSize < pFrameInfo.nWidth * pFrameInfo.nHeight * 2)
                    {
                        if (g_pCalibBuf != IntPtr.Zero)
                        {
                            Marshal.FreeHGlobal(g_pCalibBuf);
                            g_pCalibBuf = IntPtr.Zero;
                            g_nCalibBufSize = 0;
                        }

                        g_pCalibBuf = Marshal.AllocHGlobal((int)(pFrameInfo.nWidth * pFrameInfo.nHeight * 2));
                        if (g_pCalibBuf == IntPtr.Zero)
                        {
                            Console.WriteLine("malloc pCalibBuf failed");
                        }
                        g_nCalibBufSize = (uint)(pFrameInfo.nWidth * pFrameInfo.nHeight * 2);
                    }

                    stLSCCalib.pCalibBuf = g_pCalibBuf;
                    stLSCCalib.nCalibBufSize = g_nCalibBufSize;

                    stLSCCalib.nSecNumW = 689;
                    stLSCCalib.nSecNumH = 249;
                    stLSCCalib.nPadCoef = 2;
                    stLSCCalib.nCalibMethod = 2;
                    stLSCCalib.nTargetGray = 100;

                    //同一个相机，在场景、算法参数和图像参数都不变情况下，理论上只需要进行一次标定，可将标定表保存下来。
                    //不同相机图片标定出来的标定表不可复用，当场景改变或算法参数改变或图像参数改变时，需要重新标定。
                    nRet = camera.MV_CC_LSCCalib_NET(ref stLSCCalib);
                    if (MyCamera.MV_OK != nRet)
                    {
                        Console.WriteLine("LSC Calib failed:{0:x8}", nRet);
                    }

                    //保存标定表到本地
                    byte[] LSCCalibData = new byte[stLSCCalib.nCalibBufLen];
                    Marshal.Copy(stLSCCalib.pCalibBuf, LSCCalibData, 0, (int)stLSCCalib.nCalibBufLen);
                    FileStream pFile = null;
                    try
                    {
                        pFile = new FileStream(lscFile, FileMode.Create);
                        pFile.Write(LSCCalibData, 0, LSCCalibData.Length);
                    }
                    catch
                    {
                        Console.WriteLine("保存失败");
                    }
                    finally
                    {
                        pFile.Close();
                    }

                    IsNeedLSCCalib = false;
                }

                //LSC校正
                if (g_pDstData == IntPtr.Zero || g_nDstDataSize < pFrameInfo.nFrameLen)
                {
                    if (g_pDstData != IntPtr.Zero)
                    {
                        Marshal.FreeHGlobal(g_pDstData);
                        g_pDstData = IntPtr.Zero;
                        g_nDstDataSize = 0;
                    }

                    g_pDstData = Marshal.AllocHGlobal((int)pFrameInfo.nFrameLen);
                    if (g_pDstData == IntPtr.Zero)
                    {
                        Console.WriteLine("malloc pDstData failed");
                    }
                    g_nDstDataSize = pFrameInfo.nFrameLen;
                }

                MyCamera.MV_CC_LSC_CORRECT_PARAM stLSCCorrectParam = new MyCamera.MV_CC_LSC_CORRECT_PARAM();
                stLSCCorrectParam.nWidth = pFrameInfo.nWidth;
                stLSCCorrectParam.nHeight = pFrameInfo.nHeight;
                stLSCCorrectParam.enPixelType = pFrameInfo.enPixelType;
                stLSCCorrectParam.pSrcBuf = pData;
                stLSCCorrectParam.nSrcBufLen = pFrameInfo.nFrameLen;

                stLSCCorrectParam.pDstBuf = g_pDstData;
                stLSCCorrectParam.nDstBufSize = g_nDstDataSize;

                stLSCCorrectParam.pCalibBuf = g_pCalibBuf;
                stLSCCorrectParam.nCalibBufLen = g_nCalibBufSize;
                nRet = camera.MV_CC_LSCCorrect_NET(ref stLSCCorrectParam);
                if (MyCamera.MV_OK != nRet)
                {
                    Console.WriteLine("LSC Correct failed:{0:x8}", nRet);
                }
            }

            isGrey = IsMonoData(pFrameInfo.enPixelType);

            IntPtr imageBuf = pData;
            if (isGrey)
            {
            }
            else
            {
                int len = pFrameInfo.nWidth * pFrameInfo.nHeight * 3;
                if (m_ImageBufSize != len)
                {
                    m_ImageBufSize = (uint)len;
                    if (m_ImageBuf != IntPtr.Zero)
                    {
                        Marshal.Release(m_ImageBuf);
                        m_ImageBuf = IntPtr.Zero;
                    }
                }

                if (m_ImageBuf == IntPtr.Zero)
                {
                    m_ImageBuf = Marshal.AllocHGlobal((int)m_ImageBufSize);
                }

                // 像素类型转换
                MyCamera.MV_PIXEL_CONVERT_PARAM stConverPixelParam = new MyCamera.MV_PIXEL_CONVERT_PARAM
                {
                    nWidth = pFrameInfo.nWidth,
                    nHeight = pFrameInfo.nHeight,
                    pSrcData = pData,
                    nSrcDataLen = pFrameInfo.nFrameLen,
                    enSrcPixelType = pFrameInfo.enPixelType,
                    enDstPixelType = isGrey ? MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono8 : MyCamera.MvGvspPixelType.PixelType_Gvsp_BGR8_Packed,
                    pDstBuffer = m_ImageBuf,
                    nDstBufferSize = m_ImageBufSize
                };
                if (closing)
                {
                    return null;
                }
                try
                {
                    nRet = camera.MV_CC_ConvertPixelType_NET(ref stConverPixelParam);
                }
                catch { return null; }
                if (MyCamera.MV_OK == nRet)
                {
                    m_ImageBufSize = stConverPixelParam.nDstLen;
                }
                else
                {

                }
            }
            imageBuf = m_ImageBuf;

            Bitmap bitmap = new Bitmap(pFrameInfo.nWidth, pFrameInfo.nHeight, isGrey ? PixelFormat.Format8bppIndexed : PixelFormat.Format24bppRgb);
            if (isGrey)
            {
                ColorPalette cp = bitmap.Palette;
                for (int i = 0; i < 256; i++)
                {
                    cp.Entries[i] = Color.FromArgb(i, i, i);
                }
                bitmap.Palette = cp;
            }
            BitmapData bmpData = null;
            try
            {
                bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
                byte[] buffer = new byte[bmpData.Stride * bitmap.Height];
                Marshal.Copy(imageBuf, buffer, 0, bmpData.Stride * bitmap.Height);
                Marshal.Copy(buffer, 0, bmpData.Scan0, bmpData.Stride * bitmap.Height);
            }
            finally
            {
                bitmap.UnlockBits(bmpData);
            }
            return bitmap;
        }
        private Bitmap GetImage2(IntPtr pData, MyCamera.MV_FRAME_OUT_INFO stFrameInfo)
        {
            Bitmap bmp = null;
            {
                int nRet;
                // ch:用于保存图像的缓存 | en:Buffer for saving image
                uint m_nBufSizeForSaveImage = 3072 * 2048 * 3 * 3 + 2048;
                byte[] m_pBufForSaveImage = new byte[3072 * 2048 * 3 * 3 + 2048];

                if ((3 * stFrameInfo.nFrameLen + 2048) > m_nBufSizeForSaveImage)
                {
                    m_nBufSizeForSaveImage = 3 * stFrameInfo.nFrameLen + 2048;
                    m_pBufForSaveImage = new byte[m_nBufSizeForSaveImage];
                }
                //uint m_nBufSizeForSaveImage = 3 * stFrameInfo.nFrameLen + 2048;
                //byte[] m_pBufForSaveImage = new byte[m_nBufSizeForSaveImage];
                IntPtr pImage = Marshal.UnsafeAddrOfPinnedArrayElement(m_pBufForSaveImage, 0);
                MyCamera.MV_SAVE_IMAGE_PARAM_EX stSaveParam = new MyCamera.MV_SAVE_IMAGE_PARAM_EX();
                stSaveParam.enImageType = MyCamera.MV_SAVE_IAMGE_TYPE.MV_Image_Bmp;
                stSaveParam.enPixelType = stFrameInfo.enPixelType;
                stSaveParam.pData = pData;
                stSaveParam.nDataLen = stFrameInfo.nFrameLen;
                stSaveParam.nHeight = stFrameInfo.nHeight;
                stSaveParam.nWidth = stFrameInfo.nWidth;
                stSaveParam.pImageBuffer = pImage;
                stSaveParam.nBufferSize = m_nBufSizeForSaveImage;
                stSaveParam.nJpgQuality = 80;
                nRet = camera.MV_CC_SaveImageEx_NET(ref stSaveParam);
                if (MyCamera.MV_OK == nRet)
                {
                    using (MemoryStream stream = new MemoryStream(m_pBufForSaveImage))
                    {
                        bmp = new Bitmap(stream);
                        stream.Flush();
                        stream.Close();
                        stream.Dispose();
                    }
                    //ColorPalette cp = bmp.Palette;
                    //// init palette
                    //for (int i = 0; i < 256; i++)
                    //{
                    //    cp.Entries[i] = Color.FromArgb(i, i, i);
                    //}
                    //// set palette back
                    //bmp.Palette = cp;
                }
            }
            //GC.Collect();
            return bmp;
        }


        [DllImport("kernel32.dll", EntryPoint = "CopyMemory", SetLastError = false)]
        public static extern void CopyMemory(IntPtr dest, IntPtr src, uint count);
        private Bitmap DeepCopyIntPtrToBitmap(bool isGrey, int width, int height, IntPtr pImage)
        {
            Bitmap bitmap = new Bitmap(width, height, isGrey ? PixelFormat.Format8bppIndexed : PixelFormat.Format24bppRgb);
            if (isGrey)
            {
                ColorPalette cp = bitmap.Palette;
                for (int i = 0; i < 256; i++)
                {
                    cp.Entries[i] = Color.FromArgb(i, i, i);
                }
                bitmap.Palette = cp;
            }
            BitmapData bmpData = null;
            try
            {
                bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
                byte[] buffer = new byte[bmpData.Stride * bitmap.Height];
                Marshal.Copy(pImage, buffer, 0, bmpData.Stride * bitmap.Height);
                Marshal.Copy(buffer, 0, bmpData.Scan0, bmpData.Stride * bitmap.Height);
            }
            finally
            {
                bitmap.UnlockBits(bmpData);
            }

            return bitmap;
        }


        public bool NeedLscCalib()
        {
            if (true == File.Exists(lscFile))
            {
                FileStream fs = new FileStream(lscFile, FileMode.Open);
                byte[] data = new byte[fs.Length];

                if (g_pCalibBuf == IntPtr.Zero || g_nCalibBufSize < fs.Length)
                {
                    if (g_pCalibBuf != IntPtr.Zero)
                    {
                        Marshal.FreeHGlobal(g_pCalibBuf);
                        g_pCalibBuf = IntPtr.Zero;
                        g_nCalibBufSize = 0;
                    }

                    g_pCalibBuf = Marshal.AllocHGlobal((int)fs.Length);
                    if (g_pCalibBuf == IntPtr.Zero)
                    {
                        Console.WriteLine("malloc pCalibBuf failed");
                        return true;
                    }
                    g_nCalibBufSize = (uint)fs.Length;
                }

                fs.Read(data, 0, data.Length);
                fs.Close();

                Marshal.Copy(data, 0, g_pCalibBuf, (Int32)g_nCalibBufSize);

                IsNeedLSCCalib = false;
                return false;
            }
            return true;
        }
        private bool IsMonoData(MyCamera.MvGvspPixelType enGvspPixelType)
        {
            switch (enGvspPixelType)
            {
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono8:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono10:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono10_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono12:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono12_Packed:
                    return true;

                default:
                    return false;
            }
        }

        /************************************************************************
         *  @fn     IsColorData()
         *  @brief  判断是否是彩色数据
         *  @param  enGvspPixelType         [IN]           像素格式
         *  @return 成功，返回0；错误，返回-1 
         ************************************************************************/
        private bool IsColorData(MyCamera.MvGvspPixelType enGvspPixelType)
        {
            switch (enGvspPixelType)
            {
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR8:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG8:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB8:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG8:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR10:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG10:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB10:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG10:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR12:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG12:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB12:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG12:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR10_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG10_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB10_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG10_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR12_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG12_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB12_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG12_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_RGB8_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_YUV422_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_YUV422_YUYV_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_YCBCR411_8_CBYYCRYY:
                    return true;

                default:
                    return false;
            }
        }
        class FrameEx
        {
            public FrameEx(IntPtr data, MyCamera.MV_FRAME_OUT_INFO_EX frameInfo)
            {
                Data = data;
                FrameInfo = frameInfo;
            }

            internal IntPtr Data { get; }
            internal MyCamera.MV_FRAME_OUT_INFO_EX FrameInfo { get; }
        }
        class Frame
        {
            public Frame(IntPtr data, MyCamera.MV_FRAME_OUT_INFO frameInfo)
            {
                Data = data;
                FrameInfo = frameInfo;
            }

            internal IntPtr Data { get; }
            internal MyCamera.MV_FRAME_OUT_INFO FrameInfo { get; }
        }
    }
}
