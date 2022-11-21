using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Adjuster.Camera
{
    // class MyCamera
    //{
    //    public const int MV_UNKNOW_DEVICE = 0;
    //    public const int MV_GIGE_DEVICE = 1;
    //    public const int MV_1394_DEVICE = 2;
    //    public const int MV_USB_DEVICE = 4;
    //    public const int MV_CAMERALINK_DEVICE = 8;
    //    public const int MV_OK = 0;
    //    public const int MV_E_HANDLE = -2147483648;
    //    public const int MV_E_SUPPORT = -2147483647;
    //    public const int MV_E_BUFOVER = -2147483646;
    //    public const int MV_E_CALLORDER = -2147483645;
    //    public const int MV_E_PARAMETER = -2147483644;
    //    public const int MV_E_RESOURCE = -2147483642;
    //    public const int MV_E_NODATA = -2147483641;
    //    public const int MV_E_PRECONDITION = -2147483640;
    //    public const int MV_E_VERSION = -2147483639;
    //    public const int MV_E_NOENOUGH_BUF = -2147483638;
    //    public const int MV_E_ABNORMAL_IMAGE = -2147483637;
    //    public const int MV_E_LOAD_LIBRARY = -2147483636;
    //    public const int MV_E_NOOUTBUF = -2147483635;
    //    public const int MV_E_UNKNOW = -2147483393;
    //    public const int MV_E_GC_GENERIC = -2147483392;
    //    public const int MV_E_GC_ARGUMENT = -2147483391;
    //    public const int MV_E_GC_RANGE = -2147483390;
    //    public const int MV_E_GC_PROPERTY = -2147483389;
    //    public const int MV_E_GC_RUNTIME = -2147483388;
    //    public const int MV_E_GC_LOGICAL = -2147483387;
    //    public const int MV_E_GC_ACCESS = -2147483386;
    //    public const int MV_E_GC_TIMEOUT = -2147483385;
    //    public const int MV_E_GC_DYNAMICCAST = -2147483384;
    //    public const int MV_E_GC_UNKNOW = -2147483137;
    //    public const int MV_E_NOT_IMPLEMENTED = -2147483136;
    //    public const int MV_E_INVALID_ADDRESS = -2147483135;
    //    public const int MV_E_WRITE_PROTECT = -2147483134;
    //    public const int MV_E_ACCESS_DENIED = -2147483133;
    //    public const int MV_E_BUSY = -2147483132;
    //    public const int MV_E_PACKET = -2147483131;
    //    public const int MV_E_NETER = -2147483130;
    //    public const int MV_E_IP_CONFLICT = -2147483103;
    //    public const int MV_E_USB_READ = -2147482880;
    //    public const int MV_E_USB_WRITE = -2147482879;
    //    public const int MV_E_USB_DEVICE = -2147482878;
    //    public const int MV_E_USB_GENICAM = -2147482877;
    //    public const int MV_E_USB_BANDWIDTH = -2147482876;
    //    public const int MV_E_USB_DRIVER = -2147482875;
    //    public const int MV_E_USB_UNKNOW = -2147482625;
    //    public const int MV_E_UPG_FILE_MISMATCH = -2147482624;
    //    public const int MV_E_UPG_LANGUSGE_MISMATCH = -2147482623;
    //    public const int MV_E_UPG_CONFLICT = -2147482622;
    //    public const int MV_E_UPG_INNER_ERR = -2147482621;
    //    public const int MV_E_UPG_UNKNOW = -2147482369;
    //    public const int INFO_MAX_BUFFER_SIZE = 64;
    //    public const int MV_MAX_DEVICE_NUM = 256;
    //    public const int MV_IP_CFG_STATIC = 83886080;
    //    public const int MV_IP_CFG_DHCP = 100663296;
    //    public const int MV_IP_CFG_LLA = 67108864;
    //    public const int MV_NET_TRANS_DRIVER = 1;
    //    public const int MV_NET_TRANS_SOCKET = 2;
    //    public const int MV_MATCH_TYPE_NET_DETECT = 1;
    //    public const int MV_MATCH_TYPE_USB_DETECT = 2;
    //    public const int MV_MAX_XML_DISC_STRLEN_C = 512;
    //    public const int MV_MAX_XML_NODE_STRLEN_C = 64;
    //    public const int MV_MAX_XML_NODE_NUM_C = 128;
    //    public const int MV_MAX_XML_SYMBOLIC_NUM = 64;
    //    public const int MV_MAX_XML_STRVALUE_STRLEN_C = 64;
    //    public const int MV_MAX_XML_PARENTS_NUM = 8;
    //    public const int MV_MAX_XML_SYMBOLIC_STRLEN_C = 64;
    //    public const int MV_EXCEPTION_DEV_DISCONNECT = 32769;
    //    public const int MV_EXCEPTION_VERSION_CHECK = 32770;
    //    public const int MV_ACCESS_Exclusive = 1;
    //    public const int MV_ACCESS_ExclusiveWithSwitch = 2;
    //    public const int MV_ACCESS_Control = 3;
    //    public const int MV_ACCESS_ControlWithSwitch = 4;
    //    public const int MV_ACCESS_ControlSwitchEnable = 5;
    //    public const int MV_ACCESS_ControlSwitchEnableWithKey = 6;
    //    public const int MV_ACCESS_Monitor = 7;
    //    public const int MAX_EVENT_NAME_SIZE = 128;
    //    private IntPtr handle;

    //    public static uint MV_CC_GetSDKVersion_NET()
    //    {
    //        return MyCamera.MV_CC_GetSDKVersion();
    //    }

    //    public static int MV_CC_EnumerateTls_NET()
    //    {
    //        return MyCamera.MV_CC_EnumerateTls();
    //    }

    //    public static int MV_CC_EnumDevices_NET(
    //      uint nTLayerType,
    //      ref MyCamera.MV_CC_DEVICE_INFO_LIST stDevList)
    //    {
    //        return MyCamera.MV_CC_EnumDevices(nTLayerType, ref stDevList);
    //    }

    //    public static int MV_CC_EnumDevicesEx_NET(
    //      uint nTLayerType,
    //      ref MyCamera.MV_CC_DEVICE_INFO_LIST stDevList,
    //      string pManufacturerName)
    //    {
    //        return MyCamera.MV_CC_EnumDevicesEx(nTLayerType, ref stDevList, pManufacturerName);
    //    }

    //    public static bool MV_CC_IsDeviceAccessible_NET(
    //      ref MyCamera.MV_CC_DEVICE_INFO stDevInfo,
    //      uint nAccessMode)
    //    {
    //        return MyCamera.MV_CC_IsDeviceAccessible(ref stDevInfo, nAccessMode);
    //    }

    //    public static int MV_CC_SetSDKLogPath_NET(string pSDKLogPath)
    //    {
    //        return MyCamera.MV_CC_SetSDKLogPath(pSDKLogPath);
    //    }

    //    public MyCamera()
    //    {
    //        this.handle = IntPtr.Zero;
    //    }

    //    ~MyCamera()
    //    {
    //        this.MV_CC_DestroyDevice_NET();
    //    }

    //    public int MV_CC_CreateDevice_NET(ref MyCamera.MV_CC_DEVICE_INFO stDevInfo)
    //    {
    //        if (IntPtr.Zero != this.handle)
    //        {
    //            MyCamera.MV_CC_DestroyHandle(this.handle);
    //            this.handle = IntPtr.Zero;
    //        }
    //        return MyCamera.MV_CC_CreateHandle(ref this.handle, ref stDevInfo);
    //    }

    //    public int MV_CC_CreateDeviceWithoutLog_NET(ref MyCamera.MV_CC_DEVICE_INFO stDevInfo)
    //    {
    //        if (IntPtr.Zero != this.handle)
    //        {
    //            MyCamera.MV_CC_DestroyHandle(this.handle);
    //            this.handle = IntPtr.Zero;
    //        }
    //        return MyCamera.MV_CC_CreateHandleWithoutLog(ref this.handle, ref stDevInfo);
    //    }

    //    public int MV_CC_DestroyDevice_NET()
    //    {
    //        int num = MyCamera.MV_CC_DestroyHandle(this.handle);
    //        this.handle = IntPtr.Zero;
    //        return num;
    //    }

    //    public int MV_CC_OpenDevice_NET()
    //    {
    //        return MyCamera.MV_CC_OpenDevice(this.handle, 1U, (ushort)0);
    //    }

    //    public int MV_CC_OpenDevice_NET(uint nAccessMode, ushort nSwitchoverKey)
    //    {
    //        return MyCamera.MV_CC_OpenDevice(this.handle, nAccessMode, nSwitchoverKey);
    //    }

    //    public int MV_CC_CloseDevice_NET()
    //    {
    //        return MyCamera.MV_CC_CloseDevice(this.handle);
    //    }

    //    public int MV_CC_RegisterImageCallBackEx_NET(MyCamera.cbOutputExdelegate cbOutput, IntPtr pUser)
    //    {
    //        return MyCamera.MV_CC_RegisterImageCallBackEx(this.handle, cbOutput, pUser);
    //    }

    //    public int MV_CC_RegisterImageCallBackForRGB_NET(
    //      MyCamera.cbOutputExdelegate cbOutput,
    //      IntPtr pUser)
    //    {
    //        return MyCamera.MV_CC_RegisterImageCallBackForRGB(this.handle, cbOutput, pUser);
    //    }

    //    public int MV_CC_RegisterImageCallBackForBGR_NET(
    //      MyCamera.cbOutputExdelegate cbOutput,
    //      IntPtr pUser)
    //    {
    //        return MyCamera.MV_CC_RegisterImageCallBackForBGR(this.handle, cbOutput, pUser);
    //    }

    //    public int MV_CC_StartGrabbing_NET()
    //    {
    //        return MyCamera.MV_CC_StartGrabbing(this.handle);
    //    }

    //    public int MV_CC_StopGrabbing_NET()
    //    {
    //        return MyCamera.MV_CC_StopGrabbing(this.handle);
    //    }

    //    public int MV_CC_GetImageForRGB_NET(
    //      IntPtr pData,
    //      uint nDataSize,
    //      ref MyCamera.MV_FRAME_OUT_INFO_EX pFrameInfo,
    //      int nMsec)
    //    {
    //        return MyCamera.MV_CC_GetImageForRGB(this.handle, pData, nDataSize, ref pFrameInfo, nMsec);
    //    }

    //    public int MV_CC_GetImageForBGR_NET(
    //      IntPtr pData,
    //      uint nDataSize,
    //      ref MyCamera.MV_FRAME_OUT_INFO_EX pFrameInfo,
    //      int nMsec)
    //    {
    //        return MyCamera.MV_CC_GetImageForBGR(this.handle, pData, nDataSize, ref pFrameInfo, nMsec);
    //    }

    //    public int MV_CC_GetImageBuffer_NET(ref MyCamera.MV_FRAME_OUT pFrame, int nMsec)
    //    {
    //        return MyCamera.MV_CC_GetImageBuffer(this.handle, ref pFrame, nMsec);
    //    }

    //    public int MV_CC_FreeImageBuffer_NET(ref MyCamera.MV_FRAME_OUT pFrame)
    //    {
    //        return MyCamera.MV_CC_FreeImageBuffer(this.handle, ref pFrame);
    //    }

    //    public int MV_CC_GetOneFrameTimeout_NET(
    //      IntPtr pData,
    //      uint nDataSize,
    //      ref MyCamera.MV_FRAME_OUT_INFO_EX pFrameInfo,
    //      int nMsec)
    //    {
    //        return MyCamera.MV_CC_GetOneFrameTimeout(this.handle, pData, nDataSize, ref pFrameInfo, nMsec);
    //    }

    //    public int MV_CC_Display_NET(IntPtr hWnd)
    //    {
    //        return MyCamera.MV_CC_Display(this.handle, hWnd);
    //    }

    //    public int MV_CC_DisplayOneFrame_NET(ref MyCamera.MV_DISPLAY_FRAME_INFO pDisplayInfo)
    //    {
    //        return MyCamera.MV_CC_DisplayOneFrame(this.handle, ref pDisplayInfo);
    //    }

    //    public int MV_CC_SetImageNodeNum_NET(uint nNum)
    //    {
    //        return MyCamera.MV_CC_SetImageNodeNum(this.handle, nNum);
    //    }

    //    public int MV_CC_GetImageInfo_NET(ref MyCamera.MV_IMAGE_BASIC_INFO pstInfo)
    //    {
    //        return MyCamera.MV_CC_GetImageInfo(this.handle, ref pstInfo);
    //    }

    //    public int MV_CC_GetDeviceInfo_NET(ref MyCamera.MV_CC_DEVICE_INFO pstDevInfo)
    //    {
    //        return MyCamera.MV_CC_GetDeviceInfo(this.handle, ref pstDevInfo);
    //    }

    //    public int MV_CC_GetAllMatchInfo_NET(ref MyCamera.MV_ALL_MATCH_INFO pstInfo)
    //    {
    //        return MyCamera.MV_CC_GetAllMatchInfo(this.handle, ref pstInfo);
    //    }

    //    public int MV_CC_GetIntValue_NET(string strKey, ref MyCamera.MVCC_INTVALUE pstValue)
    //    {
    //        return MyCamera.MV_CC_GetIntValue(this.handle, strKey, ref pstValue);
    //    }

    //    public int MV_CC_GetIntValueEx_NET(string strKey, ref MyCamera.MVCC_INTVALUE_EX pstValue)
    //    {
    //        return MyCamera.MV_CC_GetIntValueEx(this.handle, strKey, ref pstValue);
    //    }

    //    public int MV_CC_SetIntValue_NET(string strKey, uint nValue)
    //    {
    //        return MyCamera.MV_CC_SetIntValue(this.handle, strKey, nValue);
    //    }

    //    public int MV_CC_SetIntValueEx_NET(string strKey, long nValue)
    //    {
    //        return MyCamera.MV_CC_SetIntValueEx(this.handle, strKey, nValue);
    //    }

    //    public int MV_CC_GetEnumValue_NET(string strKey, ref MyCamera.MVCC_ENUMVALUE pstValue)
    //    {
    //        return MyCamera.MV_CC_GetEnumValue(this.handle, strKey, ref pstValue);
    //    }

    //    public int MV_CC_SetEnumValue_NET(string strKey, uint nValue)
    //    {
    //        return MyCamera.MV_CC_SetEnumValue(this.handle, strKey, nValue);
    //    }

    //    public int MV_CC_SetEnumValueByString_NET(string strKey, string sValue)
    //    {
    //        return MyCamera.MV_CC_SetEnumValueByString(this.handle, strKey, sValue);
    //    }

    //    public int MV_CC_GetFloatValue_NET(string strKey, ref MyCamera.MVCC_FLOATVALUE pstValue)
    //    {
    //        return MyCamera.MV_CC_GetFloatValue(this.handle, strKey, ref pstValue);
    //    }

    //    public int MV_CC_SetFloatValue_NET(string strKey, float fValue)
    //    {
    //        return MyCamera.MV_CC_SetFloatValue(this.handle, strKey, fValue);
    //    }

    //    public int MV_CC_GetBoolValue_NET(string strKey, ref bool pbValue)
    //    {
    //        return MyCamera.MV_CC_GetBoolValue(this.handle, strKey, ref pbValue);
    //    }

    //    public int MV_CC_SetBoolValue_NET(string strKey, bool bValue)
    //    {
    //        return MyCamera.MV_CC_SetBoolValue(this.handle, strKey, bValue);
    //    }

    //    public int MV_CC_GetStringValue_NET(string strKey, ref MyCamera.MVCC_STRINGVALUE pstValue)
    //    {
    //        return MyCamera.MV_CC_GetStringValue(this.handle, strKey, ref pstValue);
    //    }

    //    public int MV_CC_SetStringValue_NET(string strKey, string strValue)
    //    {
    //        return MyCamera.MV_CC_SetStringValue(this.handle, strKey, strValue);
    //    }

    //    public int MV_CC_SetCommandValue_NET(string strKey)
    //    {
    //        return MyCamera.MV_CC_SetCommandValue(this.handle, strKey);
    //    }

    //    public int MV_CC_InvalidateNodes_NET()
    //    {
    //        return MyCamera.MV_CC_InvalidateNodes(this.handle);
    //    }

    //    public int MV_CC_GetWidth_NET(ref MyCamera.MVCC_INTVALUE pstValue)
    //    {
    //        return MyCamera.MV_CC_GetWidth(this.handle, ref pstValue);
    //    }

    //    public int MV_CC_SetWidth_NET(uint nValue)
    //    {
    //        return MyCamera.MV_CC_SetWidth(this.handle, nValue);
    //    }

    //    public int MV_CC_GetHeight_NET(ref MyCamera.MVCC_INTVALUE pstValue)
    //    {
    //        return MyCamera.MV_CC_GetHeight(this.handle, ref pstValue);
    //    }

    //    public int MV_CC_SetHeight_NET(uint nValue)
    //    {
    //        return MyCamera.MV_CC_SetHeight(this.handle, nValue);
    //    }

    //    public int MV_CC_GetAOIoffsetX_NET(ref MyCamera.MVCC_INTVALUE pstValue)
    //    {
    //        return MyCamera.MV_CC_GetAOIoffsetX(this.handle, ref pstValue);
    //    }

    //    public int MV_CC_SetAOIoffsetX_NET(uint nValue)
    //    {
    //        return MyCamera.MV_CC_SetAOIoffsetX(this.handle, nValue);
    //    }

    //    public int MV_CC_GetAOIoffsetY_NET(ref MyCamera.MVCC_INTVALUE pstValue)
    //    {
    //        return MyCamera.MV_CC_GetAOIoffsetY(this.handle, ref pstValue);
    //    }

    //    public int MV_CC_SetAOIoffsetY_NET(uint nValue)
    //    {
    //        return MyCamera.MV_CC_SetAOIoffsetY(this.handle, nValue);
    //    }

    //    public int MV_CC_GetAutoExposureTimeLower_NET(ref MyCamera.MVCC_INTVALUE pstValue)
    //    {
    //        return MyCamera.MV_CC_GetAutoExposureTimeLower(this.handle, ref pstValue);
    //    }

    //    public int MV_CC_SetAutoExposureTimeLower_NET(uint nValue)
    //    {
    //        return MyCamera.MV_CC_SetAutoExposureTimeLower(this.handle, nValue);
    //    }

    //    public int MV_CC_GetAutoExposureTimeUpper_NET(ref MyCamera.MVCC_INTVALUE pstValue)
    //    {
    //        return MyCamera.MV_CC_GetAutoExposureTimeUpper(this.handle, ref pstValue);
    //    }

    //    public int MV_CC_SetAutoExposureTimeUpper_NET(uint nValue)
    //    {
    //        return MyCamera.MV_CC_SetAutoExposureTimeUpper(this.handle, nValue);
    //    }

    //    public int MV_CC_GetBrightness_NET(ref MyCamera.MVCC_INTVALUE pstValue)
    //    {
    //        return MyCamera.MV_CC_GetBrightness(this.handle, ref pstValue);
    //    }

    //    public int MV_CC_SetBrightness_NET(uint nValue)
    //    {
    //        return MyCamera.MV_CC_SetBrightness(this.handle, nValue);
    //    }

    //    public int MV_CC_GetFrameRate_NET(ref MyCamera.MVCC_FLOATVALUE pstValue)
    //    {
    //        return MyCamera.MV_CC_GetFrameRate(this.handle, ref pstValue);
    //    }

    //    public int MV_CC_SetFrameRate_NET(float fValue)
    //    {
    //        return MyCamera.MV_CC_SetFrameRate(this.handle, fValue);
    //    }

    //    public int MV_CC_GetGain_NET(ref MyCamera.MVCC_FLOATVALUE pstValue)
    //    {
    //        return MyCamera.MV_CC_GetGain(this.handle, ref pstValue);
    //    }

    //    public int MV_CC_SetGain_NET(float fValue)
    //    {
    //        return MyCamera.MV_CC_SetGain(this.handle, fValue);
    //    }

    //    public int MV_CC_GetExposureTime_NET(ref MyCamera.MVCC_FLOATVALUE pstValue)
    //    {
    //        return MyCamera.MV_CC_GetExposureTime(this.handle, ref pstValue);
    //    }

    //    public int MV_CC_SetExposureTime_NET(float fValue)
    //    {
    //        return MyCamera.MV_CC_SetExposureTime(this.handle, fValue);
    //    }

    //    public int MV_CC_GetPixelFormat_NET(ref MyCamera.MVCC_ENUMVALUE pstValue)
    //    {
    //        return MyCamera.MV_CC_GetPixelFormat(this.handle, ref pstValue);
    //    }

    //    public int MV_CC_SetPixelFormat_NET(uint nValue)
    //    {
    //        return MyCamera.MV_CC_SetPixelFormat(this.handle, nValue);
    //    }

    //    public int MV_CC_GetAcquisitionMode_NET(ref MyCamera.MVCC_ENUMVALUE pstValue)
    //    {
    //        return MyCamera.MV_CC_GetAcquisitionMode(this.handle, ref pstValue);
    //    }

    //    public int MV_CC_SetAcquisitionMode_NET(uint nValue)
    //    {
    //        return MyCamera.MV_CC_SetAcquisitionMode(this.handle, nValue);
    //    }

    //    public int MV_CC_GetGainMode_NET(ref MyCamera.MVCC_ENUMVALUE pstValue)
    //    {
    //        return MyCamera.MV_CC_GetGainMode(this.handle, ref pstValue);
    //    }

    //    public int MV_CC_SetGainMode_NET(uint nValue)
    //    {
    //        return MyCamera.MV_CC_SetGainMode(this.handle, nValue);
    //    }

    //    public int MV_CC_GetExposureAutoMode_NET(ref MyCamera.MVCC_ENUMVALUE pstValue)
    //    {
    //        return MyCamera.MV_CC_GetExposureAutoMode(this.handle, ref pstValue);
    //    }

    //    public int MV_CC_SetExposureAutoMode_NET(uint nValue)
    //    {
    //        return MyCamera.MV_CC_SetExposureAutoMode(this.handle, nValue);
    //    }

    //    public int MV_CC_GetTriggerMode_NET(ref MyCamera.MVCC_ENUMVALUE pstValue)
    //    {
    //        return MyCamera.MV_CC_GetTriggerMode(this.handle, ref pstValue);
    //    }

    //    public int MV_CC_SetTriggerMode_NET(uint nValue)
    //    {
    //        return MyCamera.MV_CC_SetTriggerMode(this.handle, nValue);
    //    }

    //    public int MV_CC_GetTriggerDelay_NET(ref MyCamera.MVCC_FLOATVALUE pstValue)
    //    {
    //        return MyCamera.MV_CC_GetTriggerDelay(this.handle, ref pstValue);
    //    }

    //    public int MV_CC_SetTriggerDelay_NET(float fValue)
    //    {
    //        return MyCamera.MV_CC_SetTriggerDelay(this.handle, fValue);
    //    }

    //    public int MV_CC_GetTriggerSource_NET(ref MyCamera.MVCC_ENUMVALUE pstValue)
    //    {
    //        return MyCamera.MV_CC_GetTriggerSource(this.handle, ref pstValue);
    //    }

    //    public int MV_CC_SetTriggerSource_NET(uint nValue)
    //    {
    //        return MyCamera.MV_CC_SetTriggerSource(this.handle, nValue);
    //    }

    //    public int MV_CC_TriggerSoftwareExecute_NET()
    //    {
    //        return MyCamera.MV_CC_TriggerSoftwareExecute(this.handle);
    //    }

    //    public int MV_CC_GetGammaSelector_NET(ref MyCamera.MVCC_ENUMVALUE pstValue)
    //    {
    //        return MyCamera.MV_CC_GetGammaSelector(this.handle, ref pstValue);
    //    }

    //    public int MV_CC_SetGammaSelector_NET(uint nValue)
    //    {
    //        return MyCamera.MV_CC_SetGammaSelector(this.handle, nValue);
    //    }

    //    public int MV_CC_GetGamma_NET(ref MyCamera.MVCC_FLOATVALUE pstValue)
    //    {
    //        return MyCamera.MV_CC_GetGamma(this.handle, ref pstValue);
    //    }

    //    public int MV_CC_SetGamma_NET(float fValue)
    //    {
    //        return MyCamera.MV_CC_SetGamma(this.handle, fValue);
    //    }

    //    public int MV_CC_GetSharpness_NET(ref MyCamera.MVCC_INTVALUE pstValue)
    //    {
    //        return MyCamera.MV_CC_GetSharpness(this.handle, ref pstValue);
    //    }

    //    public int MV_CC_SetSharpness_NET(uint nValue)
    //    {
    //        return MyCamera.MV_CC_SetSharpness(this.handle, nValue);
    //    }

    //    public int MV_CC_GetHue_NET(ref MyCamera.MVCC_INTVALUE pstValue)
    //    {
    //        return MyCamera.MV_CC_GetHue(this.handle, ref pstValue);
    //    }

    //    public int MV_CC_SetHue_NET(uint nValue)
    //    {
    //        return MyCamera.MV_CC_SetHue(this.handle, nValue);
    //    }

    //    public int MV_CC_GetSaturation_NET(ref MyCamera.MVCC_INTVALUE pstValue)
    //    {
    //        return MyCamera.MV_CC_GetSaturation(this.handle, ref pstValue);
    //    }

    //    public int MV_CC_SetSaturation_NET(uint nValue)
    //    {
    //        return MyCamera.MV_CC_SetSaturation(this.handle, nValue);
    //    }

    //    public int MV_CC_GetBalanceWhiteAuto_NET(ref MyCamera.MVCC_ENUMVALUE pstValue)
    //    {
    //        return MyCamera.MV_CC_GetBalanceWhiteAuto(this.handle, ref pstValue);
    //    }

    //    public int MV_CC_SetBalanceWhiteAuto_NET(uint nValue)
    //    {
    //        return MyCamera.MV_CC_SetBalanceWhiteAuto(this.handle, nValue);
    //    }

    //    public int MV_CC_GetBalanceRatioRed_NET(ref MyCamera.MVCC_INTVALUE pstValue)
    //    {
    //        return MyCamera.MV_CC_GetBalanceRatioRed(this.handle, ref pstValue);
    //    }

    //    public int MV_CC_SetBalanceRatioRed_NET(uint nValue)
    //    {
    //        return MyCamera.MV_CC_SetBalanceRatioRed(this.handle, nValue);
    //    }

    //    public int MV_CC_GetBalanceRatioGreen_NET(ref MyCamera.MVCC_INTVALUE pstValue)
    //    {
    //        return MyCamera.MV_CC_GetBalanceRatioGreen(this.handle, ref pstValue);
    //    }

    //    public int MV_CC_SetBalanceRatioGreen_NET(uint nValue)
    //    {
    //        return MyCamera.MV_CC_SetBalanceRatioGreen(this.handle, nValue);
    //    }

    //    public int MV_CC_GetBalanceRatioBlue_NET(ref MyCamera.MVCC_INTVALUE pstValue)
    //    {
    //        return MyCamera.MV_CC_GetBalanceRatioBlue(this.handle, ref pstValue);
    //    }

    //    public int MV_CC_SetBalanceRatioBlue_NET(uint nValue)
    //    {
    //        return MyCamera.MV_CC_SetBalanceRatioBlue(this.handle, nValue);
    //    }

    //    public int MV_CC_GetDeviceUserID_NET(ref MyCamera.MVCC_STRINGVALUE pstValue)
    //    {
    //        return MyCamera.MV_CC_GetDeviceUserID(this.handle, ref pstValue);
    //    }

    //    public int MV_CC_SetDeviceUserID_NET(string chValue)
    //    {
    //        return MyCamera.MV_CC_SetDeviceUserID(this.handle, chValue);
    //    }

    //    public int MV_CC_GetBurstFrameCount_NET(ref MyCamera.MVCC_INTVALUE pstValue)
    //    {
    //        return MyCamera.MV_CC_GetBurstFrameCount(this.handle, ref pstValue);
    //    }

    //    public int MV_CC_SetBurstFrameCount_NET(uint nValue)
    //    {
    //        return MyCamera.MV_CC_SetBurstFrameCount(this.handle, nValue);
    //    }

    //    public int MV_CC_GetAcquisitionLineRate_NET(ref MyCamera.MVCC_INTVALUE pstValue)
    //    {
    //        return MyCamera.MV_CC_GetAcquisitionLineRate(this.handle, ref pstValue);
    //    }

    //    public int MV_CC_SetAcquisitionLineRate_NET(uint nValue)
    //    {
    //        return MyCamera.MV_CC_SetAcquisitionLineRate(this.handle, nValue);
    //    }

    //    public int MV_CC_GetHeartBeatTimeout_NET(ref MyCamera.MVCC_INTVALUE pstValue)
    //    {
    //        return MyCamera.MV_CC_GetHeartBeatTimeout(this.handle, ref pstValue);
    //    }

    //    public int MV_CC_SetHeartBeatTimeout_NET(uint nValue)
    //    {
    //        return MyCamera.MV_CC_SetHeartBeatTimeout(this.handle, nValue);
    //    }

    //    public int MV_CC_LocalUpgrade_NET(string pFilePathName)
    //    {
    //        return MyCamera.MV_CC_LocalUpgrade(this.handle, pFilePathName);
    //    }

    //    public int MV_CC_GetUpgradeProcess_NET(ref uint pnProcess)
    //    {
    //        return MyCamera.MV_CC_GetUpgradeProcess(this.handle, ref pnProcess);
    //    }

    //    public int MV_CC_GetOptimalPacketSize_NET()
    //    {
    //        return MyCamera.MV_CC_GetOptimalPacketSize(this.handle);
    //    }

    //    public int MV_CC_ReadMemory_NET(IntPtr pBuffer, long nAddress, long nLength)
    //    {
    //        return MyCamera.MV_CC_ReadMemory(this.handle, pBuffer, nAddress, nLength);
    //    }

    //    public int MV_CC_WriteMemory_NET(IntPtr pBuffer, long nAddress, long nLength)
    //    {
    //        return MyCamera.MV_CC_WriteMemory(this.handle, pBuffer, nAddress, nLength);
    //    }

    //    public int MV_CC_RegisterExceptionCallBack_NET(
    //      MyCamera.cbExceptiondelegate cbException,
    //      IntPtr pUser)
    //    {
    //        return MyCamera.MV_CC_RegisterExceptionCallBack(this.handle, cbException, pUser);
    //    }

    //    public int MV_CC_RegisterEventCallBack_NET(MyCamera.cbEventdelegate cbEvent, IntPtr pUser)
    //    {
    //        return MyCamera.MV_CC_RegisterEventCallBack(this.handle, cbEvent, pUser);
    //    }

    //    public int MV_CC_RegisterAllEventCallBack_NET(MyCamera.cbEventdelegateEx cbEvent, IntPtr pUser)
    //    {
    //        return MyCamera.MV_CC_RegisterAllEventCallBack(this.handle, cbEvent, pUser);
    //    }

    //    public int MV_CC_RegisterEventCallBackEx_NET(
    //      string pEventName,
    //      MyCamera.cbEventdelegateEx cbEvent,
    //      IntPtr pUser)
    //    {
    //        return MyCamera.MV_CC_RegisterEventCallBackEx(this.handle, pEventName, cbEvent, pUser);
    //    }

    //    public int MV_GIGE_ForceIpEx_NET(uint nIP, uint nSubNetMask, uint nDefaultGateWay)
    //    {
    //        return MyCamera.MV_GIGE_ForceIpEx(this.handle, nIP, nSubNetMask, nDefaultGateWay);
    //    }

    //    public int MV_GIGE_SetIpConfig_NET(uint nType)
    //    {
    //        return MyCamera.MV_GIGE_SetIpConfig(this.handle, nType);
    //    }

    //    public int MV_GIGE_SetNetTransMode_NET(uint nType)
    //    {
    //        return MyCamera.MV_GIGE_SetNetTransMode(this.handle, nType);
    //    }

    //    public int MV_GIGE_GetNetTransInfo_NET(ref MyCamera.MV_NETTRANS_INFO pstInfo)
    //    {
    //        return MyCamera.MV_GIGE_GetNetTransInfo(this.handle, ref pstInfo);
    //    }

    //    public int MV_GIGE_SetGvcpTimeout_NET(uint nMillisec)
    //    {
    //        return MyCamera.MV_GIGE_SetGvcpTimeout(this.handle, nMillisec);
    //    }

    //    public int MV_GIGE_SetResend_NET(uint bEnable, uint nMaxResendPercent, uint nResendTimeout)
    //    {
    //        return MyCamera.MV_GIGE_SetResend(this.handle, bEnable, nMaxResendPercent, nResendTimeout);
    //    }

    //    public int MV_GIGE_GetGevSCPSPacketSize_NET(ref MyCamera.MVCC_INTVALUE pstValue)
    //    {
    //        return MyCamera.MV_GIGE_GetGevSCPSPacketSize(this.handle, ref pstValue);
    //    }

    //    public int MV_GIGE_SetGevSCPSPacketSize_NET(uint nValue)
    //    {
    //        return MyCamera.MV_GIGE_SetGevSCPSPacketSize(this.handle, nValue);
    //    }

    //    public int MV_GIGE_GetGevSCPD_NET(ref MyCamera.MVCC_INTVALUE pstValue)
    //    {
    //        return MyCamera.MV_GIGE_GetGevSCPD(this.handle, ref pstValue);
    //    }

    //    public int MV_GIGE_SetGevSCPD_NET(uint nValue)
    //    {
    //        return MyCamera.MV_GIGE_SetGevSCPD(this.handle, nValue);
    //    }

    //    public int MV_GIGE_GetGevSCDA_NET(ref uint pnIP)
    //    {
    //        return MyCamera.MV_GIGE_GetGevSCDA(this.handle, ref pnIP);
    //    }

    //    public int MV_GIGE_SetGevSCDA_NET(uint nIP)
    //    {
    //        return MyCamera.MV_GIGE_SetGevSCDA(this.handle, nIP);
    //    }

    //    public int MV_GIGE_GetGevSCSP_NET(ref uint pnPort)
    //    {
    //        return MyCamera.MV_GIGE_GetGevSCSP(this.handle, ref pnPort);
    //    }

    //    public int MV_GIGE_SetGevSCSP_NET(uint nPort)
    //    {
    //        return MyCamera.MV_GIGE_SetGevSCSP(this.handle, nPort);
    //    }

    //    public int MV_GIGE_SetTransmissionType_NET(
    //      ref MyCamera.MV_CC_TRANSMISSION_TYPE pstTransmissionType)
    //    {
    //        return MyCamera.MV_GIGE_SetTransmissionType(this.handle, ref pstTransmissionType);
    //    }

    //    public int MV_XML_GetGenICamXML_NET(IntPtr pData, uint nDataSize, ref uint pnDataLen)
    //    {
    //        return MyCamera.MV_XML_GetGenICamXML(this.handle, pData, nDataSize, ref pnDataLen);
    //    }

    //    public int MV_XML_GetRootNode_NET(ref MyCamera.MV_XML_NODE_FEATURE pstNode)
    //    {
    //        return MyCamera.MV_XML_GetRootNode(this.handle, ref pstNode);
    //    }

    //    public int MV_XML_GetChildren_NET(ref MyCamera.MV_XML_NODE_FEATURE pstNode, IntPtr pstNodesList)
    //    {
    //        return MyCamera.MV_XML_GetChildren(this.handle, ref pstNode, pstNodesList);
    //    }

    //    public int MV_XML_GetChildren_NET(
    //      ref MyCamera.MV_XML_NODE_FEATURE pstNode,
    //      ref MyCamera.MV_XML_NODES_LIST pstNodesList)
    //    {
    //        return MyCamera.MV_XML_GetChildren(this.handle, ref pstNode, ref pstNodesList);
    //    }

    //    public int MV_XML_GetNodeFeature_NET(
    //      ref MyCamera.MV_XML_NODE_FEATURE pstNode,
    //      IntPtr pstFeature)
    //    {
    //        return MyCamera.MV_XML_GetNodeFeature(this.handle, ref pstNode, pstFeature);
    //    }

    //    public int MV_XML_UpdateNodeFeature_NET(MyCamera.MV_XML_InterfaceType enType, IntPtr pstFeature)
    //    {
    //        return MyCamera.MV_XML_UpdateNodeFeature(this.handle, enType, pstFeature);
    //    }

    //    public int MV_XML_RegisterUpdateCallBack_NET(
    //      MyCamera.cbXmlUpdatedelegate cbXmlUpdate,
    //      IntPtr pUser)
    //    {
    //        return MyCamera.MV_XML_RegisterUpdateCallBack(this.handle, cbXmlUpdate, pUser);
    //    }

    //    public int MV_CC_SaveImageEx_NET(ref MyCamera.MV_SAVE_IMAGE_PARAM_EX stSaveParam)
    //    {
    //        return MyCamera.MV_CC_SaveImageEx2(this.handle, ref stSaveParam);
    //    }

    //    public int MV_CC_ConvertPixelType_NET(ref MyCamera.MV_PIXEL_CONVERT_PARAM pstCvtParam)
    //    {
    //        return MyCamera.MV_CC_ConvertPixelType(this.handle, ref pstCvtParam);
    //    }

    //    public int MV_CC_SetBayerCvtQuality_NET(uint BayerCvtQuality)
    //    {
    //        return MyCamera.MV_CC_SetBayerCvtQuality(this.handle, BayerCvtQuality);
    //    }

    //    public IntPtr MV_CC_GetTlProxy_NET()
    //    {
    //        return MyCamera.MV_CC_GetTlProxy(this.handle);
    //    }

    //    public int MV_CC_FeatureSave_NET(string pFileName)
    //    {
    //        return MyCamera.MV_CC_FeatureSave(this.handle, pFileName);
    //    }

    //    public int MV_CC_FeatureLoad_NET(string pFileName)
    //    {
    //        return MyCamera.MV_CC_FeatureLoad(this.handle, pFileName);
    //    }

    //    public int MV_CC_FileAccessRead_NET(ref MyCamera.MV_CC_FILE_ACCESS pstFileAccess)
    //    {
    //        return MyCamera.MV_CC_FileAccessRead(this.handle, ref pstFileAccess);
    //    }

    //    public int MV_CC_FileAccessWrite_NET(ref MyCamera.MV_CC_FILE_ACCESS pstFileAccess)
    //    {
    //        return MyCamera.MV_CC_FileAccessWrite(this.handle, ref pstFileAccess);
    //    }

    //    public int MV_CC_GetFileAccessProgress_NET(
    //      ref MyCamera.MV_CC_FILE_ACCESS_PROGRESS pstFileAccessProgress)
    //    {
    //        return MyCamera.MV_CC_GetFileAccessProgress(this.handle, ref pstFileAccessProgress);
    //    }

    //    public int MV_CC_GetOneFrame_NET(
    //      IntPtr pData,
    //      uint nDataSize,
    //      ref MyCamera.MV_FRAME_OUT_INFO pFrameInfo)
    //    {
    //        return MyCamera.MV_CC_GetOneFrame(this.handle, pData, nDataSize, ref pFrameInfo);
    //    }

    //    public int MV_CC_GetOneFrameEx_NET(
    //      IntPtr pData,
    //      uint nDataSize,
    //      ref MyCamera.MV_FRAME_OUT_INFO_EX pFrameInfo)
    //    {
    //        return MyCamera.MV_CC_GetOneFrameEx(this.handle, pData, nDataSize, ref pFrameInfo);
    //    }

    //    public int MV_CC_RegisterImageCallBack_NET(MyCamera.cbOutputdelegate cbOutput, IntPtr pUser)
    //    {
    //        return MyCamera.MV_CC_RegisterImageCallBack(this.handle, cbOutput, pUser);
    //    }

    //    public int MV_CC_SaveImage_NET(ref MyCamera.MV_SAVE_IMAGE_PARAM stSaveParam)
    //    {
    //        return MyCamera.MV_CC_SaveImage(ref stSaveParam);
    //    }

    //    public int MV_GIGE_ForceIp_NET(uint nIP)
    //    {
    //        return MyCamera.MV_GIGE_ForceIp(this.handle, nIP);
    //    }

    //    public IntPtr GetCameraHandle()
    //    {
    //        return this.handle;
    //    }

    //    public static object ByteToStruct(byte[] bytes, Type type)
    //    {
    //        int num1 = Marshal.SizeOf(type);
    //        if (num1 > bytes.Length)
    //            return (object)null;
    //        IntPtr num2 = Marshal.AllocHGlobal(num1);
    //        Marshal.Copy(bytes, 0, num2, num1);
    //        object structure = Marshal.PtrToStructure(num2, type);
    //        Marshal.FreeHGlobal(num2);
    //        return structure;
    //    }

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern uint MV_CC_GetSDKVersion();

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_EnumerateTls();

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_EnumDevices(
    //      uint nTLayerType,
    //      ref MyCamera.MV_CC_DEVICE_INFO_LIST stDevList);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_EnumDevicesEx(
    //      uint nTLayerType,
    //      ref MyCamera.MV_CC_DEVICE_INFO_LIST stDevList,
    //      string pManufacturerName);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern bool MV_CC_IsDeviceAccessible(
    //      ref MyCamera.MV_CC_DEVICE_INFO stDevInfo,
    //      uint nAccessMode);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_SetSDKLogPath(string pSDKLogPath);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_CreateHandle(
    //      ref IntPtr handle,
    //      ref MyCamera.MV_CC_DEVICE_INFO stDevInfo);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_CreateHandleWithoutLog(
    //      ref IntPtr handle,
    //      ref MyCamera.MV_CC_DEVICE_INFO stDevInfo);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_DestroyHandle(IntPtr handle);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_OpenDevice(
    //      IntPtr handle,
    //      uint nAccessMode,
    //      ushort nSwitchoverKey);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_CloseDevice(IntPtr handle);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_RegisterImageCallBackEx(
    //      IntPtr handle,
    //      MyCamera.cbOutputExdelegate cbOutput,
    //      IntPtr pUser);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_RegisterImageCallBackForRGB(
    //      IntPtr handle,
    //      MyCamera.cbOutputExdelegate cbOutput,
    //      IntPtr pUser);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_RegisterImageCallBackForBGR(
    //      IntPtr handle,
    //      MyCamera.cbOutputExdelegate cbOutput,
    //      IntPtr pUser);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_StartGrabbing(IntPtr handle);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_StopGrabbing(IntPtr handle);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_GetImageForRGB(
    //      IntPtr handle,
    //      IntPtr pData,
    //      uint nDataSize,
    //      ref MyCamera.MV_FRAME_OUT_INFO_EX pFrameInfo,
    //      int nMsec);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_GetImageForBGR(
    //      IntPtr handle,
    //      IntPtr pData,
    //      uint nDataSize,
    //      ref MyCamera.MV_FRAME_OUT_INFO_EX pFrameInfo,
    //      int nMsec);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_GetImageBuffer(
    //      IntPtr handle,
    //      ref MyCamera.MV_FRAME_OUT pFrame,
    //      int nMsec);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_FreeImageBuffer(IntPtr handle, ref MyCamera.MV_FRAME_OUT pFrame);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_GetOneFrameTimeout(
    //      IntPtr handle,
    //      IntPtr pData,
    //      uint nDataSize,
    //      ref MyCamera.MV_FRAME_OUT_INFO_EX pFrameInfo,
    //      int nMsec);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_Display(IntPtr handle, IntPtr hWnd);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_DisplayOneFrame(
    //      IntPtr handle,
    //      ref MyCamera.MV_DISPLAY_FRAME_INFO pDisplayInfo);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_SetImageNodeNum(IntPtr handle, uint nNum);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_GetImageInfo(
    //      IntPtr handle,
    //      ref MyCamera.MV_IMAGE_BASIC_INFO pstInfo);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_GetDeviceInfo(
    //      IntPtr handle,
    //      ref MyCamera.MV_CC_DEVICE_INFO pstDevInfo);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_GetAllMatchInfo(
    //      IntPtr handle,
    //      ref MyCamera.MV_ALL_MATCH_INFO pstInfo);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_GetIntValue(
    //      IntPtr handle,
    //      string strValue,
    //      ref MyCamera.MVCC_INTVALUE pIntValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_GetIntValueEx(
    //      IntPtr handle,
    //      string strValue,
    //      ref MyCamera.MVCC_INTVALUE_EX pIntValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_SetIntValue(IntPtr handle, string strValue, uint nValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_SetIntValueEx(IntPtr handle, string strValue, long nValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_GetEnumValue(
    //      IntPtr handle,
    //      string strValue,
    //      ref MyCamera.MVCC_ENUMVALUE pEnumValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_SetEnumValue(IntPtr handle, string strValue, uint nValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_SetEnumValueByString(
    //      IntPtr handle,
    //      string strValue,
    //      string sValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_GetFloatValue(
    //      IntPtr handle,
    //      string strValue,
    //      ref MyCamera.MVCC_FLOATVALUE pFloatValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_SetFloatValue(IntPtr handle, string strValue, float fValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_GetBoolValue(
    //      IntPtr handle,
    //      string strValue,
    //      ref bool pBoolValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_SetBoolValue(IntPtr handle, string strValue, bool bValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_GetStringValue(
    //      IntPtr handle,
    //      string strKey,
    //      ref MyCamera.MVCC_STRINGVALUE pStringValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_SetStringValue(IntPtr handle, string strKey, string sValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_SetCommandValue(IntPtr handle, string strValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_InvalidateNodes(IntPtr handle);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_GetWidth(IntPtr handle, ref MyCamera.MVCC_INTVALUE pstValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_SetWidth(IntPtr handle, uint nValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_GetHeight(IntPtr handle, ref MyCamera.MVCC_INTVALUE pstValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_SetHeight(IntPtr handle, uint nValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_GetAOIoffsetX(
    //      IntPtr handle,
    //      ref MyCamera.MVCC_INTVALUE pstValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_SetAOIoffsetX(IntPtr handle, uint nValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_GetAOIoffsetY(
    //      IntPtr handle,
    //      ref MyCamera.MVCC_INTVALUE pstValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_SetAOIoffsetY(IntPtr handle, uint nValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_GetAutoExposureTimeLower(
    //      IntPtr handle,
    //      ref MyCamera.MVCC_INTVALUE pstValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_SetAutoExposureTimeLower(IntPtr handle, uint nValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_GetAutoExposureTimeUpper(
    //      IntPtr handle,
    //      ref MyCamera.MVCC_INTVALUE pstValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_SetAutoExposureTimeUpper(IntPtr handle, uint nValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_GetBrightness(
    //      IntPtr handle,
    //      ref MyCamera.MVCC_INTVALUE pstValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_SetBrightness(IntPtr handle, uint nValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_GetFrameRate(
    //      IntPtr handle,
    //      ref MyCamera.MVCC_FLOATVALUE pstValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_SetFrameRate(IntPtr handle, float fValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_GetGain(IntPtr handle, ref MyCamera.MVCC_FLOATVALUE pstValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_SetGain(IntPtr handle, float fValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_GetExposureTime(
    //      IntPtr handle,
    //      ref MyCamera.MVCC_FLOATVALUE pstValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_SetExposureTime(IntPtr handle, float fValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_GetPixelFormat(
    //      IntPtr handle,
    //      ref MyCamera.MVCC_ENUMVALUE pstValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_SetPixelFormat(IntPtr handle, uint nValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_GetAcquisitionMode(
    //      IntPtr handle,
    //      ref MyCamera.MVCC_ENUMVALUE pstValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_SetAcquisitionMode(IntPtr handle, uint nValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_GetGainMode(IntPtr handle, ref MyCamera.MVCC_ENUMVALUE pstValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_SetGainMode(IntPtr handle, uint nValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_GetExposureAutoMode(
    //      IntPtr handle,
    //      ref MyCamera.MVCC_ENUMVALUE pstValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_SetExposureAutoMode(IntPtr handle, uint nValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_GetTriggerMode(
    //      IntPtr handle,
    //      ref MyCamera.MVCC_ENUMVALUE pstValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_SetTriggerMode(IntPtr handle, uint nValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_GetTriggerDelay(
    //      IntPtr handle,
    //      ref MyCamera.MVCC_FLOATVALUE pstValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_SetTriggerDelay(IntPtr handle, float fValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_GetTriggerSource(
    //      IntPtr handle,
    //      ref MyCamera.MVCC_ENUMVALUE pstValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_SetTriggerSource(IntPtr handle, uint nValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_TriggerSoftwareExecute(IntPtr handle);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_GetGammaSelector(
    //      IntPtr handle,
    //      ref MyCamera.MVCC_ENUMVALUE pstValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_SetGammaSelector(IntPtr handle, uint nValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_GetGamma(IntPtr handle, ref MyCamera.MVCC_FLOATVALUE pstValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_SetGamma(IntPtr handle, float fValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_GetSharpness(IntPtr handle, ref MyCamera.MVCC_INTVALUE pstValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_SetSharpness(IntPtr handle, uint nValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_GetHue(IntPtr handle, ref MyCamera.MVCC_INTVALUE pstValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_SetHue(IntPtr handle, uint nValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_GetSaturation(
    //      IntPtr handle,
    //      ref MyCamera.MVCC_INTVALUE pstValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_SetSaturation(IntPtr handle, uint nValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_GetBalanceWhiteAuto(
    //      IntPtr handle,
    //      ref MyCamera.MVCC_ENUMVALUE pstValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_SetBalanceWhiteAuto(IntPtr handle, uint nValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_GetBalanceRatioRed(
    //      IntPtr handle,
    //      ref MyCamera.MVCC_INTVALUE pstValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_SetBalanceRatioRed(IntPtr handle, uint nValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_GetBalanceRatioGreen(
    //      IntPtr handle,
    //      ref MyCamera.MVCC_INTVALUE pstValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_SetBalanceRatioGreen(IntPtr handle, uint nValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_GetBalanceRatioBlue(
    //      IntPtr handle,
    //      ref MyCamera.MVCC_INTVALUE pstValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_SetBalanceRatioBlue(IntPtr handle, uint nValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_GetDeviceUserID(
    //      IntPtr handle,
    //      ref MyCamera.MVCC_STRINGVALUE pstValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_SetDeviceUserID(IntPtr handle, string chValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_GetBurstFrameCount(
    //      IntPtr handle,
    //      ref MyCamera.MVCC_INTVALUE pstValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_SetBurstFrameCount(IntPtr handle, uint nValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_GetAcquisitionLineRate(
    //      IntPtr handle,
    //      ref MyCamera.MVCC_INTVALUE pstValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_SetAcquisitionLineRate(IntPtr handle, uint nValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_GetHeartBeatTimeout(
    //      IntPtr handle,
    //      ref MyCamera.MVCC_INTVALUE pstValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_SetHeartBeatTimeout(IntPtr handle, uint nValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_LocalUpgrade(IntPtr handle, string pFilePathName);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_GetUpgradeProcess(IntPtr handle, ref uint pnProcess);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_GetOptimalPacketSize(IntPtr handle);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_ReadMemory(
    //      IntPtr handle,
    //      IntPtr pBuffer,
    //      long nAddress,
    //      long nLength);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_WriteMemory(
    //      IntPtr handle,
    //      IntPtr pBuffer,
    //      long nAddress,
    //      long nLength);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_RegisterExceptionCallBack(
    //      IntPtr handle,
    //      MyCamera.cbExceptiondelegate cbException,
    //      IntPtr pUser);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_RegisterEventCallBack(
    //      IntPtr handle,
    //      MyCamera.cbEventdelegate cbEvent,
    //      IntPtr pUser);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_RegisterAllEventCallBack(
    //      IntPtr handle,
    //      MyCamera.cbEventdelegateEx cbEvent,
    //      IntPtr pUser);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_RegisterEventCallBackEx(
    //      IntPtr handle,
    //      string pEventName,
    //      MyCamera.cbEventdelegateEx cbEvent,
    //      IntPtr pUser);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_GIGE_ForceIpEx(
    //      IntPtr handle,
    //      uint nIP,
    //      uint nSubNetMask,
    //      uint nDefaultGateWay);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_GIGE_SetIpConfig(IntPtr handle, uint nType);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_GIGE_SetNetTransMode(IntPtr handle, uint nType);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_GIGE_GetNetTransInfo(
    //      IntPtr handle,
    //      ref MyCamera.MV_NETTRANS_INFO pstInfo);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_GIGE_SetGvcpTimeout(IntPtr handle, uint nMillisec);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_GIGE_SetResend(
    //      IntPtr handle,
    //      uint bEnable,
    //      uint nMaxResendPercent,
    //      uint nResendTimeout);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_GIGE_GetGevSCPSPacketSize(
    //      IntPtr handle,
    //      ref MyCamera.MVCC_INTVALUE pstValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_GIGE_SetGevSCPSPacketSize(IntPtr handle, uint nValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_GIGE_GetGevSCPD(IntPtr handle, ref MyCamera.MVCC_INTVALUE pstValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_GIGE_SetGevSCPD(IntPtr handle, uint nValue);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_GIGE_GetGevSCDA(IntPtr handle, ref uint pnIP);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_GIGE_SetGevSCDA(IntPtr handle, uint nIP);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_GIGE_GetGevSCSP(IntPtr handle, ref uint pnPort);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_GIGE_SetGevSCSP(IntPtr handle, uint nPort);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_GIGE_SetTransmissionType(
    //      IntPtr handle,
    //      ref MyCamera.MV_CC_TRANSMISSION_TYPE pstTransmissionType);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_XML_GetGenICamXML(
    //      IntPtr handle,
    //      IntPtr pData,
    //      uint nDataSize,
    //      ref uint pnDataLen);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_XML_GetRootNode(
    //      IntPtr handle,
    //      ref MyCamera.MV_XML_NODE_FEATURE pstNode);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_XML_GetChildren(
    //      IntPtr handle,
    //      ref MyCamera.MV_XML_NODE_FEATURE pstNode,
    //      IntPtr pstNodesList);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_XML_GetChildren(
    //      IntPtr handle,
    //      ref MyCamera.MV_XML_NODE_FEATURE pstNode,
    //      ref MyCamera.MV_XML_NODES_LIST pstNodesList);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_XML_GetNodeFeature(
    //      IntPtr handle,
    //      ref MyCamera.MV_XML_NODE_FEATURE pstNode,
    //      IntPtr pstFeature);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_XML_UpdateNodeFeature(
    //      IntPtr handle,
    //      MyCamera.MV_XML_InterfaceType enType,
    //      IntPtr pstFeature);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_XML_RegisterUpdateCallBack(
    //      IntPtr handle,
    //      MyCamera.cbXmlUpdatedelegate cbXmlUpdate,
    //      IntPtr pUser);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_SaveImageEx2(
    //      IntPtr handle,
    //      ref MyCamera.MV_SAVE_IMAGE_PARAM_EX stSaveParam);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_ConvertPixelType(
    //      IntPtr handle,
    //      ref MyCamera.MV_PIXEL_CONVERT_PARAM pstCvtParam);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_SetBayerCvtQuality(IntPtr handle, uint BayerCvtQuality);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern IntPtr MV_CC_GetTlProxy(IntPtr handle);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_FeatureSave(IntPtr handle, string pFileName);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_FeatureLoad(IntPtr handle, string pFileName);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_FileAccessRead(
    //      IntPtr handle,
    //      ref MyCamera.MV_CC_FILE_ACCESS pstFileAccess);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_FileAccessWrite(
    //      IntPtr handle,
    //      ref MyCamera.MV_CC_FILE_ACCESS pstFileAccess);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_GetFileAccessProgress(
    //      IntPtr handle,
    //      ref MyCamera.MV_CC_FILE_ACCESS_PROGRESS pstFileAccessProgress);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_GetOneFrame(
    //      IntPtr handle,
    //      IntPtr pData,
    //      uint nDataSize,
    //      ref MyCamera.MV_FRAME_OUT_INFO pFrameInfo);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_GetOneFrameEx(
    //      IntPtr handle,
    //      IntPtr pData,
    //      uint nDataSize,
    //      ref MyCamera.MV_FRAME_OUT_INFO_EX pFrameInfo);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_RegisterImageCallBack(
    //      IntPtr handle,
    //      MyCamera.cbOutputdelegate cbOutput,
    //      IntPtr pUser);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_CC_SaveImage(ref MyCamera.MV_SAVE_IMAGE_PARAM stSaveParam);

    //    [DllImport("MvCameraControl.dll")]
    //    private static extern int MV_GIGE_ForceIp(IntPtr handle, uint nIP);

    //    public delegate void cbOutputdelegate(
    //      IntPtr pData,
    //      ref MyCamera.MV_FRAME_OUT_INFO pFrameInfo,
    //      IntPtr pUser);

    //    public delegate void cbOutputExdelegate(
    //      IntPtr pData,
    //      ref MyCamera.MV_FRAME_OUT_INFO_EX pFrameInfo,
    //      IntPtr pUser);

    //    public delegate void cbXmlUpdatedelegate(
    //      MyCamera.MV_XML_InterfaceType enType,
    //      IntPtr pstFeature,
    //      ref MyCamera.MV_XML_NODES_LIST pstNodesList,
    //      IntPtr pUser);

    //    public delegate void cbExceptiondelegate(uint nMsgType, IntPtr pUser);

    //    public delegate void cbEventdelegate(uint nUserDefinedId, IntPtr pUser);

    //    public delegate void cbEventdelegateEx(ref MyCamera.MV_EVENT_OUT_INFO pEventInfo, IntPtr pUser);

    //    public struct MV_GIGE_DEVICE_INFO
    //    {
    //        public uint nIpCfgOption;
    //        public uint nIpCfgCurrent;
    //        public uint nCurrentIp;
    //        public uint nCurrentSubNetMask;
    //        public uint nDefultGateWay;
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
    //        public string chManufacturerName;
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
    //        public string chModelName;
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
    //        public string chDeviceVersion;
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 48)]
    //        public string chManufacturerSpecificInfo;
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
    //        public string chSerialNumber;
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
    //        public string chUserDefinedName;
    //        public uint nNetExport;
    //        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    //        public uint[] nReserved;
    //    }

    //    public struct MV_USB3_DEVICE_INFO
    //    {
    //        public byte CrtlInEndPoint;
    //        public byte CrtlOutEndPoint;
    //        public byte StreamEndPoint;
    //        public byte EventEndPoint;
    //        public ushort idVendor;
    //        public ushort idProduct;
    //        public uint nDeviceNumber;
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
    //        public string chDeviceGUID;
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
    //        public string chVendorName;
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
    //        public string chModelName;
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
    //        public string chFamilyName;
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
    //        public string chDeviceVersion;
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
    //        public string chManufacturerName;
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
    //        public string chSerialNumber;
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
    //        public string chUserDefinedName;
    //        public uint nbcdUSB;
    //        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
    //        public uint[] nReserved;
    //    }

    //    public struct MV_CC_DEVICE_INFO
    //    {
    //        public ushort nMajorVer;
    //        public ushort nMinorVer;
    //        public uint nMacAddrHigh;
    //        public uint nMacAddrLow;
    //        public uint nTLayerType;
    //        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    //        public uint[] nReserved;
    //        public MyCamera.MV_CC_DEVICE_INFO.SPECIAL_INFO SpecialInfo;

    //        [StructLayout(LayoutKind.Explicit, Size = 540)]
    //        public struct SPECIAL_INFO
    //        {
    //            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 216)]
    //            [FieldOffset(0)]
    //            public byte[] stGigEInfo;
    //            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 540)]
    //            [FieldOffset(0)]
    //            public byte[] stUsb3VInfo;
    //        }
    //    }

    //    public struct MV_CC_DEVICE_INFO_LIST
    //    {
    //        public uint nDeviceNum;
    //        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
    //        public IntPtr[] pDeviceInfo;
    //    }

    //    public struct MV_NETTRANS_INFO
    //    {
    //        public long nReviceDataSize;
    //        public int nThrowFrameCount;
    //        public uint nNetRecvFrameCount;
    //        public long nRequestResendPacketCount;
    //        public long nResendPacketCount;
    //    }

    //    public struct MV_FRAME_OUT_INFO
    //    {
    //        public ushort nWidth;
    //        public ushort nHeight;
    //        public MyCamera.MvGvspPixelType enPixelType;
    //        public uint nFrameNum;
    //        public uint nDevTimeStampHigh;
    //        public uint nDevTimeStampLow;
    //        public uint nReserved0;
    //        public long nHostTimeStamp;
    //        public uint nFrameLen;
    //        public uint nLostPacket;
    //        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
    //        public uint[] nReserved;
    //    }

    //    public struct MV_FRAME_OUT_INFO_EX
    //    {
    //        public ushort nWidth;
    //        public ushort nHeight;
    //        public MyCamera.MvGvspPixelType enPixelType;
    //        public uint nFrameNum;
    //        public uint nDevTimeStampHigh;
    //        public uint nDevTimeStampLow;
    //        public uint nReserved0;
    //        public long nHostTimeStamp;
    //        public uint nFrameLen;
    //        public uint nSecondCount;
    //        public uint nCycleCount;
    //        public uint nCycleOffset;
    //        public float fGain;
    //        public float fExposureTime;
    //        public uint nAverageBrightness;
    //        public uint nRed;
    //        public uint nGreen;
    //        public uint nBlue;
    //        public uint nFrameCounter;
    //        public uint nTriggerIndex;
    //        public uint nInput;
    //        public uint nOutput;
    //        public ushort nOffsetX;
    //        public ushort nOffsetY;
    //        public ushort nChunkWidth;
    //        public ushort nChunkHeight;
    //        public uint nLostPacket;
    //        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 39)]
    //        public uint[] nReserved;
    //    }

    //    public struct MV_FRAME_OUT
    //    {
    //        public IntPtr pBufAddr;
    //        public MyCamera.MV_FRAME_OUT_INFO_EX stFrameInfo;
    //        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
    //        public uint[] nReserved;
    //    }

    //    public struct MV_DISPLAY_FRAME_INFO
    //    {
    //        public IntPtr hWnd;
    //        public IntPtr pData;
    //        public uint nDataLen;
    //        public ushort nWidth;
    //        public ushort nHeight;
    //        public MyCamera.MvGvspPixelType enPixelType;
    //        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    //        public uint[] nReserved;
    //    }

    //    public enum MV_SAVE_IAMGE_TYPE
    //    {
    //        MV_Image_Undefined,
    //        MV_Image_Bmp,
    //        MV_Image_Jpeg,
    //        MV_Image_Png,
    //        MV_Image_Tif,
    //    }

    //    public struct MV_SAVE_IMAGE_PARAM
    //    {
    //        public IntPtr pData;
    //        public uint nDataLen;
    //        public MyCamera.MvGvspPixelType enPixelType;
    //        public ushort nWidth;
    //        public ushort nHeight;
    //        public IntPtr pImageBuffer;
    //        public uint nImageLen;
    //        public uint nBufferSize;
    //        public MyCamera.MV_SAVE_IAMGE_TYPE enImageType;
    //    }

    //    public struct MV_SAVE_IMAGE_PARAM_EX
    //    {
    //        public IntPtr pData;
    //        public uint nDataLen;
    //        public MyCamera.MvGvspPixelType enPixelType;
    //        public ushort nWidth;
    //        public ushort nHeight;
    //        public IntPtr pImageBuffer;
    //        public uint nImageLen;
    //        public uint nBufferSize;
    //        public MyCamera.MV_SAVE_IAMGE_TYPE enImageType;
    //        public uint nJpgQuality;
    //        public uint iMethodValue;
    //        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
    //        public uint[] nReserved;
    //    }

    //    public struct MV_PIXEL_CONVERT_PARAM
    //    {
    //        public ushort nWidth;
    //        public ushort nHeight;
    //        public MyCamera.MvGvspPixelType enSrcPixelType;
    //        public IntPtr pSrcData;
    //        public uint nSrcDataLen;
    //        public MyCamera.MvGvspPixelType enDstPixelType;
    //        public IntPtr pDstBuffer;
    //        public uint nDstLen;
    //        public uint nDstBufferSize;
    //        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    //        public uint[] nRes;
    //    }

    //    public enum MV_CAM_ACQUISITION_MODE
    //    {
    //        MV_ACQ_MODE_SINGLE,
    //        MV_ACQ_MODE_MUTLI,
    //        MV_ACQ_MODE_CONTINUOUS,
    //    }

    //    public enum MV_CAM_GAIN_MODE
    //    {
    //        MV_GAIN_MODE_OFF,
    //        MV_GAIN_MODE_ONCE,
    //        MV_GAIN_MODE_CONTINUOUS,
    //    }

    //    public enum MV_CAM_EXPOSURE_MODE
    //    {
    //        MV_EXPOSURE_MODE_TIMED,
    //        MV_EXPOSURE_MODE_TRIGGER_WIDTH,
    //    }

    //    public enum MV_CAM_EXPOSURE_AUTO_MODE
    //    {
    //        MV_EXPOSURE_AUTO_MODE_OFF,
    //        MV_EXPOSURE_AUTO_MODE_ONCE,
    //        MV_EXPOSURE_AUTO_MODE_CONTINUOUS,
    //    }

    //    public enum MV_CAM_TRIGGER_MODE
    //    {
    //        MV_TRIGGER_MODE_OFF,
    //        MV_TRIGGER_MODE_ON,
    //    }

    //    public enum MV_CAM_GAMMA_SELECTOR
    //    {
    //        MV_GAMMA_SELECTOR_USER = 1,
    //        MV_GAMMA_SELECTOR_SRGB = 2,
    //    }

    //    public enum MV_CAM_BALANCEWHITE_AUTO
    //    {
    //        MV_BALANCEWHITE_AUTO_OFF,
    //        MV_BALANCEWHITE_AUTO_CONTINUOUS,
    //        MV_BALANCEWHITE_AUTO_ONCE,
    //    }

    //    public enum MV_CAM_TRIGGER_SOURCE
    //    {
    //        MV_TRIGGER_SOURCE_LINE0 = 0,
    //        MV_TRIGGER_SOURCE_LINE1 = 1,
    //        MV_TRIGGER_SOURCE_LINE2 = 2,
    //        MV_TRIGGER_SOURCE_LINE3 = 3,
    //        MV_TRIGGER_SOURCE_COUNTER0 = 4,
    //        MV_TRIGGER_SOURCE_SOFTWARE = 7,
    //        MV_TRIGGER_SOURCE_FrequencyConverter = 8,
    //    }

    //    public enum MV_GIGE_TRANSMISSION_TYPE
    //    {
    //        MV_GIGE_TRANSTYPE_UNICAST = 0,
    //        MV_GIGE_TRANSTYPE_MULTICAST = 1,
    //        MV_GIGE_TRANSTYPE_LIMITEDBROADCAST = 2,
    //        MV_GIGE_TRANSTYPE_SUBNETBROADCAST = 3,
    //        MV_GIGE_TRANSTYPE_CAMERADEFINED = 4,
    //        MV_GIGE_TRANSTYPE_UNICAST_DEFINED_PORT = 5,
    //        MV_GIGE_TRANSTYPE_UNICAST_WITHOUT_RECV = 65536, // 0x00010000
    //        MV_GIGE_TRANSTYPE_MULTICAST_WITHOUT_RECV = 65537, // 0x00010001
    //    }

    //    public struct MV_ALL_MATCH_INFO
    //    {
    //        public uint nType;
    //        public IntPtr pInfo;
    //        public uint nInfoSize;
    //    }

    //    public struct MV_MATCH_INFO_NET_DETECT
    //    {
    //        public long nReviceDataSize;
    //        public long nLostPacketCount;
    //        public uint nLostFrameCount;
    //        public uint nNetRecvFrameCount;
    //        public long nRequestResendPacketCount;
    //        public long nResendPacketCount;
    //    }

    //    public struct MV_MATCH_INFO_USB_DETECT
    //    {
    //        public long nReviceDataSize;
    //        public uint nRevicedFrameCount;
    //        public uint nErrorFrameCount;
    //        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
    //        public uint[] nReserved;
    //    }

    //    public struct MV_IMAGE_BASIC_INFO
    //    {
    //        public ushort nWidthValue;
    //        public ushort nWidthMin;
    //        public uint nWidthMax;
    //        public uint nWidthInc;
    //        public uint nHeightValue;
    //        public uint nHeightMin;
    //        public uint nHeightMax;
    //        public uint nHeightInc;
    //        public float fFrameRateValue;
    //        public float fFrameRateMin;
    //        public float fFrameRateMax;
    //        public uint enPixelType;
    //        public uint nSupportedPixelFmtNum;
    //        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
    //        public uint[] enPixelList;
    //        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
    //        public uint[] nReserved;
    //    }

    //    public enum MV_XML_InterfaceType
    //    {
    //        IFT_IValue,
    //        IFT_IBase,
    //        IFT_IInteger,
    //        IFT_IBoolean,
    //        IFT_ICommand,
    //        IFT_IFloat,
    //        IFT_IString,
    //        IFT_IRegister,
    //        IFT_ICategory,
    //        IFT_IEnumeration,
    //        IFT_IEnumEntry,
    //        IFT_IPort,
    //    }

    //    public enum MV_XML_AccessMode
    //    {
    //        AM_NI,
    //        AM_NA,
    //        AM_WO,
    //        AM_RO,
    //        AM_RW,
    //        AM_Undefined,
    //        AM_CycleDetect,
    //    }

    //    public enum MV_XML_Visibility
    //    {
    //        V_Beginner = 0,
    //        V_Expert = 1,
    //        V_Guru = 2,
    //        V_Invisible = 3,
    //        V_Undefined = 99, // 0x00000063
    //    }

    //    public struct MV_EVENT_OUT_INFO
    //    {
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
    //        public string EventName;
    //        public ushort nEventID;
    //        public ushort nStreamChannel;
    //        public uint nBlockIdHigh;
    //        public uint nBlockIdLow;
    //        public uint nTimestampHigh;
    //        public uint nTimestampLow;
    //        public IntPtr pEventData;
    //        public uint nEventDataSize;
    //        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
    //        public uint[] nReserved;
    //    }

    //    public struct MV_CC_FILE_ACCESS
    //    {
    //        public string pUserFileName;
    //        public string pDevFileName;
    //        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
    //        public uint[] nReserved;
    //    }

    //    public struct MV_CC_FILE_ACCESS_PROGRESS
    //    {
    //        public long nCompleted;
    //        public long nTotal;
    //        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
    //        public uint[] nReserved;
    //    }

    //    public struct MV_CC_TRANSMISSION_TYPE
    //    {
    //        public MyCamera.MV_GIGE_TRANSMISSION_TYPE enTransmissionType;
    //        public uint nDestIp;
    //        public ushort nDestPort;
    //        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
    //        public uint[] nReserved;
    //    }

    //    public struct MV_XML_NODE_FEATURE
    //    {
    //        public MyCamera.MV_XML_InterfaceType enType;
    //        public MyCamera.MV_XML_Visibility enVisivility;
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
    //        public string strDescription;
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
    //        public string strDisplayName;
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
    //        public string strName;
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
    //        public string strToolTip;
    //        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    //        public uint[] nReserved;
    //    }

    //    public struct MV_XML_NODES_LIST
    //    {
    //        public uint nNodeNum;
    //        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
    //        public MyCamera.MV_XML_NODE_FEATURE[] stNodes;
    //    }

    //    public struct MVCC_INTVALUE
    //    {
    //        public uint nCurValue;
    //        public uint nMax;
    //        public uint nMin;
    //        public uint nInc;
    //        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    //        public uint[] nReserved;
    //    }

    //    public struct MVCC_INTVALUE_EX
    //    {
    //        public long nCurValue;
    //        public long nMax;
    //        public long nMin;
    //        public long nInc;
    //        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
    //        public uint[] nReserved;
    //    }

    //    public struct MVCC_FLOATVALUE
    //    {
    //        public float fCurValue;
    //        public float fMax;
    //        public float fMin;
    //        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    //        public uint[] nReserved;
    //    }

    //    public struct MVCC_ENUMVALUE
    //    {
    //        public uint nCurValue;
    //        public uint nSupportedNum;
    //        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
    //        public uint[] nSupportValue;
    //        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    //        public uint[] nReserved;
    //    }

    //    public struct MVCC_STRINGVALUE
    //    {
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
    //        public string chCurValue;
    //        public long nMaxLength;
    //        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
    //        public uint[] nReserved;
    //    }

    //    public struct MV_XML_FEATURE_Integer
    //    {
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
    //        public string strName;
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
    //        public string strDisplayName;
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
    //        public string strDescription;
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
    //        public string strToolTip;
    //        public MyCamera.MV_XML_Visibility enVisivility;
    //        public MyCamera.MV_XML_AccessMode enAccessMode;
    //        public int bIsLocked;
    //        public long nValue;
    //        public long nMinValue;
    //        public long nMaxValue;
    //        public long nIncrement;
    //        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    //        public uint[] nReserved;
    //    }

    //    public struct MV_XML_FEATURE_Boolean
    //    {
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
    //        public string strName;
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
    //        public string strDisplayName;
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
    //        public string strDescription;
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
    //        public string strToolTip;
    //        public MyCamera.MV_XML_Visibility enVisivility;
    //        public MyCamera.MV_XML_AccessMode enAccessMode;
    //        public int bIsLocked;
    //        public bool bValue;
    //        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    //        public uint[] nReserved;
    //    }

    //    public struct MV_XML_FEATURE_Command
    //    {
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
    //        public string strName;
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
    //        public string strDisplayName;
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
    //        public string strDescription;
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
    //        public string strToolTip;
    //        public MyCamera.MV_XML_Visibility enVisivility;
    //        public MyCamera.MV_XML_AccessMode enAccessMode;
    //        public int bIsLocked;
    //        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    //        public uint[] nReserved;
    //    }

    //    public struct MV_XML_FEATURE_Float
    //    {
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
    //        public string strName;
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
    //        public string strDisplayName;
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
    //        public string strDescription;
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
    //        public string strToolTip;
    //        public MyCamera.MV_XML_Visibility enVisivility;
    //        public MyCamera.MV_XML_AccessMode enAccessMode;
    //        public int bIsLocked;
    //        public double dfValue;
    //        public double dfMinValue;
    //        public double dfMaxValue;
    //        public double dfIncrement;
    //        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    //        public uint[] nReserved;
    //    }

    //    public struct MV_XML_FEATURE_String
    //    {
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
    //        public string strName;
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
    //        public string strDisplayName;
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
    //        public string strDescription;
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
    //        public string strToolTip;
    //        public MyCamera.MV_XML_Visibility enVisivility;
    //        public MyCamera.MV_XML_AccessMode enAccessMode;
    //        public int bIsLocked;
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
    //        public string strValue;
    //        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    //        public uint[] nReserved;
    //    }

    //    public struct MV_XML_FEATURE_Register
    //    {
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
    //        public string strName;
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
    //        public string strDisplayName;
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
    //        public string strDescription;
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
    //        public string strToolTip;
    //        public MyCamera.MV_XML_Visibility enVisivility;
    //        public MyCamera.MV_XML_AccessMode enAccessMode;
    //        public int bIsLocked;
    //        public long nAddrValue;
    //        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    //        public uint[] nReserved;
    //    }

    //    public struct MV_XML_FEATURE_Category
    //    {
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
    //        public string strDescription;
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
    //        public string strDisplayName;
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
    //        public string strName;
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
    //        public string strToolTip;
    //        public MyCamera.MV_XML_Visibility enVisivility;
    //        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    //        public uint[] nReserved;
    //    }

    //    public struct MV_XML_FEATURE_EnumEntry
    //    {
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
    //        public string strName;
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
    //        public string strDisplayName;
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
    //        public string strDescription;
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
    //        public string strToolTip;
    //        public int bIsImplemented;
    //        public int nParentsNum;
    //        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
    //        public MyCamera.MV_XML_NODE_FEATURE[] stParentsList;
    //        public MyCamera.MV_XML_Visibility enVisivility;
    //        public long nValue;
    //        public MyCamera.MV_XML_AccessMode enAccessMode;
    //        public int bIsLocked;
    //        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
    //        public uint[] nReserved;
    //    }

    //    public struct StrSymbolic
    //    {
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
    //        public string str;
    //    }

    //    public struct MV_XML_FEATURE_Enumeration
    //    {
    //        public MyCamera.MV_XML_Visibility enVisivility;
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
    //        public string strDescription;
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
    //        public string strDisplayName;
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
    //        public string strName;
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
    //        public string strToolTip;
    //        public int nSymbolicNum;
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
    //        public string strCurrentSymbolic;
    //        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
    //        public string[] strSymbolic;
    //        public MyCamera.MV_XML_AccessMode enAccessMode;
    //        public int bIsLocked;
    //        public long nValue;
    //        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    //        public uint[] nReserved;
    //    }

    //    public struct MV_XML_FEATURE_Port
    //    {
    //        public MyCamera.MV_XML_Visibility enVisivility;
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
    //        public string strDescription;
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
    //        public string strDisplayName;
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
    //        public string strName;
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
    //        public string strToolTip;
    //        public MyCamera.MV_XML_AccessMode enAccessMode;
    //        public int bIsLocked;
    //        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    //        public uint[] nReserved;
    //    }

    //    public enum MvGvspPixelType
    //    {
    //        PixelType_Gvsp_Jpeg = -2145124351, // -0x7FDBFFFF
    //        PixelType_Gvsp_COORD3D_DEPTH_PLUS_MASK = -2111307775, // -0x7DD7FFFF
    //        PixelType_Gvsp_Undefined = -1,
    //        PixelType_Gvsp_Mono1p = 16842807, // 0x01010037
    //        PixelType_Gvsp_Mono2p = 16908344, // 0x01020038
    //        PixelType_Gvsp_Mono4p = 17039417, // 0x01040039
    //        PixelType_Gvsp_Mono8 = 17301505, // 0x01080001
    //        PixelType_Gvsp_Mono8_Signed = 17301506, // 0x01080002
    //        PixelType_Gvsp_BayerGR8 = 17301512, // 0x01080008
    //        PixelType_Gvsp_BayerRG8 = 17301513, // 0x01080009
    //        PixelType_Gvsp_BayerGB8 = 17301514, // 0x0108000A
    //        PixelType_Gvsp_BayerBG8 = 17301515, // 0x0108000B
    //        PixelType_Gvsp_Mono10_Packed = 17563652, // 0x010C0004
    //        PixelType_Gvsp_Mono12_Packed = 17563654, // 0x010C0006
    //        PixelType_Gvsp_BayerGR10_Packed = 17563686, // 0x010C0026
    //        PixelType_Gvsp_BayerRG10_Packed = 17563687, // 0x010C0027
    //        PixelType_Gvsp_BayerGB10_Packed = 17563688, // 0x010C0028
    //        PixelType_Gvsp_BayerBG10_Packed = 17563689, // 0x010C0029
    //        PixelType_Gvsp_BayerGR12_Packed = 17563690, // 0x010C002A
    //        PixelType_Gvsp_BayerRG12_Packed = 17563691, // 0x010C002B
    //        PixelType_Gvsp_BayerGB12_Packed = 17563692, // 0x010C002C
    //        PixelType_Gvsp_BayerBG12_Packed = 17563693, // 0x010C002D
    //        PixelType_Gvsp_Mono10 = 17825795, // 0x01100003
    //        PixelType_Gvsp_Mono12 = 17825797, // 0x01100005
    //        PixelType_Gvsp_Mono16 = 17825799, // 0x01100007
    //        PixelType_Gvsp_BayerGR10 = 17825804, // 0x0110000C
    //        PixelType_Gvsp_BayerRG10 = 17825805, // 0x0110000D
    //        PixelType_Gvsp_BayerGB10 = 17825806, // 0x0110000E
    //        PixelType_Gvsp_BayerBG10 = 17825807, // 0x0110000F
    //        PixelType_Gvsp_BayerGR12 = 17825808, // 0x01100010
    //        PixelType_Gvsp_BayerRG12 = 17825809, // 0x01100011
    //        PixelType_Gvsp_BayerGB12 = 17825810, // 0x01100012
    //        PixelType_Gvsp_BayerBG12 = 17825811, // 0x01100013
    //        PixelType_Gvsp_Mono14 = 17825829, // 0x01100025
    //        PixelType_Gvsp_BayerGR16 = 17825838, // 0x0110002E
    //        PixelType_Gvsp_BayerRG16 = 17825839, // 0x0110002F
    //        PixelType_Gvsp_BayerGB16 = 17825840, // 0x01100030
    //        PixelType_Gvsp_BayerBG16 = 17825841, // 0x01100031
    //        PixelType_Gvsp_YUV411_Packed = 34340894, // 0x020C001E
    //        PixelType_Gvsp_YCBCR411_8_CBYYCRYY = 34340924, // 0x020C003C
    //        PixelType_Gvsp_YCBCR601_411_8_CBYYCRYY = 34340927, // 0x020C003F
    //        PixelType_Gvsp_YCBCR709_411_8_CBYYCRYY = 34340930, // 0x020C0042
    //        PixelType_Gvsp_YUV422_Packed = 34603039, // 0x0210001F
    //        PixelType_Gvsp_YUV422_YUYV_Packed = 34603058, // 0x02100032
    //        PixelType_Gvsp_RGB565_Packed = 34603061, // 0x02100035
    //        PixelType_Gvsp_BGR565_Packed = 34603062, // 0x02100036
    //        PixelType_Gvsp_YCBCR422_8 = 34603067, // 0x0210003B
    //        PixelType_Gvsp_YCBCR601_422_8 = 34603070, // 0x0210003E
    //        PixelType_Gvsp_YCBCR709_422_8 = 34603073, // 0x02100041
    //        PixelType_Gvsp_YCBCR422_8_CBYCRY = 34603075, // 0x02100043
    //        PixelType_Gvsp_YCBCR601_422_8_CBYCRY = 34603076, // 0x02100044
    //        PixelType_Gvsp_YCBCR709_422_8_CBYCRY = 34603077, // 0x02100045
    //        PixelType_Gvsp_RGB8_Packed = 35127316, // 0x02180014
    //        PixelType_Gvsp_BGR8_Packed = 35127317, // 0x02180015
    //        PixelType_Gvsp_YUV444_Packed = 35127328, // 0x02180020
    //        PixelType_Gvsp_RGB8_Planar = 35127329, // 0x02180021
    //        PixelType_Gvsp_YCBCR8_CBYCR = 35127354, // 0x0218003A
    //        PixelType_Gvsp_YCBCR601_8_CBYCR = 35127357, // 0x0218003D
    //        PixelType_Gvsp_YCBCR709_8_CBYCR = 35127360, // 0x02180040
    //        PixelType_Gvsp_RGBA8_Packed = 35651606, // 0x02200016
    //        PixelType_Gvsp_BGRA8_Packed = 35651607, // 0x02200017
    //        PixelType_Gvsp_RGB10V1_Packed = 35651612, // 0x0220001C
    //        PixelType_Gvsp_RGB10V2_Packed = 35651613, // 0x0220001D
    //        PixelType_Gvsp_RGB12V1_Packed = 35913780, // 0x02240034
    //        PixelType_Gvsp_RGB10_Packed = 36700184, // 0x02300018
    //        PixelType_Gvsp_BGR10_Packed = 36700185, // 0x02300019
    //        PixelType_Gvsp_RGB12_Packed = 36700186, // 0x0230001A
    //        PixelType_Gvsp_BGR12_Packed = 36700187, // 0x0230001B
    //        PixelType_Gvsp_RGB10_Planar = 36700194, // 0x02300022
    //        PixelType_Gvsp_RGB12_Planar = 36700195, // 0x02300023
    //        PixelType_Gvsp_RGB16_Planar = 36700196, // 0x02300024
    //        PixelType_Gvsp_RGB16_Packed = 36700211, // 0x02300033
    //        PixelType_Gvsp_Coord3D_AC32f = 37748930, // 0x024000C2
    //        PixelType_Gvsp_Coord3D_ABC32f = 43385024, // 0x029600C0
    //        PixelType_Gvsp_Coord3D_ABC32f_Planar = 43385025, // 0x029600C1
    //    }
    //}
}
