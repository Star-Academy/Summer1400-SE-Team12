﻿using System.Collections.Generic;

namespace Phase05
{
    public interface IInvertedIndex
    {
        HashSet<string> GetInvertedIndexValue(string key);
    }
}