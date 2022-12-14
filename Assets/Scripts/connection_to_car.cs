using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;

public class connection_to_car : MonoBehaviour
{

    public void SendThrottleSignal() => StartCoroutine(SendThrottleCoroutine());
    public void SendBrakeSignal() => StartCoroutine(SendBrakeCoroutine());
    public void SendReverseSignal() => StartCoroutine(SendReverseCoroutine());
    public void SendStayStraightSignal() => StartCoroutine(SendStraightCoroutine());
    public void SendTurnLeftSignal() => StartCoroutine(SendLeftCoroutine());
    public void SendTurnRightSignal() => StartCoroutine(SendRightCoroutine());
    public void SendKillSignal() => StartCoroutine(SendKillCoroutine());
    IEnumerator SendThrottleCoroutine()
    {
        using (UnityWebRequest request = UnityWebRequest.Get("http://192.168.0.6:5000/car/throttle"))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(request.error);
            }
            else
            {
                Debug.Log(request.downloadHandler.text);
            }
        }
    }
    IEnumerator SendBrakeCoroutine()
    {
        using (UnityWebRequest request = UnityWebRequest.Get("http://192.168.0.6:5000/car/stop"))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(request.error);
            }
            else
            {
                Debug.Log(request.downloadHandler.text);
            }
        }
    }
    IEnumerator SendStraightCoroutine()
    {
        using (UnityWebRequest request = UnityWebRequest.Get("http://192.168.0.6:5000/car/turn/straight"))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(request.error);
            }
            else
            {
                Debug.Log(request.downloadHandler.text);
            }
        }
    }

    IEnumerator SendRightCoroutine()
    {
        using (UnityWebRequest request = UnityWebRequest.Get("http://192.168.0.6:5000/car/turn/right"))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(request.error);
            }
            else
            {
                Debug.Log(request.downloadHandler.text);
            }
        }
    }

    IEnumerator SendLeftCoroutine()
    {
        using (UnityWebRequest request = UnityWebRequest.Get("http://192.168.0.6:5000/car/turn/left"))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(request.error);
            }
            else
            {
                Debug.Log(request.downloadHandler.text);
            }
        }
    }
    IEnumerator SendReverseCoroutine()
    {
        using (UnityWebRequest request = UnityWebRequest.Get("http://192.168.0.6:5000/car/reverse"))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(request.error);
            }
            else
            {
                Debug.Log(request.downloadHandler.text);
            }
        }

    }
    IEnumerator SendKillCoroutine()
    {
        using (UnityWebRequest request = UnityWebRequest.Get("http://192.168.0.6:5000/car/kill"))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(request.error);
            }
            else
            {
                Debug.Log(request.downloadHandler.text);
            }
        }

    }
}
