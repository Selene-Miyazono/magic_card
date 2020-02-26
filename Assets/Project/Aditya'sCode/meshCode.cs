﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class meshCode : MonoBehaviour
{
    public HexTileMapGenerator hx;
    public Material BlackMaterial;
    public MLSpatialMapper Mapper;
    private MLInputController _controller;

    void Start () {
      //Start receiving input by the Control
      MLInput.Start();
      MLInput.OnControllerButtonDown += OnButtonDown;
      _controller = MLInput.GetController(MLInput.Hand.Left);
    }
    void OnDestroy () {
      //Stop receiving input by the Control
      MLInput.Stop();
    }
    void Update () {
    }

    void OnButtonDown(byte controller_id, MLInputControllerButton button) {
      if (button == MLInputControllerButton.Bumper) {
        Debug.Log("yacha yacha");
        for (int i = 0; i < transform.childCount; i++) {
        // Get the child gameObject
        GameObject gameObject = transform.GetChild(i).gameObject;
        // Get the meshRenderer component
        MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();
        // Get the assigned material
        Material material = meshRenderer.sharedMaterial;
        if (material != BlackMaterial) {
           meshRenderer.material = BlackMaterial;
        }
     }
        hx.createHex();
      }
    }
}