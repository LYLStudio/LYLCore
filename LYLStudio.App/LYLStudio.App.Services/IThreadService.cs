﻿using System;

namespace LYLStudio.App.Services
{
    /// <summary>
    /// 執行緒服務基底介面
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IThreadService<T> : IDisposable        
    {
        /// <summary>
        /// 將自訂運算排入佇列
        /// </summary>
        /// <param name="anything"></param>
        void Enqueue(T anything);
    }

    /// <summary>
    /// 執行緒佇列物件介面
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IAnything<T>
    {
        /// <summary>
        /// Callback參數
        /// </summary>
        T Parameter { get; set; }
        /// <summary>
        /// 自訂Callback
        /// </summary>
        Action<T> Callback { get; set; }
    }
}
