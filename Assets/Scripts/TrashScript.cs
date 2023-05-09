using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

// The Script for the Amount of trash you have and displaying it on the screen

public class TrashScript : MonoBehaviour
{
    public int TrashAmount = 0;
    public TMP_Text TrashTextUI;

    string ogTrashText;

    private void Start()
    {
        ogTrashText = TrashTextUI.text;
    }

    private void Update()
    {
        TrashTextUI.text = ogTrashText + TrashAmount;
    }

}
