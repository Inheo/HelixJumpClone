using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private int _levelCount;
    [SerializeField] private float _additionalScale;
    [SerializeField] private Beam _beam;
    [SerializeField] private SpawnPlatform _spawnPlatform;
    [SerializeField] private FinishPlatform _finishPlatform;
    [SerializeField] private Platform[] _platforms;

    private float _startAndFinishAdditionalScale = 0.5f;

    public float BeamScaleY => _levelCount / 2f + _startAndFinishAdditionalScale + _additionalScale / 2f;
    private void Awake()
    {
        Build();
    }

    private void Build()
    {
        Beam beam = Instantiate(_beam, transform);
        beam.transform.localScale = new Vector3(beam.transform.localScale.x, BeamScaleY, beam.transform.localScale.z);

        Vector3 spawnPosition = beam.transform.position;
        spawnPosition.y += beam.transform.localScale.y - _additionalScale;

        SpawnPlatform(_spawnPlatform, ref spawnPosition, Quaternion.identity, beam.transform);

        for (int i = 0; i < _levelCount; i++)
        {
            Platform randomPlatform = _platforms[Random.Range(0, _platforms.Length)];
            Quaternion rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
            SpawnPlatform(randomPlatform, ref spawnPosition, rotation, beam.transform);
        }

        SpawnPlatform(_finishPlatform, ref spawnPosition, Quaternion.identity, beam.transform);
    }

    private void SpawnPlatform(Platform platform, ref Vector3 spawnPosition, Quaternion rotation, Transform parent)
    {
        Instantiate(platform, spawnPosition, rotation).transform.SetParent(parent, true);
        spawnPosition.y -= 1;
    }
}
