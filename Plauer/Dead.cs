using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Dead : MonoBehaviour
{
    public HP hp;
    public GameObject Body;
    public ScopeTame ST;

    public void Start()
    {
        ST = GameObject.Find("SurvRoom").GetComponent<ScopeTame>();
    }
    void Update()
    {
        if (hp.HPme <= 0 && Body.tag == "Player")
        {
            if (ST != null)
            { 
                ST.Stop();
            }
            SceneManager.LoadScene(0);
        }
        if (hp.HPme <= 0 && Body.tag != "Player")
        {   
            if (ST != null)
            { 
                ST.Score += 50;
            }
            Destroy(Body);
        }
    }
}
