using LoginLibrary.DataClasses;

//INSTANT C# NOTE: Formerly VB project-level imports:
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using System.Xml.Linq;
using System.Threading.Tasks;

namespace LoginUserInterface
{
	[Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
	public partial class MainForm : System.Windows.Forms.Form
	{
		//Form overrides dispose to clean up the component list.
		[System.Diagnostics.DebuggerNonUserCode()]
		protected override void Dispose(bool disposing)
		{
			try
			{
				if (disposing && components != null)
				{
					components.Dispose();
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}

		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;

		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.  
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.ProductsDataGridView = new System.Windows.Forms.DataGridView();
			this.Panel1 = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)this.ProductsDataGridView).BeginInit();
			this.SuspendLayout();
			//
			//ProductsDataGridView
			//
			this.ProductsDataGridView.AllowUserToAddRows = false;
			this.ProductsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.ProductsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ProductsDataGridView.Location = new System.Drawing.Point(0, 0);
			this.ProductsDataGridView.Name = "ProductsDataGridView";
			this.ProductsDataGridView.Size = new System.Drawing.Size(668, 307);
			this.ProductsDataGridView.TabIndex = 0;
			//
			//Panel1
			//
			this.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.Panel1.Location = new System.Drawing.Point(0, 307);
			this.Panel1.Name = "Panel1";
			this.Panel1.Size = new System.Drawing.Size(668, 47);
			this.Panel1.TabIndex = 1;
			//
			//MainForm
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(668, 354);
			this.Controls.Add(this.ProductsDataGridView);
			this.Controls.Add(this.Panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Products";
			((System.ComponentModel.ISupportInitialize)this.ProductsDataGridView).EndInit();
			this.ResumeLayout(false);

//INSTANT C# NOTE: Converted design-time event handler wireups:
			base.Load += new System.EventHandler(MainForm_Load);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(MainFormClosed);
		}

		internal DataGridView ProductsDataGridView;
		internal Panel Panel1;
	}

}