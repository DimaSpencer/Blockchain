using System;
using System.Collections.Generic;
using System.Text;

namespace Blockchain
{
    interface IBlock
    {
        string Data { get; }
        string Hash { get; }
        string PreviousHash { get; }
        DateTime TimeOfCreation { get; }
    }
}
