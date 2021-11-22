﻿using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrimeLogger_Client.Helper
{
    public static class IJSRuntimeExtensions
    {
        public static async ValueTask ToastrSeccess(this IJSRuntime JSRuntime, string message)
        {
            await JSRuntime.InvokeVoidAsync("ShowToastr", "success", message);
        }

        public static async ValueTask ToastrError(this IJSRuntime JSRuntime, string message)
        {
            await JSRuntime.InvokeVoidAsync("ShowToastr", "error", message);
        }
    }
}
