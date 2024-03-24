using UnityEngine;

public class Checkpoint : MonoBehaviour {
    public int checkpointNumber;
    public TimeTrialCounter timeTrialCounter;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            if (checkpointNumber - 1 == -1) {
                checkpointNumber = 1;
            }


            if (!timeTrialCounter.checkpoints[checkpointNumber - 1].activeSelf) {
                timeTrialCounter.currentCheckpoint = checkpointNumber;
            }

            gameObject.SetActive(false);
        }
    }
}