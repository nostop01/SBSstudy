using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Stone : MonoBehaviour
{
    [SerializeField]private float timer = 2f;

    private bool _timerStart = false;
    public bool _canThrowStone = true;


    public Vector3 dir;
    public Vector3 _throwPower;

    Vector3 _dir;

    StoneSpawn _stoneSpawn;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = transform.position + dir;

        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<SphereCollider>().isTrigger = true;
        _stoneSpawn = FindObjectOfType<StoneSpawn>();
    }

    // Update is called once per frame
    void Update()
    {
        _dir = transform.TransformDirection(_throwPower);

        if (Input.GetMouseButtonDown(0))
        {
            transform.parent = null;
            GetComponent<SphereCollider>().isTrigger = false;
            GetComponent<Rigidbody>().useGravity = true;

            if (_canThrowStone)
            {
                GetComponent<Rigidbody>().AddForce(_dir, ForceMode.Impulse);
            }

            _timerStart = true;

            _canThrowStone = false;

            _stoneSpawn._haveStone = false;
        }

        if (_timerStart == true)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
