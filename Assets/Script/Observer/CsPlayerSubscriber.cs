using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsPlayerSubscriber : Subscriber
{
    public CsPlayerSubscriber(string id, CsPublisher pb) : base(id, pb)
    {

    }

    protected override void HandleCustomEvent(object obj, CustomEventArgs e)
    {
        
    }
}
