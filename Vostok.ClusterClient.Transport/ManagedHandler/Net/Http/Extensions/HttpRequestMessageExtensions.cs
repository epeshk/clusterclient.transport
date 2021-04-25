﻿using System;
using System.Net.Http.Headers;
using System.Reflection;

namespace System.Net.Http
{
    internal static class HttpRequestMessageExtensions
    {
        public static bool HasHeaders(this HttpRequestMessage request)
        {
            // Note: The field name is _headers in .NET core 
            string headersFieldName = "_headers"; // RuntimeUtils.IsDotNetFramework() ? "headers" : "_headers";
            FieldInfo headersField = typeof(HttpRequestMessage).GetField(headersFieldName, BindingFlags.Instance | BindingFlags.NonPublic);
            HttpRequestHeaders headers = (HttpRequestHeaders)headersField.GetValue(request);
            return headers != null;
        }
    }
}
