using System;
using System.Collections.Generic;
using UnityEngine;

public class CsPublisher : MonoBehaviour
{
    public event EventHandler<CustomEventArgs> customEvent;
    public CsPlayer csPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (csPlayer.MoveMent.x > 1)
            OnRaiseCustomEvent(new CustomEventArgs("moving x"));
    }

    protected virtual void OnRaiseCustomEvent(CustomEventArgs e)
    {
        customEvent?.Invoke(this, e);
    }
}

abstract public class Subscriber
{
    protected string _id;
    public Subscriber(string id, CsPublisher pb)
    {
        _id = id;
        pb.customEvent += HandleCustomEvent;
    }

    abstract protected void HandleCustomEvent(object obj, CustomEventArgs e);
}