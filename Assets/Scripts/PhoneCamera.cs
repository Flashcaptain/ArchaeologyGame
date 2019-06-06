using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneCamera : MonoBehaviour
{
    private static WebCamTexture _phoneCamera;
    public Texture _texture;

    void Start()
    {
        string selectedDeviceName = "";
        for (int i = 0; i < WebCamTexture.devices.Length-1; i++)
        {
            if (WebCamTexture.devices[i].isFrontFacing)
            {
                selectedDeviceName = WebCamTexture.devices[4].name;
            }
        }

        _phoneCamera = new WebCamTexture(selectedDeviceName, 960, 640);
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
