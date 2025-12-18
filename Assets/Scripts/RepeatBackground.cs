using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 _startPos;
    private float repeatWidth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        repeatWidth = GetComponent < BoxCollider > ().size.x / 2;
        _startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if ( transform.position.x < _startPos.x - repeatWidth)
        {
            transform.position = _startPos;
        }
    }
}
