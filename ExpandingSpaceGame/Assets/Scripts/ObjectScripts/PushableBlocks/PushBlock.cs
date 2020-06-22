using System.Collections;
using UnityEngine;

public class PushBlock : MonoBehaviour
{
    public bool right = false;
    public bool left = false;
    public bool front = false;
    public bool back = false;
    public GameObject rightGameobject;
    public GameObject leftGameobject;
    public GameObject frontGameobject;
    public GameObject backGameobject;

    public GameObject block;
    public float blockSize = 2.5f;

    public float speedInSeconds = 0.3f;
    public bool canBePushed = true;

    private void OnTriggerStay(Collider collision)
    {
        //wanneer de player collision maakt wil ik dit block update
        if (collision.gameObject.tag.Equals("Player"))
        {
            if (canBePushed)
            {
                if (right)
                {
                    //de check komt van de andere kant van het gameobject "right is dus left" omdat ik wil weten of er ruimte is aan de andere kant
                    if (leftGameobject.GetComponent<AllowPushChecker>().getCanMove())
                    {
                        StartCoroutine(MoveOverSeconds(block, block.transform.position + new Vector3(blockSize, 0, 0), speedInSeconds));
                    }
                }

                if (left)
                {
                    //de check komt van de andere kant van het gameobject "right is dus left" omdat ik wil weten of er ruimte is aan de andere kant
                    if (rightGameobject.GetComponent<AllowPushChecker>().getCanMove())
                    {
                        StartCoroutine(MoveOverSeconds(block, block.transform.position + new Vector3(-blockSize, 0, 0), speedInSeconds));
                    }
                }

                if (front)
                {
                    //de check komt van de andere kant van het gameobject "right is dus left" omdat ik wil weten of er ruimte is aan de andere kant
                    if (backGameobject.GetComponent<AllowPushChecker>().getCanMove())
                    {
                        StartCoroutine(MoveOverSeconds(block, block.transform.position + new Vector3(0, 0, blockSize), speedInSeconds));
                    }
                }

                if (back)
                {
                    //de check komt van de andere kant van het gameobject "right is dus left" omdat ik wil weten of er ruimte is aan de andere kant
                    if (frontGameobject.GetComponent<AllowPushChecker>().getCanMove())
                    {
                        StartCoroutine(MoveOverSeconds(block, block.transform.position + new Vector3(0, 0, -blockSize), speedInSeconds));
                    }
                }
            }
        }
    }

    //zorg dat de speler moved over time in seconds (smooth overgang)
    //terwijl het block word gepushed zorg ik dat hij niet nog een keer kan worden gepushed
    //dit zodat het er visuel nog wat beter uitziet.
    public IEnumerator MoveOverSeconds(GameObject objectToMove, Vector3 end, float seconds)
    {
        canBePushed = false;
        float elapsedTime = 0;
        Vector3 startingPos = objectToMove.transform.position;
        while (elapsedTime < seconds)
        {
            objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        objectToMove.transform.position = end;
        yield return new WaitForSeconds(0.5f);
        canBePushed = true;
    }
}