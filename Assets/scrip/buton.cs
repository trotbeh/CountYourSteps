using UnityEngine;

public class buton : MonoBehaviour
{

    public PlayeYurume player;
    public PortalTrigger portal;
    public float cellSize = 32f;
    
    public Vector2Int Cell { get; private set; }
    bool basildi;


    void Start()
    {
        Cell = new Vector2Int(
            Mathf.RoundToInt(transform.position.x / cellSize),
            Mathf.RoundToInt(transform.position.y / cellSize));

        
    }

    
    void Update()
    {
        if (basildi || player == null || portal == null) return;

        if (player.Cell == Cell)
        {
            basildi = true;
            portal.Ac();
            Debug.Log("Butona basildi, portal acildi");


        }
        
        
        
    
    }
}
