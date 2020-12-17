namespace CircleCal.Math
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public struct Circle2d
    {
        public Vector2 Center;
        public float Radius;
        public Circle2d(Vector2 _center, float _radius)
        {
            this.Center = _center;
            this.Radius = _radius;
        }
        public float CalcPerimeter()
        {
            return (6.283185f * this.Radius);
        }
        public float CalcArea()
        {
            return (3.141593f * this.Radius * this.Radius);
        }
        public Vector2 Eval(float t)
        {
            return new Vector2(this.Center.x + (this.Radius * Mathf.Cos(t)), this.Center.y + (this.Radius * Mathf.Sin(t)));
        }
    }
}


