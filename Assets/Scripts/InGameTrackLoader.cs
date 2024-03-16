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
}