using System;

namespace NullableFunctional
{
    public static class ObjectsExtensions
    {
        public static T Do<T>(this T nullable, Action<T> action) where T : class
        {
            if (nullable != null) action(nullable);
            return nullable;
        }

        public static T DoWhenNull<T>(this T nullable, Action action) where T : class
        {
            if (nullable == null) action();
            return nullable;
        }

        public static TOut Select<TIn, TOut>(this TIn nullable, Func<TIn, TOut> transformation)
            where TIn : class where TOut : class
        {
            return nullable != null ? transformation(nullable) : null;
        }

        public static TOut SelectOrElse<TIn, TOut>(this TIn nullable, Func<TIn, TOut> transformation, TOut option)
            where TIn : class where TOut : class
        {
            return nullable != null ? transformation(nullable) : option;
        }

        public static T Where<T>(this T nullable, Func<T, bool> query) where T : class
        {
            return nullable != null && query(nullable) ? nullable : null;
        }

        public static bool Condition<T>(this T nullable, Func<T, bool> query) where T : class
        {
            return nullable != null && query(nullable);
        }

        public static T OrDefault<T>(this T nullable, T defaultValue) where T : class
        {
            return nullable ?? defaultValue;
        }
    }
}