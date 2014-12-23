using System;
using System.Collections.Generic;

namespace opt.UI.Mru
{
    internal interface IMruList : IEnumerable<MruItem>
    {
        event Action<IMruList> Changed;

        void Push(MruItem item);
        void Clear();
        void PruneObsolete();
    }
}