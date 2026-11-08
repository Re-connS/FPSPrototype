using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;

public class OpenSceneLivt : MonoBehaviour
{
    public int i;
    public List<string> NameScene = new List<string>();
    public TMP_Text Log;

    public void UpLev()
    {
        if (i < NameScene.Count - 1)
        { 
            i += 1;
            Log.text = NameScene[i];
        }
    }
    public void DownLev()
    {
        if (i > 0)
        { 
            i -= 1;
            Log.text = NameScene[i];
        }
    }
    public void LoadScene()
    {
        if (SceneManager.GetActiveScene().buildIndex != i)
        { 
            SceneManager.LoadScene(i);
        }
    }
}
