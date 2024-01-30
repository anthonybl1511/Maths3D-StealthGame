using System;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private GameObject TextCanvas;
    [SerializeField] private GameObject SeeCanvas;

    private bool hasSeen = false;

    private void Update()
    {

        //Check back to stab
        if (Vector3.Dot(transform.forward.normalized, PlayerMovement.instance.transform.forward.normalized) > 0.6f && transform.position.x - PlayerMovement.instance.transform.position.x < 1.5f && transform.position.z - PlayerMovement.instance.transform.position.z < 1.5f && !PlayerMovement.instance.GetIsSeen())
        {
            TextCanvas.SetActive(true);
            if (Input.GetKeyDown("e"))
            {
                PlayerMovement.instance.GetAudioSource().Play();

                Destroy(gameObject);
            }
        }
        else
        {
            TextCanvas.SetActive(false);
        }

        //check front to see
        if (MathF.Abs(Vector3.Angle(transform.forward, PlayerMovement.instance.transform.position - transform.position)) < 40 
            && Vector3.Distance(transform.position, PlayerMovement.instance.transform.position) < 20
            && !Physics.Linecast(transform.position, PlayerMovement.instance.transform.position, 5))
        {
            SeeCanvas.SetActive(true);

            if(!hasSeen)
            {
                PlayerMovement.instance.SetIsSeen(true);
                hasSeen = true;
            }
        }
        else
        {
            SeeCanvas.SetActive(false);

            if (hasSeen)
            {
                PlayerMovement.instance.SetIsSeen(false);
                hasSeen = false;
            }
        }
    }
}
