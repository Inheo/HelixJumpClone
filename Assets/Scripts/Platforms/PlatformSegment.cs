using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlatformSegment : MonoBehaviour
{
    public Platform ParentPlatform { get; private set; }

    private MeshCollider _collider;

    private void Awake()
    {
        ParentPlatform = GetComponentInParent<Platform>();
        _collider = GetComponent<MeshCollider>();
    }

    public void Bounce(float force, Vector3 center, float radius)
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();

        rigidbody.isKinematic = false;
        rigidbody.AddExplosionForce(force, center, radius);

        _collider.enabled = false;
        transform.SetParent(null);
        Destroy(gameObject, 5f);
    }
}
