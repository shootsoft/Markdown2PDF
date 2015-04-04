// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoMac.Foundation;
using System.CodeDom.Compiler;

namespace Markdown2PDF.Mac
{
	[Register ("MainWindowController")]
	partial class MainWindowController
	{
		[Outlet]
		MonoMac.AppKit.NSButton ButtonClose { get; set; }

		[Outlet]
		MonoMac.AppKit.NSButton ButtonDrop { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (ButtonClose != null) {
				ButtonClose.Dispose ();
				ButtonClose = null;
			}

			if (ButtonDrop != null) {
				ButtonDrop.Dispose ();
				ButtonDrop = null;
			}
		}
	}

	[Register ("MainWindow")]
	partial class MainWindow
	{
		
		void ReleaseDesignerOutlets ()
		{
		}
	}
}
