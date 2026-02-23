using UnityEngine;
// this let me use the new input system
using UnityEngine.InputSystem;

public class Player_1_Jump : MonoBehaviour
{
    ///// call the new input system I created in the input actions asset
    private Input_Actions_Platformer Input_Actions_Platformer;

    ///// declare variables for input actions and input values
    private InputAction jump;


    [Header("Rigibody")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Jump Settings")]
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float jumpCutMultiplier = 0.5f;

    [Header("Fall Settings")]
    [SerializeField] private float fallMultiplier = 2.5f;
    [SerializeField] private float lowJumpMultiplier = 2f;
    [SerializeField] private float maxFallSpeed = -10f;

    ///// state of the jump input
    private bool isJumpPressed = false;
    private bool isJumpHeld = false;
    private bool isJumpReleased = false;

    ///// prevent double jump in air
    private bool isjumping = false;

    [Header("Ground Detention Check")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    
    ///// Im using a box instead of a circle for the ground check
    [SerializeField] private Vector2 groundCheckSize = new Vector2(0.5f, 0.05f);

    [Header("Coyote Time")]
    [SerializeField] private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;

    //////////// LOGIC ///////////

    /// Before game start initialize the input actions
    private void Awake()
    {
        Input_Actions_Platformer = new Input_Actions_Platformer();
    }

    private void OnEnable()
    {
        ///// get Inputs into the variable Jump
        jump = Input_Actions_Platformer.Player_1.Jump;

        ///// enable the input actions
        jump.Enable();

        ///// subscribe to the jump = button press = Callback
        jump.performed += onJumpPerformed;
        jump.canceled += onJumpCanceled;
    }

    private void OnDisable()
    {
        ///// disable the input actions
        jump.Disable();

        ///// unsubscribe from the jump
        jump.performed -= onJumpPerformed;
        jump.canceled -= onJumpCanceled;
    }

    ///// OnJumpPerformed = Callback = Button Press = this method is ejecuted
    private void onJumpPerformed(InputAction.CallbackContext context)
    {
        // Check if the input action was performed (button pressed) = Callback
        if (context.performed)
        {

            Debug.Log("Jump button pressed!");
        }
    }
    ///// OnJumpCanceled = Callback = Button Release = this method is ejecuted
    private void onJumpCanceled(InputAction.CallbackContext context)
    {
        // Check if the input action was canceled (button released) = Callback
        if (context.canceled)
        {

            Debug.Log("Jump button released!");
        }
    }
    ///// Checks if player is touching the ground using an overlapBox, im using this time a box instead of a circle
    ///// I need an anlge of 0f because the box is not rotated
    private bool IsGrounded()
    {
        return Physics2D.OverlapBox(groundCheck.position, groundCheckSize, 0f, groundLayer);
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        // Draw the ground check box in Scene view
        Gizmos.DrawWireCube(groundCheck.position, groundCheckSize);
    }
}
