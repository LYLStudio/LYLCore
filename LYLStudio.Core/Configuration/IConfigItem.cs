﻿namespace LYLStudio.Core.Configuration
{
    public interface IConfigItem
    {
        string Path { get; set; }
        object Value { get; }
    }
}
