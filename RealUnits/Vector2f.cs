﻿/*
 *    Copyright 2009-2010 Nerijus Arlauskas and contributors
 * 
 *    This file is part of RealUnits.
 *
 *    RealUnits is free software: you can redistribute it and/or modify
 *    it under the terms of the GNU Lesser General Public License as 
 *    published by the Free Software Foundation, either version 3 of 
 *    the License, or (at your option) any later version.
 *
 *    RealUnits is distributed in the hope that it will be useful,
 *    but WITHOUT ANY WARRANTY; without even the implied warranty of
 *    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 *    GNU Lesser General Public License for more details.
 *
 *    You should have received a copy of the GNU Lesser General Public 
 *    License along with RealUnits. If not, see 
 *    <http://www.gnu.org/licenses/>.
 *
 */

using System;
using System.Text;

namespace RealUnits
{
    /// <summary>
    /// Vector in real units
    /// </summary>
    public sealed class Vector2f
    {
        private float x;
        private float y;
        private Unit unit;

        /// <summary>
        /// Create new vector from two distance values
        /// </summary>
        /// <param name="x">X value</param>
        /// <param name="y">Y value</param>
        public Vector2f(Distance x, Distance y)
        {
            this.x = x.NativeValue;
            this.y = y.GetIn(x.NativeUnit);
            this.unit = x.NativeUnit;
        }

