using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneCamera : MonoBehaviour
{
    public Texture _texture;

    [SerializeField]
    private Text _countdownText;

    private static WebCamTexture _phoneCamera;

    void Start()
    {
        string selectedDeviceName = "";
        selectedDeviceName = WebCamTexture.devices[WebCamTexture.devices.Length-1].name;

        _phoneCamera = new WebCamTexture(selectedDeviceName, 960, 640);
        GetComponent<Renderer>().material.mainTexture = _phoneCamera;

        _phoneCamera.Play();
        StartCoroutine(Pause());
    }

    private IEnumerator Pause()
    {
        _countdownText.text = "3";
        yield return new WaitForSeconds(0.5f);
        _countdownText.text = "2";
        yield return new WaitForSeconds(0.5f);
        _countdownText.text = "1";
        yield return new WaitForSeconds(0.5f);
        _countdownText.text = "";
        _phoneCamera.Pause();
        _texture = GetComponent<Renderer>().material.mainTexture;
    }
}
