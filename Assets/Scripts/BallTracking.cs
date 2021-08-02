using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTracking : MonoBehaviour
{
    [SerializeField] private Vector3 _directionOffset;
    [SerializeField] private float _length;

    private Ball _ball;
    private Beam _beam;

    private Vector3 _cameraPosition;
    private Vector3 _minimumBallPosition;

    private void Start()
    {
        _ball = Ball.Instance;
        _beam = Beam.Instance;

        _cameraPosition = _ball.transform.position;
        _minimumBallPosition = _ball.transform.position;

        Track();
    }

    private void Update()
    {
        if(_ball.transform.position.y < _minimumBallPosition.y)
        {
            Track();
            _minimumBallPosition = _ball.transform.position;
        }
    }

    private void Track()
    {
        Vector3 beamPosition = _beam.transform.position;
        beamPosition.y = _ball.transform.position.y;

        _cameraPosition = _ball.transform.position;
        Vector3 direction = (beamPosition - _ball.transform.position).normalized + _directionOffset;
        _cameraPosition -= direction * _length;

        transform.position = _cameraPosition;
        transform.LookAt(_ball.transform);
    }
}