        /// <summary>
        /// Create new vector from two distance values and specified unit type
        /// </summary>
        /// <param name="x">X value</param>
        /// <param name="y">Y value</param>
        /// <param name="unit">Unit type value</param>
        public Vector2f(float x, float y, Unit unit)
        {
            this.unit = unit;
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Create new vector from two distance values and specified unit types
        /// </summary>
        /// <param name="x">X value</param>
        /// <param name="y">Y value</param>
        /// <param name="unitX">Unit type for X</param>
        /// <param name="unitY">Unit type for Y</param>
        public Vector2f(float x, float y, Unit unitX, Unit unitY)
        {
            this.unit = unitX;
            this.x = x;
            this.y = unitY.Convert(y, unitX);
        }

        /// <summary>
        /// Gets or sets X distance
        /// </summary>
        public Distance X
        {
            get
            {
                return new Distance(x, unit);
            }
            set
            {
                this.x = value.GetIn(unit);
            }
        }

        /// <summary>
        /// Gets or sets Y distance
        /// </summary>
        public Distance Y
        {
            get
            {
                return new Distance(y, unit);
            }
            set
            {
                this.y = value.GetIn(unit);
            }
        }

        /// <summary>
        /// Get units used for this vector
        /// </summary>
        public Unit NativeUnit
        {
            get
            {
                return unit;
            }
        }

        /// <summary>
        /// Get stored X value
        /// </summary>
        public float NativeX
        {
            get
            {
                return x;
            }
        }

        /// <summary>
        /// Get stored Y value
        /// </summary>
        public float NativeY
        {
            get
            {
                return y;
            }
        }

        /// <summary>
        /// Returns vector converted to another units
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        public Vector2f Converted(Unit unit)
        {
            return new Vector2f(this.unit.Convert(this.x, unit), this.unit.Convert(this.y, unit), unit);
        }

        /// <summary>
        /// Performs vector addition
        /// </summary>
        /// <param name="a">Vector A</param>
        /// <param name="b">Vector B</param>
        /// <returns>New vector</returns>
        public static Vector2f operator +(Vector2f a, Vector2f b)
        {
            return new Vector2f(a.NativeX + XofBinA(a, b), a.NativeY + YofBinA(a, b), a.NativeUnit);
        }

        /// <summary>
        /// Performs vector subtraction
        /// </summary>
        /// <param name="a">Vector A</param>
        /// <param name="b">Vector B</param>
        /// <returns>New vector</returns>
        public static Vector2f operator -(Vector2f a, Vector2f b)
        {
            return new Vector2f(a.NativeX - XofBinA(a, b), a.NativeY - YofBinA(a, b), a.NativeUnit);
        }

        /// <summary>
        /// Performs vector multiplication (dor product)
        /// </summary>
        /// <param name="a">Vector A</param>
        /// <param name="b">Vector B</param>
        /// <returns>Scalar value</returns>
        public static float operator *(Vector2f a, Vector2f b)
        {
            return a.NativeX * XofBinA(a, b) + a.NativeY * YofBinA(a, b);
        }

        /// <summary>
        /// Divides vector by specified value
        /// </summary>
        /// <param name="a">Vector A</param>
        /// <param name="value">Scalar division value</param>
        /// <returns>New vector</returns>
        public static Vector2f operator /(Vector2f a, float value)
        {
            return new Vector2f(a.NativeX / value, a.NativeY / value, a.NativeUnit);
        }

        /// <summary>
        /// Divides vector by specified value
        /// </summary>
        /// <param name="a">Vector A</param>
        /// <param name="value">Scalar division value</param>
        /// <returns>New vector</returns>
        public static Vector2f operator /(Vector2f a, double value)
        {
            return new Vector2f((float)((double)a.NativeX / value), (float)((double)a.NativeY / value), a.NativeUnit);
        }

        /// <summary>
        /// Divides vector by specified value
        /// </summary>
        /// <param name="a">Vector A</param>
        /// <param name="value">Scalar division value</param>
        /// <returns>New vector</returns>
        public static Vector2f operator /(Vector2f a, int value)
        {
            return new Vector2f(a.NativeX / (float)value, a.NativeY / (float)value, a.NativeUnit);
        }

        /// <summary>
        /// Multiplies vector by specified value
        /// </summary>
        /// <param name="a">Vector A</param>
        /// <param name="value">Scalar multiplication value</param>
        /// <returns>New vector</returns>
        public static Vector2f operator *(Vector2f a, float value)
        {
            return new Vector2f(a.NativeX * value, a.NativeY * value, a.NativeUnit);
        }

        /// <summary>
        /// Multiplies vector by specified value
        /// </summary>
        /// <param name="a">Vector A</param>
        /// <param name="value">Scalar multiplication value</param>
        /// <returns>New vector</returns>
        public static Vector2f operator *(Vector2f a, int value)
        {
            return new Vector2f(a.NativeX * value, a.NativeY * value, a.NativeUnit);
        }

        /// <summary>
        /// Multiplies vector by specified value
        /// </summary>
        /// <param name="a">Vector A</param>
        /// <param name="value">Scalar multiplication value</param>
        /// <returns>New vector</returns>
        public static Vector2f operator *(Vector2f a, double value)
        {
            return new Vector2f((float)((double)a.NativeX * value), (float)((double)a.NativeY * value), a.NativeUnit);
        }

        /// <summary>
        /// Multiplies vector by specified value
        /// </summary>
        /// <param name="value">Scalar multiplication value</param>
        /// <param name="a">Vector A</param>
        /// <returns>New vector</returns>
        public static Vector2f operator *(float value, Vector2f a)
        {
            return new Vector2f(a.NativeX * value, a.NativeY * value, a.NativeUnit);
        }

        /// <summary>
        /// Multiplies vector by specified value
        /// </summary>
        /// <param name="value">Scalar multiplication value</param>
        /// <param name="a">Vector A</param>
        /// <returns>New vector</returns>
        public static Vector2f operator *(int value, Vector2f a)
        {
            return new Vector2f(a.NativeX * value, a.NativeY * value, a.NativeUnit);
        }

        /// <summary>
        /// Multiplies vector by specified value
        /// </summary>
        /// <param name="value">Scalar multiplication value</param>
        /// <param name="a">Vector A</param>
        /// <returns>New vector</returns>
        public static Vector2f operator *(double value, Vector2f a)
        {
            return new Vector2f((float)((double)a.NativeX * value), (float)((double)a.NativeY * value), a.NativeUnit);
        }

        /// <summary>
        /// Returns length of vector squared
        /// </summary>
        public Distance LengthSquared
        {
            get
            {
                return new Distance(NativeLengthSquared, unit);
            }
        }

        /// <summary>
        /// Returns length of vector
        /// </summary>
        public Distance Length
        {
            get
            {
                return new Distance(NativeLength, unit);
            }
        }

        /// <summary>
        /// Returns length of vector squared in native units
        /// </summary>
        public float NativeLengthSquared
        {
            get
            {
                return x * x + y * y;
            }
        }

        /// <summary>
        /// Returns length of vector in native units
        /// </summary>
        public float NativeLength
        {
            get
            {
                return (float)Math.Sqrt(NativeLengthSquared);
            }
        }

        /// <summary>
        /// Scales vector to match specified length
        /// </summary>
        /// <param name="newLength">New vector length</param>
        public void Scale(Distance newLength)
        {
            float scale = newLength.GetIn(unit) / NativeLength;
            x *= scale;
            y *= scale;
        }

        /// <summary>
        /// Returns scaled vector which maches specified length
        /// </summary>
        /// <param name="newLength">New vector length</param>
        /// <returns>New vector of specified length</returns>
        public Vector2f Scaled(Distance newLength)
        {
            float scale = newLength.GetIn(unit) / NativeLength;
            return this * scale;
        }

        /// <summary>
        /// Normalizes vector so that it's length is 1
        /// </summary>
        public void Normalize()
        {
            float scale = 1.0f / NativeLength;
            x *= scale;
            y *= scale;
        }

        /// <summary>
        /// Returns normalized vector of 1 length
        /// </summary>
        public Vector2f Normalized
        {
            get
            {
                float scale = 1.0f / NativeLength;
                return this * scale;
            }
        }

        /// <summary>
        /// Returns vector perpendicular to this vector
        /// </summary>
        public Vector2f Perpendicular
        {
            get
            {
                return new Vector2f(-y, x, unit);
            }
        }

        private static float XofBinA(Vector2f a, Vector2f b)
        {
            return b.NativeUnit.Convert(b.NativeX, a.NativeUnit);
        }

        private static float YofBinA(Vector2f a, Vector2f b)
        {
            return b.NativeUnit.Convert(b.NativeY, a.NativeUnit);
        }

        /// <summary>
        /// Converts vector to string representation
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(X.ToString());
            sb.Append(' ');
            sb.Append(Y.ToString());
            return sb.ToString();
        }

        /// <summary>
        /// Create new vector object from size defined in pixels
        /// </summary>
        /// <param name="x">Pixels in X direction</param>
        /// <param name="y">Pixels in Y direction</param>
        /// <param name="dpi">Dpi vector</param>
        /// <returns>New vector object</returns>
        public static Vector2f FromPixels(int x, int y, DpiVector2f dpi)
        {
            return new Vector2f(Distance.FromPixels(x, dpi.DpiX), Distance.FromPixels(y, dpi.DpiY));
        }
    }
}
