using System;
using UnityEngine;

public class PlaceableObject : MonoBehaviour
{
    public Direction Direction { get; private set; }
    
    public Vector3 LocalScale { get => transform.localScale; }

    private const int ROTATIONDEGREE = 90;

    protected Node placedOnNode;
    protected GridBuildingSystem gridBuildingSystem;

    [SerializeField] private int xSize;
    [SerializeField] private int ySize;
    [SerializeField] private Transform modelTransform;

    public Action<Direction.DirectionType> OnDirectionChanged;

    private void Awake()
    {
        Direction = Direction.Forward;
    }

    public void Apply90RotationAntiClockwise()
    {
        Direction = Direction.GetDirectionWithType(Direction.DirectionAfter90Degree);
        modelTransform.Rotate(new Vector3(0, ROTATIONDEGREE, 0));
        OnDirectionChanged?.Invoke(Direction.Type);
    }

    protected Vector3 GetFacingDirectionVector(Direction.DirectionType directionType)
    {
        return Direction.GetDirectionWithType(directionType).DirectionVector;
    }

    protected Vector3 GetOppositeDirectionVector(Direction.DirectionType directionType)
    {
        return Direction.GetDirectionWithType(directionType).OppositeDirectionVector;
    }

    public virtual void InvokeOnPlaced(Node placedOnNode)
    {
        this.placedOnNode = placedOnNode;
    }
}
