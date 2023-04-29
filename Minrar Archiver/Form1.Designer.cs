namespace Minrar_Archiver
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnArchive = new Button();
            btnOpen = new Button();
            btnExtract = new Button();
            imageList1 = new ImageList(components);
            listView1 = new ListView();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BorderStyle = BorderStyle.Fixed3D;
            flowLayoutPanel1.Controls.Add(btnArchive);
            flowLayoutPanel1.Controls.Add(btnOpen);
            flowLayoutPanel1.Controls.Add(btnExtract);
            flowLayoutPanel1.Dock = DockStyle.Top;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1255, 131);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // btnArchive
            // 
            btnArchive.Image = (Image)resources.GetObject("btnArchive.Image");
            btnArchive.ImageAlign = ContentAlignment.TopCenter;
            btnArchive.Location = new Point(3, 3);
            btnArchive.Name = "btnArchive";
            btnArchive.Size = new Size(166, 121);
            btnArchive.TabIndex = 0;
            btnArchive.Text = "Archive files";
            btnArchive.TextAlign = ContentAlignment.BottomCenter;
            btnArchive.UseVisualStyleBackColor = true;
            btnArchive.Click += btnArchive_Click;
            // 
            // btnOpen
            // 
            btnOpen.Image = (Image)resources.GetObject("btnOpen.Image");
            btnOpen.ImageAlign = ContentAlignment.TopCenter;
            btnOpen.Location = new Point(175, 3);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(166, 121);
            btnOpen.TabIndex = 1;
            btnOpen.Text = "Open Archive";
            btnOpen.TextAlign = ContentAlignment.BottomCenter;
            btnOpen.UseVisualStyleBackColor = true;
            btnOpen.Click += btnOpen_Click;
            // 
            // btnExtract
            // 
            btnExtract.Image = (Image)resources.GetObject("btnExtract.Image");
            btnExtract.ImageAlign = ContentAlignment.TopCenter;
            btnExtract.Location = new Point(347, 3);
            btnExtract.Name = "btnExtract";
            btnExtract.Size = new Size(166, 121);
            btnExtract.TabIndex = 2;
            btnExtract.Text = "Extract";
            btnExtract.TextAlign = ContentAlignment.BottomCenter;
            btnExtract.UseVisualStyleBackColor = true;
            btnExtract.Click += btnExtract_Click;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth8Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "documents.png");
            // 
            // listView1
            // 
            listView1.Dock = DockStyle.Fill;
            listView1.LargeImageList = imageList1;
            listView1.Location = new Point(0, 131);
            listView1.Name = "listView1";
            listView1.Size = new Size(1255, 533);
            listView1.SmallImageList = imageList1;
            listView1.TabIndex = 1;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.List;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1255, 664);
            Controls.Add(listView1);
            Controls.Add(flowLayoutPanel1);
            Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(5);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Minrar";
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnArchive;
        private Button btnOpen;
        private ImageList imageList1;
        private Button btnExtract;
        private ListView listView1;
    }
}