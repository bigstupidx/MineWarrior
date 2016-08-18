using UnityEngine;
using System.Collections;

public class SpiderScript : MonoBehaviour
{

    [SerializeField]
    Transform sightStart, sightEnd;

    Vector2 startPos, endPos;

    Vector2 topPos;
    bool down = false, up = false;

    Vector2 velocity;

    MState _cMState;

    public enum MState
    {
        Idle,
        Down,
        Up
    }

    void Awake()
    {
        startPos = transform.position;
        topPos = new Vector2(transform.position.x, transform.position.y);
    }

    void Start()
    {

    }

    void Update()
    {
        Raycasting();
        switch (_cMState)
        {
            case MState.Idle:
                break;
            case MState.Down:
                moveDown();
                break;
            case MState.Up:
                moveUp();
                StartCoroutine(TurnIdle());
                break;
        }

    }

    void moveDown()
    {
        transform.position = Vector2.SmoothDamp(transform.position, endPos, ref velocity, .5f);
    }

    void moveUp()
    {
        transform.position = Vector2.SmoothDamp(transform.position, topPos, ref velocity, .5f);
    }

    void Raycasting()
    {
        Debug.DrawLine(sightStart.position, sightEnd.position, Color.green);
        RaycastHit2D hit = Physics2D.Linecast(sightStart.position, sightEnd.position, 1 << LayerMask.NameToLayer("Player"));
        if (hit)
        {
            if (hit.collider.tag == "Player" && _cMState == MState.Idle)
            {
                _cMState = MState.Down;               
                endPos = new Vector3(hit.transform.position.x, hit.transform.position.y - 0, hit.transform.position.z);
                StartCoroutine(GoBackUp());
            }
        }
    }

    void OnTriggerEnter2D()
    {
        _cMState = MState.Up;
    }

    IEnumerator TurnIdle()
    {
        yield return new WaitForSeconds(.5f);
        if (_cMState == MState.Up)
            _cMState = MState.Idle;
    }

    IEnumerator GoBackUp()
    {
        yield return new WaitForSeconds(2f);
        if(_cMState == MState.Down)
            _cMState = MState.Up;
    }
}
