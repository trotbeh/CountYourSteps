using UnityEngine;

public class PortalTrigger : MonoBehaviour
{

    public float cellSize = 32f;
    public bool butonGerekli = false;
    public bool acik = false;
    public GameObject zincirliPortal;
    public GameObject animasyonluPortal;
    

    
    public Vector2Int Cell
    {
        get
        {
            return new Vector2Int(
                Mathf.RoundToInt(transform.position.x / cellSize),
                Mathf.RoundToInt(transform.position.y / cellSize));
        }
    }

    void Start()
    {
                
        if (butonGerekli)
        {
           
            if (animasyonluPortal != null) animasyonluPortal.SetActive(false);
        }
        else
        {
            if (zincirliPortal != null) zincirliPortal.SetActive(false);

        }
    }

    public void Ac()
    {
        
        if (acik) return;
       
        acik = true;
        if (zincirliPortal != null) zincirliPortal.SetActive(false);
        if (animasyonluPortal != null) animasyonluPortal.SetActive(true);


    }
}