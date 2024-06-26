﻿using UnityEngine;

namespace Net.Component
{
    public static class Matrix4Utils
    {
        public static Matrix4x4 GetPosition(this Matrix4x4 self, Vector3 position)
        {
            Matrix4x4 matrix = Matrix4x4.identity;
            matrix.m03 = position.x;
            matrix.m13 = position.y;
            matrix.m23 = position.z;
            return matrix;
        }

        public static Matrix4x4 GetPosition(Vector3 position)
        {
            Matrix4x4 matrix = Matrix4x4.identity;
            matrix.m03 = position.x;
            matrix.m13 = position.y;
            matrix.m23 = position.z;
            return matrix;
        }

        public static void SetPosition(ref Matrix4x4 matrix, Vector3 position)
        {
            matrix.m03 = position.x;
            matrix.m13 = position.y;
            matrix.m23 = position.z;
        }

        public static Quaternion GetRotation(this Matrix4x4 matrix4X4)
        {
            //float qw = Mathf.Sqrt(1f + matrix4X4.m00 + matrix4X4.m11 + matrix4X4.m22) / 2;
            //float w = 4 * qw;
            //float qx = (matrix4X4.m21 - matrix4X4.m12) / w;
            //float qy = (matrix4X4.m02 - matrix4X4.m20) / w;
            //float qz = (matrix4X4.m10 - matrix4X4.m01) / w;
            //return new Quaternion(qx, qy, qz, qw);

            var m00 = matrix4X4.m00;
            var m01 = matrix4X4.m01;
            var m02 = matrix4X4.m02;
            var m10 = matrix4X4.m10;
            var m11 = matrix4X4.m11;
            var m12 = matrix4X4.m12;
            var m20 = matrix4X4.m20;
            var m21 = matrix4X4.m21;
            var m22 = matrix4X4.m22;

            var trace = m00 + m11 + m22;
            var q = new Quaternion();

            if (trace > 0f)
            {
                var num = Mathf.Sqrt(1f + trace);
                q.w = num * 0.5f;
                num = 0.5f / num;
                q.x = (m21 - m12) * num;
                q.y = (m02 - m20) * num;
                q.z = (m10 - m01) * num;
                return q;
            }

            if (m00 >= m11 && m00 >= m22)
            {
                float num = Mathf.Sqrt(1f + m00 - m11 - m22);
                float num4 = 0.5f / num;
                q.x = 0.5f * num;
                q.y = (m01 + m10) * num4;
                q.z = (m02 + m20) * num4;
                q.w = (m12 - m21) * num4;
                return q;
            }

            if (m11 > m22)
            {
                float num6 = Mathf.Sqrt(1f + m11 - m00 - m22);
                float num3 = 0.5f / num6;
                q.x = (m10 + m01) * num3;
                q.y = 0.5f * num6;
                q.z = (m21 + m12) * num3;
                q.w = (m02 - m20) * num3;
                return q;
            }

            var num5 = Mathf.Sqrt(1f + m22 - m00 - m11);
            var num2 = 0.5f / num5;
            q.x = (m20 + m02) * num2;
            q.y = (m21 + m12) * num2;
            q.z = 0.5f * num5;
            q.w = (m01 - m10) * num2;
            return q;
        }

        public static Vector3 GetPosition(this Matrix4x4 matrix4X4)
        {
            float x = matrix4X4.m03;
            float y = matrix4X4.m13;
            float z = matrix4X4.m23;
            if (float.IsNaN(x))
                x = 0;
            if (float.IsNaN(y))
                y = 0;
            if (float.IsNaN(z))
                z = 0;
            return new Vector3(x, y, z);
        }

        public static Vector3 GetScale(this Matrix4x4 m)
        {
            float x = Mathf.Sqrt(m.m00 * m.m00 + m.m01 * m.m01 + m.m02 * m.m02);
            float y = Mathf.Sqrt(m.m10 * m.m10 + m.m11 * m.m11 + m.m12 * m.m12);
            float z = Mathf.Sqrt(m.m20 * m.m20 + m.m21 * m.m21 + m.m22 * m.m22);
            return new Vector3(x, y, z);
        }

        public static void Rotate(ref Matrix4x4 self, Quaternion q)
        {
            float num = q.x * 2f;
            float num2 = q.y * 2f;
            float num3 = q.z * 2f;
            float num4 = q.x * num;
            float num5 = q.y * num2;
            float num6 = q.z * num3;
            float num7 = q.x * num2;
            float num8 = q.x * num3;
            float num9 = q.y * num3;
            float num10 = q.w * num;
            float num11 = q.w * num2;
            float num12 = q.w * num3;
            self.m00 = 1f - (num5 + num6);
            self.m10 = num7 + num12;
            self.m20 = num8 - num11;
            self.m01 = num7 - num12;
            self.m11 = 1f - (num4 + num6);
            self.m21 = num9 + num10;
            self.m02 = num8 + num11;
            self.m12 = num9 - num10;
            self.m22 = 1f - (num4 + num5);
            self.m33 = 1f;
        }
    }
}
