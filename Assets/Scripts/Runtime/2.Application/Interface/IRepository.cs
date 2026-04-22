using System.Collections.Generic;
using Domain;

namespace Application
{
    interface IRepository
    {
        Dictionary<int, MinionEntity> MinionDictionary { get; }
    }
}
