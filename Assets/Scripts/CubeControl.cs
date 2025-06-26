using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeControl : MonoBehaviour
{
    private Rigidbody _rb;

    void Start()
    {
        Debug.Log("script started");
        _rb = GetComponent<Rigidbody>();
    }

    public void StartButton() {
    Debug.Log("StartButton нажата");
    _rb.useGravity = true;
    }

    public void StopButton() {
        Debug.Log("StopButton нажата");
        _rb.useGravity = false;
    }

    public void ChangeColorButton() {
        Debug.Log("ChangeColorButton нажата");
        _rb.gameObject.GetComponent<Renderer>().material.color = Color.red;
    }
}