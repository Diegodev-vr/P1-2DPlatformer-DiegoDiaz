# P1-2DPlatformer-DiegoDiaz
Dawson College | Scripting 2 | 582-85E-DW
Diego Diaz - Student # 2545873

https://github.com/Diegodev-vr/P1-2DPlatformer-DiegoDiaz.git

NEW INPUT SYSTEM CONTROLS
- Keyboard
    Movement: WASD or arrow Keys
    Jump: Spacebar
- Gamepad
    Movement: Left stick
    Jump: South button

- PHYSICS APPROACH
    I used the Rigidbody2D for Physics interactions
    fixedUpdate() has the logic of these physics rb.linearVelocity
    as Jump uses physics I did movement also with physics
    physics provides natural and smoother movement and a better integration with unity 2D physics system

- GROUND DETECTION
    Physics2D.OverlapBox with LayerMask filtering

- JUMP TECHNIQUE
    Coyote time