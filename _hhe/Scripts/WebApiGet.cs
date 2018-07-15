/*
 * get from webAPI
 *  https://www.youtube.com/watch?v=9rPJeRF7S_8
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WebApiGet : MonoBehaviour
{

    #region Events C#
    public struct DevicesEventArgs
    {
        //public int Id;
    }
    public delegate void DevicesEventHandler(object sender, DevicesEventArgs e);
    public event DevicesEventHandler DevicesRefreshed;
    #endregion Events C#

    public RootObject[] Devices;

    void Start ()
    {
        StartCoroutine(GetDevices());
	}
	
	IEnumerator GetDevices()
    {
        string geturl = "http://172.31.104.145:666/api/devices";
        using (UnityWebRequest www = UnityWebRequest.Get(geturl))
        {
            www.chunkedTransfer = false;
            yield return www.Send();
            if(www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                //string jsonResult = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                string jsonResult = www.downloadHandler.text;
                Debug.Log(jsonResult);
                Devices = JsonHelpers.getjsonArray<RootObject>(jsonResult);

                #region Events C#
                DevicesEventArgs e = new DevicesEventArgs();
                //args.Id = 1;
                if(DevicesRefreshed != null)
                {
                    DevicesRefreshed(this, e);
                }
                #endregion Events C#
            }
        }
    }
}
