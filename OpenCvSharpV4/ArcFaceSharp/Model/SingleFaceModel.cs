using System.Drawing;
using ArcFaceSharp.ArcFace;

namespace ArcFaceSharp.Model
{
    /// <summary>
    /// 单人脸信息
    /// </summary>
    public class SingleFaceModel
    {
        /// <summary>
        /// 人脸框
        /// </summary>
        public Rectangle FaceRect { get; set; }

        /// <summary>
        /// 人相角度
        /// </summary>
        public int FaceOrient { get; set; }


        public SingleFaceModel(){}

        public SingleFaceModel(AsfSingleFaceInfo singleFaceInfo)
        {
            this.FaceRect = singleFaceInfo.faceRect.Rectangle;
            this.FaceOrient = singleFaceInfo.faceOrient;
        }
    }
}
