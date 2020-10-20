using System;
using ArcFaceSharp.ArcFace;

namespace ArcFaceSharp.Exceptions
{
    /// <summary>
    /// ResultCode 错误码类型的异常
    /// </summary>
    public class ResultCodeException : Exception
    {
        public ResultCode ResultCode { get; }

        public ResultCodeException(ResultCode resultCode) : base(resultCode.ToString())
        {
            this.ResultCode = resultCode;
        }
    }
}
