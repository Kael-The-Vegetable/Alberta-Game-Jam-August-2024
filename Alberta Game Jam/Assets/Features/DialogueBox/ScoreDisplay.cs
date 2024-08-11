
using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    public TMP_Text scoreText;
    
    public void IntensityCount(int intensity)
    {
        scoreText.text = "Intensity: " + Singleton.Global.GameManager.Intensity;
    }
}
