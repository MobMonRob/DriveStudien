using System;

namespace DrivePlus.Client.View
{
    public partial class SnapshotView
    {
        public SnapshotView(Uri snapshotUri)
        {
            InitializeComponent();
            SnapshotBrowser.Navigate(snapshotUri);
        }
    }
}
