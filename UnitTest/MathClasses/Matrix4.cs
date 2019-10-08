﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClasses
{
    public class Matrix4
    {
        public float m1, m2, m3, m4, m5, m6, m7, m8, m9, m10, m11, m12, m13, m14, m15, m16;

        public Matrix4()
        {
            m1 = 1; m2 = 0; m3 = 0; m4 = 0;
            m5 = 0; m6 = 1; m7 = 0; m8 = 0;
            m9 = 0; m10 = 0; m11 = 1; m12 = 0;
            m13 = 0; m14 = 0; m15 = 0; m16 = 1;
        }

        public Matrix4(float m1, float m2, float m3, float m4, float m5, float m6, float m7, float m8, float m9, float m10, float m11, float m12, float m13, float m14, float m15, float m16)
        {
            this.m1 = m1; this.m2 = m2; this.m3 = m3; this.m4 = m4;
            this.m5 = m5; this.m6 = m6; this.m7 = m7; this.m8 = m8;
            this.m9 = m9; this.m10 = m10; this.m11 = m11; this.m12 = m12;
            this.m13 = m13; this.m14 = m14; this.m15 = m15; this.m16 = m16;
        }

        public static Matrix4 operator *(Matrix4 lhs, Matrix4 rhs)
        {
            return new Matrix4
            (
                //X
                rhs.m1 * lhs.m1 + rhs.m2 * lhs.m5 + rhs.m3 * lhs.m9 + rhs.m4 * lhs.m13,
                rhs.m1 * lhs.m2 + rhs.m2 * lhs.m6 + rhs.m3 * lhs.m10 + rhs.m4 * lhs.m14,
                rhs.m1 * lhs.m3 + rhs.m2 * lhs.m7 + rhs.m3 * lhs.m11 + rhs.m4 * lhs.m15,
                rhs.m1 * lhs.m4 + rhs.m2 * lhs.m8 + rhs.m3 * lhs.m12 + rhs.m4 * lhs.m16,

                //Y
                rhs.m5 * lhs.m1 + rhs.m6 * lhs.m5 + rhs.m7 * lhs.m9 + rhs.m8 * lhs.m13,
                rhs.m5 * lhs.m2 + rhs.m6 * lhs.m6 + rhs.m7 * lhs.m10 + rhs.m8 * lhs.m14,
                rhs.m5 * lhs.m3 + rhs.m6 * lhs.m7 + rhs.m7 * lhs.m11 + rhs.m8 * lhs.m15,
                rhs.m5 * lhs.m4 + rhs.m6 * lhs.m8 + rhs.m7 * lhs.m12 + rhs.m8 * lhs.m16,

                //Z
                rhs.m9 * lhs.m1 + rhs.m10 * lhs.m5 + rhs.m11 * lhs.m9 + rhs.m12 * lhs.m13,
                rhs.m9 * lhs.m2 + rhs.m10 * lhs.m6 + rhs.m11 * lhs.m10 + rhs.m12 * lhs.m14,
                rhs.m9 * lhs.m3 + rhs.m10 * lhs.m7 + rhs.m11 * lhs.m11 + rhs.m12 * lhs.m15,
                rhs.m9 * lhs.m4 + rhs.m10 * lhs.m8 + rhs.m11 * lhs.m12 + rhs.m12 * lhs.m16,

                //W
                rhs.m13 * lhs.m1 + rhs.m14 * lhs.m5 + rhs.m15 * lhs.m9 + rhs.m16 * lhs.m13,
                rhs.m13 * lhs.m2 + rhs.m14 * lhs.m6 + rhs.m15 * lhs.m10 + rhs.m16 * lhs.m14,
                rhs.m13 * lhs.m3 + rhs.m14 * lhs.m7 + rhs.m15 * lhs.m11 + rhs.m16 * lhs.m15,
                rhs.m13 * lhs.m4 + rhs.m14 * lhs.m8 + rhs.m15 * lhs.m12 + rhs.m16 * lhs.m16
            );
        }

        public static Vector4 operator *(Matrix4 lhs, Vector4 rhs)
        {
            return new Vector4
            (
                //X
                (rhs.x * lhs.m1) + (rhs.y * lhs.m5) + (rhs.z * lhs.m9) + (rhs.w * lhs.m13),

                //Y
                (rhs.x * lhs.m2) + (rhs.y * lhs.m6) + (rhs.z * lhs.m10) + (rhs.w * lhs.m14),

                //Z
                (rhs.x * lhs.m3) + (rhs.y * lhs.m7) + (rhs.z * lhs.m11) + (rhs.w * lhs.m15),

                //W
                (rhs.x * lhs.m4) + (rhs.y * lhs.m8) + (rhs.z * lhs.m12) + (rhs.w * lhs.m16)
            );
        }

        public static Matrix4 CreateIdentity()
        {
            return new Matrix4(1.0f, 0.0f, 0.0f, 0.0f,
                               0.0f, 1.0f, 0.0f, 0.0f,
                               0.0f, 0.0f, 1.0f, 0.0f,
                               0.0f, 0.0f, 0.0f, 1.0f);
        }

        public void Set(Matrix4 matrix)
        {
            m1 = matrix.m1; m2 = matrix.m2; m3 = matrix.m3; m4 = matrix.m4;
            m5 = matrix.m5; m6 = matrix.m6; m7 = matrix.m7; m8 = matrix.m8;
            m9 = matrix.m9; m10 = matrix.m10; m11 = matrix.m11; m12 = matrix.m12;
            m13 = matrix.m13; m14 = matrix.m14; m15 = matrix.m15; m16 = matrix.m16;
        }

        public void SetScaled(float x, float y, float z)
        {
            m1 = x; m2 = 0; m3 = 0; m4 = 0;
            m5 = 0; m6 = y; m7 = 0; m8 = 0;
            m9 = 0; m10 = 0; m11 = z; m12 = 0;
            m13 = 0; m14 = 0; m15 = 0; m16 = 1;
        }

        public void SetRotateX(double radians)
        {
            Matrix4 m = new Matrix4(1, 0, 0, 0,
                                    0, (float)Math.Cos(radians), (float)Math.Sin(radians), 0,
                                    0, (float)-Math.Sin(radians), (float)Math.Cos(radians), 0,
                                    0, 0, 0, 1);
            Set(m);
        }

        public void SetRotateY(double radians)
        {
            Matrix4 m = new Matrix4((float)Math.Cos(radians), 0, (float)-Math.Sin(radians), 0,
                                    0, 1, 0, 0,
                                    (float)Math.Sin(radians), 0, (float)Math.Cos(radians), 0,
                                    0, 0, 0, 1);
            Set(m);
        }

        public void SetRotateZ(double radians)
        {
            Matrix4 m = new Matrix4((float)Math.Cos(radians), (float)Math.Sin(radians), 0, 0,
                                    (float)-Math.Sin(radians), (float)Math.Cos(radians), 0, 0,
                                    0, 0, 1, 0,
                                    0, 0, 0, 1);
            Set(m);
        }

        public void Scale(float x, float y, float z)
        {
            Matrix4 m = new Matrix4(m1, m2, m3, m4, m5, m6, m7, m8, m9, m10, m11, m12, m13, m14, m15, m16);
            m.SetScaled(x, y, z);
            Set(m);
        }

        public void RotateX(double radians)
        {
            Matrix4 m = new Matrix4(m1, m2, m3, m4, m5, m6, m7, m8, m9, m10, m11, m12, m13, m14, m15, m16);
            m.SetRotateX(radians);
            Set(m);
        }

        public void RotateY(double radians)
        {
            Matrix4 m = new Matrix4(m1, m2, m3, m4, m5, m6, m7, m8, m9, m10, m11, m12, m13, m14, m15, m16);
            m.SetRotateY(radians);
            Set(m);
        }

        public void RotateZ(double radians)
        {
            Matrix4 m = new Matrix4(m1, m2, m3, m4, m5, m6, m7, m8, m9, m10, m11, m12, m13, m14, m15, m16);
            m.SetRotateZ(radians);
            Set(m);
        }

        public void SetTranslation(float x, float y, float z)
        {
            m13 = x; m14 = y; m15 = z; m16 = 1;
        }

        void Translate(float x, float y, float z)
        {
            // apply vector offset
            m13 += x; m14 += y; m15 += z;
        }
    }
}
