using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class P1Controller : MonoBehaviour
{
    private float _speed = 10f;

    private string _apiKey = "<API_KEY>";

    private string _entryID = "<ENTRY_ID>";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // determine movement by user input
        this.gameObject.GetComponent<RemoteTransformations>().enabled = false;
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.right * _speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.left * _speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.back * _speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.forward * _speed);
        }

        // update echoAR of current position
        UpdateEntryData("x", gameObject.transform.position.x.ToString());
        UpdateEntryData("y", gameObject.transform.position.y.ToString());
        UpdateEntryData("z", gameObject.transform.position.z.ToString());
        this.GetComponent<RemoteTransformations>().enabled = true;
    }

    public IEnumerator UpdateEntryData(string dataKey, string dataValue)
    {
        // Create form
        WWWForm form = new WWWForm();
        // Set form data
        form.AddField("key", _apiKey);        // API Key
        form.AddField("entry", _entryID);     // Entry ID
        form.AddField("data", dataKey);      // Key
        form.AddField("value", dataValue);   // Value
        UnityWebRequest www = UnityWebRequest.Post("https://console.echoar.xyz/post", form);
        // Send request
        yield return www.SendWebRequest();
        // Check for errors
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Data update complete!");
        }
    }
}
