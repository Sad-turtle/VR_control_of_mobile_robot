using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class GetVideoStream : MonoBehaviour
{
    GameObject plane;
    Texture2D tex;
    byte[] decodedBytes = null;
    Vector3 baselineForward;

    string pi = "http://192.168.0.6:5000";
    void Start()
    {
        plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        tex = new Texture2D(640, 480, TextureFormat.RGBA32, false);
        AttachPlane();

        Invoke(nameof(LoadFrame), 0);
        
    }

    void Update()
    {
        ReloadTexture();
    }

    async Task LoadFrame()
    {
        try
        {
            var client = new HttpClient();
            var response = await client.GetAsync($"{pi}/stream.jpg");
            decodedBytes = await response.Content.ReadAsByteArrayAsync();
        }
        catch (Exception ex)
        {
            Debug.LogError(ex);
        }

        Invoke(nameof(LoadFrame), 0.2f);
    }
    void AttachPlane()
    {
        var lookAt = gameObject.transform.forward;
        var offset = lookAt * 15;
        plane.transform.SetParent(gameObject.transform);

        plane.transform.SetPositionAndRotation(gameObject.transform.position + offset, Quaternion.LookRotation(-lookAt));
        plane.transform.Rotate(90, 0, 0);

        baselineForward = gameObject.transform.rotation.eulerAngles;
    }
    void ReloadTexture()
    {
        if (decodedBytes != null)
        {
            tex.LoadImage(decodedBytes);
            tex.Apply();

            var scale = (float)tex.width / tex.height;
            plane.transform.localScale = new Vector3(scale, 1, 1);
            plane.GetComponent<Renderer>().material.mainTexture = tex;
        }
    }
}
