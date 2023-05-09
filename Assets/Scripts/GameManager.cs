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
    public GameObject GameOverUI;
    public GameObject CountersUI;

    TrashScript Trash;

    float KiloMetersTraveled;
    float KmTimer;
    float TrashTimer;

    private void Start()
    {
        GameOverUI.SetActive(false);
        CountersUI.SetActive(true);
        Trash = GetComponent<TrashScript>();
    }

    void Update()
    {
        // Had to be seperate for convenience reasons
        KmTimer += Time.deltaTime;
        TrashTimer += Time.deltaTime;

        // Timer to count every 1.2 seconds and add .1f to the Kilometers Traveled.
        // These are not a random numbers
        // It is the speed that a bullet train crosses .1km at 300km/h (Average speed of Bullet Train)

        if (KmTimer >= 1.2f)
        {
            KmTimer -= 1.2f;
            KiloMetersTraveled += .1f;
            KmTextUI.text = "Km: " + KiloMetersTraveled;
        }

        // To Remove 1kg of trash every ~.033 Km
        if (TrashTimer >= .4f)
        {
            TrashTimer -= .4f;

            // If you have no Trash left to fuel the train it cannot move
            if (Trash.TrashAmount <= 0)
            {
                GameOverUI.SetActive(true);
                CountersUI.SetActive(false);
                GameOverKmText.text = "You Traveled " + KiloMetersTraveled + " Km";
                Time.timeScale = 0f;
            }
            else
            {
                Trash.TrashAmount -= 1;
            }
        }
    }
}
