﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    public float time;
    public float startTime;
    public Text txtTime;
    public Text txtStartDirections;
    public bool isOn = false;
    private bool isNotEnded;
    public float negativeOffset = 1;
    public GameObject resultsButton;

    // Start is called before the first frame update
    void Start()
    {
        ResetScene();
        resultsButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isNotEnded)
        {
            if (!isOn)
            {
                //presiona Espacio sin haber iniciado el juego
                txtStartDirections.text = "Press Space when time reaches 0.";
                isOn = true;
            }
            else
            {
                //presiona Espacio durante el juego
                isOn = false;
                isNotEnded = false;
                GameEnded();
            }
        }
        if (!isNotEnded)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                ResetScene();
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                GameManager.Instance.ChangeScene("Results");
            }
        }
        

        if (isOn)
        {
            //el tiempo se va decrementando
            time -= Time.deltaTime;
            //cambia de color cuando llega a cero
            if (time < 0)
            {
                txtTime.color = Color.red;
            }
            //deja de contar cuando llega a un límite
            if (time <= 0 - negativeOffset)
            {
                isOn = false;
            }
        }
        txtTime.text = time.ToString("F2");
    }

    void ResetScene()
    {        
        isOn = false;
        isNotEnded = true;
        time = startTime;
        txtTime.color = Color.white;
        txtTime.text = time.ToString();
        txtStartDirections.text = "Press Space to begin";
    }

    void GameEnded()
    {
        resultsButton.SetActive(true);
        txtStartDirections.text = "Press P to play again or R.";
        GameManager.Instance.score = time;
        float hiscore = GameManager.Instance.hiscore;
        if (Mathf.Abs(time) < hiscore)
        {
            GameManager.Instance.hiscore = time;
        }
    }
}
