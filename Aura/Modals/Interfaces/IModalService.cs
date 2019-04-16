using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.Modals.Interfaces
{
    public interface IModalService
    {
        bool? Show(ModalTypes modal);
    }
}
