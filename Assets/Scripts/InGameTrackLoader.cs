using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class InGameTrackLoader : MonoBehaviour {

    public GameObject[] cars;
    public Transform carPosition;

    public CinemachineVirtualCamera cinemachineVirtualCamera;

    public Text speedText;

    private void Start() {
        int selectedCar = PlayerPrefs.GetInt("SelectedCar", 0);
        GameObject car = Instantiate(cars[selectedCar], carPosition.position, carPosition.rotation);

        cinemachineVirtualCamera.Follow = car.transform;
        cinemachineVirtualCamera.LookAt = car.transform;

        car.GetComponent<PrometeoCarController>().carSpeedText = speedText;
    }

    public void Update() {
        float speed = float.Parse(speedText.text);
        float targetFOV = Mathf.Clamp(70 + speed, 70, 100);
        float smoothTime = 0.3f;
        cinemachineVirtualCamera.m_Lens.FieldOfView = Mathf.Lerp(cinemachineVirtualCamera.m_Lens.FieldOfView, targetFOV, smoothTime * Time.deltaTime);
    }
}