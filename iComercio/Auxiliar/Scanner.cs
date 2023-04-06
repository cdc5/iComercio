using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIA;

namespace iComercio.Auxiliar
{
    public class Scanner
    {
        private readonly DeviceInfo _deviceInfo;

        public Scanner(DeviceInfo deviceInfo)
        {
            this._deviceInfo = deviceInfo;
        }

        //Scanear desde gestor de scan del scaner, permite seleccionar el scaner a utilizar en el momento
        public static ImageFile Scan()
        {
            try
            {
                WIA.CommonDialog a = new WIA.CommonDialog();
                //a.ShowSelectDevice(WiaDeviceType.ScannerDeviceType);
                //a.ShowDeviceProperties(device);
                //var d = a.ShowAcquisitionWizard(device);
                //   var b = a.ShowTransfer(item);
                var c = a.ShowAcquireImage(WiaDeviceType.ScannerDeviceType, WiaImageIntent.UnspecifiedIntent,
                                          WiaImageBias.MaximizeQuality, FormatID.wiaFormatJPEG, true, true, true);
                return c;
            }
            catch (System.Runtime.InteropServices.COMException comEx)
            {
                if (comEx.ErrorCode == -2145320860)
                {
                    //No quiero que se haga nada
                }
            }
            return null;
        }

        //Scanear desde un device seleccionado, hay que seleccionar un dispositivo antes para escanear
        public ImageFile ScanFromDevice()
        {
           var device = this._deviceInfo.Connect();
           var item = device.Items[1];
           var imageFile = (ImageFile)item.Transfer(FormatID.wiaFormatJPEG);
           return imageFile;            
        }

        public override string ToString()
        {
            return this._deviceInfo.Properties["Name"].get_Value().ToString();
        }
    }
}
