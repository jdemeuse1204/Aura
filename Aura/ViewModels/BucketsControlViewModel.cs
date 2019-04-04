using Aura.AddOns.Step;
using Aura.Common;
using Aura.Common.Extensions;
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

        #region Commands
        public ICommand NewBucketClick => new CommandHandler(() => NewBucketHandler(), true);
        public ICommand DeleteBucketClick => new CommandHandler(() => DeleteBucketHandler(), true);
        public ICommand SaveBucketClick => new CommandHandler(() => SaveBucketHandler(), true);
        #endregion

        [Inject]
        public BucketsControlViewModel(IBucketsManager bucketsManager)
        {
            BucketsManager = bucketsManager;

            var buckets = BucketsManager.GetBuckets();
            Buckets = new ObservableCollection<IBucket>(buckets);
        }

        private void NewBucketHandler()
        {
            Bucket = new Bucket
            {
                Id = Guid.NewGuid()
            };

            Buckets.Add(Bucket);

            this.RaisePropertyChanged(w => w.Buckets);
            this.RaisePropertyChanged(w => w.Bucket);
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
