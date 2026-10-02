using UnityEngine;
public class GoalZone : MonoBehaviour
{
    public int score = 0;

    public GameObject zoneWall;

    void OnTriggerEnter(Collider other)
    {
        EnergyCore core = other.GetComponent<EnergyCore>();
        if (core != null)
        {
            score++;
            Debug.Log(
            "Energy Core delivered! Score: " + score
            );

            zoneWall.SetActive(false);

            core.ResetCore();
        }
    }
}