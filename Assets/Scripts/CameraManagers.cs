using UnityEngine;
using System.Collections;
using DG.Tweening;


public class CameraManagers : MonoBehaviour
{
    [SerializeField]
    GameObject player1;
    [SerializeField]
    GameObject player2;
    public bool ready;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    public IEnumerator CameraSwitch(Player target)
    {
        
        ready = false;
        Vector3 leftbound = target.head.transform.position - new Vector3(.4f, .7f, .4f);

        Vector3 rightbound = target.head.transform.position + new Vector3(.4f, .7f, .4f);


        transform.DOMove(target.head.transform.position, 3f);
        transform.DORotate(target.head.transform.rotation.eulerAngles, 2f);
        Debug.Log(target.head.transform.rotation);
        while (!ready)
        {
            yield return null;
            if ((transform.position.x >= leftbound.x && transform.position.y >= leftbound.y && transform.position.z >= leftbound.z)
                && (transform.position.x <= rightbound.x && transform.position.y <= rightbound.y && transform.position.z <= rightbound.z) && transform.eulerAngles == target.head.transform.eulerAngles)
            {
                ready = true;
                yield break;
            }       
        }

    }

    public void CameraMoveToPlayer1()
    {
        transform.position = Vector3.MoveTowards(transform.position, player1.transform.position, Time.deltaTime * 1.0f);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, player1.transform.rotation, Time.deltaTime * 1.0f);

    }

    public void CameraMoveToPlayer2()
    {
        transform.position = Vector3.MoveTowards(transform.position, player2.transform.position, Time.deltaTime * 1.0f);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, player2.transform.rotation, Time.deltaTime * 1.0f);
    }
}
