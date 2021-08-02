using UnityEngine;

public class Ball : MonoBehaviour
{
    public static Ball Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlatformSegment platformSegment))
        {
            platformSegment.ParentPlatform.Break();
        }
    }
}
