using UnityEngine;

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
                Destroy(gameObject);
            }
        }
        else
        {
            TextCanvas.SetActive(false);
        }

        //check front to see
        if (Vector3.Dot(transform.forward.normalized, PlayerMovement.instance.transform.position.normalized) < -0.7f && Vector3.Dot(transform.right.normalized, PlayerMovement.instance.transform.position.normalized) < 0.4f && Vector3.Dot(transform.right.normalized, PlayerMovement.instance.transform.position.normalized) > -0.4f && transform.forward.z * transform.position.z - PlayerMovement.instance.transform.position.z < -1)
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
