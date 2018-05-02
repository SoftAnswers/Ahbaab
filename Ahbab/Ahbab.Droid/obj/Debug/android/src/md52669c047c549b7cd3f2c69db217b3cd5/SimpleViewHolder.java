package md52669c047c549b7cd3f2c69db217b3cd5;


public class SimpleViewHolder
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_toString:()Ljava/lang/String;:GetToStringHandler\n" +
			"";
		mono.android.Runtime.register ("Asawer.Droid.SimpleViewHolder, Asawer.Droid, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", SimpleViewHolder.class, __md_methods);
	}


	public SimpleViewHolder (android.view.View p0)
	{
		super (p0);
		if (getClass () == SimpleViewHolder.class)
			mono.android.TypeManager.Activate ("Asawer.Droid.SimpleViewHolder, Asawer.Droid, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Views.View, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	public java.lang.String toString ()
	{
		return n_toString ();
	}

	private native java.lang.String n_toString ();

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
