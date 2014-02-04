// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace AOTagExample
{
	[Register ("AOTagExampleViewController")]
	partial class AOTagExampleViewController
	{
		[Outlet]
		MonoTouch.UIKit.UITextField txtFind { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (txtFind != null) {
				txtFind.Dispose ();
				txtFind = null;
			}
		}
	}
}
