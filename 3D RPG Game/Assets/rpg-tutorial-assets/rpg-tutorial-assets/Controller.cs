using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public It focus;
    // Start is called before the first frame update
    public LayerMask movementMask;
    Camera cam;
    Motor motor;



    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<Motor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100, movementMask))
            {
                motor.MoveToPoint(hit.point);

                RemoveFocus();
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(
                Input.mousePosition);
            RaycastHit hit;
            
            if(Physics.Raycast(ray, out hit, 100))
            {
                It interactable = hit.collider.gameObject.GetComponent<It>();
                if(interactable != null)
                {
                    SetFocus(interactable);
                }

            }
        }
    }

    void SetFocus(It newFocus)
    {
        if (newFocus != focus)
        {
            if(focus != null)
            {
                focus.OnDefocused();
            }

            focus = newFocus;
            motor.FollowTarget(newFocus);
        }
        newFocus.Onfocused(transform);
    }
    void RemoveFocus()
    {
        if(focus != null)
        {
            focus.OnDefocused();
            focus = null;
            motor.StopFollowing();
        }
    }
}
