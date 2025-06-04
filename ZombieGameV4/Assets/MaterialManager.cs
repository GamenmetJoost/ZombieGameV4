using UnityEngine;

public class MaterialManager : MonoBehaviour
{
    public static MaterialManager Instance;

    public int materialAmount = 100; // Starting amount

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Kopieer eventueel de materialAmount naar de bestaande Instance
            Instance.materialAmount = materialAmount;
            Destroy(gameObject);
        }
    }
}
