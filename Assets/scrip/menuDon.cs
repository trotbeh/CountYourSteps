using UnityEngine;
using UnityEngine.SceneManagement;

public class menuDon : MonoBehaviour
{
    public string menuSceneName = "menu";

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) AnaMenuyeDon();

    }
    public void AnaMenuyeDon()
    {
        SceneManager.LoadScene(menuSceneName);

    }


}

