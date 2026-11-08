using UnityEngine;
using TMPro;

public class ScopeTame : MonoBehaviour
{
    public int Score;
    public int MaxScore;
    public TMP_Text Temp;

    public void Start()
    {
        MaxScore = PlayerPrefs.GetInt("MaxS");
        Temp.text = "Your task is to survive and score as many points as possible. Best  score:" + MaxScore;
    }
    public void Stop()
    {
        if (Score > MaxScore)
        {
            MaxScore = Score;
        }
        Temp.text = "Your task is to survive and score as many points as possible. Best  score:" + MaxScore;
        Score = 0;
        PlayerPrefs.SetInt("MaxS", MaxScore);
    }
}
