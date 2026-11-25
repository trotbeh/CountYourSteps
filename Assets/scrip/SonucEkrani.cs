using UnityEngine;
using UnityEngine.SceneManagement;


public class SonucEkrani : MonoBehaviour
{

    public static string sonrakiSahne = "";
    public GameObject nextLevelButonu;

    void Start()
    {
        if (nextLevelButonu != null)
            nextLevelButonu.SetActive(!string.IsNullOrEmpty(sonrakiSahne));
    }

    public void SonrakiSeviye()
    {
        if (string.IsNullOrEmpty(sonrakiSahne)) return;
        UnityEngine.SceneManagement.SceneManager.LoadScene(sonrakiSahne);

    }

    public string oyunSahnesi = "oyun";
    public string menuSahnesi = "menu";
    
    public void TekrarOyna()
    {
        SceneManager.LoadScene(oyunSahnesi);

    }
    public void AnaMenuyeDon()
    {
        SceneManager.LoadScene(menuSahnesi);
    }
}
