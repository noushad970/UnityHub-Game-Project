using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    [SerializeField]
    private Transform playerRoot, lookRoot;

    [SerializeField] 
    private bool invert;
    [SerializeField]
    private bool can_unlock = true;

    [SerializeField]
    private float sensivility = 5f;
    [SerializeField]
    private int smooth_step = 10;
    [SerializeField]
    private float smooth_weight = 0.4f;
    [SerializeField]
    private float roll_angle = 10f;
    [SerializeField]
    private float roll_speed = 3f;
    [SerializeField]
    private Vector2 Default_look_limits = new Vector2(-70f, 80f);//this mean we cannot move the mouse rotation more than 80 or less than -70

    private Vector2 look_angle;
    private Vector2 current_mouse_look;
    private Vector2 smooth_move;
    private float current_roll_angle;
    private Vector2 last_look_frame;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        CursorLockAndUnlock();
        if(Cursor.lockState == CursorLockMode.Locked)
        {
            LookAround();
        }
    }
    void CursorLockAndUnlock()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
                Cursor.lockState = CursorLockMode.None;
            else
            {      Cursor.lockState = CursorLockMode.Locked;
                   Cursor.visible = false;
            }
        } 
    }

    void LookAround()
    {
        current_mouse_look = new Vector2(Input.GetAxis(MouseAxis.Mouse_y), Input.GetAxis(MouseAxis.Mouse_x));


        look_angle.x += current_mouse_look.x * sensivility * (invert ? 1f : -1f);
        look_angle.y += current_mouse_look.y * sensivility;

        look_angle.x=Mathf.Clamp(look_angle.x,Default_look_limits.x,Default_look_limits.y);
       // modkhur code = current_roll_angle=Mathf.Lerp(current_roll_angle,Input.GetAxisRaw(MouseAxis.Mouse_x)*roll_angle,Time.deltaTime*roll_speed);
        //if i want to drunk a player or character than the upper code is useful for me;
        
        lookRoot.localRotation=Quaternion.Euler(look_angle.x,0f,0f);
        playerRoot.localRotation=Quaternion.Euler(0f,look_angle.y,0f);
    




    }



}




