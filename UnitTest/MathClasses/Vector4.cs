﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClasses
{
    public class Vector4
    {
        public float x, y, z, w;

        public Vector4(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public float Magnitude()
        {
            return (float)Math.Sqrt(x * x + y * y + z * z + w * w);
        }

        public float MagnitudeSqr()
        {
            return (x * x + y * y + z * z + w * w);
        }

        public void Normalize()
        {
            float m = Magnitude();
            x /= m;
            y /= m;
            z /= m;
            w /= m;
        }

        public Vector4 GetNormalised()
        {
            Normalize();
            return new Vector4(x, y, z, w);
        }

        public static Vector4 operator +(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4(
            lhs.x + rhs.x,
            lhs.y + rhs.y,
            lhs.z + rhs.z,
            lhs.w + rhs.w);
        }

        public static Vector4 operator -(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4(
            lhs.x - rhs.x,
            lhs.y - rhs.y,
            lhs.z - rhs.z,
            lhs.w - rhs.w);
        }

        public static Vector4 operator *(Vector4 lhs, float rhs)
        {
            return new Vector4(
            lhs.x * rhs,
            lhs.y * rhs,
            lhs.z * rhs,
            lhs.w * rhs);
        }

        public static Vector4 operator *(float lhs, Vector4 rhs)
        {
            return rhs * lhs;
        }

        public static Vector4 operator /(Vector4 lhs, float rhs)
        {
            return new Vector4(
            lhs.x / rhs,
            lhs.y / rhs,
            lhs.z / rhs,
            lhs.w / rhs);
        }

        public Vector4 Cross(Vector4 rhs)
        {
            return new Vector4(
            y * rhs.z - z * rhs.y,
            z * rhs.x - x * rhs.z,
            x * rhs.y - y * rhs.x,
            0);
        }

        public float Dot(Vector4 rhs)
        {
            return x * rhs.x + y * rhs.y + z * rhs.z + w * rhs.w;
        }
    }
}
