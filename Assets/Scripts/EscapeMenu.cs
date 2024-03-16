using System.Collections;
using TMPro;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public Canvas canvas;

    public TimeTrialCounter timeTrialCounter;

    public TMP_InputField usernameInput;

    void Start()
    {
        canvas.enabled = false;
        Time.timeScale = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale != 0)
            {
                Time.timeScale = 0;
                canvas.enabled = true;
                ShowBestLap();
            }
            else
            {
                Time.timeScale = 1;
                canvas.enabled = false;
            }
        }
    }

    public void ShowBestLap()
    {
        if (canvas.enabled && timeTrialCounter.bestLap != 0)
        {
            System.TimeSpan t = System.TimeSpan.FromMilliseconds((double)timeTrialCounter.bestLap);
            string bestLap = string.Format("{0:D2}:{1:D2}:{2:D3}", t.Minutes, t.Seconds, t.Milliseconds);
            
            canvas.GetComponentInChildren<UnityEngine.UI.Text>().text = "Best Lap: " + bestLap;
        }
    }

    public void SendTimeToLeaderboard() {
        string username = usernameInput.text.Trim();
        if (username.Length > 0 && timeTrialCounter.bestLap != 0) {
            string url = "https://supabase-wcs04ok.ortieez.com/rest/v1/times";
            string json = "{\"username\":\"" + username + "\",\"time_driven\":" + timeTrialCounter.bestLap + "}";
            string apikey = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJzdXBhYmFzZSIsImlhdCI6MTcxMDU4Nzc2MCwiZXhwIjo0ODY2MjYxMzYwLCJyb2xlIjoic2VydmljZV9yb2xlIn0.7v8aE_zHfPqUaQusNYj5P_nO10hGksoti9C2gcQX2Tg";

            StartCoroutine(PostRequestTime(url, json, apikey));
        }
    }


    IEnumerator PostRequestTime(string url, string json, string apikey) {
        var request = new UnityEngine.Networking.UnityWebRequest(url, "POST");
        byte[] bodyRaw = new System.Text.UTF8Encoding().GetBytes(json);
        request.uploadHandler = new UnityEngine.Networking.UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new UnityEngine.Networking.DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("apikey", apikey);

        yield return request.SendWebRequest();

        if (request.responseCode != 201) {
            Debug.Log("Username already exists");
        } else {
            Debug.Log("Time sent to leaderboard");
        }
    }
}
