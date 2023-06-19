using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private TextMeshProUGUI field;
    public int score = 0;

    private void Awake()
    {
        field = GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        field.text = score.ToString();
    }
    public void IncreaseScore()
    {
        score += 1;
        field.text = score.ToString();
    }
}
