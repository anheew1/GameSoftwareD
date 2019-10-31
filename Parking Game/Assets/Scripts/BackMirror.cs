﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackMirror : MonoBehaviour
{
    private Camera camera;

    void Awake(){
        camera = GetComponent<Camera>();
    }
    public void OnPreCull(){
        camera.ResetProjectionMatrix();
        camera.projectionMatrix = camera.projectionMatrix * Matrix4x4.Scale(new Vector3(-1,1,1));
    }
    public void OnPreRender(){
        GL.invertCulling = true;
    }
    public void OnPostRender(){
        GL.invertCulling = false;
    }
}
