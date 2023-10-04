using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fabrik : MonoBehaviour
{
    [SerializeField]
    Transform[] bones;
    
    [SerializeField]
    float[] boneLeghts;

    [SerializeField]
    int solverIterations = 5;

    [SerializeField]
    Transform target;

    Vector3 startPosition;
    
    void Start()
    {
        boneLeghts = new float[bones.Length];

        for (int i = 0; i < bones.Length; i++)
        {
            if (i < bones.Length - 1)
            {
                boneLeghts[i] = (bones[i + 1].localPosition - bones[i].localPosition).magnitude;
            }
            else
            {
                boneLeghts[i] = 0;
            }
        }

        startPosition = bones[0].localPosition;

    }
    
    void Update()
    {
        SolveIK();
    }

    void SolveIK()
    {
        Vector3[] finalBonePositions = new Vector3[bones.Length];

        for (int i = 0; i < bones.Length; i++)
        {
            finalBonePositions[i] = bones[i].localPosition;
        }

        for (int i = 0; i < solverIterations; i++)
        {
            finalBonePositions = SolveForwardPositions(SolveBackwardPositions(finalBonePositions));
        }

        for (int i = 0; i < bones.Length; i++)
        {
            bones[i].localPosition = finalBonePositions[i];

            if (i != bones.Length - 1)
            {
                bones[i].rotation = Quaternion.LookRotation(finalBonePositions[i + 1] - bones[i].localPosition);
            }
            else
            {
                bones[i].rotation = Quaternion.LookRotation(target.position - bones[i].position);

            }
        }


    }


    Vector3[] SolveBackwardPositions(Vector3[] forwardPositions)
    {
        Vector3[] inversePositions = new Vector3[forwardPositions.Length];

        for (int i = (forwardPositions.Length - 1); i >= 0; i--)
        {
            if (i == forwardPositions.Length - 1)
            {
                inversePositions[i] = target.position;
            }
            else
            {
                Vector3 nextPosition = inversePositions[i + 1];
                Vector3 currentPosition = forwardPositions[i];
                Vector3 direction = (currentPosition - nextPosition ).normalized;
                float lenght = boneLeghts[i];
                inversePositions[i] = nextPosition + (direction * lenght);
            }
        }

        return inversePositions;
    }


    Vector3[] SolveForwardPositions(Vector3[] inversePositions)
    {
        Vector3[] forwardPositions = new Vector3[inversePositions.Length];

        for (int i = 0; i < inversePositions.Length; i++)
        {
            if (i == 0)
            {
                forwardPositions[i] = startPosition;
            }
            else
            {
                Vector3 currentPosition = inversePositions[i];
                Vector3 previousPosition = forwardPositions[i - 1];
                Vector3 direction = (currentPosition - previousPosition).normalized;
                float lenght = boneLeghts[i - 1];
                forwardPositions[i] = previousPosition + (direction * lenght);
            }
        }

        return forwardPositions;
    }
}
