using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerMotor))]
public class PlyaerController : MonoBehaviour
{
    // focus 할 객체 
    public Interactable Focus;

    public LayerMask movementMask;

    Camera cam;

    PlayerMotor motor;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask))
              {
                Debug.Log(hit.collider.name + " " + hit.point);

                // 플레이어가 클릭한곳으로 움직이기를 원함 
                motor.MoveToPoint(hit.point);

                // 아무 오브젝트도 focusing 하지 않기를 원함
                RemoveFocus();
            }
        }

        // 좌클릭 : movement,  우클릭 : interaction 할것
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                //누른게 interactable인지 확인

                Interactable interactable = hit.collider.GetComponent<Interactable>(); 
                if (interactable != null)
                {
                    SetFocus(interactable);
                }
                //interactable이라면, 그걸 foucs로 설정
            }

        }

    }


    //객체에 focus를 설정하는법
    void SetFocus(Interactable newFocus)
    {

        if (newFocus != Focus)
        {
            if (Focus !=null)
                Focus.OnDefocused();
            
            Focus = newFocus;
            motor.FollowTarget(newFocus);
        }
        newFocus.Onfocused(transform);

    }

    //객체의 Focus를 삭제하는법
    void RemoveFocus()
    {
        if (Focus != null)
            Focus.OnDefocused();
        Focus = null;
        motor.StopFollowingTarget();
    }


}
