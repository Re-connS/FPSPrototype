using UnityEngine;

public class OpenWindMenu : MonoBehaviour
{
    public Animator Canva;
    public bool Open;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Open = !Open;
            Cursor.visible = !Cursor.visible;
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            Canva.SetBool("Open", Open);
        }
    }
    public void ExitGame()
    { 
        Application.Quit();
    }
}
