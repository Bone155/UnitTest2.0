﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClasses
{
    public class Matrix3
    {
        public float m1, m2, m3, m4, m5, m6, m7, m8, m9;
       
        public Matrix3()
        {
            m1 = 1; m2 = 0; m3 = 0;
            m4 = 0; m5 = 1; m6 = 0;
            m7 = 0; m8 = 0; m9 = 1;
        }

        public Matrix3(float _m1, float _m2, float _m3, float _m4, float _m5, float _m6, float _m7, float _m8, float _m9)
        {
            m1 = _m1; m2 = _m2; m3 = _m3;
            m4 = _m4; m5 = _m5; m6 = _m6;
            m7 = _m7; m8 = _m8; m9 = _m9;
        }

        public static Matrix3 operator *(Matrix3 lhs, Matrix3 rhs)
        {

            Matrix3 mat = new Matrix3
            (
                //X
                rhs.m1 * lhs.m1 + rhs.m2 * lhs.m4 + rhs.m3 * lhs.m7,
                rhs.m1 * lhs.m2 + rhs.m2 * lhs.m5 + rhs.m3 * lhs.m8,
                rhs.m1 * lhs.m3 + rhs.m2 * lhs.m6 + rhs.m3 * lhs.m9,

                //Y
                rhs.m4 * lhs.m1 + rhs.m5 * lhs.m4 + rhs.m6 * lhs.m7,
                rhs.m4 * lhs.m2 + rhs.m5 * lhs.m5 + rhs.m6 * lhs.m8,
                rhs.m4 * lhs.m3 + rhs.m5 * lhs.m6 + rhs.m6 * lhs.m9,

                //Z
                rhs.m7 * lhs.m1 + rhs.m8 * lhs.m4 + rhs.m9 * lhs.m7,
                rhs.m7 * lhs.m2 + rhs.m8 * lhs.m5 + rhs.m9 * lhs.m8,
                rhs.m7 * lhs.m3 + rhs.m8 * lhs.m6 + rhs.m9 * lhs.m9
            );

            return mat;
        }

        public static Vector3 operator *(Matrix3 lhs, Vector3 rhs)
        {
            return new Vector3
            (
                (lhs.m1 * rhs.x) + (lhs.m4 * rhs.y) + (lhs.m7 * rhs.z),
                (lhs.m2 * rhs.x) + (lhs.m5 * rhs.y) + (lhs.m8 * rhs.z),
                (lhs.m3 * rhs.x) + (lhs.m6 * rhs.y) + (lhs.m9 * rhs.z)
            );
        }

        public Matrix3 GetTansposed()
        {
            // flip row and column
            return new Matrix3
            (
                m1, m4, m7,
                m2, m5, m8,
                m3, m6, m9
            );
        }

        public static Matrix3 Indentity()
        {
            //Flat identity
            return new Matrix3
            (
                1, 0, 0,
                0, 1, 0,
                0, 0, 1
            );
        }

        public Vector3 GetXAxis()
        {
            return new Vector3(m1, m4, m7);
        }

        public Vector3 GetYAxis()
        {
            return new Vector3(m2, m5, m8);
        }

        public Vector3 GetZAxis()
        {
            return new Vector3(m3, m6, m9);
        }

        public void Set(Matrix3 matrix)
        {
            m1 = matrix.m1; m2 = matrix.m2; m3 = matrix.m3;
            m4 = matrix.m4; m5 = matrix.m5; m6 = matrix.m6;
            m7 = matrix.m7; m8 = matrix.m8; m9 = matrix.m9;
        }

        public void SetScaled(float x, float y, float z)
        {
            m1 = x; m2 = 0; m3 = 0;
            m4 = 0; m5 = y; m6 = 0;
            m7 = 0; m8 = 0; m9 = z;
        }

        public void SetRotateX(double radians)
        {
            Matrix3 m = new Matrix3(1, 0, 0, 
                                    0, (float)Math.Cos(radians), (float)Math.Sin(radians), 
                                    0, (float)-Math.Sin(radians), (float)Math.Cos(radians));
            Set(m);
        }

        public void SetRotateY(double radians)
        {
            Matrix3 m = new Matrix3((float)Math.Cos(radians), 0, (float)-Math.Sin(radians), 
                                    0, 1, 0, 
                                    (float)Math.Sin(radians), 0, (float)Math.Cos(radians));
            Set(m);
        }

        public void SetRotateZ(double radians)
        {
            Matrix3 m = new Matrix3((float)Math.Cos(radians), (float)Math.Sin(radians), 0, 
                                    (float)-Math.Sin(radians), (float)Math.Cos(radians), 0, 
                                    0, 0, 1);
            Set(m);
        }

        public void Scale(float x, float y, float z)
        {
            Matrix3 m = new Matrix3();
            m.SetScaled(x, y, z);
            Set(m);
        }

        public void RotateX(double radians)
        {
            Matrix3 m = new Matrix3();
            m.SetRotateX(radians);
            Set(m);
        }

        public void RotateY(double radians)
        {
            Matrix3 m = new Matrix3();
            m.SetRotateY(radians);
            Set(m);
        }

        public void RotateZ(double radians)
        {
            Matrix3 m = new Matrix3();
            m.SetRotateZ(radians);
            Set(m);
        }

        public void SetTranslation(float x, float y)
        {
            m7 = x; m8 = y; m9 = 1;
        }

        public void Translate(float x, float y)
        {
            // apply vector offset
            m7 += x; m8 += y;
        }
    }
}