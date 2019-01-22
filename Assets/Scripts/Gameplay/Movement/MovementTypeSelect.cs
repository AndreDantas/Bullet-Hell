using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class MovementTypeSelect
{
    public enum Movements { None, MoveBetweenPoints, MoveRandomArea, MoveCircle }

    [SerializeField, HideInInspector]
    private Movements movementType;

    [ShowInInspector, PropertyOrder(-1)]
    public Movements MovementType
    {
        get => movementType;

        set
        {
            //if (movementType == value && details != null)
            //    return;
            movementType = value;
            SetDetails();
        }
    }

    protected MovementDetails Details
    {
        get
        {
            SetDetails();
            return details;
        }
        set => details = value;
    }

    private MovementDetails details;

    [ShowIf("MovementType", Movements.MoveBetweenPoints)] public MoveBetweenPointsDetails moveBetweenPointsDetails = new MoveBetweenPointsDetails();
    [ShowIf("MovementType", Movements.MoveRandomArea)] public MoveRandomAreaDetails moveRandomAreaDetails = new MoveRandomAreaDetails();
    [ShowIf("MovementType", Movements.MoveCircle)] public MoveCircleDetails moveCircleDetails = new MoveCircleDetails();

    protected void SetDetails()
    {
        switch (movementType)
        {
            case Movements.None:
                Details = null;
                break;
            case Movements.MoveBetweenPoints:
                Details = moveBetweenPointsDetails;
                break;
            case Movements.MoveRandomArea:
                Details = moveRandomAreaDetails;
                break;
            case Movements.MoveCircle:
                Details = moveCircleDetails;
                break;

        }
    }

    public MovementDetails GetDetails()
    {
        return Details;
    }
}
