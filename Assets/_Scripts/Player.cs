using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveController))]
public class Player : MonoBehaviour
{
    [System.Serializable]
    public class MouseInput {
        public Vector2 Damping;
        public Vector2 Sensitivity;        
    }

    [SerializeField] MouseInput MouseControl;
    [SerializeField] float speed;

    private MoveController m_moveController;
    public MoveController MoveController {
        get {
            if (m_moveController == null)
            {
                m_moveController = GetComponent<MoveController>();
            }  else { /* nothing to do */}
            return  m_moveController;
        }
    }
    InputController playerController;
    Vector2 mouseInput;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameManager.Instance.InputController; 
        GameManager.Instance.LocalPlayer = this;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = new Vector2(playerController.Vertical * speed, playerController.Horizontal * speed);
        MoveController.Move(direction);

        mouseInput.x = Mathf.Lerp(mouseInput.x, playerController.MouseInput.x, 1f / MouseControl.Damping.x);

        transform.Rotate(Vector3.up * mouseInput.x * MouseControl.Sensitivity.x);
    }
}
