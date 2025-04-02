using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDiamonds : MonoBehaviour
{
    public int diamonds;
    public int highScoreDiamonds;
    public Text counter;
    public Text highScore;

    void Start()
    {
        
        if (PlayerPrefs.HasKey("Diamonds"))
            highScoreDiamonds = PlayerPrefs.GetInt("Diamonds");
        highScore.text = highScoreDiamonds.ToString();
    }

    public void UpdateText()
    {
        counter.text = diamonds.ToString();
    }

    public void SaveDiamonds()
    {
        if (diamonds > highScoreDiamonds) {
            PlayerPrefs.SetInt("Diamonds", diamonds);
            PlayerPrefs.Save();
        }
        
    }
}
