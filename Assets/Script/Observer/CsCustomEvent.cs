using System;
using System.Collections.Generic;
using UnityEngine;

public class CustomEventArgs : EventArgs
{
    private string message;

    public CustomEventArgs(string s)
    {
        Message = s;
    }

    public string Message { get => message; set => message = value; }
}
