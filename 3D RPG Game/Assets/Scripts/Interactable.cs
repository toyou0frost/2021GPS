using UnityEngine;
using UnityEngine.UIElements;

public class Interactable : MonoBehaviour
{
    // interactable가능하도록 만드는 거리
    public float radius = 3f;

    bool isFocus = false;

    bool hasInteracted = false;

    Transform player;

    public Transform interactionTransform ;

    private void Update()
    {

        if (isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if (distance <= radius)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }


    public virtual void Interact()
    {
        Debug.Log("Interaction with" + interactionTransform.name);

    }

    public void Onfocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnDefocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }


    //object를 선택했을때만 gizmo를 그림
    private void OnDrawGizmosSelected()
    {
        if (interactionTransform == null)
            interactionTransform = transform;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }

}
