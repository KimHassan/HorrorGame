﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CsEcoEffect : MonoBehaviour
{
    public Material ecoTableEffect;

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, ecoTableEffect);
    }
}
