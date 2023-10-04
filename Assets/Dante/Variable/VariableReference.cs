using System;
using UnityEngine;

namespace Dante.Variable
{
    [Serializable]
    public class VariableReference<T>
    {
        [SerializeField] private bool useConstant;

        [SerializeField] private Variable<T> variable;

        [SerializeField] private T constant;

        public T Value
        {
            get { return useConstant ? constant : variable.Value; }
        }
    }
}