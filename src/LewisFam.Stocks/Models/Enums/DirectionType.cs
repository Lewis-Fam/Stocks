using System;

namespace LewisFam.Stocks.Models.Enums
{
    /// <summary>
    /// DirectionType
    /// </summary>
    /// <remarks>DirectionType will be removed. Use <see cref="DirectionSlide"/></remarks>            
    [Obsolete("DirectionType will be removed. Use Slide.")]
    [Serializable]
    public enum DirectionType
    {
        //ToDo: Remove Lowercases.
        NotSet, //0
        Call, //1
        call, //2
        Put, //3
        put //4
    }
}
