using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public float GetHorizontalInput()
    {
        return Input.GetAxis("Horizontal");
    }

    public bool GetJumpInput()
    {
        return Input.GetButtonDown("Jump");
    }
}
