using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductoCruz : MonoBehaviour
{
    [SerializeField] Vector3 initalPosition;

    [SerializeField] Vector3 ValueVectorA;

    [SerializeField] Vector3 ValueVectorB;

    [SerializeField] Vector3 ValueVectorC;

    private float VectorALength;
    private float VectorBLength;
    private float VectorCLength;

    private float piramidBase;
    private float baseFirstVectorAndSecondVector;

    private float auxPiramidHeight;
    private float auxPiramidHeight2;
    private float PiramidHeight;
    private float PiramidHeight2;

    private float piramidArea;
    private float piramidArea2;
    private float piramidArea3;

    [SerializeField] private float piramidTotalArea;

    private void Start()
    {
        setStartPosition();
    }
    void setStartPosition() 
    {
        initalPosition.Set(0, 0, 0);

        piramidBase = 0;
        baseFirstVectorAndSecondVector = 0;
        auxPiramidHeight = 0;
        auxPiramidHeight2 = 0;
        PiramidHeight = 0;
        PiramidHeight2 = 0;
        piramidArea = 0;
        piramidArea2 = 0;
        piramidArea3 = 0;

        //float positionX = Random.Range(1, 10);
        //float positionY = Random.Range(1, 10);
        //float positionZ = Random.Range(1, 10);

        float positionX = 5.1f;
        float positionY = 3.1f;
        float positionZ = 8.1f;

        ValueVectorA = new Vector3(positionX, positionY, positionZ);

        float bPositionX = ValueVectorA.y;
        float bPositionY = - ValueVectorA.x;
        float bPositionZ = ValueVectorA.z;


        ValueVectorB = new Vector3(bPositionX, bPositionY, bPositionZ);

        float cPositionX = ((ValueVectorA.y * ValueVectorB.z) - (ValueVectorA.z * ValueVectorB.y));
        float cPositionY = ((ValueVectorA.z * ValueVectorB.x) - (ValueVectorA.x * ValueVectorB.z));
        float cPositionZ = ((ValueVectorA.x * ValueVectorB.y) - (ValueVectorA.y * ValueVectorB.x));

        ValueVectorC = new Vector3(cPositionX, cPositionY, cPositionZ);


        VectorALength = Mathf.Sqrt(Mathf.Pow(initalPosition.x - initalPosition.y - initalPosition.z,2) + Mathf.Pow(ValueVectorA.x - ValueVectorA.y - ValueVectorA.z, 2));
        VectorBLength = Mathf.Sqrt(Mathf.Pow(initalPosition.x - initalPosition.y - initalPosition.z,2) + Mathf.Pow(ValueVectorB.x - ValueVectorB.y - ValueVectorB.z, 2));
        VectorCLength = Mathf.Sqrt(Mathf.Pow(initalPosition.x - initalPosition.y - initalPosition.z,2) + Mathf.Pow(ValueVectorC.x - ValueVectorC.y - ValueVectorC.z, 2));
    }
    private void FixedUpdate()
    {
        initalPosition.Set(0,0,0);

        float bPositionX = ValueVectorA.y;
        float bPositionY = -ValueVectorA.x;
        float bPositionZ = ValueVectorA.z;


        ValueVectorB = new Vector3(bPositionX, bPositionY, bPositionZ);

        float cPositionX = ((ValueVectorA.y * ValueVectorB.z) - (ValueVectorA.z * ValueVectorB.y));
        float cPositionY = ((ValueVectorA.z * ValueVectorB.x) - (ValueVectorA.x * ValueVectorB.z));
        float cPositionZ = ((ValueVectorA.x * ValueVectorB.y) - (ValueVectorA.y * ValueVectorB.x));

        ValueVectorC = new Vector3(cPositionX, cPositionY, cPositionZ);


        float aVectorAngle = Vector2.Angle(ValueVectorA, ValueVectorB);
        float bVectorAngle = Vector3.Angle(ValueVectorB, ValueVectorC);
        float cVectorAngle = Vector3.Angle(ValueVectorC, ValueVectorA);


        VectorALength = Mathf.Sqrt(Mathf.Pow(initalPosition.x - initalPosition.y - initalPosition.z, 2) + Mathf.Pow(ValueVectorA.x - ValueVectorA.y - ValueVectorA.z, 2));
        VectorBLength = Mathf.Sqrt(Mathf.Pow(initalPosition.x - initalPosition.y - initalPosition.z, 2) + Mathf.Pow(ValueVectorB.x - ValueVectorB.y - ValueVectorB.z, 2));
        VectorCLength = Mathf.Sqrt(Mathf.Pow(initalPosition.x - initalPosition.y - initalPosition.z, 2) + Mathf.Pow(ValueVectorC.x - ValueVectorC.y - ValueVectorC.z, 2));

        Debug.Log("Angulo Vector A y B");
        Debug.Log(aVectorAngle);
        Debug.Log("Angulo Vector B y C");
        Debug.Log(bVectorAngle);
        Debug.Log("Angulo Vector C y A");
        Debug.Log(cVectorAngle);

        checkPiramidBase();
        checkPiramidHeight();
        checkPiramidArea();
    }

    void checkPiramidBase()
    {
        if (VectorALength < VectorBLength)
        {
            piramidBase = Mathf.Sqrt(Mathf.Pow(ValueVectorA.x - ValueVectorA.y - ValueVectorA.z, 2) + Mathf.Pow(ValueVectorC.x - ValueVectorA.y - ValueVectorC.z, 2));
        }
        if (VectorBLength < VectorALength)
        {
            piramidBase = Mathf.Sqrt(Mathf.Pow(ValueVectorB.x - ValueVectorB.y - ValueVectorB.z, 2) + Mathf.Pow(ValueVectorC.x - ValueVectorB.y - ValueVectorC.z, 2));
        }
        else
        {
            piramidBase = Mathf.Sqrt(Mathf.Pow(ValueVectorA.x - ValueVectorA.y - ValueVectorA.z, 2) + Mathf.Pow(ValueVectorC.x - ValueVectorA.y - ValueVectorC.z, 2));
        }

        //Debug.Log("Base Piramide");
        //Debug.Log(piramidBase);

        baseFirstVectorAndSecondVector = piramidBase = Mathf.Sqrt(Mathf.Pow(ValueVectorA.x - ValueVectorA.y - ValueVectorA.z, 2) + Mathf.Pow(ValueVectorB.x - ValueVectorB.y - ValueVectorB.z, 2));
    }

    void checkPiramidHeight()
    {
        auxPiramidHeight = (auxPiramidHeight + piramidBase) / 2;
        PiramidHeight = Mathf.Sqrt(Mathf.Pow(initalPosition.x - initalPosition.y - initalPosition.z, 2) + Mathf.Pow(auxPiramidHeight, 2));
        auxPiramidHeight2 = (auxPiramidHeight2 + baseFirstVectorAndSecondVector) / 2;
        PiramidHeight2 = Mathf.Sqrt(Mathf.Pow(initalPosition.x - initalPosition.y - initalPosition.z, 2) + Mathf.Pow(auxPiramidHeight2, 2));
    }

    void checkPiramidArea() 
    {
        piramidArea = (piramidBase * PiramidHeight) / 2;
        piramidArea2 = (piramidBase * PiramidHeight) / 2;
        piramidArea3 = (baseFirstVectorAndSecondVector * PiramidHeight2) / 2;

        piramidTotalArea = piramidArea + piramidArea2 + piramidArea3; 
    }

    [ExecuteInEditMode]

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(initalPosition, ValueVectorA);
        Gizmos.color = Color.green;
        Gizmos.DrawLine(initalPosition, ValueVectorB);
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(initalPosition, ValueVectorC);

    }
}
