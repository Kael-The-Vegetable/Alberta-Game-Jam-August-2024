using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    private GameManager gameManager;
    public TMP_Text scoreText;
    
    public void IntensityCount(int intensity)
    {
        scoreText.text = "Intensity: " + Singleton.Global.GameManager.intensity;
    }
}
