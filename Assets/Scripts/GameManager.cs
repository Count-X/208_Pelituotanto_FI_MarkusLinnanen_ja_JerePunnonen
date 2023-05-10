using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// The function of this Game Manager is to count the Distance Traveled and
// change when the Train is Moving (Trash Rain) or when the Train is Stopped and you are recycling or
// You have lost and it displays Game Over UI

public class GameManager : MonoBehaviour
{
    public ObjectSpawnScript ObjectSpawn;
    public TMP_Text KmTextUI;
    public TMP_Text GameOverKmText;
    public TMP_Text ReasonText;
    public GameObject GameOverUI;
    public GameObject CountersUI;

    TrashScript Trash;

    int MetersTraveled = 0;
    float DistanceTimer;
    float TrashTimer;

    private void Start()
    {
        GameOverUI.SetActive(false);
        CountersUI.SetActive(true);
        Trash = GetComponent<TrashScript>();
        KmTextUI.text = "Km: " + MetersTraveled;
    }

    void Update()
    {
        // Had to be seperate for convenience reasons
        DistanceTimer += Time.deltaTime;
        TrashTimer += Time.deltaTime;

        // Timer to count every 1.2 seconds and add .1f to the Kilometers Traveled.
        // These are not a random numbers
        // It is the speed that a bullet train crosses .1km at 300km/h (Average speed of Bullet Train)

        if (DistanceTimer >= .012f)
        {
            DistanceTimer -= 0.012f;
            MetersTraveled += 1;
            KmTextUI.text = "Meters: " + MetersTraveled;
        }

        // To Remove 1kg of trash every ~.033 Km
        if (TrashTimer >= .4f)
        {
            TrashTimer -= .4f;

            // If you have no Trash left to fuel the train it cannot move
            if (Trash.TrashAmount <= 0)
            {
                GameOver("You ran out of Trash to fuel to train");
            }
            else
            {
                Trash.TrashAmount -= 1;
            }
        }
    }
    
    public void GameOver(string str)
    {
        GameOverUI.SetActive(true);
        CountersUI.SetActive(false);
        ReasonText.text = str;    
        GameOverKmText.text = "You Traveled " + MetersTraveled + " Meters";
        Time.timeScale = 0f;
    }
}
