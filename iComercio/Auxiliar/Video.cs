using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Drawing;
using System.Windows.Forms;
  

namespace iComercio.Auxiliar
{
    public class Video
    {
        private bool DeviceExist = false;
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource = null;
        private PictureBox pcb;
       
        //public void DeviceSet()
        //{

        //}

        public List<string> getListaCamara()
        {
            List<string> devices = null;
            try
            {
                
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                if (videoDevices.Count == 0)
                {
                    throw new VideoException("No Existen dispositivos para capturar imagenes");
                    //MessageBox.Show("No Existen dispositivos para capturar imagenes");                   
                }
                    

                devices = new List<string>();
               // DeviceExist = true;
                foreach (FilterInfo device in videoDevices)
                {
                    devices.Add(device.Name);
                }
            }
            catch (ApplicationException)
            {
                DeviceExist = false;
                throw;
            }
            return devices;
        }


        //close the device safely
        public void Cerrar()
        {
            if (!(videoSource == null))
                if (videoSource.IsRunning)
                {
                    videoSource.SignalToStop();
                    videoSource = null;
                }
        }

        public void IniciarDispositivo(int DeviceID,NewFrameEventHandler FrameEventHandler)
        {
            getListaCamara();
            FilterInfo vd = videoDevices[DeviceID];
            if (vd != null)
            //if (DeviceExist)
                {
                    videoSource = new VideoCaptureDevice(videoDevices[DeviceID].MonikerString);
                    //videoSource.NewFrame += new NewFrameEventHandler(VideoNewFrame);
                    videoSource.NewFrame += FrameEventHandler;
                    Cerrar();
                    //videoSource.DesiredFrameSize = new Size(160, 120);
                    videoSource.VideoResolution = videoSource.VideoCapabilities[0];
                   //videoSource.DesiredFrameRate = 10;
                    videoSource.Start();
                }
                else
                {
                     throw new VideoException("No hay dispositivo seleccionado");
                }
        }

        public VideoCapabilities[] VideoCapabilities()
        {
            return videoSource.VideoCapabilities;
        }

        public void SetVideoCapabilities(VideoCapabilities vc)
        {
            if (videoSource != null)
                videoSource.VideoResolution = vc;
        }

        //eventhandler if new frame is ready
        private void VideoNewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap img = (Bitmap)eventArgs.Frame.Clone();
            //do processing here
            pcb.Image = img;
        }

    }


    public class VideoException:ApplicationException
    {

        public VideoException()
        : base() { }
       
        public VideoException(string message)
        : base(message) { }

        public VideoException(string format, params object[] args)
        : base(string.Format(format, args)) { }
    
        public VideoException(string message, Exception innerException)
        : base(message, innerException) { }

        public VideoException(string format, Exception innerException, params object[] args)
        : base(string.Format(format, args), innerException) { }
    }
}
