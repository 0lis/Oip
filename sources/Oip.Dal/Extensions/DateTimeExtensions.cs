using System;

namespace Oip.Dal.Extensions;

public static class DateTimeExtensions
{
    public static DateTime WithKind(this DateTime dateTime, DateTimeKind kind)
    {
        return new DateTime(dateTime.Ticks, kind);
    }
}