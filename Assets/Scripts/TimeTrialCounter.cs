using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class TimeTrialCounter : MonoBehaviour {
    public float time = 0;
    public bool isCounting = false;

    public List<float> times = new();
    public Text timeText;
    public Text recentTimesText; 

    private readonly float updateInterval = 0.05f;
    private float nextUpdate = 0;

    public BigInteger bestLap = 0;

    void Update() {
        if (isCounting) {
            time += Time.deltaTime;

            if (Time.time >= nextUpdate) {
                nextUpdate = Time.time + updateInterval;
                System.TimeSpan t = System.TimeSpan.FromSeconds(time);
                timeText.text = string.Format("{0:D2}:{1:D2}:{2:D3}", t.Minutes, t.Seconds, t.Milliseconds);
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            if (isCounting) {
                StopCounting();
            } else {
                StartCounting();
            }
        }
    }

    public void StartCounting() {
        isCounting = true;
    }

    public void StopCounting() {
        isCounting = false;
        times.Add(time);

        BigInteger timeInMilliseconds = (BigInteger)(time * 1000);
        if (bestLap == 0 || timeInMilliseconds < bestLap) {
            bestLap = timeInMilliseconds;
        }

        ResetCounting();

        string recentTimes = "";
        for (int i = times.Count - 1; i >= 0 && i >= times.Count - 3; i--) {
            System.TimeSpan t = System.TimeSpan.FromSeconds(times[i]);
            recentTimes += string.Format("{0:D2}:{1:D2}:{2:D3}\n", t.Minutes, t.Seconds, t.Milliseconds);
        }
        recentTimesText.text = recentTimes;

        
    }

    public void ResetCounting() {
        time = 0;
        StartCounting();
    }
}