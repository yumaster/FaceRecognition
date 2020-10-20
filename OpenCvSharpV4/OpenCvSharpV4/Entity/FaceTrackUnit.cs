using ArcFaceSharp.ArcFace;
using System;

namespace ArcSoftFace.Entity
{
    /// <summary>
    /// 视频检测缓存实体类
    /// </summary>
    public class FaceTrackUnit
    {
        public Mrect Rect { get; set; }
        public IntPtr Feature { get; set; }
        public string message = string.Empty;
    }
}
