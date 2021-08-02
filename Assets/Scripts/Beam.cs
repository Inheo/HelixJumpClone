using UnityEngine;

public class Beam : MonoBehaviour
{
    public static Beam Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
}
