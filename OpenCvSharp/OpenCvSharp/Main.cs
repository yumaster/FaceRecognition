using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenCvSharp
{
    public partial class Main : Form
    {
        public static bool bPlayflag = false;
        public static VideoCapture m_vCapture;
        public static Thread ThreadCam;
        public static bool bTakePicture = false;
        public static string PicSavePath = @"E:\ZHANGYU.JPG";
        public Main()
        {
            InitializeComponent();
        }
        //打开摄像头
        private void btn_play_Click(object sender, EventArgs e)
        {
            if(!bPlayflag)
            {
                m_vCapture = new VideoCapture(CaptureDevice.Any);
                if(!m_vCapture.IsOpened())
                {
                    MessageBox.Show("摄像头打不开", "摄像头故障", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                m_vCapture.Set(CaptureProperty.FrameWidth, 640);//宽度
                m_vCapture.Set(CaptureProperty.FrameHeight, 480);//高度

                bPlayflag = true;
                ThreadCam = new Thread(Play_Camera);
                ThreadCam.Start();
                pic_cam.Image = null;
                btn_play.Text = "关闭摄像头";
            }else
            {
                bPlayflag = false;
                ThreadCam.Abort();
                m_vCapture.Release();
                btn_play.Text = "打开摄像头";
            }
        }
        /// <summary>
        /// 播放摄像头线程
        /// </summary>
        private void Play_Camera()
        {
            while(bPlayflag)
            {
                //Thread.Sleep(40);
                Mat cFrame = new Mat();
                m_vCapture.Read(cFrame);
                int sleepTime = (int)Math.Round(1000 / m_vCapture.Fps);
                Cv2.WaitKey(sleepTime);
                if(cFrame.Empty())
                {
                    continue;
                }
                Cv2.Flip(cFrame, cFrame, OpenCvSharp.FlipMode.Y);
                Rect cMaxrect = new Rect(170, 90, 150, 150);
                if(bTakePicture)//拍照，截取指定区域
                {
                    Mat cHead = new Mat(cFrame, cMaxrect);
                    Cv2.ImWrite(PicSavePath, cHead);
                    SetPictureBoxImage(pic_head, cHead.ToBitmap());
                    cHead.Release();
                    bTakePicture = false;
                }
                //绘制指定区域(人脸框)
                Scalar color = new Scalar(0, 100, 0);
                Cv2.Rectangle(cFrame, cMaxrect, color, 2);

                SetPictureBoxImage(pic_cam, cFrame.ToBitmap());

                cFrame.Release();//释放   
            }
        }

        private void SetPictureBoxImage(PictureBox pic, Bitmap bitmap)
        {
            //throw new NotImplementedException();
            pic.Image = bitmap;
        }

        private void btn_cam_Click(object sender, EventArgs e)
        {
            bTakePicture = true;
        }
    }
}
