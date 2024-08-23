using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Results : MonoBehaviour
{
    [SerializeField] private Text txtScore;
    [SerializeField] private Text txtHiScore;
    private void Start()
    {
        txtScore.text = GameManager.Instance.score.ToString("F2");
        txtHiScore.text = GameManager.Instance.hiscore.ToString("F2");
    }
}
