using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayeYurume player;
    public adımSay counter;
    public PortalTrigger portal;

    public string winSceneName = "Kazandin";
    public string loseSceneName = "Kaybettin";

    public bool IsOver { get; private set; }
    public bool Won { get; private set; }

    void OnEnable()
    {
        if (player != null) player.Moved += HandleMove;        
    }
    void OnDisable()
    {
        if (player != null) player.Moved -= HandleMove;
    }
    
    void HandleMove(Vector2Int cell)
    {
        if (IsOver) return;

        counter.SpendStep();

        if (counter.StepsLeft > 0) return;
        bool portalda = portal != null && portal.Cell == cell;
        if (portalda) Win();
        else Lose();


    }

    void Win()
    {
        IsOver = true;
        Won = true;
        if (player != null) player.canMove = false;
        Invoke("KazanSahnesineGit" , 0.5f);
    }
    void KazanSahnesineGit()
    {
        SceneManager.LoadScene(winSceneName);        

    }


    
        void Lose()
    {
        IsOver = true;
        Won = false;
        if (player != null) player.canMove = false;
        Invoke("KaybetSahnesineGit" , 0.5f);


    }
    void KaybetSahnesineGit()
    {
        SceneManager.LoadScene(loseSceneName);

    }
}





