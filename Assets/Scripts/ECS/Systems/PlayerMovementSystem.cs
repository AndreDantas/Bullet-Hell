
using UnityEngine;
using Unity.Entities;
[UpdateBefore(typeof(ObjectBoundsSystem))]
public class PlayerMovementSystem : ComponentSystem
{
    struct Group
    {
        public Player player;

    }

    protected override void OnUpdate()
    {
        foreach (var item in GetEntities<Group>())
        {
            if (Application.isEditor)
                CalculateMouseMovement(item.player);
            else
            {

                if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
                    CalculateTouchMovement(item.player);
                else if (Application.platform == RuntimePlatform.PS4)
                {
                    CalculateInputMovement(item.player);
                }
                else
                    CalculateMouseMovement(item.player);
            }

        }
    }

    void CalculateInputMovement(Player move)
    {
        var inputX = Input.GetAxis("Horizontal");
        var inputY = Input.GetAxis("Vertical");

        move.transform.position = new Vector3(inputX * move.speed * Time.deltaTime + move.transform.position.x,
                                                inputY * move.speed * Time.deltaTime + move.transform.position.y, move.transform.position.z);
        move.transform.eulerAngles = new Vector3(0f, 0f, inputX * -move.tilt);
    }

    void CalculateMouseMovement(Player move)
    {
        var inputX = Input.GetAxisRaw("Horizontal");
        var inputY = Input.GetAxisRaw("Vertical");
        if (inputX != 0 || inputY != 0)
        {
            CalculateInputMovement(move);
            return;
        }

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0) && !move.moving)
        {

            move.moving = true;
            move.touchOrigin = mousePos;
            move.playerOrigin = move.transform.position;

        }
        if (Input.GetMouseButtonUp(0))
        {
            //move.refVelocity = Vector3.zero;
            move.moving = false;
        }

        if (move.moving)
        {
            Vector2 currentPosition = (mousePos) - move.touchOrigin;
            Vector3 smoothMovePos = Vector3.SmoothDamp(move.transform.position, move.playerOrigin + currentPosition, ref move.refVelocity, move.smoothing);

            move.transform.position = smoothMovePos;
            move.refVelocity = new Vector3(Mathf.Clamp(move.refVelocity.x, -move.speed, move.speed), Mathf.Clamp(move.refVelocity.y, -move.speed, move.speed), move.refVelocity.z);
            move.position = mousePos;
        }
        else
        {
            move.refVelocity = new Vector3(move.refVelocity.x.ChangeToZero(50f), 0f, 0);
        }
        move.transform.eulerAngles = new Vector3(0f, 0f, UtilityFunctions.Map(-move.speed, move.speed, -1f, 1f, move.refVelocity.x) * -move.tilt);
    }

    void CalculateTouchMovement(Player move)
    {
        var inputX = Input.GetAxisRaw("Horizontal");
        var inputY = Input.GetAxisRaw("Vertical");
        if (inputX != 0 || inputY != 0)
        {
            CalculateInputMovement(move);
            return;
        }
        if (Input.touchCount > 0 && !move.moving)
        {

            move.moving = true;
            move.pointerID = Input.GetTouch(0).fingerId;
            move.touchOrigin = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            move.playerOrigin = move.transform.position;

        }
        if (Input.touchCount == 0)
        {
            move.moving = false;


        }

        if (move.moving)
        {
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Vector2 currentPosition = touchPos - move.touchOrigin;

            move.transform.position = Vector3.SmoothDamp(move.transform.position, move.playerOrigin + currentPosition, ref move.refVelocity, move.smoothing);
            move.refVelocity = new Vector3(Mathf.Clamp(move.refVelocity.x, -move.speed, move.speed), Mathf.Clamp(move.refVelocity.y, -move.speed, move.speed), move.refVelocity.z);
            move.position = touchPos;

        }
        else
        {
            move.refVelocity = new Vector3(move.refVelocity.x.ChangeToZero(50f), 0f, 0);
        }
        move.transform.eulerAngles = new Vector3(0f, 0f, UtilityFunctions.Map(-move.speed, move.speed, -1f, 1f, move.refVelocity.x) * -move.tilt);
    }
}
