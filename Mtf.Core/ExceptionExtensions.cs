﻿using System;
using System.Runtime.InteropServices;

namespace Mtf.Core
{
    public static class ExceptionExtensions
    {
        public static int GetErrorCode(this Exception ex)
        {
            return Marshal.GetHRForException(ex);
        }

        public static string GetDetails(this Exception ex)
        {
            return new ExceptionDetails(ex).Details;
        }
    }
}
