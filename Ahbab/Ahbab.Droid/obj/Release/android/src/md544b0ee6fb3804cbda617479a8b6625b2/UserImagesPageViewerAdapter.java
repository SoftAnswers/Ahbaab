package md544b0ee6fb3804cbda617479a8b6625b2;


public class UserImagesPageViewerAdapter
	extends android.support.v4.view.PagerAdapter
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getCount:()I:GetGetCountHandler\n" +
			"n_instantiateItem:(Landroid/view/View;I)Ljava/lang/Object;:GetInstantiateItem_Landroid_view_View_IHandler\n" +
			"n_destroyItem:(Landroid/view/View;ILjava/lang/Object;)V:GetDestroyItem_Landroid_view_View_ILjava_lang_Object_Handler\n" +
			"n_isViewFromObject:(Landroid/view/View;Ljava/lang/Object;)Z:GetIsViewFromObject_Landroid_view_View_Ljava_lang_Object_Handler\n" +
			"";
		mono.android.Runtime.register ("Asawer.Droid.Adapters.UserImagesPageViewerAdapter, Asawer.Droid, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", UserImagesPageViewerAdapter.class, __md_methods);
	}


	public UserImagesPageViewerAdapter ()
	{
		super ();
		if (getClass () == UserImagesPageViewerAdapter.class)
			mono.android.TypeManager.Activate ("Asawer.Droid.Adapters.UserImagesPageViewerAdapter, Asawer.Droid, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public int getCount ()
	{
		return n_getCount ();
	}

	private native int n_getCount ();


	public java.lang.Object instantiateItem (android.view.View p0, int p1)
	{
		return n_instantiateItem (p0, p1);
	}

	private native java.lang.Object n_instantiateItem (android.view.View p0, int p1);


	public void destroyItem (android.view.View p0, int p1, java.lang.Object p2)
	{
		n_destroyItem (p0, p1, p2);
	}

	private native void n_destroyItem (android.view.View p0, int p1, java.lang.Object p2);


	public boolean isViewFromObject (android.view.View p0, java.lang.Object p1)
	{
		return n_isViewFromObject (p0, p1);
	}

	private native boolean n_isViewFromObject (android.view.View p0, java.lang.Object p1);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
