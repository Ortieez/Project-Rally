using UnityEngine;

public class CarSelection : MonoBehaviour {
    public GameObject[] cars;
    public int selectedCar = 0;

    public LevelLoader levelLoader;

    private void Start() {
        SelectCar();
    }

    public void SelectCar() {
        for (int i = 0; i < cars.Length; i++) {
            cars[i].SetActive(i == selectedCar);
        }
    }

    public void NextCar() {
        selectedCar = (selectedCar + 1) % cars.Length;
        SelectCar();
    }

    public void PreviousCar() {
        selectedCar = (selectedCar - 1 + cars.Length) % cars.Length;
        SelectCar();
    }

    public void SelectCarAndLoadTrack() {
        PlayerPrefs.SetInt("SelectedCar", selectedCar);
        levelLoader.LoadTrack();
    }
}