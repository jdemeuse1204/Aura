using Aura.Common.Extensions;
using Aura.Modals;
using Aura.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Aura.ViewModels.Modal
{
    public class ModalWindowViewModel : ViewModel
    {
        public string Title { get; set; }  

        public Visibility IsAddBucketControlVisible { get; set; }

        public void ShowControl(ModalTypes modal)
        {
            this.SetProperty(w => w.IsAddBucketControlVisible, Visibility.Hidden);

            switch (modal)
            {
                case ModalTypes.AddBucket:
                    this.SetProperty(w => w.IsAddBucketControlVisible, Visibility.Visible);
                    this.SetProperty(w => w.Title, "Add New Bucket");
                    break;
                default:
                    break;
            }
        }
    }
}
