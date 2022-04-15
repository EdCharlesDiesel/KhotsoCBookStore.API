using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhotsoCBookStore.API.Infrastructure
{
    public interface INotifier
    {
        void Notify(string message);
    }
}
