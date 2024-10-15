using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager instance;

    //singleton
    public static ScoreManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType(typeof(ScoreManager)) as ScoreManager;
            }
            return instance;
        }
    }

    public void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else 
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public int crownAmount;
    public int coinAmount;

    private void Start()
    {
        crownAmount = 0; 
        coinAmount = 0;
    }
}
