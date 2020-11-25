// ReSharper disable once CheckNamespace

using System;
using System.Collections.Generic;
using System.Linq;

namespace NullableFunctional
{
    public static class Extensions
    {
        public static T? Do<T>(this T? nullable, Action<T> action) where T : struct
        {
            if (nullable.HasValue) action(nullable.Value);
            return nullable;
        }
        public static T? DoWhenAbsent<T>(this T? nullable, Action action) where T : struct
        {
            if (!nullable.HasValue) action();
            return nullable;
        }
        public static TOut? Select<TIn,TOut>(this TIn? nullable, Func<TIn,TOut> transformation) where TIn : struct  where TOut : struct
        {
            return nullable.HasValue ? (TOut?) transformation(nullable.Value) : null;
        }
        public static T? Where<T>(this T? nullable, Func<T,bool> query) where T: struct
        {
            return nullable.HasValue && query(nullable.Value) ? nullable : null;
        }

        public static bool Condition<T>(this T? nullable, Func<T, bool> query) where T : struct
        {
            return nullable.HasValue && query(nullable.Value);
        }
        public static T? OrDefault<T>(this T? nullable, T defaultValue = default) where T: struct
        {
            return nullable ?? defaultValue;
        }
    }
}