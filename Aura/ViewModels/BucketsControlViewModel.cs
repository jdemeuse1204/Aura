using Aura.AddOns.Step;
using Aura.Common;
using Aura.Common.Extensions;
using Aura.Modals;
using Aura.Modals.Interfaces;
using Aura.Models;
using Aura.Services.Interfaces;
using Aura.ViewModels.Base;
using Ninject;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Aura.ViewModels
{
    public class BucketsControlViewModel : ViewModel
    {
        public ObservableCollection<IBucket> Buckets { get; set; }
        public IBucket Bucket { get; set; }

        private readonly IBucketsManager BucketsManager;
        private readonly IModalService ModalService;

        #region Commands
        public ICommand NewBucketClick => new CommandHandler(() => NewBucketHandler(), true);
        public ICommand DeleteBucketClick => new CommandHandler(() => DeleteBucketHandler(), true);
        public ICommand SaveBucketClick => new CommandHandler(() => SaveBucketHandler(), true);
        #endregion

        [Inject]
        public BucketsControlViewModel(IBucketsManager bucketsManager, IModalService modalService)
        {
            BucketsManager = bucketsManager;
            ModalService = modalService;

            Buckets = new ObservableCollection<IBucket>(BucketsManager.GetBuckets());
        }

        private void NewBucketHandler()
        {
            var result = ModalService.Show(ModalTypes.AddBucket);

            if (result.HasValue)
            {
                // done, refresh buckets
                this.SetProperty(w => w.Buckets, new ObservableCollection<IBucket>(BucketsManager.GetBuckets()));
            }
        }

        private void DeleteBucketHandler()
        {

        }

        private void SaveBucketHandler()
        {
            if (Bucket == null)
            {
                MessageBox.Show("Please create or select existing bucket");
                return;
            }

            if (string.IsNullOrEmpty(Bucket.Name))
            {
                MessageBox.Show("Bucket name cannot be empty");
                return;
            }

            BucketsManager.Save(Buckets);
        }
    }
}
