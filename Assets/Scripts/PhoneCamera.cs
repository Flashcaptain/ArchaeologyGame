using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneCamera : MonoBehaviour
{
    private static WebCamTexture _phoneCamera;
    public Texture _texture;

    // Update is called once per frame
    void Start()
    {
        _phoneCamera = new WebCamTexture();
        GetComponent<Renderer>().material.mainTexture = _phoneCamera;

        _phoneCamera.Play();
        Invoke("Pause", 1.5f);
    }

    private void Pause()
    {
        _phoneCamera.Pause();
        _texture = GetComponent<Renderer>().material.mainTexture;
    }
}
