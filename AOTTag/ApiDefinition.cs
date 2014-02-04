using System.Drawing;
using System;
using MonoTouch.ObjCRuntime;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace AOTTagBinding {

	[BaseType (typeof (NSObject))]
	public partial interface EGOImageLoader {

		[Static, Export ("SharedImageLoader")]
		EGOImageLoader SharedImageLoader { get; }

		[Export ("IsLoadingImageURL")]
		bool IsLoadingImageURL (NSUrl aURL);

		[Export ("LoadImageForURL")]
		void LoadImageForURL (NSUrl aURL, EGOImageLoaderObserver observer);

		[Export ("ImageForURL")]
		UIImage ImageForURL (NSUrl aURL, EGOImageLoaderObserver observer);

		[Export ("RemoveObserver")]
		void RemoveObserver (EGOImageLoaderObserver observer);

		[Export ("RemoveObserver")]
		void RemoveObserver (EGOImageLoaderObserver observer, NSUrl aURL);

		[Export ("HasLoadedImageURL")]
		bool HasLoadedImageURL (NSUrl aURL);

		[Export ("CancelLoadForURL")]
		void CancelLoadForURL (NSUrl aURL);

		[Export ("ClearCacheForURL")]
		void ClearCacheForURL (NSUrl aURL);

		[Export ("ClearCacheForURL")]
		void ClearCacheForURL (NSUrl aURL, string style);

		[Export ("currentConnections", ArgumentSemantic.Retain)]
		NSDictionary CurrentConnections { get; set; }
	}

	[BaseType (typeof (NSObject))]
	[Model]
	public partial interface EGOImageLoaderObserver {

		[Export ("ImageLoaderDidLoad")]
		void ImageLoaderDidLoad (NSNotification notification);

		[Export ("ImageLoaderDidFailToLoad")]
		void ImageLoaderDidFailToLoad (NSNotification notification);
	}

	[BaseType (typeof (UIImageView))]
	public partial interface EGOImageView : EGOImageLoaderObserver {

		[Export ("InitWithPlaceholderImage")]
		IntPtr Constructor (UIImage anImage);

		[Export ("InitWithPlaceholderImage")]
		IntPtr Constructor (UIImage anImage, EGOImageViewDelegate aDelegate);

		[Export ("CancelImageLoad")]
		void CancelImageLoad ();

		[Export ("imageURL", ArgumentSemantic.Retain)]
		NSUrl ImageURL { get; set; }

		[Export ("placeholderImage", ArgumentSemantic.Retain)]
		UIImage PlaceholderImage { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)]
		EGOImageViewDelegate Delegate { get; set; }
	}

	[Model, BaseType (typeof (NSObject))]
	public partial interface EGOImageViewDelegate {

		[Export ("ImageViewLoadedImage")]
		void ImageViewLoadedImage (EGOImageView imageView);

		[Export ("ImageViewFailedToLoadImage")]
		void ImageViewFailedToLoadImage (EGOImageView imageView, NSError error);
	}

	[BaseType (typeof (NSObject))]
	[Model]
	public partial interface AOTagDelegate {

		[Export ("tagDistantImageDidLoad:")]
		void TagDistantImageDidLoad (AOTag tag);

		[Export ("tagDistantImageDidFailLoad:")]
		void TagDistantImageDidFailLoad (AOTag tag, NSError error);

		[Export ("tagDidAddTag:")]
		void TagDidAddTag (AOTag tag);

		[Export ("tagDidRemoveTag:")]
		void TagDidRemoveTag (AOTag tag);

		[Export ("tagDidSelectTag:")]
		void TagDidSelectTag (AOTag tag);
	}

	[BaseType (typeof (UIView))]
	public partial interface AOTagList {

		[Export ("delegate", ArgumentSemantic.Assign)]
		AOTagDelegate Delegate { get; set; }

		[Export ("tags", ArgumentSemantic.Retain)]
		NSMutableArray Tags { get; set; }

		[Export("addTag:withImage:")]
		void AddTag (string tTitle, string tImage);

		[Export ("addTag")]
		void AddTag (string tTitle, string tImage, UIColor labelColor, UIColor backgroundColor, UIColor closeColor);

		[Export ("addTag:withImageURL:andImagePlaceholder:")]
		void AddTag (string tTitle, NSUrl imageURL, string tPlaceholderImage);

		[Export ("addTag:withImagePlaceholder:withImageURL:withLabelColor:withBackgroundColor:withCloseButtonColor:")]
		void AddTag (string tTitle, string tPlaceholderImage, NSUrl imageURL, UIColor labelColor, UIColor backgroundColor, UIColor closeColor);

		[Export ("addTags")]
		void AddTags (NSObject [] tags);

		[Export ("removeTag")]
		void RemoveTag (AOTag tag);

		[Export ("removeAllTag")]
		void RemoveAllTag ();

	}

	[BaseType (typeof (UIView))]
	public partial interface AOTag : EGOImageViewDelegate {

		[Export ("delegate", ArgumentSemantic.Assign)]
		AOTagDelegate Delegate { get; set; }

		[Export ("tLabelColor", ArgumentSemantic.Retain)]
		UIColor TLabelColor { get; set; }

		[Export ("tBackgroundColor", ArgumentSemantic.Retain)]
		UIColor TBackgroundColor { get; set; }

		[Export ("tCloseButtonColor", ArgumentSemantic.Retain)]
		UIColor TCloseButtonColor { get; set; }

		[Export ("tImage", ArgumentSemantic.Retain)]
		UIImage TImage { get; set; }

		[Export ("tImageURL", ArgumentSemantic.Retain)]
		EGOImageView TImageURL { get; set; }

		[Export ("tTitle", ArgumentSemantic.Copy)]
		string TTitle { get; set; }

		[Export ("tURL", ArgumentSemantic.Retain)]
		NSUrl TURL { get; set; }

		[Export ("GetTagSize")]
		SizeF GetTagSize { get; }
	}

	[BaseType (typeof (UIView))]
	public partial interface AOTagCloseButton {

		[Export ("cColor", ArgumentSemantic.Retain)]
		UIColor CColor { get; set; }

		[Export ("InitWithFrame")]
		IntPtr Constructor (RectangleF frame, UIColor color);
	}
}
