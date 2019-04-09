using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.Modals.Interfaces
{
    public interface IModalService
    {
        bool? Show(ModalTypes modal);
    }
}
