using UnityEngine;
using UnityEngine.SceneManagement;


public class SonucEkrani : MonoBehaviour
{

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
