namespace SMHospitall.Reports
{
    partial class rptBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrHeader = new DevExpress.XtraReports.UI.XRPictureBox();
            this.endUserbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.work = new SMHospitall.UnitOfWork();
            ((System.ComponentModel.ISupportInitialize)(this.endUserbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.work)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 34.375F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 45.83333F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrHeader});
            this.ReportHeader.HeightF = 78.54166F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrHeader
            // 
            this.xrHeader.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Image", this.endUserbindingSource, "HeaderImage")});
            this.xrHeader.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrHeader.Name = "xrHeader";
            this.xrHeader.SizeF = new System.Drawing.SizeF(413.5417F, 78.54165F);
            this.xrHeader.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage;
            // 
            // endUserbindingSource
            // 
            this.endUserbindingSource.DataSource = typeof(SMHospitall.Data.EndUser);
            // 
            // rptBase
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader});
            this.Margins = new System.Drawing.Printing.Margins(100, 100, 34, 46);
            this.Version = "11.1";
            ((System.ComponentModel.ISupportInitialize)(this.endUserbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.work)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        protected internal UnitOfWork work;
        public DevExpress.XtraReports.UI.XRPictureBox xrHeader;
        public System.Windows.Forms.BindingSource endUserbindingSource;
        public DevExpress.XtraReports.UI.DetailBand Detail;
        public DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        public DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        public DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
    }
}
