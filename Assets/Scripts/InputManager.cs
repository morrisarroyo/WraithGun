using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    //Keyboard
    public delegate void InputHorizontal(float horizontal);
    public static event InputHorizontal OnInputHorizontal;
    public delegate void InputVertical(float vertical);
    public static event InputVertical OnInputVertical;    
    public delegate void InputSpace();
    public static event InputSpace OnInputSpace;
    public delegate void InputF();
    public static event InputF OnInputF;
    
    // Mouse
    public delegate void InputLeftClick();
    public static event InputLeftClick OnInputLeftClick;
    public delegate void InputMouseXAxis(float mouseX);
    public static event InputMouseXAxis OnInputMouseXAxis;
    public delegate void InputMouseYAxis(float mouseX);
    public static event InputMouseYAxis OnInputMouseYAxis;
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        #region InputHorizontal
        float horizontal = Input.GetAxis("Horizontal");
        OnInputHorizontal?.Invoke(horizontal);
        #endregion
        
        #region InputVertical
        float vertical = Input.GetAxis("Vertical");
        OnInputVertical?.Invoke(vertical);
        #endregion
        
        #region InputSpace
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnInputSpace?.Invoke();
        }
        #endregion
        
        #region InputF
        if (Input.GetKeyDown(KeyCode.F))
        {
            OnInputF?.Invoke();
        }
        #endregion
        
        #region InputLeftClick
        if (Input.GetMouseButtonDown(0))
        {
            OnInputLeftClick?.Invoke();
        }
        #endregion
        
        #region OnInputMouseXAxis
        float mouseX = Input.GetAxis("Mouse X");
        OnInputMouseXAxis?.Invoke(mouseX);
        #endregion
        
        #region OnInputMouseYAxis
        float mouseY = Input.GetAxis("Mouse Y");
        OnInputMouseYAxis?.Invoke(mouseY);
        #endregion
    }
}
