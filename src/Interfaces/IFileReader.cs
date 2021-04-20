using System.Collections.Generic;

namespace Intercom.Interfaces
{
    public interface IFileReader
    {
        IList<string> ReadAllLines();
    }
}