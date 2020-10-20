using ArcFaceSharp;
using ArcFaceSharp.ArcFace;
using ArcFaceSharp.Image;
using ArcFaceSharp.Model;
using ArcSoftFace.Utils;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;


namespace OpenCvSharpV4
{
    public partial class Main : Form
    {
        private static bool bPlayflag = false;
        private static VideoCapture m_vCapture;
        private static Thread ThreadCam;
        private static bool bTakePicture = false;
        private static string PicSavePath = @"E:\CAM.JPG";

        //人脸追踪引擎
        private static string APPID = "HrSKyCMMH7vx7sqHwNV8evpP3qzjXccnu8mo6WeFZdVU"; 
        private static string FT_SDKKEY = "D8GoabzvPwuK1ZNw1JCMebVLgM37on4zSrHov5qmwn2R";//32位
        private ArcFaceCore arcFace;
        public Main()
        {
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();

            // 创建 ArcFaceCore 对象，向构造函数传入相关参数进行 ArcFace 引擎的初始化
            arcFace = new ArcFaceCore(APPID, FT_SDKKEY, ArcFaceDetectMode.VIDEO,
                ArcFaceFunction.FACE_DETECT | ArcFaceFunction.FACE_RECOGNITION | ArcFaceFunction.AGE | ArcFaceFunction.FACE_3DANGLE | ArcFaceFunction.GENDER, DetectionOrientPriority.ASF_OP_0_ONLY, 1, 16);

            //初始化
            string retCode = arcFace.VersionInfo.Version;
            if (string.IsNullOrWhiteSpace(retCode))
            {
                MessageBox.Show(string.Format("人脸追踪引擎初始化失败，错误码={0}", retCode), "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        /// <summary>
        /// 打开摄像头
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_play_Click(object sender, EventArgs e)
        {
            if (!bPlayflag)
            {
                m_vCapture = new VideoCapture(VideoCaptureAPIs.ANY.GetHashCode());
                if (!m_vCapture.IsOpened())
                {
                    MessageBox.Show("摄像头打不开", "摄像头故障", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                m_vCapture.Set(VideoCaptureProperties.FrameWidth, 550);//宽度
                m_vCapture.Set(VideoCaptureProperties.FrameHeight, 425);//高度

                bPlayflag = true;
                ThreadCam = new Thread(Play_Camera);
                ThreadCam.Start();
                pic_cam.Image = null;
                btn_play.Text = "关闭摄像头";
            }
            else
            {
                bPlayflag = false;
                ThreadCam.Abort();
                
                m_vCapture.Release();
                btn_play.Text = "打开摄像头";

                GC.Collect();
            }
        }

        /// <summary>
        /// 播放摄像头线程
        /// </summary>
        private void Play_Camera()
        {
            while (bPlayflag)
            {
                Mat cFrame = new Mat();
                try
                {
                    m_vCapture.Read(cFrame);
                    int sleepTime = (int)Math.Round(1000 / m_vCapture.Fps);
                    Cv2.WaitKey(sleepTime);
                    if (cFrame.Empty())
                    {
                        continue;
                    }
                    Cv2.Flip(cFrame, cFrame, OpenCvSharp.FlipMode.Y);

                    #region 人脸追踪
                    //检测人脸，得到Rect框
                    MultiFaceModel multiFaceInfo = arcFace.FaceDetection(cFrame.ToBitmap());
                    if (multiFaceInfo.FaceInfoList.Count > 0)
                    {
                        Mrect mrect = multiFaceInfo.FaceInfoList[0].faceRect;
                        Rect cMaxrect = new Rect(mrect.left, mrect.top, mrect.right - mrect.left, mrect.bottom - mrect.top);
                        //绘制指定区域(人脸框)
                        Scalar color = new Scalar(0, 0, 255);
                        Cv2.Rectangle(cFrame, cMaxrect, color, 1);

                        if (bTakePicture)//拍照，截取指定区域
                        {
                            Mat cHead = new Mat(cFrame, cMaxrect);
                            Cv2.ImWrite(PicSavePath, cHead);
                            SetPictureBoxImage(pic_head, cHead.ToBitmap());
                            cHead.Release();
                            bTakePicture = false;
                        }
                    }
                    multiFaceInfo.Dispose();
                    #endregion
                    SetPictureBoxImage(pic_cam, cFrame.ToBitmap());
                    cFrame.Release();//释放   
                    //GC.Collect();
                }
                catch(Exception ex)
                {
                    cFrame.Release();//释放 
                    bTakePicture = false;
                    //GC.Collect();
                }finally
                {
                    //GC.Collect();
                }
            }
        }
        private void SetPictureBoxImage(PictureBox pic, Bitmap bitmap)
        {
            pic.Image = bitmap;
        }

        /// <summary>
        /// 拍照
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_cam_Click(object sender, EventArgs e)
        {
            bTakePicture = true;
            this.pic_IdCard.Image= Image.FromFile("E:\\IDCARDIMG.JPG");
        }

        private void btn_compare_Click(object sender, EventArgs e)
        {
            //图片比对
            ArcFaceCore arcFaceImg = new ArcFaceCore(APPID, FT_SDKKEY, ArcFaceDetectMode.IMAGE,
             ArcFaceFunction.FACE_DETECT | ArcFaceFunction.FACE_RECOGNITION | ArcFaceFunction.AGE | ArcFaceFunction.FACE_3DANGLE | ArcFaceFunction.GENDER, DetectionOrientPriority.ASF_OP_0_ONLY, 1, 16);

            Bitmap camImg = new Bitmap(@"E:\\CAM.JPG");
            Bitmap idCardImg = new Bitmap(@"E:\\IDCARDIMG.JPG");
            //将第一张图片的 Bitmap 转换成 ImageData
            ImageData camImgData = ImageDataConverter.ConvertToImageData(camImg);
            ImageData idCardImgData = ImageDataConverter.ConvertToImageData(idCardImg);
            try
            {
                // 检测第一张图片中的人脸
                MultiFaceModel camImgMultiFace = arcFaceImg.FaceDetection(camImgData);
                // 取第一张图片中返回的第一个人脸信息
                AsfSingleFaceInfo camImgfaceInfo = camImgMultiFace.FaceInfoList.First();
                // 提第一张图片中返回的第一个人脸的特征
                AsfFaceFeature asfFaceFeatureCam = arcFaceImg.FaceFeatureExtract(camImgData, ref camImgfaceInfo);

                
                MultiFaceModel idCardImgMultiFace = arcFaceImg.FaceDetection(idCardImgData);
                AsfSingleFaceInfo idCardImgfaceInfo = idCardImgMultiFace.FaceInfoList.First();
                AsfFaceFeature asfFaceFeatureIdCard = arcFaceImg.FaceFeatureExtract(idCardImgData, ref idCardImgfaceInfo);

                float ret = arcFaceImg.FaceCompare(asfFaceFeatureCam, asfFaceFeatureIdCard);

                if (ret > 0.6)
                {
                    //MessageBox.Show("人脸匹配成功"+ret);
                    lbl_msg.ForeColor = Color.Green;
                    lbl_msg.Text = "人脸匹配成功--相似度：" + ret;


                    bPlayflag = false;
                    ThreadCam.Abort();
                    m_vCapture.Release();
                    btn_play.Text = "打开摄像头";

                }
                else
                {
                    //MessageBox.Show("人脸匹配失败" + ret);
                    lbl_msg.ForeColor = Color.Red;
                    lbl_msg.Text = "人脸匹配失败--相似度：" + ret;
                }
            }
            catch(Exception ex)
            {
                //MessageBox.Show("人脸匹配失败Ex");
                lbl_msg.ForeColor = Color.Red;
                lbl_msg.Text = "人脸匹配失败Ex：" + ex.Message;
            }
            finally
            {
                //释放销毁引擎
                arcFaceImg.Dispose();

                // ImageData使用完之后记得要 Dispose 否则会导致内存溢出 
                camImgData.Dispose();
                idCardImgData.Dispose();
                // BItmap也要记得 Dispose
                camImg.Dispose();
                idCardImg.Dispose();

                GC.Collect();
            }
        }
    }
}
